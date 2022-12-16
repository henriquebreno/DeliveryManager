using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DeliveryManager.Infra.Repositories
{
    public class CardapioRepository: BaseRepository<Cardapio>,ICardapioRepository
    {
        public CardapioRepository(DbContext context) : base(context)
        {
                
        }
    }
}
