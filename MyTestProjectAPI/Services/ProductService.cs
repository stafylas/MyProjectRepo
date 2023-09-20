using MyTestProjectAPI.Models;
using MyTestProjectAPI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyTestProjectAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            using var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://fakestoreapi.com/products");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                return products;
            }
            else
            {
              
                throw new Exception("Failed to fetch products from the API.");
            }

        }
    }
}
