using Skype.Data.Tables;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Skype.Data.Services
{
  public class MessageService
  {
    private readonly SkypeDbContext context;

    public MessageService(SkypeDbContext context)
    {
      this.context = context;
    }

    public async Task Add(Message value)
    {
      this.context.Messages.Add(value);
      await context.SaveChangesAsync();
    }


    public async Task<object> GetByRoom(long roomId)
    {
      return await this.context.Messages.AsNoTracking()
        .Where(e => e.RoomId == roomId)
        .ToArrayAsync();
    }
  }
}
