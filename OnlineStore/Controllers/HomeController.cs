using Microsoft.AspNetCore.Mvc;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.Models;
using OnlineStore.Models.DTOs;
using OnlineStore.Models.Entities;
using OnlineStore.Models.ViewModels;
using System.Diagnostics;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger,IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            List<ProductDetailDto> products = _productRepository.GetProductDetails();
            return View(products);
        }
        public IActionResult Categories()
        {
            List<ProductDetailDto> products = _productRepository.GetProductDetails();
            List<Category> categories = _categoryRepository.GetAll();
            HomeViewModel homeView = new HomeViewModel
            {
                Products = products,
                Categories = categories
            };
            return View(homeView);
        }

        public IActionResult ProductDetail(int id)
        {
            ProductDetailDto productDetail = _productRepository.GetProductDetail(id);
            return View(productDetail);
        }
        [HttpGet]
        public IActionResult GetProductsByCategoryId(int id) 
        { 
            List<ProductDetailDto> products = _productRepository.GetAllByCategoryId(id);
           
            return PartialView("_ProductsPartial", products);
        }
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            List<ProductDetailDto> products = _productRepository.GetProductDetails();

            return PartialView("_ProductsPartial", products);
        }

        public IActionResult Communication()
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
