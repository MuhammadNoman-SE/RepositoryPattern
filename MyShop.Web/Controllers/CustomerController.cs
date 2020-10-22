using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = _unitOfWork.customerRepository.GetAll();

                return View(customers);
            }
            else
            {
                var customer = _unitOfWork.customerRepository.Get(id.Value);

                return View(new[] { customer });
            }
        }
    }
}
