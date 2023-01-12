using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public interface IChannelRepository
    {
        Task<List<Channel>> GetAllChannels();

        Task<Channel> GetChannel(int id);

        Task<Channel> PostChannel(Channel Channel);

        Task<Channel> UpdateChannel(Channel updateChannel);

        Task<bool> DeleteChannel(int id);
    }
}
