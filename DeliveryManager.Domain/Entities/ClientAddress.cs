using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class ClientAddress : Entity
    {
        public String Street { get;  set; }
        public String City { get;  set; }
        public String State { get;  set; }
        public String Country { get;  set; }
        public String ZipCode { get;  set; }

        public virtual Client Client { get;  set; }


        public ClientAddress() { }

        public ClientAddress(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }


        public ClientAddress(Client client)
        {
            this.Client = client;
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
