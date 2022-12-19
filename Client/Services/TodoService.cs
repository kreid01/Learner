using Learner.Client.DTOs;
using Learner.Shared.Models;
using System.Net.Http.Json;

namespace Learner.Client.Services
{
    public class TodoService : ITodoService
    {

        private readonly HttpClient _http;

        public TodoService(HttpClient http)
        {
            _http = http;
        }
        public List<Todos> Todos { get; set; } = new List<Todos>();


        public async Task GetTodos()
        {
            var result = await _http.GetFromJsonAsync<List<Todos>>("api/Todos");

            if (result != null)
                Todos = result;
        }

        public async Task<Todos> GetTodo(int id)
        {
            var result = await _http.GetFromJsonAsync<Todos>($"api/Todos/{id}");
            if (result != null)
                return result;
            throw new Exception("Todo not found");
        }


        public async Task UpdateTodo(Todos todo)
        {
            await _http.PutAsJsonAsync($"api/Todos", todo);
            await GetTodos();
        }


        public async Task DeleteTodo(int id)
        {
            await _http.DeleteAsync($"api/Todos/{id}");
            await GetTodos();
        }

        public async Task PostTodo(PostTodoDto updateTodo)
        {

            Todos todo = new()
            {
                Id = Todos.Count + 1,
                PosterId = 1,
                Title = updateTodo.Title,
                Description = updateTodo.Description,
                CreatedDate = DateTime.UtcNow.ToString()
            };

            await _http.PostAsJsonAsync("api/Todos", todo);
            await GetTodos();
        }

    }
}
