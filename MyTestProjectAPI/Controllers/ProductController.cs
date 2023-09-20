using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTestProjectAPI.Models;
using MyTestProjectAPI.Services;
using MyTestProjectAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTestProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            var result = await this._productService.GetProducts();

            return Ok(result);
        }
    }
}
