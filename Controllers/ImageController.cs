using CerealAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CerealAPI.Controllers;

[Route("api/image")] // api/cereals[]
[ApiController]

public class ImageController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImageController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    [HttpGet]
    [Route("{cerealId:int}")]
    public async Task<IActionResult> GetImageById([FromRoute] int cerealId)
    {
        try
        {
            var imagePath = await _imageRepository.GetImageFilePathAsync(cerealId);
            return Ok(imagePath);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as appropriate
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching cereals.");
        }
    }
}