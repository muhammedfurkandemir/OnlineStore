using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.Models.Entities;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductImageController(IProductRepository productRepository)
        {
                _productRepository = productRepository;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            List<Product> products = _productRepository.GetAll();   
            return Ok(products);
        }

    }
}
