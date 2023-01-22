using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException() : base("Client not found")
        {

        }

        public ClientNotFoundException(string message) : base(message)
        {

        }
    }
}
