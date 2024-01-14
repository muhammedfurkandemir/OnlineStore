using OnlineStore.Models.DTOs;
using OnlineStore.Models.Entities;
using OnlineStore.Utilities.EntityFreamwork.Repositories;
using System.Linq.Expressions;

namespace OnlineStore.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();

        ProductDetailDto GetProductDetail(int id);

        List<ProductDetailDto> GetAllByCategoryId(int categoryId);
    }
}
