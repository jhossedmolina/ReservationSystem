using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationSystemBackend.Core.DTOs;
using ReservationSystemBackend.Core.Entities;
using ReservationSystemBackend.Core.Interfaces;

namespace ReservationSystemBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;

        public ClientController(IMapper mapper, IClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
        {
            var clients = _clientService.GetAllClients();
            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
            return Ok(clientsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClientById(int id)
        {
            var client = await _clientService.GetClientById(id);
            var clientDto = _mapper.Map<ClientDto>(client);

            if (clientDto is null)
                return NotFound();

            return Ok(clientDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientService.CreateClient(client);
            clientDto = _mapper.Map<ClientDto>(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, clientDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateClient(int id, ClientDto clientDto)
        {
            var currentClient = await _clientService.GetClientById(id);
            if (currentClient is null)
                return NotFound();

            var result = await _clientService.UpdateClient(currentClient);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientById(int id)
        {
            var currentClient = await _clientService.GetClientById(id);
            if (currentClient is null)
                return NotFound();

            var result = await _clientService.DeleteClientById(id);
            return NoContent();
        }
    }
}
