using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OnlineStore.Models.Abstract;
using OnlineStore.Models.Concrete;
using OnlineStore.Models.DTOs;
using System.Diagnostics;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger,IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            List<Product> productDetails=_productRepository.GetAll();
            return View(productDetails);
        }

        public IActionResult ProductDetail(int id)
        {
            ProductDetailDto productDetail = _productRepository.GetProductDetail(id);
            return View(productDetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
