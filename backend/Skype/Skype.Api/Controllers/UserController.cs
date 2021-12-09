using Microsoft.AspNetCore.Mvc;
using Skype.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skype.Api.Controllers
{
  [ApiController]
  [Route("user")]
  public class UserController : ControllerBase
  {
    private readonly UserService userService;

    public UserController(UserService userService)
    {
      this.userService = userService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<RegisterResponse> Register(RegisterParams args)
    {
      var newUser = new Data.Tables.User
      {
        Name = args.Name
      };

      await this.userService.Create(newUser);

      return new RegisterResponse
      {
        Id = newUser.Id
      };
    }

    [HttpGet]
    [Route("get")]
    public async Task<GetUserResponse> Get(long id)
    {
      var value = await this.userService.Get(id);
      return new GetUserResponse
      {
        Id = value.Id,
        Name = value.Name
      };
    }

    [HttpGet]
    [Route("get-all-except")]
    public async Task<GetUserResponse[]> GetAllExcept(long id)
    {
      var value = await this.userService.GetAllExcept(id);
      return value.Select(e => new GetUserResponse
      {
        Id = e.Id,
        Name = e.Name
      }).ToArray();
    }
  }

  public class GetUserResponse
  {
    public long Id { get; set; }
    public string Name { get; set; }
  }

  public class RegisterResponse
  {
    public long Id { get; set; }
  }

  public class RegisterParams
  {
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
  }
}
