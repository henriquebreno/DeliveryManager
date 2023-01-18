using DeliveryManager.Application.Dtos.Product;
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
    public class ProductController : ControllerBase
    {
        private IProductApplication _productApplication;

        public ProductController(IProductApplication clientApplication)
        {
            _productApplication = clientApplication;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var clientList = _productApplication.GetAll();
                return Ok(clientList);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetProductById(long productId)
        {
            try
            {
                var clientList = _productApplication.GetProduct(productId);
                return Ok(clientList);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto product)
        {
            try
            {
                _productApplication.CreateProduct(product);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
