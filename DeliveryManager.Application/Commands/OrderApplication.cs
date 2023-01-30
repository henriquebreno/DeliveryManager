using AutoMapper;
using DeliveryManager.Application.Dtos.Order;
using DeliveryManager.Application.Interfaces;
using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;

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

        public void CreateOrder(OrderDto orderDto)
        {
            var client = _clientRepository.GetById(orderDto.BuyerId);
            var order = new Order(client.Id,
                new Domain.ValueObject.Address(
                    orderDto.OrderAddress.Street,
                    orderDto.OrderAddress.Number,
                    orderDto.OrderAddress.Complement,
                    orderDto.OrderAddress.District,
                    orderDto.OrderAddress.State,
                    orderDto.OrderAddress.City,
                    orderDto.OrderAddress.ZipCode
                    )
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

        public void DeleteOrder(long orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null) 
            {
                throw new NotImplementedException();
            }
            _orderRepository.Delete(order);
            _unitOfWork.Commit();
        }

        public List<OrderDto> GetAll()
        {
            var orders = _orderRepository.Get();
            var ordersDto = new List<OrderDto>();
            foreach (var order in orders)
            {
                ordersDto.Add(_mapper.Map<Order, OrderDto>(order));
            }

            return ordersDto;
        }

        public OrderDto GetOrder(long orderId)
        {
            var order = _mapper.Map<Order, OrderDto>(_orderRepository.GetById(orderId));
            if (order == null)
            {
                throw new NotImplementedException();
            }
            return order;
        }

        public void UpdateOrder(OrderDto orderDto, long orderId)
        {
            throw new NotImplementedException();
        }
    }
}
