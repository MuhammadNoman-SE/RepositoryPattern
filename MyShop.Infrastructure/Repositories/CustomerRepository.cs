using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MyShop.Infrastructure.Services;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext shoppingContext) : base(shoppingContext) { }
        public override IEnumerable<Customer> GetAll()
        {

            return base.GetAll().Select(c => { 
            c.ProfilePicValueHolder = new Lazy<byte[]>(() => {
                return ProfilePicService.GetFor(c.Name);
            });
            return c; 
        });
        }
    }
}
