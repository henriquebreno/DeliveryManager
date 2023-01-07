using DeliveryManager.Application.Dtos;
using DeliveryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Interfaces
{
    public interface IClientApplication
    {
        void CreateClient(ClientDto client);

        ClientDto GetClient(long id);

        List<ClientDto> GetAll();

        void DeleteClient(long id);

        void UpdateClient(ClientDto client);
    }
}
