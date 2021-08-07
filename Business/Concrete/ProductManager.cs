using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return productDal?.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return productDal?.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return productDal?.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
