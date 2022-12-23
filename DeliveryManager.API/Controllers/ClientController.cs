using DeliveryManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeliveryManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientApplication _clientApplication;

        public ClientController(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            try 
            {
                var clientList = _clientApplication.GetAll();
                return Ok(clientList);
            }            
            catch (Exception ex)            
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var clientList = _clientApplication.GetClient(id);
                return Ok(clientList);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
