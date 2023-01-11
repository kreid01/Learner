using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public interface IChatRepository
    {
        Task<List<Chat>> GetAllChats();

        Task<Chat> GetChat(int id);

        Task<Chat> PostChat(Chat Chat);

        Task<Chat> UpdateChat(Chat updateChat);

        Task<bool> DeleteChat(int id);
    }
}
