﻿using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Infra.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DeliveryManager.Infra.Repositories
{
    public class FoodRepository: BaseRepository<Food>,IFoodRepository
    {
        public FoodRepository(Context context) : base(context)
        {
                
        }
    }
}
