using Projeto_SPA_Blazor.Contracts;
using Projeto_SPA_Blazor.Contracts.V1.Product;

namespace Projeto_SPA_Blazor.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
            => _http = http;

        public async Task<ApiResponse<List<ProductResponse>>?> GetAllAsync()
            => await _http.GetFromJsonAsync<ApiResponse<List<ProductResponse>>>("/api/v1/products");

        public async Task<ApiResponse<ProductResponse>?> GetAsync(int id)
            => await _http.GetFromJsonAsync<ApiResponse<ProductResponse>>($"/api/v1/products/{id}");

        public async Task<ApiResponse<ProductResponse>?> CreateAsync(CreateProductRequest request)
        {
            var response = await _http.PostAsJsonAsync("/api/v1/products", request);

            return await response.Content.ReadFromJsonAsync<ApiResponse<ProductResponse>>();
        }

        public async Task<ApiResponse<ProductResponse>?> UpdateAsync(int id, UpdateProductRequest request)
        {
            var response = await _http.PutAsJsonAsync($"/api/v1/products/{id}", request);

            return await response.Content.ReadFromJsonAsync<ApiResponse<ProductResponse>>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"/api/v1/products/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
