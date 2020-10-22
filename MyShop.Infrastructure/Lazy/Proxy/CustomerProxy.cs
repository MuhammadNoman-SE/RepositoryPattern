using MyShop.Domain.Models;
using MyShop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Lazy.Proxy
{
    public class CustomerProxy : Customer
    {
        public override byte[] ProfilePic {
            get
            {
                if (null == base.ProfilePic)
                    base.ProfilePic = ProfilePicService.GetFor(Name);
                return base.ProfilePic;
            }
            set
            {
                base.ProfilePic = value;
            }
        }
    }
}
