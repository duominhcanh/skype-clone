using Microsoft.AspNetCore.SignalR;
using Skype.Data.Tables;
using System.Threading.Tasks;

namespace Skype.Api.Hubs
{
  public class ChatHub : Hub
  {
    public async Task Send(Message args)
    {
      await Clients.All.SendAsync("Message", args);
    }
  }
}
