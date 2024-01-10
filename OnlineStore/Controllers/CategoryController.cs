using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Abstract.Repositories;
using OnlineStore.Models.Concrete;
using OnlineStore.Utilities.Constants;

namespace OnlineStore.Controllers
{
    [Authorize(Roles =UserRoles.Role_Admin)]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository= categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> result=_categoryRepository.GetAll();
            return View(result);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                TempData["Success"] = Messages.Added;
                return RedirectToAction("Index","Category");
            }
            return View();
        }
        public IActionResult Update(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            Category category = _categoryRepository.Get(c => c.Id == id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                TempData["Success"] = Messages.Update;
                return RedirectToAction("Index","Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id==null ||id==0)
            {
                return NotFound();
            }
            Category category = _categoryRepository.Get(c => c.Id == id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
           
                _categoryRepository.Delete(category);
                TempData["Success"] = Messages.Delete;
                return RedirectToAction("Index","Category");
            
        }

        
    }
}
