using OnlineStore.DataAccess.Abstract;
using OnlineStore.Models.DTOs;
using OnlineStore.Models.Entities;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineStore.DataAccess.Concrete
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private OnlineStoreContext _onlineStoreContext;
        public ProductRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        public List<ProductDetailDto> GetAllByCategoryId(int categoryId)
        {
            var result = from product in _onlineStoreContext.Products
                        join category in _onlineStoreContext.Categories
                        on product.CategoryId equals category.Id
                        where product.CategoryId == categoryId
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
            return result.ToList();
        }

        public ProductDetailDto GetProductDetail(int id)
        {
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
