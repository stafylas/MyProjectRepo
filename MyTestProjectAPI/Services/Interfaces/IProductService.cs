using Microsoft.AspNetCore.Mvc;
using MyTestProjectAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTestProjectAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<ActionResult<IEnumerable<Product>>> GetProducts();
    }
}
