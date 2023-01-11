using Learner.Client.DTOs;
using Learner.Shared.Models;

namespace Learner.Client.Services
{
    public interface IMessageService
    {
        List<Message> Messages { get; set; }

        Task GetMessages();

        Task<Message> GetMessage(int id);

        Task<List<Message>> GetChatMessages(int chatId);

        Task PostMessage(PostMessageDto Messages);

        Task DeleteMessage(int id);

        Task UpdateMessage(Message Messages);
    }
}
