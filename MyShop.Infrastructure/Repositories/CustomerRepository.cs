using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MyShop.Infrastructure.Services;
using MyShop.Infrastructure.Lazy.Proxy;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext shoppingContext) : base(shoppingContext) { }
        public override IEnumerable<Customer> GetAll()
        {

            //return base.GetAll().Select(c => 
            //{ 
            //    c.ProfilePicValueHolder = new Lazy<byte[]>(() => 
            //    {
            //    return ProfilePicService.GetFor(c.Name);
            //    });
            //return c; 
            //});
            return base.GetAll().Select(MapProxy);
        }
        private CustomerProxy MapProxy(Customer customer)
        {
            return new CustomerProxy
            {
                Name = customer.Name,
                City = customer.City,
                ShippingAddress = customer.ShippingAddress,
                PostalCode = customer.PostalCode,
                Country = customer.Country
            };
        }
    }
}
