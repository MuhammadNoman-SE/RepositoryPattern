using MyShop.Domain.Models;
using MyShop.Infrastructure.Lazy.Proxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Lazy
{
    enum State 
    {
    Ghost=0,
    Loading,
    Loaded
    }
    public class CustomerGhost:CustomerProxy
    {
        public CustomerGhost(Func<Customer> load) {
            this.load = load;
        }
        State state;
        Func<Customer> load;
        private void Load() 
        {
            if (state == State.Ghost)
            {
                state = State.Loading;
                Customer customer = load();
                base.Name = customer.Name;
                base.PostalCode = customer.PostalCode;
                base.ProfilePic = customer.ProfilePic;
                base.City = customer.City;
                base.Country = customer.Country;
                base.ShippingAddress = customer.ShippingAddress;

                state = State.Loaded;

            }
        }
        public override string Name
        {
            get
            {
                Load();
                return base.Name;
            }
            set
            {
                Load();
                base.Name = value;
            }
        }
    }
}
