using Learner.Shared.Models;

namespace Learner.Server.Services
{

    public class ControllerService : IControllerService
    {
        public bool IsCorrectPassword(string password, string enteredPassword)
        {
            if (password == enteredPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Message> FilterMessagesForChat(List<Message> messages, int id)
        {
            return messages.Where(m => m.ChatId == id).OrderByDescending(m => m.Id).ToList();
        }
    }
}
