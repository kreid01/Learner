using Learner.Client.DTOs;
using Learner.Shared.Models;
using System.Net.Http.Json;

namespace Learner.Client.Services
{
    public class MessageService : IMessageService
    {

        private readonly HttpClient _http;

        public MessageService(HttpClient http)
        {
            _http = http;
        }
        public List<Message> Messages { get; set; } = new List<Message>();


        public async Task GetMessages()
        {
            var result = await _http.GetFromJsonAsync<List<Message>>("api/Messages");

            if (result != null)
                Messages = result;
        }

        public async Task<Message> GetMessage(int id)
        {
            var result = await _http.GetFromJsonAsync<Message>($"api/Messages/{id}");
            if (result != null)
                return result;
            throw new Exception("Message not found");
        }


        public async Task<List<Message>> GetChatMessages(int chatId)
        {
            var result = await _http.GetFromJsonAsync<List<Message>>($"chats/{chatId}");
            if (result != null)
                return result;
            throw new Exception("Message not found");
        }


        public async Task UpdateMessage(Message Message)
        {
            await _http.PutAsJsonAsync($"api/Messages", Message);
            await GetMessages();
        }


        public async Task DeleteMessage(int id)
        {
            await _http.DeleteAsync($"api/Messages/{id}");
            await GetMessages();
        }

        public async Task PostMessage(PostMessageDto updateMessage)
        {

            Message Message = new()
            {
                Id = Messages.Count + 1,
                Content = updateMessage.Content,
                ChatId = updateMessage.ChatId,
                PosterName = updateMessage.PosterName,
                CreatedDate = DateTime.UtcNow.ToString()
            };

            await _http.PostAsJsonAsync("api/Messages", Message);
            await GetMessages();
        }

    }
}
