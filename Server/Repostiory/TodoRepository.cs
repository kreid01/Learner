using Amazon.DynamoDBv2.DataModel;
using Learner.Shared.Models;

namespace Learner.Server.Repostiory
{
    public class TodoRepository : ITodoRepository
    {

        private readonly IDynamoDBContext _context;
        public TodoRepository(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteTodo(int id)
        {

            var Todo = await _context.LoadAsync<Todos>(id);
            if (Todo == null) return false;

            try
            {
                await _context.DeleteAsync(Todo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Todos> GetTodo(int id)
        {
            var Todo = await _context.LoadAsync<Todos>(id);
            if (Todo == null) return new Todos();
            return Todo;
        }

        public async Task<List<Todos>> GetTodos() => await _context.ScanAsync<Todos>(default).GetRemainingAsync();


        public async Task<Todos> PostTodo(Todos todo)
        {

            var Todo = await _context.LoadAsync<Todos>(todo.Id);
            if (Todo != null) return new Todos();
            try
            {

                await _context.SaveAsync(todo);
                return todo;

            }
            catch (Exception)
            {
                return new Todos();
            }
        }

        public async Task<Todos> UpdateTodo(Todos updateTodo)
        {
            var Todo = await _context.LoadAsync<Todos>(updateTodo.Id);
            if (Todo == null) return new Todos();

            try
            {
                await _context.SaveAsync(updateTodo);
                return Todo;

            }
            catch (Exception)
            {
                return new Todos();
            }

        }
    }
}
