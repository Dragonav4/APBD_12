using APBD_s31722_12.Data;
using APBD_s31722_12.Exceptions;
using APBD_s31722_12.Interfaces;
using APBD_s31722_12.Models;
using APBD_s31722_12.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace APBD_s31722_12.Service;

public class TripService : ITripService
{
    private MasterContext _masterContext;

    public TripService(MasterContext masterContext)
    {
        _masterContext = masterContext;
    }

    public async Task<TripResponseDto> GetTrips(int page = 1, int pageSize = 10)
    {
        var trips = await _masterContext.Trips
            .OrderBy(t => t.DateFrom)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(t => new TripDto
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom.ToString("yyyy/MM/dd"),
                DateTo = t.DateTo.ToString("yyyy/MM/dd"),
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries.Select(ct => new CountryDto()
                {
                    Name = ct.Name,
                }).ToList(),
                Clients = t.ClientTrips.Select(c => new ClientDto()
                {
                    FirstName = c.IdClientNavigation.FirstName,
                    LastName = c.IdClientNavigation.LastName,
                }).ToList()
            }).ToListAsync();
        return new TripResponseDto()
        {
            PageNum = page.ToString(),
            PageSize = pageSize,
            AllPages = (int)Math.Ceiling((double)trips.Count / pageSize),
            Trips = trips
        };
    }

    public async Task<TripDto> GetTrip(int tripId)
    {
        var trip = await _masterContext.Trips
            .Where(t => t.IdTrip == tripId)
            .Select(t => new TripDto
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom.ToString("yyyy/MM/dd"),
                DateTo = t.DateTo.ToString("yyyy/MM/dd"),
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries.Select(ct => new CountryDto()
                {
                    Name = ct.Name,
                }).ToList(),
                Clients = t.ClientTrips.Select(c => new ClientDto()
                {
                    FirstName = c.IdClientNavigation.FirstName,
                    LastName = c.IdClientNavigation.LastName,
                }).ToList()

            }).FirstOrDefaultAsync();
        return trip;
    }
}