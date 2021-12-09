using Skype.Data.Tables;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Skype.Data.Services
{
    public class FriendService
    {
        private readonly SkypeDbContext context;

        public FriendService(SkypeDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Friend value)
        {
            this.context.Friends.Add(value);
            await context.SaveChangesAsync();
        }

        public async Task Remove(Friend value)
        {
            var friend = context.Friends.AsNoTracking()
                .Where(e => e.LeftId == value.LeftId && e.RightId == value.RightId)
                .FirstOrDefault();

            context.Entry(friend).State = System.Data.Entity.EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Friend>> GetAllOf(long id)
        {
            return await this.context.Friends.AsNoTracking()
                .Where(e => e.LeftId == id)
                .ToArrayAsync();
        }
    }
}
