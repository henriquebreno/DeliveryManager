using AutoMapper;
using DeliveryManager.Application.Dtos.Product;
using DeliveryManager.Application.Exceptions;
using DeliveryManager.Application.Interfaces;
using DeliveryManager.Application.Validations;
using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryManager.Application.Commands
{
    public class ProductApplication : IProductApplication
    {
        protected IProductRepository _productRepository;
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        protected ProductValidator _validator;

        public ProductApplication(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper, ProductValidator validator)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public void CreateProduct(ProductDto productDto)
        {
            var product = new Product
                (new Domain.ValueObject.Money(
                    productDto.Price.Amount), 
                    productDto.Name, 
                    productDto.Description, 
                    productDto.Url
                );

            _productRepository.Add(product);
            _unitOfWork.Commit();
        }

        public List<ProductDto> GetAll()
        {
            var products = _productRepository.Get();
            var productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDto.Add(_mapper.Map<Product, ProductDto>(product));
            }

            return productsDto;
        }

        public ProductDto GetProduct(long productId)
        {
            return _mapper.Map<Product, ProductDto>(_productRepository.GetById(productId));
        }

        public void DeleteProduct(long productId)
        {
            var product = _productRepository.GetById(productId);
            _productRepository.Delete(product);
            _unitOfWork.Commit();
        }

        public void UpdateProduct(ProductDto productDto, long productId)
        {
            var product = _productRepository.GetById(productId);
            var obj = new Product(new Money
                (                  
                    productDto.Price.Amount
                ), productDto.Name,productDto.Url,productDto.Description);
            

            var validationResult = _validator.Validate(obj);
            if (!validationResult.IsValid) 
            {
                throw new ArgumentException(validationResult.Errors.First().ErrorMessage);
            }

            product.UpdateProduct(obj);                         
            _productRepository.Update(product);
            _unitOfWork.Commit();
        }
    }
}
