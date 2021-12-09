using Skype.Data.Defined.Enums;
using Skype.Data.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skype.Data.Services
{
  public class RoomService
  {
    private readonly SkypeDbContext context;

    public RoomService(SkypeDbContext context)
    {
      this.context = context;
    }

    public async Task Create(CreateRoomArgs args)
    {
      var dbTrans = this.context.Database.BeginTransaction();
      try
      {
        var room = new Room { Name = args.Name };
        context.Rooms.Add(room);
        await context.SaveChangesAsync();

        foreach (var item in args.Members)
        {
          this.context.Members.Add(new Member
          {
            RoomId = room.Id,
            UserId = item.UserId,
            Role = item.Role
          });
        }
        await context.SaveChangesAsync();
        dbTrans.Commit();
      }
      catch
      {
        dbTrans.Rollback();
        throw;
      }
    }

    public async Task<object> Get(long id)
    {
      return await context.Rooms.FindAsync(id);
    }

    public async Task<object> GetPrticipatedIn(long id)
    {
      return await this.context.Members.AsNoTracking()
        .Where(e => e.UserId == id)
        .Select(e => new
        {
          Role = e.Role,
          RoomId = e.RoomId
        }).ToListAsync();
    }
  }

  public class RoomMember
  {
    public long UserId { get; set; }
    public Roles Role { get; set; }
  }

  public class CreateRoomArgs
  {
    public string Name { get; set; }
    public RoomMember[] Members { get; set; }
  }
}
