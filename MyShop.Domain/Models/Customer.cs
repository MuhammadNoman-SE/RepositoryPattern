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

        public Lazy<byte[]> ProfilePicValueHolder { get; set; }
        public byte[] ProfilePic { 
            get {
                return ProfilePicValueHolder.Value;
            }
            
        }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
