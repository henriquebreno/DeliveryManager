using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{

    public class Cliente
    {

        public string Cpf { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Id_cliente { get; set; }
    }
}
