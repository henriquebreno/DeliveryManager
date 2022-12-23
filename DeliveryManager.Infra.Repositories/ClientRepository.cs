﻿using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Infra.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Infra.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository 
    {
        public ClientRepository(Context context) : base(context)
        {
        }
    }
}
