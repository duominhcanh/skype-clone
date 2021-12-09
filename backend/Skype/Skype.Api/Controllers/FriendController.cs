using Microsoft.AspNetCore.Mvc;
using Skype.Data.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skype.Api.Controllers
{
  [ApiController]
  [Route("friend")]
  public class FriendController : ControllerBase
  {
    private readonly FriendService friendService;

    public FriendController(FriendService friendService)
    {
      this.friendService = friendService;
    }

    public class AddFriendParams
    {
      public long LeftId { get; set; }
      public long RightId { get; set; }
    }

    public class RemoveFriendParams
    {
      public long LeftId { get; set; }
      public long RightId { get; set; }
    }

    public class GetFriendsResponse
    {
      public long LeftId { get; set; }
      public long RightId { get; set; }
    }

    [HttpPost]
    [Route("add")]
    public async Task Add(AddFriendParams value)
    {
      await this.friendService.Add(new Data.Tables.Friend
      {
        LeftId = value.LeftId,
        RightId = value.RightId
      });
    }

    [HttpPost]
    [Route("remove")]
    public async Task Remove(RemoveFriendParams value)
    {
      await this.friendService.Remove(new Data.Tables.Friend
      {
        LeftId = value.LeftId,
        RightId = value.RightId
      });
    }

    [HttpGet]
    [Route("get-all-of")]
    public async Task<IEnumerable<GetFriendsResponse>> GetAllOf(long id)
    {
      return (await this.friendService.GetAllOf(id)).Select(e => new GetFriendsResponse
      {
        LeftId = e.LeftId,
        RightId = e.RightId
      });
    }
  }
}
