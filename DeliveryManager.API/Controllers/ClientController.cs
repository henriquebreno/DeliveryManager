using DeliveryManager.Application.Dtos;
using DeliveryManager.Application.Dtos.Address;
using DeliveryManager.Application.Dtos.Client;
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
        [HttpGet("{clientId}")]
        public IActionResult GetClientById(int clientId)
        {
            var client = new ClientDto();
            try
            {
                client = _clientApplication.GetClient(clientId);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, client);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateClient([FromBody] CreateClientDto client)
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
        [HttpPut("{clientId}")]
        public IActionResult UpdateClient([FromBody] UpdateClientDto client)
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
        [HttpDelete("{clientId}")]
        public IActionResult DeleteClient(long clientId)
        {           
            try
            {
                _clientApplication.DeleteClient(clientId);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{clientId}/address")]
        public IActionResult GetClientAddresses(int clientId)
        {
            var clientAddresses = new List<ClientAddressDto>();
            try
            {
                clientAddresses = _clientApplication.GetClientAddresses(clientId);
                return Ok(clientAddresses);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, clientAddresses);
            }
        }

        [HttpPost("{clientId}/address")]
        public IActionResult CreateClientAddress([FromBody] CreateClientAddressDto client,int clientId)
        {
            try
            {
                _clientApplication.CreateClientAddress(client, clientId);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{clientId}/address/{addressId}")]
        public IActionResult ChangeClientAddress([FromBody] UpdateClientAddressDto client, int clientId, int addressId )
        {
            try
            {
                _clientApplication.ChangeClientAddress(client, clientId, addressId);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{clientId}/address/{addressId}")]
        public IActionResult DeleteClientAddress(long clientId,long addressId)
        {
            try
            {
                _clientApplication.DeleteClientAddress(clientId, addressId);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
