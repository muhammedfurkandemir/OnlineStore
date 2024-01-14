using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.DataAccess.Concrete;
using OnlineStore.Models.Concrete;
using OnlineStore.Models.Entities;
using OnlineStore.Utilities.Constants;
using OnlineStore.Utilities.Helpers.GuidHelper;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = UserRoles.Role_User)]
    public class CartController : Controller
    {
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(IProductRepository productRepository, IOrderRepository orderRepository,
            UserManager<IdentityUser> userManager)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
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
        [HttpPost]
        public IActionResult Checkout(ShippingDetails shippingDetails)
        {
            var cart = Cart.GetCart;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (cart.CartLines.Count==0)
            {
                ModelState.AddModelError("NoExistProduct", "Sepetinizde ürün bulunmamaktadır.");
            }
            if (ModelState.IsValid)
            {
                var orderLines=new List<OrderLine>();
                foreach (var cartLine in cart.CartLines)
                {
                    orderLines.Add(new OrderLine
                    {
                        Quantity = cartLine.Quantity,
                        Price = cartLine.Quantity * cartLine.Product.UnitPrice,
                        ProductId = cartLine.Product.Id
                    });
                }
                _orderRepository.Add(new Order
                {
                    UserName = shippingDetails.FullName,
                    UserId=userId,
                    OrderState=EnumOrderState.Waiting,
                    AdressName = shippingDetails.AdressName,
                    Adress = shippingDetails.Address,
                    City = shippingDetails.City,
                    District = shippingDetails.District,
                    Street = shippingDetails.Street,
                    HomeNo = shippingDetails.HomeNo,
                    OrderDate = DateTime.Now,
                    OrderNumber = GuidHelper.CreateGuid(),
                    Total = cart.Total(),
                    OrderLines = orderLines
                }); 
                cart.Clear();
                return View("Completed");
            }
            else return View(shippingDetails);  
        }

    }
}
