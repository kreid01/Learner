using Learner.Shared.Models;

namespace Learner.Server.Services
{
    public interface IControllerService
    {
        public bool IsCorrectPassword(string password, string enteredPassword);

        public List<Message> FilterMessagesForChat(List<Message> messages, int id);
    }
}
