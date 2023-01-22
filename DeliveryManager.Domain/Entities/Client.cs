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
        public string FullName { get; set; }
        public string Cellphone { get; set; }
        public string BirthDate { get; set; }

        public ICollection<ClientAddress> ClientAddress { get; private set; }


        public override void Validate()
        {
            throw new NotImplementedException();
        }

        public Client(string email, string cpf, string fullName, string cellphone, string birthDate )
        {
            Email = email;
            Cpf = cpf;
            FullName = fullName;
            Cellphone = cellphone;
            BirthDate = birthDate;
            ClientAddress = new List<ClientAddress>();
        }

        public Client() { }

        public void AddAddressItem(ClientAddress clientAddress) 
        {
            if (clientAddress != null) 
            {
                this.ClientAddress.Add(clientAddress);
                ActiveAddress(clientAddress);
            }                
        }

        public void ChangeAddress(long addressId,string street, string number, string complement, string district, string state, string city, string zipCode)
        {

            foreach (var address in this.ClientAddress) 
            {
                if (address.Id == addressId) 
                {
                    address.Street = street;
                    address.Number = number;
                    address.Complement = complement;
                    address.District = district;
                    address.State = state;
                    address.City = city;
                    address.ZipCode = zipCode;
                    ActiveAddress(address);
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

        public void ActiveAddress(ClientAddress clientAddress)
        {
            foreach (var address in this.ClientAddress)
            {
                if (address.Id == clientAddress.Id)
                {
                    address.IsActive = true;
                }
                else 
                {
                    address.IsActive = false;
                }
                
            }
        }

    }
}
