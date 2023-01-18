using DeliveryManager.Application.Dtos;
using DeliveryManager.Application.Dtos.Address;
using DeliveryManager.Application.Dtos.Client;
using DeliveryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Interfaces
{
    public interface IClientApplication
    {
        void CreateClient(ClientDto client);

        ClientDto GetClient(long clientId);

        List<ClientDto> GetAll();

        void DeleteClient(long clientId);

        void UpdateClient(ClientDto client);

        List<ClientAddressDto> GetClientAddresses(long clientId);

        void CreateClientAddress(ClientAddressDto client,long clientId);

        void ChangeClientAddress(ClientAddressDto client, long clientId,long addressId);

        void DeleteClientAddress(long clientId,long addressId);

    }
}
