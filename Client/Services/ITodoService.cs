using Learner.Client.DTOs;
using Learner.Shared.Models;

namespace Learner.Client.Services
{
    public interface ITodoService
    {
        List<Todos> Todos { get; set; }

        Task GetTodos();

        Task<Todos> GetTodo(int id);

        Task PostTodo(PostTodoDto todo);

        Task DeleteTodo(int id);

        Task UpdateTodo(Todos todo);
    }
}
