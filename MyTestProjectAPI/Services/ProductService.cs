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
            // Create an HttpClient
            using var httpClient = _httpClientFactory.CreateClient();
            // Send an HTTP GET request to the external API
            var response = await httpClient.GetAsync("https://fakestoreapi.com/products");
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                var content = await response.Content.ReadAsStringAsync();
                // Deserialize the JSON response into a list of Product objects
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                return products; //Return the list of products
            }
            else
            {
                // If the request is not successful, throw an exception
                throw new Exception("Failed to fetch products from the API.");
            }

        }
    }
}
