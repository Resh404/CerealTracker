using CerealAPI.Dto;
using CerealAPI.Interfaces;
using CerealAPI.Mappers;
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
            var cereals = await _cerealRepository.GetCerealsAsync();
            var cerealDto = cereals.Select(c => c.ToCerealDto());

            return Ok(cerealDto);
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

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    public async Task<IActionResult> AddCerealAsync([FromBody] CerealDto cerealCreate)
    {
        if (cerealCreate == null)
            return BadRequest();

        var cereals = await _cerealRepository.GetCerealsAsync();
        var matchingCereal = cereals.FirstOrDefault(c =>
            string.Equals(c.Name.Trim(), cerealCreate.name.Trim(), StringComparison.OrdinalIgnoreCase));

        if (matchingCereal != null)
        {
            ModelState.AddModelError("", "A cereal with that name already exists.");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Convert CerealDto to Cereal entity before passing to repository
        var cereal = cerealCreate.ToCerealFromDto();

        // Add cereal to the repository
        var added = await _cerealRepository.AddCerealAsync(cereal);
        if (!added)
        {
            // Handle failure to add cereal to the repository
            return StatusCode(500, "Failed to add cereal.");
        }

        return NoContent(); // 204 status code
    }

    [HttpPut("update/{cerealId:int}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateCerealAsync(int cerealId, [FromBody] CerealDto cerealUpdate)
    {
        if (cerealUpdate == null)
            return BadRequest();

        var cereals = await _cerealRepository.GetCerealsAsync();
        var cerealToBeUpdated = cereals.FirstOrDefault(c => c.Id == cerealId);

        var matchingCereal = await _cerealRepository.CerealExistsAsync(cerealId);

        if (!matchingCereal)
        {
            ModelState.AddModelError("", "A cereal with that ID does not exist.");
            return NotFound();
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Convert CerealDto to Cereal entity before passing to repository
        var updatedCereal = new Cereal
        {
            Id = cerealId, // Make sure to assign the Id if it's not an init-only property
            Name = cerealUpdate.name,
            Manufacturer = cerealUpdate.manufacturer,
            Type = cerealUpdate.type,
            Calories = cerealUpdate.calories,
            Protein = cerealUpdate.protein,
            Fat = cerealUpdate.fat,
            Sodium = cerealUpdate.sodium,
            Fiber = cerealUpdate.fiber,
            Carbohydrates = cerealUpdate.carbohydrates,
            Sugars = cerealUpdate.sugars,
            Potassium = cerealUpdate.potassium,
            Vitamins = cerealUpdate.vitamins,
            Shelf = cerealUpdate.shelf,
            Weight = cerealUpdate.weight,
            Cups = cerealUpdate.cups,
            Rating = cerealUpdate.rating
        };

        // Update cereal in the repository
        var updated = await _cerealRepository.UpdateCerealAsync(updatedCereal);
        if (!updated)
        {
            // Handle failure to update cereal in the repository
            return StatusCode(500, "Failed to update cereal.");
        }

        return NoContent(); // 204 status code
    }

    [HttpDelete("delete/{cerealId:int}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteCerealAsync(int cerealId)
    {
        var matchingCereal = await _cerealRepository.CerealExistsAsync(cerealId);
        if (!matchingCereal)
        {
            ModelState.AddModelError("", "A cereal with that ID does not exist.");
            return NotFound();
        }

        var cerealToDelete = await _cerealRepository.GetCerealByIdAsync(cerealId);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var deleted = await _cerealRepository.DeleteCerealAsync(cerealToDelete);

        if (!deleted)
        {
            ModelState.AddModelError("", "Failed to delete cereal.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }
}