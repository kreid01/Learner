using Learner.Server.Repostiory;
using Learner.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learner.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodosController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{TodoId}")]
        public async Task<IActionResult> GetById(int todoId)
        {

            var result = await _repository.GetTodo(todoId);

            if (result.Id == null)
            {
                return NotFound($"Todo with {todoId} id does not exist");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var result = await _repository.GetTodos();

            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(Todos todoRequest)
        {
            var result = _repository.PostTodo(todoRequest);

            if (result.Id == 0)
            {
                return BadRequest($"Todo with Id {todoRequest.Id} already exists");
            }

            return Ok(result);
        }

        [HttpDelete("{TodoId}")]
        public async Task<IActionResult> DeleteTodo(int todoId)
        {
            var result = await _repository.DeleteTodo(todoId);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo(Todos todoRequest)
        {
            var result = await _repository.UpdateTodo(todoRequest);

            if (result.Id == 0)
            {
                return BadRequest($"Todo with Id {todoRequest.Id} does not exist");
            }

            return Ok(result);
        }
    }
}
