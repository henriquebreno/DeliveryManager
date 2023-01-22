using DeliveryManager.Application.Dtos.Order;
using DeliveryManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderApplication _orderApplication;

        public OrderController(IOrderApplication orderApplication)
        {
            _orderApplication = orderApplication;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var orders = _orderApplication.GetAll();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(long orderId)
        {
            var order = new OrderDto();
            try
            {
                order = _orderApplication.GetOrder(orderId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, order);
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                _orderApplication.CreateOrder(orderDto);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{orderId}")]
        public IActionResult ChangeOrder([FromBody] UpdateOrderDto client,long orderId)
        {
            try
            {
                _orderApplication.UpdateOrder(client, orderId);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{orderId}")]
        public IActionResult Delete(long orderId)
        {
            try
            {
                _orderApplication.DeleteOrder(orderId);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
