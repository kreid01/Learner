using Learner.Server.Repostiory;
using Learner.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learner.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelRepository _repository;

        public ChannelController(IChannelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{ChannelId}")]
        public async Task<IActionResult> GetById(int ChannelId)
        {

            var result = await _repository.GetChannel(ChannelId);

            if (result.Id == null)
            {
                return NotFound($"Todo with {ChannelId} id does not exist");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChannels()
        {
            var result = await _repository.GetAllChannels();

            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChannel(Channel ChannelRequest)
        {
            var result = await _repository.PostChannel(ChannelRequest);

            if (result != null)
            {
                return BadRequest($"Todo with Id {ChannelRequest.Id} already exists");
            }

            return Ok(result);
        }

        [HttpDelete("{ChannelId}")]
        public async Task<IActionResult> DeleteChannel(int ChannelId)
        {
            var result = await _repository.DeleteChannel(ChannelId);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo(Channel ChannelRequest)
        {
            var result = await _repository.UpdateChannel(ChannelRequest);

            if (result.Id == 0)
            {
                return BadRequest($"Channel with Id {ChannelRequest.Id} does not exist");
            }

            return Ok(result);
        }
    }
}
