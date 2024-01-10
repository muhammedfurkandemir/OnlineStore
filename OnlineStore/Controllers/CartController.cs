using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Abstract.Repositories;
using OnlineStore.Models.Concrete;
using OnlineStore.Utilities.Constants;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = UserRoles.Role_User)]
    public class CartController : Controller
    {
        private IProductRepository _productRepository;


        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        public IActionResult Index()
        {
            
            return View(Cart.GetCart);
        }

        public IActionResult AddToCart(int id)
        {
            var product = _productRepository.Get(p => p.Id == id);
            if (product != null)
            {
                Cart.GetCart.AddProduct(product, 1);
            }
            
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int id)
        {
            var product = _productRepository.Get(p => p.Id == id);
            if (product != null)
            {
                Cart.GetCart.DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Summary(int id)
        {
            return PartialView(Cart.GetCart);
        }
        public IActionResult Checkout()
        {
            return PartialView();
        }

    }
}
