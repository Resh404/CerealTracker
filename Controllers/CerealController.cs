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
    public IActionResult GetCereals()
    {
        var cereals =  _cerealRepository.GetCereals();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(cereals);
    }
}