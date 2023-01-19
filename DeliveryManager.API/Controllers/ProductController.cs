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
        [HttpGet("{productId}")]
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
        public IActionResult CreateProduct([FromBody] CreateProductDto product)
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
        [HttpPut("{productId}")]
        public IActionResult ChangeProduct(long productId, [FromBody] UpdateProductDto updateProduct)
        {
            try
            {
                _productApplication.UpdateClient(updateProduct, productId);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{productId}")]
        public IActionResult RemoveProduct(long productId)
        {
            try
            {
                _productApplication.DeleteClient(productId);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
