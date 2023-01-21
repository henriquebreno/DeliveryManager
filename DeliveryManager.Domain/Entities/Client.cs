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

        public ICollection<ClientAddress> ClientAddress { get; private set; }


        public override void Validate()
        {
            throw new NotImplementedException();
        }

        public Client(string email,string cpf,string firstName,string lastName,string cellphone,string birthDate)
        {
            Email = email;
            Cpf = cpf;
            FirstName = firstName;
            LastName = lastName;
            Cellphone = cellphone;
            BirthDate = birthDate;
        }

        public Client() { }

        public void AddAddressItem(ClientAddress clientAddress) 
        {
            if (clientAddress != null) 
            {
                this.ClientAddress.Add(clientAddress);
            }
                
        }

        public void ChangeAddress(ClientAddress clientAddress)
        {
            if (clientAddress != null)
            {
                foreach (var address in this.ClientAddress) 
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
        public void RemoveAddress(long clientAddressId)
        {

            var clientAddress = ClientAddress.FirstOrDefault(client => client.Id == clientAddressId);
            if (clientAddress != null)
            {
                ClientAddress.Remove(clientAddress);
            }

        }

        

    }
}
