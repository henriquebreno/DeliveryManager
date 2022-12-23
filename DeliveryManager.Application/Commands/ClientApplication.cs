using DeliveryManager.Application.Dtos;
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
        public ClientApplication(IClientRepository clientRepository, IUnitOfWork unitOfWork) 
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateUser(ClientDto client) 
        {
            _clientRepository.Add(client);
            _unitOfWork.Commit();
        }

        public List<ClientDto> GetAll()
        {
            return _clientRepository.Get().ToList();
        }

        public Client GetClient(int id) 
        {
            return _clientRepository.GetById(id);
        }
    }
}
