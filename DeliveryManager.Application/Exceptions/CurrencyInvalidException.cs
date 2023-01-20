using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Exceptions
{
    public class CurrencyInvalidException : Exception
    {
        public CurrencyInvalidException() : base("Invalid Currency")
        {
                    
        }

        public CurrencyInvalidException(string message) : base(message)
        {

        }
    }
}
