using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId = 1, ProductName = "Bardak", CategoryId = 1, UnitPrice = 15, UnitsInStock = 15},
                new Product{ProductId = 2, ProductName = "Kamera", CategoryId = 1, UnitPrice = 500, UnitsInStock = 3},
                new Product{ProductId = 3, ProductName = "Telefon", CategoryId = 2, UnitPrice = 1500, UnitsInStock = 2},
                new Product{ProductId = 4, ProductName = "Klavye", CategoryId = 2, UnitPrice = 150, UnitsInStock = 65},
                new Product{ProductId = 5, ProductName = "Fare", CategoryId = 2, UnitPrice = 85, UnitsInStock = 1},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var productToDelete = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            var productToUpdate = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
