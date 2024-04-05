using CerealAPI.Interfaces;
using CerealAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CerealAPI.Controllers;


[Route("api/[controller]")] // api/cereals[]
[ApiController]
public class CerealController : Controller
{
    private readonly ICerealRepository _cerealRepository;

    public CerealController(ICerealRepository cerealRepository)
    {
        _cerealRepository = cerealRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Cereal>))]
    public async Task<IActionResult> GetCerealsAsync()
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealsAsync(); // Assuming GetCereals() is asynchronous

            return Ok(cereals);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as appropriate
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching cereals.");
        }
    }

}