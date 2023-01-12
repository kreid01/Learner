using Learner.Client.DTOs;
using Learner.Shared.Models;
using System.Net.Http.Json;

namespace Learner.Client.Services
{
    public class ChannelService : IChannelService
    {

        private readonly HttpClient _http;

        public ChannelService(HttpClient http)
        {
            _http = http;
        }
        public List<Channel> Channels { get; set; } = new List<Channel>();


        public async Task GetChannels()
        {
            var result = await _http.GetFromJsonAsync<List<Channel>>("api/Channel");

            if (result != null)
                Channels = result;
        }

        public async Task<Channel> GetChannel(int id)
        {
            var result = await _http.GetFromJsonAsync<Channel>($"api/Channel/{id}");
            if (result != null)
                return result;
            throw new Exception("Channel not found");
        }


        public async Task UpdateChannel(Channel Channel)
        {
            await _http.PutAsJsonAsync($"api/Channel", Channel);
            await GetChannels();
        }


        public async Task DeleteChannel(int id)
        {
            await _http.DeleteAsync($"api/Channel/{id}");
            await GetChannels();
        }

        public async Task PostChannel(PostChannelDto updateChannel)
        {

            Channel Channel = new()
            {
                Id = Channels.Count + 1,
                CreatorId = 1,
                Title = updateChannel.Title,
                IsPrivate = updateChannel.Password.Length > 1 ? true : false,
                Password = updateChannel.Password != null ? updateChannel.Password : "",
            };

            await _http.PostAsJsonAsync("api/Channel", Channel);
            await GetChannels();
        }

    }
}
