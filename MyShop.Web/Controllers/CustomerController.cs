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
        private IRepository<Customer> _repository;

        public CustomerController(IRepository<Customer> repository)
        {
            _repository=repository;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = _repository.GetAll();

                return View(customers);
            }
            else
            {
                var customer = _repository.Get(id.Value);

                return View(new[] { customer });
            }
        }
    }
}
