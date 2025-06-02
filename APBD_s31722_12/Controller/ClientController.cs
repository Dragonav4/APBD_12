using APBD_s31722_12.Interfaces;
using APBD_s31722_12.Models.DTO;
using APBD_s31722_12.Service;
using Microsoft.AspNetCore.Mvc;

namespace APBD_s31722_12.Controller;

[ApiController]
[Route("api/")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("clients/{idClient}")]
    public Task<IActionResult> DeleteClient([FromRoute] int idClient)
    {
        return Task.FromResult(_clientService.Delete(idClient)); 
    }

    [HttpPost("trips/{idTrip}/clients")]
    public async Task<IActionResult> AddTrip([FromBody]AssignClientToTripDto dto)
    {
        return _clientService.assignClientToTrip(dto);
    }
}