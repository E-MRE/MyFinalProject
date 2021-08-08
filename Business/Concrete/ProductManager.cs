using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
                return new ErrorResult(Messages.ProductNameInvalid);

            productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            return new SuccessDataResult<List<Product>>(productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 21)
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);

            return new SuccessDataResult<List<ProductDetailDto>>(productDal.GetProductDetails());
        }
    }
}
