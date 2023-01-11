using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetMessages();

        Task<Message> GetMessage(int id);

        Task<Message> PostMessage(Message message);

        Task<List<Message>> GetChatMessages(int id);

        Task<Message> UpdateMessage(Message updateMessage);

        Task<bool> DeleteMessage(int id);
    }
}
