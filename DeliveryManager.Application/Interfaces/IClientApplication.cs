using DeliveryManager.Application.Dtos;
using DeliveryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Interfaces
{
    public interface IClientApplication
    {
        void CreateUser(ClientDto client);

        ClientDto GetClient(int id);

        List<ClientDto> GetAll();
    }
}
