using Amazon.DynamoDBv2.DataModel;
using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public class ChatRepository : IChatRepository
    {

        private readonly IDynamoDBContext _context;
        public ChatRepository(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteChat(int id)
        {

            var Chat = await _context.LoadAsync<Chat>(id);
            if (Chat == null) return false;

            try
            {
                await _context.DeleteAsync(Chat);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Chat> GetChat(int id)
        {
            var Chat = await _context.LoadAsync<Chat>(id);
            var oc = Chat;
            if (Chat == null) return new Chat();
            return Chat;
        }

        public async Task<List<Chat>> GetAllChats() => await _context.ScanAsync<Chat>(default).GetRemainingAsync();


        public async Task<Chat> PostChat(Chat Chat)
        {

            var chat = await _context.LoadAsync<Chat>(Chat.Id);

            if (chat != null) return new Chat();
            try
            {

                await _context.SaveAsync(Chat);
                return Chat;

            }
            catch (Exception)
            {
                return new Chat();
            }
        }

        public async Task<Chat> UpdateChat(Chat updateChat)
        {
            var Chat = await _context.LoadAsync<Chat>(updateChat.Id);
            if (Chat == null) return new Chat();

            try
            {
                await _context.SaveAsync(updateChat);
                return Chat;

            }
            catch (Exception)
            {
                return new Chat();
            }

        }
    }
}
