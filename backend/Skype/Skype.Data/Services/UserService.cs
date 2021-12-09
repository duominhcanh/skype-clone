using Skype.Data.Tables;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Skype.Data.Services
{
  public class UserService
  {
    private readonly SkypeDbContext context;

    public UserService(SkypeDbContext context)
    {
      this.context = context;
    }

    public async Task<User> Create(User user)
    {
      this.context.Users.Add(user);
      await context.SaveChangesAsync();
      return user;
    }

    public async Task<User> Get(long id)
    {
      return await this.context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllExcept(long id)
    {
      return await this.context.Users.AsNoTracking()
          .Where(e => e.Id != id)
          .ToArrayAsync();
    }

    public async Task Edit(User value)
    {
      var user = await this.context.Users.FindAsync(value.Id);
      user.Name = value.Name;
      await context.SaveChangesAsync();
    }
  }
}
