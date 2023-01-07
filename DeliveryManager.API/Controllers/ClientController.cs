using DeliveryManager.Application.Dtos;
using DeliveryManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeliveryManager.API.Controllers
{
    [Route("api/client")]
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
        public IActionResult GetAllClients()
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
        public IActionResult GetClientById(int id)
        {
            var client = new ClientDto();
            try
            {
                client = _clientApplication.GetClient(id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, client);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientDto client)
        {
            try
            {
                _clientApplication.CreateClient(client);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult UpdateClient([FromBody] ClientDto client)
        {
            try
            {
                _clientApplication.UpdateClient(client);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(long id)
        {           
            try
            {
                _clientApplication.DeleteClient(id);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
