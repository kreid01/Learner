using Learner.Client.DTOs;
using Learner.Shared.Models;

namespace Learner.Client.Services
{
    public interface IChatService
    {
        List<Chat> Chats { get; set; }

        Task GetChats();

        Task<Chat> GetChat(int id);

        Task PostChat(PostChatDto Chat);

        Task DeleteChat(int id);

        Task UpdateChat(Chat Chat);
    }
}
