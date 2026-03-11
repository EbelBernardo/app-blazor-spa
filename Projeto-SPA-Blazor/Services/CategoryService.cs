using Projeto_SPA_Blazor.Contracts;
using Projeto_SPA_Blazor.Contracts.V1.Category;

namespace Projeto_SPA_Blazor.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
            => _http = http;

        public async Task<ApiResponse<List<CategoryResponse>>?> GetAllAsync()
            => await _http.GetFromJsonAsync<ApiResponse<List<CategoryResponse>>>("/api/v1/categories");

        public async Task<ApiResponse<CategoryResponse>?> GetAsync(int id)
            => await _http.GetFromJsonAsync<ApiResponse<CategoryResponse>>($"/api/v1/categories/{id}");

        public async Task<ApiResponse<CategoryResponse>?> CreateAsync(CreateCategoryRequest request)
        {
            var response = await _http.PostAsJsonAsync("/api/v1/categories", request);

            return await response.Content.ReadFromJsonAsync<ApiResponse<CategoryResponse>>();
        }

        public async Task<ApiResponse<CategoryResponse>?> UpdateAsync(int id, UpdateCategoryRequest request)
        {
            var response = await _http.PutAsJsonAsync($"/api/v1/categories/{id}", request);

            return await response.Content.ReadFromJsonAsync<ApiResponse<CategoryResponse>>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"/api/v1/categories/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
