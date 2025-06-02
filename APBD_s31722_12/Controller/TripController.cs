using APBD_s31722_12.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBD_s31722_12.Controller;
[ApiController]
[Route("api/")]
public class TripController : ControllerBase
{
    private ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet("getTrips")]
    public async Task<IActionResult> GetTrips([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var trips = await _tripService.GetTrips(page, pageSize);
        return Ok(trips);
    }
}