using Learner.Client.DTOs;
using Learner.Shared.Models;

namespace Learner.Client.Services
{
    public interface IChannelService
    {
        List<Channel> Channels { get; set; }

        Task GetChannels();

        Task<Channel> GetChannel(int id);

        Task PostChannel(PostChannelDto Chat);

        Task DeleteChannel(int id);

        Task UpdateChannel(Channel Chat);
    }
}
