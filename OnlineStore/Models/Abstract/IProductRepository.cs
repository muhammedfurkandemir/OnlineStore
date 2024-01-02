using OnlineStore.Models.Concrete;
using OnlineStore.Models.DTOs;
using OnlineStore.Utilities.EntityFreamwork.Repositories;
using System.Linq.Expressions;

namespace OnlineStore.Models.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();

        ProductDetailDto GetProductDetail(int id);

        List<Product> GetAllByCategoryId(int categoryId);
    }
}
