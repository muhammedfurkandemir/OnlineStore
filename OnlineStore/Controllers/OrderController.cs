using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.Models.Entities;
using OnlineStore.Models.ViewModels;
using OnlineStore.Utilities.Constants;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private IOrderLineRepository _orderLineRepository;
        public OrderController(IOrderRepository categoryRepository, IOrderLineRepository orderLineRepository)
        {
            _orderRepository = categoryRepository;
            _orderLineRepository = orderLineRepository;
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Index()
        {
            List<Order> result = _orderRepository.GetAllByOrderDateDescending();
            return View(result);
        }
        [Authorize(Roles = UserRoles.Role_User)]
        public IActionResult UserIndex()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<UserOrderViewModel> result = _orderRepository.GetAllByUserId(userId);
            return View(result);
        }
        [Authorize(Roles = UserRoles.Role_User+","+UserRoles.Role_Admin)]
        public IActionResult OrderDetails(int id)
        {
            OrderDetailsViewModel result= _orderRepository.GetOrderDetails(id);
            return View(result);
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.Add(order);
                TempData["Success"] = Messages.Added;
                return RedirectToAction("Index", "Order");
            }
            return View();
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Order order = _orderRepository.Get(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Update(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.Update(order);
                TempData["Success"] = Messages.Update;
                return RedirectToAction("Index", "Order");
            }
            return View();
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Order order = _orderRepository.Get(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Delete(Order order)
        {
            var orderLines = _orderLineRepository.GetOrderLinesByOrderId(order.Id);
            _orderLineRepository.DeleteByRange(orderLines);
            order.OrderLines.AddRange(orderLines);
            _orderRepository.Delete(order);
            TempData["Success"] = Messages.Delete;
            return RedirectToAction("Index", "Order");

        }

    }
}
