using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShooping.Web.Models;
using GeekShooping.Web.Services.IServices;

namespace GeekShooping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/Product";
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));   
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync(BasePath);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling API");
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling API");
            }
            return await response.Content.ReadFromJsonAsync<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _httpClient.PostAsJsonAsync(BasePath, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling API");
            }
            return await response.Content.ReadFromJsonAsync<ProductModel>();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BasePath}/{model.Id}", model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling API");
            }
            return await response.Content.ReadFromJsonAsync<ProductModel>();
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling API");
            }
            return response.IsSuccessStatusCode;
        }
        

    }
}