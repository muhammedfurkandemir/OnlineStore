using Microsoft.AspNetCore.Http;
using OnlineStore.Models.Abstract;

namespace OnlineStore.Models.Concrete
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        private static Cart? instance;
        public List<CartLine> CartLines
        {
            get
            {
                return _cartLines;
            }
        }
        public static Cart GetCart
        {
            get
            {
                if (instance == null)
                {
                    instance = new Cart();
                }
                return instance;
            }
        }
        public static void SetCart(Cart cart)
        {
            instance = cart;
        }
        public void AddProduct(Product product,int quantity)
        {
            var productLine = _cartLines.SingleOrDefault(p => p.Product.Id == product.Id);
            if (productLine == null)
            {
                _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                productLine.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(p => p.Product.Id == product.Id);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
        public decimal Total()
        {
            return _cartLines.Sum(p => p.Product.UnitPrice * p.Quantity);
        }
    }
}
