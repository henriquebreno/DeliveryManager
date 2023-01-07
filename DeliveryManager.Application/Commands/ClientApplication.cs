using AutoMapper;
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
            List<ClientDto> clientDtos = _mapper.Map<List<Client>, List<ClientDto>>(_clientRepository.Get().ToList());
            return clientDtos;
        }

        public ClientDto GetClient(long  id) 
        {
            return _mapper.Map<Client, ClientDto>(_clientRepository.GetById(id));
        }

        public void DeleteClient(long id)
        {
            var client = _clientRepository.GetById(id);
            _clientRepository.Delete(client);
            _unitOfWork.Commit();
        }

        public void UpdateClient(ClientDto clientdto)
        {
            var client = _mapper.Map<ClientDto, Client>(clientdto);
            _clientRepository.Update(client);
            _unitOfWork.Commit();
        }
    }
}
