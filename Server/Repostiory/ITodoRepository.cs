using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public interface ITodoRepository
    {
        Task<List<Todos>> GetTodos();

        Task<Todos> GetTodo(int id);

        Task<Todos> PostTodo(Todos todo);

        Task<Todos> UpdateTodo(Todos updateTodo);

        Task<bool> DeleteTodo(int id);
    }
}
