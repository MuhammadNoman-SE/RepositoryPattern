using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MyShop.Infrastructure.Repositories
{
    public class ProductRepository:GenericRepository<Product>
    {
        public ProductRepository(ShoppingContext shoppingContext):base(shoppingContext) { }
        public override Product Update(Product entity)
        {
            Product product = _context.Products.Single(p => p.ProductId == entity.ProductId);
            product.Name = entity.Name;
            product.Price = entity.Price;
            return base.Update(product);
        }
    }
}
