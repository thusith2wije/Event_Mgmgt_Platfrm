using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIQRI.EMP.ApplicationCore.Entities;
using TIQRI.EMP.ApplicationCore.Interfaces;
using TIQRI.EMP.WebAPI.Models;

namespace TIQRI.EMP.WebAPI.Controllers
{
    //[Produces("application/json")]
    [Route("api/ClientAPI")]
    public class ClientAPIController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientAPIController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: api/ClientAPI
        [HttpGet]
        public IEnumerable<ClientViewModel> Get()
        {
            try
            {
                var clients = _clientRepository.ListAll();
                var clientList = clients.Select(s => new ClientViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    IsActive = s.IsActive
                });

                return clientList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: api/ClientAPI/5
        [HttpGet("{id}", Name = "Get")]
        public ClientViewModel Get(int id)
        {
            try
            {
                var client = _clientRepository.GetById(id);
                if (client != null)
                {
                    var viewModel = new ClientViewModel()
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Address = client.Address,
                        IsActive = client.IsActive
                    };

                    return viewModel;
                }

                throw new Exception("Record not found.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ClientViewModel clientViewModel)
        {
            try
            {
                if (clientViewModel != null)
                {
                    var client = new Client();
                    client.Name = clientViewModel.Name;
                    client.Address = clientViewModel.Address;
                    client.IsActive = clientViewModel.IsActive;
                    client.CreatedDate = DateTime.Now;

                    _clientRepository.Add(client);
                }
            }
            catch (Exception ex)
            {
            }

            return new ObjectResult("Client added successfully!");
        }


        // PUT: api/ClientAPI/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ClientViewModel clientViewModel)
        {
            try
            {
                if (id != clientViewModel.Id)
                {
                    return BadRequest();
                }

                var client = _clientRepository.GetById(id);
                if (client != null)
                {
                    client.Name = clientViewModel.Name;
                    client.Address = clientViewModel.Address;
                    client.IsActive = clientViewModel.IsActive;

                    _clientRepository.Update(client);
                }
            }
            catch (Exception ex)
            {
            }

            return new ObjectResult("Client modified successfully!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var client = _clientRepository.GetById(id);
                if (client != null)
                {
                    _clientRepository.Delete(client);
                }
            }
            catch (Exception ex)
            {
            }

            return new ObjectResult("Client deleted successfully!");
        }
    }
}
