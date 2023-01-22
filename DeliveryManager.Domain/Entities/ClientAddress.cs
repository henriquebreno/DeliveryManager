using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class ClientAddress : Entity
    {
        public String Street { get;  set; }
        public String Number { get; set; }
        public String Complement  { get;  set; }
        public String District { get; set; }
        public String City { get;  set; }
        public String State { get;  set; }
        public String ZipCode { get;  set; }
        public bool IsActive { get; set; }


        public virtual Client Client { get;  set; }

        public ClientAddress(string street, string number, string complement, string district, string state, string city, string zipCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            State = state;
            City = city;
            ZipCode = zipCode;
            IsActive = true;
        }

        public ClientAddress() { }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
