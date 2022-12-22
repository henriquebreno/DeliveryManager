using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{

    public class Client : IAggregateRoot
    {

        public string Cpf { get; set; }

        public string Name { get; set; }
        public string Cellphone { get; set; }
        public int ClientId { get; set; }
    }
}
