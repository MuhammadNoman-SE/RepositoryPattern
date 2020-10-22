using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public interface IUnitOfWork {
        IRepository<Customer> customerRepository { get; }
        IRepository<Order> orderRepository { get; }
        IRepository<Product> productRepository { get; }
        void Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private ShoppingContext _shoppingContext;
        public UnitOfWork(ShoppingContext shoppingContext) {
            _shoppingContext = shoppingContext;
        }
        private IRepository<Customer> _customerRepository;
        public IRepository<Customer> customerRepository {
            get
            {
                if (null == _customerRepository) {
                    _customerRepository = new CustomerRepository(_shoppingContext);
                }
                return _customerRepository;
            }
        }
        private IRepository<Order> _orderRepository;
        public IRepository<Order> orderRepository {
            get {
                if (null == _orderRepository) {
                    _orderRepository = new OrderRepository(_shoppingContext);
                }
                return _orderRepository;
            }
        }
        private IRepository<Product> _productRepository;
        public IRepository<Product> productRepository {
            get {
                if (null == _productRepository) {
                    _productRepository = new ProductRepository(_shoppingContext);
                }
                return _productRepository;
            }
        }

        public void Save()
        {
            _shoppingContext.SaveChanges();
        }
    }
}
