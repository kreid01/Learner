using Microsoft.AspNetCore.SignalR;

namespace Learner.Server.Hubs
{
    public class Chathub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("RecieveMessage", user, message);
        }
    }
}
