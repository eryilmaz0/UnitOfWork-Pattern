﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Business.Abstract;
using Core.Log;
using Core.Results;
using Core.Serilog;
using Entities.Dto;
using Entities.Entities;
using Entities.Enums;
using FluentValidation;
using Repository.UnıtOfWork.Abstract;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly AbstractValidator<Product> _validator;
        private readonly ILogManager _logManager;

        public ProductManager(IUnitOfWork unitOfWork, ILogger logger, AbstractValidator<Product> validator, ILogManager logManager)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _validator = validator;
            _logManager = logManager;
        }




        public IResult Add(Product product)
        {
            var validateResult = _validator.Validate(product);

            if (!validateResult.IsValid)
            {
                return new ErrorResult(validateResult.Errors.FirstOrDefault().ErrorMessage);
            }

            if (_unitOfWork._productRepository.GetByName(product.Name) != null)
            {
                return new ErrorResult("Bu İsimde Bir Ürün Zaten Bulunmakta.");
            }


            _unitOfWork._productRepository.Add(product);
            _logger.Log(new EntityOperationLog()
            {
                TableName = "Products",
                LogType = (int)LogType.Added,
                OperationDate = DateTime.Now,
                LogData = _logger.SerializeObject(product)

            });

            _unitOfWork.Commit();


            _logManager.GetLogger().Information("{@product}",product, LogType.Added);
            //HATA OLUŞURSA EXCEPTİON HANDLER TARAFINDAN YAKALANIR, HİÇBİR İŞLEM GERÇEKLEŞMEZ.

            return new SuccessResult("Ürün Başarıyla Eklendi.");
        }




        public IResult AddRange(List<Product> products)
        {
            var validateResult = CheckProducts(products);

            if (!validateResult.Success)
            {
                return validateResult;
            }

            _unitOfWork._productRepository.AddRange(products);
            _logger.Log(new EntityOperationLog()
            {
                TableName = "Products",
                LogType = (int)LogType.Added,
                OperationDate = DateTime.Now,
                LogData = _logger.SerializeObject(products)
            });
            _unitOfWork.Commit();

            _logManager.GetLogger().Information("{@product}", products, LogType.Added);

            return new SuccessResult("Ürünler Başarıyla Eklendi");
        }




        public IResult Delete(int productID)
        {
            var findProduct = _unitOfWork._productRepository.GetById(productID);

            if (findProduct == null)
            {
                return new ErrorResult("Ürün Bulunamadı.");
            }

            _unitOfWork._productRepository.Delete(findProduct);
            _logger.Log(new EntityOperationLog()
            {
                TableName = "Products",
                LogType = (int)LogType.Deleted,
                OperationDate = DateTime.Now,
                LogData = _logger.SerializeObject(findProduct)
            });

            _unitOfWork.Commit();

            return new SuccessResult("Ürün Başarıyla Silindi.");
        }




        public IDataResult<List<Product>> GetAll()
        {
           return new SuccessDataResult<List<Product>>(_unitOfWork._productRepository.GetAll());
        }




        public IDataResult<Product> GetById(int productID)
        {
            var findProduct = _unitOfWork._productRepository.GetById(productID);


            if (findProduct == null)
            {
                return new ErrorDataResult<Product>("Ürün Bulunamadı.");
            }


            return new SuccessDataResult<Product>(findProduct);
        }





        public IResult Update(Product product)
        {

            if (_unitOfWork._productRepository.GetById(product.ProductID) == null)
            {
                return new ErrorResult() { Success = false, Message = "Güncellenecek Olan Ürün Veritabanında Bulunamadı." };
            }


            if (_unitOfWork._productRepository.GetByName(product.Name) != null)
            {
                return new ErrorResult("Bu İsimde Bir Ürün Bulunmakta. (Update)");
            }


            _unitOfWork._productRepository.Update(product);
            _logger.Log(new EntityOperationLog()
            {
                TableName = "Products",
                LogType = (int)LogType.Updated,
                OperationDate = DateTime.Now,
                LogData = _logger.SerializeObject(product)

            });
            _unitOfWork.Commit();

            return new SuccessResult("Ürün Başarıyla Güncellendi");

        }



        public IDataResult<Product> GetByName(string productName)
        {
            var product = _unitOfWork._productRepository.GetByName(productName);

            if (product == null)
            {
                return new ErrorDataResult<Product>("Ürün Bulunamadı");
            }

            return new SuccessDataResult<Product>(product);
        }




        public IDataResult<List<Product>> GetByCategory(int categoryID)
        {
            var category = _unitOfWork._categoryRepository.GetById(categoryID);


            if (category == null)
            {
                return new ErrorDataResult<List<Product>>("Kategori Bulunamadı.");
            }


            var products = _unitOfWork._productRepository.GetByCategory(categoryID);


            if (products.Count() == 0)
            {
                return new ErrorDataResult<List<Product>>("Bu Kategoride Ürün Bulunamadı.");
            }

            return new SuccessDataResult<List<Product>>(products);
        }






        public IDataResult<List<GetProductsWithCategoryDto>> GetProductsWithCategory()
        {
            
            return new SuccessDataResult<List<GetProductsWithCategoryDto>>(_unitOfWork._productRepository.GetProductsWithCategory());

        }




        public IDataResult<GetProductsWithCategoryDto> GetProductWithCategory(int ProductID)
        {
            var product = _unitOfWork._productRepository.GetProductsWithCategory().Where(x => x.ProductID == ProductID).FirstOrDefault();

            if (product == null)
            {
                return new ErrorDataResult<GetProductsWithCategoryDto>("Ürün Bulunamadı");
            }
           

            return new SuccessDataResult<GetProductsWithCategoryDto>(product);
                
        }




        private IResult CheckProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                var validateResult = _validator.Validate(product);


                if (!validateResult.IsValid)
                {
                    return new ErrorResult($"{product.Name} İsimli Ürün İçin : {validateResult.Errors.FirstOrDefault().ErrorMessage}");
                }


                if (_unitOfWork._productRepository.GetByName(product.Name) != null)
                {
                    return new ErrorResult($"{product.Name} İsimli Ürün Zaten Mevcut.");
                }
            }

            return new SuccessResult(){Success = true};
        }




        
    }
}
