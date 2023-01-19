using AutoMapper;
using DeliveryManager.Application.Dtos.Product;
using DeliveryManager.Application.Interfaces;
using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Commands
{
    public class ProductApplication : IProductApplication
    {
        protected IProductRepository _productRepository;
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public ProductApplication(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDto productDto)
        {
            var product = new Product
                (new Domain.ValueObject.Money(
                    new Domain.ValueObject.Currency(),productDto.Price.Amount), 
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

        public void DeleteClient(long productId)
        {
            var product = _productRepository.GetById(productId);
            _productRepository.Delete(product);
            _unitOfWork.Commit();
        }

        public void UpdateClient(ProductDto productDto, long productId)
        {
            var product = _productRepository.GetById(productId);
            product.UpdateProduct(new Product()
            {
                Description = productDto.Description,
                Name = productDto.Name,
                Url = product.Url,
                Price = new Money(
                    new Currency(
                        product.Price.Currency.Name, productDto.Price.Currency.Symbol),
                        productDto.Price.Amount
                        )
            });
       
            
               
           
            _productRepository.Update(product);
            _unitOfWork.Commit();
        }
    }
}
