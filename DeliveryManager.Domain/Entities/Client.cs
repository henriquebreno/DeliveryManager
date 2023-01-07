using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {

        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Cellphone { get; set; }

        public string BirthDate { get; set; }

        public virtual IEnumerable<ClientAddress> ClientAddress { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }


        public void SetAddress(ClientAddress clientAddress) 
        {
            
        }
    }
}
