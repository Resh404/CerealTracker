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
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
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

    [HttpGet("id/{cerealId:int}")]
    [ProducesResponseType(200, Type = typeof(Cereal))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByIdAsync(int cerealId)
    {
        try
        {
            var cereal = await _cerealRepository.GetCerealByIdAsync(cerealId);
            return Ok(cereal);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereal.");
        }
    }

    [HttpGet("name/{cerealName}")]
    [ProducesResponseType(200, Type = typeof(Cereal))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByNameAsync(string cerealName)
    {
        try
        {
            var cereal = await _cerealRepository.GetCerealByNameAsync(cerealName);
            return Ok(cereal);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereal.");
        }
    }

    [HttpGet("mfr/{cerealManufacturer}")]
    [ProducesResponseType(200, Type = typeof(Cereal))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByManufacturerAsync(string cerealManufacturer)
    {
        try
        {
            var cereal = await _cerealRepository.GetCerealByManufacturerAsync(cerealManufacturer);
            return Ok(cereal);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereal.");
        }
    }

    [HttpGet("type/{cerealType}")]
    [ProducesResponseType(200, Type = typeof(Cereal))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByTypeAsync(string cerealType)
    {
        try
        {
            var cereal = await _cerealRepository.GetCerealByTypeAsync(cerealType);
            return Ok(cereal);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereal.");
        }
    }

    [HttpGet("cal/{cerealCalories:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByCaloriesAsync(int cerealCalories)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByCaloriesAsync(cerealCalories);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("pro/{cerealProtein:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByProteinAsync(int cerealProtein)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByProteinAsync(cerealProtein);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("fat/{cerealFat:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByFatAsync(int cerealFat)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByFatAsync(cerealFat);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("salt/{cerealSodium:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealBySodiumAsync(int cerealSodium)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealBySodiumAsync(cerealSodium);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("fib/{cerealFiber:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByFiberAsync(float cerealFiber)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByFiberAsync(cerealFiber);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("carbo/{cerealCarbohydrates:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByCarbohydratesAsync(float cerealCarbohydrates)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByCarbohydratesAsync(cerealCarbohydrates);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("sugar{cerealSugars:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealBySugarsAsync(int cerealSugars)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealBySugarsAsync(cerealSugars);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("pota/{cerealPotassium:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByPotassiumAsync(int cerealPotassium)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByPotassiumAsync(cerealPotassium);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("vita/{cerealVitamins:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByVitaminsAsync(int cerealVitamins)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByVitaminsAsync(cerealVitamins);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("shelf/{cerealShelf:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByShelfAsync(int cerealShelf)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByShelfAsync(cerealShelf);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("weight/{cerealWeight:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByWeightAsync(float cerealWeight)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByWeightAsync(cerealWeight);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("cups/{cerealCups:int}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByCupsAsync(float cerealCups)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByCupsAsync(cerealCups);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

    [HttpGet("rating/{cerealRating}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Cereal>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCerealByRatingAsync(string cerealRating)
    {
        try
        {
            var cereals = await _cerealRepository.GetCerealByRatingAsync(cerealRating);
            return Ok(cereals);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cereals.");
        }
    }

}