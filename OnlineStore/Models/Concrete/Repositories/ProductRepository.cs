using OnlineStore.Models.Abstract.Repositories;
using OnlineStore.Models.DTOs;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineStore.Models.Concrete.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private OnlineStoreContext _onlineStoreContext;
        public ProductRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _onlineStoreContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public ProductDetailDto GetProductDetail(int id)
        {
            //var product = _onlineStoreContext.Set<Product>().SingleOrDefault(filter);
            var result = from product in _onlineStoreContext.Products.Where(p => p.Id == id)
                         join category in _onlineStoreContext.Categories
                         on product.CategoryId equals category.Id
                         select new ProductDetailDto
                         {
                             Id = product.Id,
                             ImagePath = product.ImageUrl,
                             CategoryName = category.CategoryName,
                             ProductName = product.ProductName,
                             Description = product.Description,
                             UnitPrice = product.UnitPrice,
                             UnitsInStock = product.UnitsInStock
                         };

            return result.FirstOrDefault();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            var result = from product in _onlineStoreContext.Products
                         join category in _onlineStoreContext.Categories
                         on product.CategoryId equals category.Id
                         select new ProductDetailDto
                         {
                             Id = product.Id,
                             CategoryName = category.CategoryName,
                             ProductName = product.ProductName,
                             Description = product.Description,
                             UnitPrice = product.UnitPrice,
                             UnitsInStock = product.UnitsInStock,
                             ImagePath = product.ImageUrl
                         };
            return result.ToList();
        }
    }
}
