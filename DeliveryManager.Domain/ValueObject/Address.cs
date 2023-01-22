using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.ValueObject
{
    public class Address : ValueObject
    {
        public String Street { get; set; }
        public String Number { get; set; }
        public String Complement { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }


        public Address() { }

        public Address(string street, string number, string complement, string district, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
