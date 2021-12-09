using Microsoft.AspNetCore.Mvc;
using Skype.Data.Services;
using Skype.Data.Tables;
using System.Threading.Tasks;

namespace Skype.Api.Controllers
{
  [ApiController]
  [Route("message")]
  public class MessageController : ControllerBase
  {
    private readonly MessageService messageService;

    public MessageController(MessageService messageService)
    {
      this.messageService = messageService;
    }

    [HttpPost]
    [Route("add")]
    public async Task Add(Message value)
    {
      await this.messageService.Add(value);
    }

    [HttpGet]
    [Route("get-by-room")]
    public async Task<object> GetByRoom(long id)
    {
      return await this.messageService.GetByRoom(id);
    }
  }
}
