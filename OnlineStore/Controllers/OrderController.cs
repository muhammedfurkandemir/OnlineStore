using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Abstract;
using OnlineStore.Models.Concrete;
using OnlineStore.Utilities.Constants;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        public OrderController(IOrderRepository categoryRepository)
        {
            _orderRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Order> result = _orderRepository.GetAll();
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
        [HttpPost]
        public IActionResult Delete(Order order)
        {

            _orderRepository.Delete(order);
            TempData["Success"] = Messages.Delete;
            return RedirectToAction("Index", "Order");

        }
    }
}
