using AutoMapper;
using DeliveryManager.Application.Dtos;
using DeliveryManager.Application.Dtos.Address;
using DeliveryManager.Application.Dtos.Client;
using DeliveryManager.Application.Interfaces;
using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryManager.Application.Commands
{
    public class ClientApplication : IClientApplication
    {
        protected IClientRepository _clientRepository;
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public ClientApplication(IClientRepository clientRepository, IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateClient(ClientDto clientdto)
        {
            var client = _mapper.Map<ClientDto, Client>(clientdto);

            _clientRepository.Add(client);
            _unitOfWork.Commit();
        }

        public List<ClientDto> GetAll()
        {
            var clientList = _clientRepository.Include(o=>o.ClientAddress).ToList();
            var clientDtoList = new List<ClientDto>();
            foreach (var client in clientList) 
            {
                clientDtoList.Add(_mapper.Map<Client, ClientDto>(client));
            }

            return clientDtoList;
        }

        public ClientDto GetClient(long clientId) 
        {
            return _mapper.Map<Client, ClientDto>(_clientRepository.Include(o => o.ClientAddress).FirstOrDefault(o=>o.Id == clientId));
        }

        public void DeleteClient(long clientId)
        {
            var client = _clientRepository.Include(o => o.ClientAddress).FirstOrDefault(o => o.Id == clientId);
            _clientRepository.Delete(client);
            _unitOfWork.Commit();
        }

        public void UpdateClient(ClientDto clientdto)
        {
            var client = _mapper.Map<ClientDto, Client>(clientdto);
            _clientRepository.Update(client);
            _unitOfWork.Commit();
        }


        public List<ClientAddressDto> GetClientAddresses(long clientId)
        {
            var clientAddress = new List<ClientAddressDto>();
            var client = _clientRepository.Include(o => o.ClientAddress).FirstOrDefault(o => o.Id == clientId);
            foreach (var address in client.ClientAddress) 
            {
                clientAddress.Add(_mapper.Map<ClientAddress, ClientAddressDto>(address));
            }
            return clientAddress;
        }

        public void CreateClientAddress(ClientAddressDto clientAddressDto, long clientId)
        {
            var client = _clientRepository.Include(o => o.ClientAddress)
                                          .FirstOrDefault(o => o.Id == clientId);
            if (client != null) 
            {
                var clientAddress = _mapper.Map<ClientAddressDto, ClientAddress>(clientAddressDto);
                client.AddAddressItem(clientAddress);
            }

            _clientRepository.Update(client);
            _unitOfWork.Commit();
        }

        public void ChangeClientAddress(ClientAddressDto clientAddressDto, long clientId,long addressId)
        {
            var client = _clientRepository.Include(o => o.ClientAddress).FirstOrDefault(o => o.Id == clientId);
            var clientAddress = _mapper.Map<ClientAddressDto, ClientAddress>(clientAddressDto);
            client.ChangeAddress(clientAddress);

            _clientRepository.Update(client);
            _unitOfWork.Commit();
        }


        public void DeleteClientAddress(long clientId,long addressId)
        {

            var client = _clientRepository.Include(o => o.ClientAddress).FirstOrDefault(o => o.Id == clientId);
            if (client != null)
            {
                client.RemoveAddress(addressId);
            }
            _clientRepository.Update(client);
            _unitOfWork.Commit();
        }
    }
}
