using Amazon.DynamoDBv2.DataModel;
using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public class ChannelRepository : IChannelRepository
    {

        private readonly IDynamoDBContext _context;
        public ChannelRepository(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteChannel(int id)
        {

            var Channel = await _context.LoadAsync<Channel>(id);
            if (Channel == null) return false;

            try
            {
                await _context.DeleteAsync(Channel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Channel> GetChannel(int id)
        {
            var Channel = await _context.LoadAsync<Channel>(id);
            var oc = Channel;
            if (Channel == null) return new Channel();
            return Channel;
        }

        public async Task<List<Channel>> GetAllChannels() => await _context.ScanAsync<Channel>(default).GetRemainingAsync();


        public async Task<Channel> PostChannel(Channel newChannel)
        {

            var Channel = await _context.LoadAsync<Channel>(newChannel.Id);

            if (Channel != null) return new Channel();
            try
            {

                await _context.SaveAsync(newChannel);
                return Channel;

            }
            catch (Exception)
            {
                return new Channel();
            }
        }

        public async Task<Channel> UpdateChannel(Channel updateChannel)
        {
            var Channel = await _context.LoadAsync<Channel>(updateChannel.Id);
            if (Channel == null) return new Channel();

            try
            {
                await _context.SaveAsync(updateChannel);
                return Channel;

            }
            catch (Exception)
            {
                return new Channel();
            }

        }
    }
}
