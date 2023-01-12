using Learner.Server.Repostiory;
using Learner.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learner.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _repository;

        public ChatController(IChatRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetById(int chatId)
        {

            var result = await _repository.GetChat(chatId);

            if (result.Id == null)
            {
                return NotFound($"Todo with {chatId} id does not exist");
            }

            return Ok(result);
        }

        [HttpGet("/channels/{channelId}")]
        public async Task<IActionResult> GetChannelChats(int channelId, string? password)
        {

            var result = await _repository.GetChannelChats(channelId);

            if (result == null)
            {
                return NotFound($"{channelId} id does not exist");
            }

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllChats()
        {
            var result = await _repository.GetAllChats();

            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChat(Chat chatRequest)
        {
            var result = await _repository.PostChat(chatRequest);

            if (result.Id == 0)
            {
                return BadRequest($"Todo with Id {chatRequest.Id} already exists");
            }

            return Ok(result);
        }

        [HttpDelete("{chatId}")]
        public async Task<IActionResult> DeleteChat(int chatId)
        {
            var result = await _repository.DeleteChat(chatId);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo(Chat chatRequest)
        {
            var result = await _repository.UpdateChat(chatRequest);

            if (result.Id == 0)
            {
                return BadRequest($"Chat with Id {chatRequest.Id} does not exist");
            }

            return Ok(result);
        }
    }
}
