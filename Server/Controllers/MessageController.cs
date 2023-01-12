using Learner.Server.Repostiory;
using Learner.Server.Services;
using Learner.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learner.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _repository;

        public MessagesController(IMessageRepository repository, IControllerService service)
        {
            _repository = repository;

        }

        [HttpGet("{MessageId}")]
        public async Task<IActionResult> GetById(int MessageId)
        {

            var result = await _repository.GetMessage(MessageId);

            if (result.Id == null)
            {
                return NotFound($"Message with {MessageId} id does not exist");
            }

            return Ok(result);
        }

        [HttpGet("/chats/{chatId}")]
        public async Task<IActionResult> GetChatMessages(int chatId)
        {

            var result = await _repository.GetChatMessages(chatId);

            if (result == null)
            {
                return NotFound($"{chatId} id does not exist");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var result = await _repository.GetMessages();

            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message MessageRequest)
        {
            var result = await _repository.PostMessage(MessageRequest);

            if (result == null)
            {
                return BadRequest($"Message with Id {MessageRequest.Id} already exists");
            }

            return Ok(result);
        }

        [HttpDelete("{MessageId}")]
        public async Task<IActionResult> DeleteMessage(int MessageId)
        {
            var result = await _repository.DeleteMessage(MessageId);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }



        [HttpPut]
        public async Task<IActionResult> UpdateMessage(Message MessageRequest)
        {
            var result = await _repository.UpdateMessage(MessageRequest);

            if (result.Id == 0)
            {
                return BadRequest($"Message with Id {MessageRequest.Id} does not exist");
            }

            return Ok(result);
        }
    }
}
