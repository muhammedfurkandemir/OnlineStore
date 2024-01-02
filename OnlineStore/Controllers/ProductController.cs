using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Models.Abstract;
using OnlineStore.Models.Concrete;
using OnlineStore.Utilities.Constants;
using OnlineStore.Utilities.Helpers.FileHelper;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class ProductController : Controller
    {
       private IProductRepository _productRepository;
       private ICategoryRepository _categoryRepository;
        private IProductImageRepository _productImageRepository;
        private IFileHelper _fileHelper;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository,
            IProductImageRepository productImageRepository,IFileHelper fileHelper )
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
            _fileHelper = fileHelper;
        }
        public IActionResult Index()
        {
            List<Product> result = _productRepository.GetAll();
            return View(result);
        }
        public IActionResult Add()
        {
            ViewBag.Categories= GetCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                 if (file != null)
                 {
                    product.ImageUrl = _fileHelper.Upload(file, FilePath.ImagesPath);
                 }
                _productRepository.Add(product);
                TempData["Success"] = Messages.Added;
                return RedirectToAction("Index","Product");
            }
           return View();
        }
        public IActionResult Update(int? id) 
        {
            if (id==null||id==0)
            {
                return NotFound();
            }
            Product product = _productRepository.Get(p => p.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            ViewBag.Categories = GetCategories();
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product,IFormFile file) 
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    product.ImageUrl = _fileHelper.Update(file, FilePath.ImagesPath,
                        FilePath.ImagesDeletedPath + product.ImageUrl);
                }
                _productRepository.Update(product);
                TempData["Success"] = Messages.Update;
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        public IActionResult Delete(int? id) 
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            Product product = _productRepository.Get(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = GetCategories();
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _fileHelper.Delete(FilePath.ImagesDeletedPath + product.ImageUrl);
            _productRepository.Delete(product);
            TempData["Success"] = Messages.Delete;
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult GetByCategory(int categoryId)
        {
            var result=_productRepository.GetAllByCategoryId(categoryId);
            return Json(result);
        }


        private IEnumerable<SelectListItem> GetCategories()
        {
            IEnumerable<SelectListItem> result = _categoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            });
            return result;
        }

    }
}
