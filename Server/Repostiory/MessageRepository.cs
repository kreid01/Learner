using Amazon.DynamoDBv2.DataModel;
using Learner.Server.Services;
using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public class MessageRepository : IMessageRepository
    {

        private readonly IDynamoDBContext _context;
        private readonly IControllerService _service;
        public MessageRepository(IDynamoDBContext context, IControllerService service)
        {
            _context = context;
            _service = service;
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

            return _service.FilterMessagesForChat(messages, id);
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
