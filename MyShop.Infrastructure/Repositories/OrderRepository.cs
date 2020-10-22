using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository:GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext shoppingContext):base(shoppingContext) { }

        public override IEnumerable<Order> Find(Func<Order, bool> expression)
        {
            return _context.Orders
                .Include(order => order.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Where(expression).ToList();

        }
        public override Order Update(Order entity)
        {
            Order order= _context.Orders
                .Include(o => o.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Single(o=> o.OrderId==entity.OrderId);
            order.LineItems = entity.LineItems;
            order.OrderDate = entity.OrderDate;
            return base.Update(order);
        }
    }
}
