using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos
{
    public class ClientAddressDto
    {
        public String Street { get;  set; }
        public String City { get;  set; }
        public String State { get;  set; }
        public String Country { get;  set; }
        public String ZipCode { get;  set; }

    }
}
