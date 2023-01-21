using AutoMapper;
using DeliveryManager.Application.Dtos.Order;
using DeliveryManager.Application.Interfaces;
using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using System;

namespace DeliveryManager.Application
{
    public class OrderApplication : IOrderApplication
    {
        protected IOrderRepository _orderRepository;
        protected IClientRepository _clientRepository;
        protected IProductRepository _productRepository;
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        public OrderApplication(IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IClientRepository clientRepository,
            IProductRepository productRepository)
        {
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public void CreateProduct(OrderDto orderDto)
        {
            var client = _clientRepository.GetById(orderDto.BuyerId);
            var order = new Order(client.Id,
                new Domain.ValueObject.Address(
                    orderDto.OrderAddress.Street,
                    orderDto.OrderAddress.City,
                    orderDto.OrderAddress.State,
                    orderDto.OrderAddress.Country,
                    orderDto.OrderAddress.ZipCode)
                );

            foreach (var orderItemDto in orderDto.OrderItems)
            {
                var product = _productRepository.GetById(orderItemDto.ProductId);
                var productItemOrdered = new ProductItemOrdered(product.Price.Amount, product.Name, product.Description);
                order.AddOrderItem(productItemOrdered, orderItemDto.Units);
            }
            _orderRepository.Add(order);
            _unitOfWork.Commit();
        }


    }
}
