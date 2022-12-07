using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Cardapio
    {
       
        public decimal Preco { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Url { get; set; }

        public int Id_Cardapio { get; set; }
    }
}
