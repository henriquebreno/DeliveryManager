using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {

        public string Email { get; set; }
        public string Cpf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string BirthDate { get; set; }

        private readonly List<ClientAddress> _clientAddress;

        public virtual IReadOnlyList<ClientAddress> ClientAddress => _clientAddress;

        public override void Validate()
        {
            throw new NotImplementedException();
        }


        public void SetAddress(ClientAddress clientAddress) 
        {
            if (clientAddress != null) 
            {
                clientAddress.Client = this;
                _clientAddress.Add(clientAddress);
            }
                
        }

        public void ChangeAddress(ClientAddress clientAddress)
        {
            if (clientAddress != null)
            {
                foreach (var address in _clientAddress) 
                {
                    if (address.Id == clientAddress.Id) 
                    {
                        address.Street = clientAddress.Street;
                        address.City = clientAddress.City;
                        address.Country = clientAddress.Country;
                        address.State = clientAddress.State;
                        address.ZipCode = clientAddress.ZipCode;
                    }
                }
            }

        }
        public Client() 
        {
           this._clientAddress = new List<ClientAddress>();
        }

       
    }
}
