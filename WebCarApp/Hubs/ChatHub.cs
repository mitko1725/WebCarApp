using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebCarApp.Web.Hubs
{
    public class ChatHub:Hub
    {
        public async Task Send(string username,string message)
        {
            await this.Clients.Caller.SendAsync(
                "CallerMessage",
                new WebCarApp.Models.Message { User = username, Text = message, });

            await this.Clients.Others.SendAsync(
                "OthersMessage",
                new WebCarApp.Models.Message { User = username, Text = message, });
        }
    }
}
