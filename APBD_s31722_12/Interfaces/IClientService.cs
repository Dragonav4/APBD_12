using APBD_s31722_12.Models;
using APBD_s31722_12.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APBD_s31722_12.Interfaces;

public interface IClientService
{
    IActionResult Delete(int clientId);
    IActionResult assignClientToTrip(AssignClientToTripDto dto);
}