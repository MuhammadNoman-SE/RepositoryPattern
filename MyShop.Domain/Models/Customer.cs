using System;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public virtual string Name { get; set; }
        public virtual string ShippingAddress { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }

        //public Lazy<byte[]> ProfilePicValueHolder { get; set; }
        //public byte[] ProfilePic { 
        //    get {
        //        return ProfilePicValueHolder.Value;
        //    }

        //}
        public virtual byte[] ProfilePic { get; set; }
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
