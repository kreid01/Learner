using Amazon.DynamoDBv2.DataModel;
using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public class MessageRepository : IMessageRepository
    {

        private readonly IDynamoDBContext _context;
        public MessageRepository(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteMessage(int id)
        {

            var Message = await _context.LoadAsync<Message>(id);
            if (Message == null) return false;

            try
            {
                await _context.DeleteAsync(Message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Message> GetMessage(int id)
        {
            var Message = await _context.LoadAsync<Message>(id);
            if (Message == null) return new Message();
            return Message;
        }



        public async Task<List<Message>> GetMessages() => await _context.ScanAsync<Message>(default).GetRemainingAsync();


        public async Task<List<Message>> GetChatMessages(int id)
        {
            var messages = await _context.ScanAsync<Message>(default).GetRemainingAsync();

            return messages.Where(m => m.ChatId == id).OrderByDescending(m => m.Id).ToList();
        }


        public async Task<Message> PostMessage(Message newMessage)
        {

            var Message = await _context.LoadAsync<Message>(newMessage.Id);
            if (Message != null) return new Message();
            try
            {

                await _context.SaveAsync(newMessage);
                return newMessage;

            }
            catch (Exception)
            {
                return new Message();
            }
        }

        public async Task<Message> UpdateMessage(Message updateMessage)
        {
            var Message = await _context.LoadAsync<Message>(updateMessage.Id);
            if (Message == null) return new Message();

            try
            {
                await _context.SaveAsync(updateMessage);
                return Message;

            }
            catch (Exception)
            {
                return new Message();
            }

        }
    }
}
