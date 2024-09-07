using System;
using first_web.Model;

namespace first_web.Service
{
    public class TodoDetailService
    {
        private readonly HttpClient _httpClient;

        public TodoDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TodoDetail>> GetTodoDetailsAsync(string todoId)
        {
            return await _httpClient.GetFromJsonAsync<List<TodoDetail>>($"https://todo-api.bestcar.id/api/v1/todo/detail/{todoId}");
        }

        public async Task<TodoDetail> GetTodoDetailAsync(string todoDetailId)
        {
            return await _httpClient.GetFromJsonAsync<TodoDetail>($"https://todo-api.bestcar.id/api/v1/todo/detail/{todoDetailId}");
        }

        public async Task CreateTodoDetailAsync(TodoDetail todoDetail)
        {
            await _httpClient.PostAsJsonAsync($"https://todo-api.bestcar.id/api/v1/todo/detail", todoDetail);
        }

        public async Task UpdateTodoDetailAsync(TodoDetail todoDetail)
        {
            await _httpClient.PutAsJsonAsync($"https://todo-api.bestcar.id/api/v1/todo/detail", todoDetail);
        }

        public async Task DeleteTodoDetailAsync(string todoDetailId)
        {
            await _httpClient.DeleteAsync($"https://todo-api.bestcar.id/api/v1/todo/detail/?todoDetailId={todoDetailId}");
        }
    }
}

