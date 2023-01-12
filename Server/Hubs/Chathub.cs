using Learner.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace Learner.Server.Hubs
{
    public class Chathub : Hub
    {
        public Task SendMessage(NewMessage newMessage)
        {
            return Clients.All.SendAsync("RecieveMessage", newMessage);
        }
    }


}
