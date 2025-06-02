using APBD_s31722_12.Models;
using APBD_s31722_12.Models.DTO;

namespace APBD_s31722_12.Interfaces;

public interface ITripService
{
    Task<List<TripDto>> GetTrips(int page, int pageSize);
}