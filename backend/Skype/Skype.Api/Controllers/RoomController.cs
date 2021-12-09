using Microsoft.AspNetCore.Mvc;
using Skype.Data.Services;
using System.Threading.Tasks;

namespace Skype.Api.Controllers
{
  [ApiController]
  [Route("room")]
  public class RoomController : ControllerBase
  {
    private readonly RoomService roomService;

    public RoomController(RoomService roomService)
    {
      this.roomService = roomService;
    }

    [HttpPost]
    [Route("create")]
    public async Task Create(CreateRoomArgs args)
    {
      await this.roomService.Create(args);
    }

    [HttpGet]
    [Route("get")]
    public async Task<object> Get(long id)
    {
      return await this.roomService.Get(id);
    }

    [HttpGet]
    [Route("get-participated-in")]
    public async Task<object> GetPrticipatedIn(long id)
    {
      return await this.roomService.GetPrticipatedIn(id);
    }
  }
}
