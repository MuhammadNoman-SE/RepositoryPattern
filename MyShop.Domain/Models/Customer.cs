using MyShop.Domain.Services;
using System;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        private byte[] _profilePic;
        public byte[] ProfilePic { 
            get {
                if (null == _profilePic) {
                    _profilePic = ProfilePicService.GetFor(Name);
                
                }
                return _profilePic;
            }
            set {
                _profilePic = value;
            }
        }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
