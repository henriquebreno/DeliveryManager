using AutoMapper;
using DeliveryManager.Application.Dtos.Product;
using DeliveryManager.Application.Interfaces;
using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
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
            var client = _mapper.Map<ProductDto, Product>(productDto);

            _productRepository.Add(client);
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

        public void UpdateClient(ProductDto productDto)
        {
            var client = _mapper.Map<ProductDto, Product>(productDto);
            _productRepository.Update(client);
            _unitOfWork.Commit();
        }
    }
}
