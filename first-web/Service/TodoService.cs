using System;
using first_web.Model;

namespace first_web.Service
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Todo>> GetTodosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Todo>>("https://todo-api.bestcar.id/api/v1/todo?pageNumber=1&pageSize=1000");
        }

        public async Task<Todo> GetTodoAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Todo>($"https://todo-api.bestcar.id/api/v1/todo/{id}");
        }

        public async Task CreateTodoAsync(Todo todo)
        {
            await _httpClient.PostAsJsonAsync("https://todo-api.bestcar.id/api/v1/todo", todo);
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            await _httpClient.PutAsJsonAsync($"https://todo-api.bestcar.id/api/v1/todo", todo);
        }

        public async Task DeleteTodoAsync(string todoId)
        {
            var response = await _httpClient.DeleteAsync($"https://todo-api.bestcar.id/api/v1/todo/?todoId={todoId}");
            response.EnsureSuccessStatusCode();
        }
    }
}

