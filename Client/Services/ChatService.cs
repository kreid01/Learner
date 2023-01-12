using Learner.Client.DTOs;
using Learner.Shared.Models;
using System.Net.Http.Json;

namespace Learner.Client.Services
{
    public class ChatService : IChatService
    {

        private readonly HttpClient _http;

        public ChatService(HttpClient http)
        {
            _http = http;
        }
        public List<Chat> Chats { get; set; } = new List<Chat>();


        public async Task GetChats()
        {
            var result = await _http.GetFromJsonAsync<List<Chat>>("api/Chat");

            if (result != null)
                Chats = result;
        }

        public async Task<Chat> GetChat(int id)
        {
            var result = await _http.GetFromJsonAsync<Chat>($"api/Chat/{id}");
            if (result != null)
                return result;
            throw new Exception("Chat not found");
        }

        public async Task<List<Chat>> GetChannelChats(int channelId)
        {
            var result = await _http.GetFromJsonAsync<List<Chat>>($"channels/{channelId}");
            if (result != null)
                return result;
            throw new Exception("Message not found");
        }



        public async Task UpdateChat(Chat Chat)
        {
            await _http.PutAsJsonAsync($"api/Chat", Chat);
            await GetChats();
        }


        public async Task DeleteChat(int id)
        {
            await _http.DeleteAsync($"api/Chat/{id}");
            await GetChats();
        }

        public async Task PostChat(PostChatDto updateChat)
        {

            Chat Chat = new()
            {
                Id = Chats.Count + 1,
                CreatorId = 1,
                ChannelId = 1,
                Title = updateChat.Title,

            };

            await _http.PostAsJsonAsync("api/Chat", Chat);
            await GetChats();
        }

    }
}
