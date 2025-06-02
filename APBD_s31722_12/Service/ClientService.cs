using APBD_s31722_12.Data;
using APBD_s31722_12.Interfaces;
using APBD_s31722_12.Models;
using APBD_s31722_12.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_s31722_12.Service;

public class ClientService : IClientService
{
    private MasterContext _context;

    public ClientService(MasterContext context)
    {
        _context = context;
    }

    public IActionResult Delete(int clientId)
    {
        var client = _context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefault(c => c.IdClient == clientId);
        
        if(client == null) return new NotFoundResult();
        if (client.ClientTrips != null && client.ClientTrips.Any())
            return new ObjectResult("Cannot delete client with assigned trips.")
            {
                StatusCode= 409
            };
        _context.Clients.Remove(client);
         _context.SaveChanges();
        return new NoContentResult();
    }

    public IActionResult assignClientToTrip(AssignClientToTripDto dto)
    {
        var client = _context.Clients.FirstOrDefault(c => c.Pesel == dto.Pesel);

        if (client == null)
        {
            client = new Client
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Telephone = dto.Telephone,
                Pesel = dto.Pesel
            };
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
        else
        {
            if (_context.Clients.Any(c => c.Pesel == dto.Pesel && c.IdClient != client.IdClient))
                return new ObjectResult("A client with this PESEL already exists.") { StatusCode = 409 };
        }

        var alreadyAssigned = _context.ClientTrips.Any(ct => ct.IdClient == client.IdClient && ct.IdTrip == dto.IdTrip);
        if (alreadyAssigned)
            return new ObjectResult("Client already registered for this trip.") { StatusCode = 409 };

        var trip = _context.Trips.FirstOrDefault(t => t.IdTrip == dto.IdTrip);
        if (trip == null)
            return new NotFoundObjectResult("Trip not found.");
        if (trip.DateFrom <= DateTime.Now)
            return new ObjectResult("Cannot register for a trip that has already occurred.") { StatusCode = 400 };

        var clientTrip = new ClientTrip
        {
            IdClient = client.IdClient,
            IdTrip = dto.IdTrip,
            RegisteredAt = DateTime.Now,
            PaymentDate = string.IsNullOrEmpty(dto.PaymentDate)
                ? null
                : DateTime.Parse(dto.PaymentDate)
        };

        _context.ClientTrips.Add(clientTrip);
        _context.SaveChanges();

        return new OkObjectResult("Client assigned to trip successfully.");
    }
}