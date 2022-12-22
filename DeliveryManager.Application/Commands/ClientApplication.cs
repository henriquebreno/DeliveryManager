using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Commands
{
    public class ClientApplication
    {
        protected IClientRepository _clientRepository;
        protected IUnitOfWork _unitOfWork;
        public ClientApplication(IClientRepository clientRepository, IUnitOfWork unitOfWork) 
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateUser() 
        {
            _clientRepository.Add(new Client());
            _unitOfWork.Commit();
        }

        public Client GetClient(int id) 
        {
            return _clientRepository.GetById(id);
        }
    }
}
