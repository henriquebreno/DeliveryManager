using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos
{
    public class ClientDto : NotificationBase
    {
        public string Cpf { get; set; }

        public string Name { get; set; }
        public string Cellphone { get; set; }
        public int ClientId { get; set; }
    }
}
