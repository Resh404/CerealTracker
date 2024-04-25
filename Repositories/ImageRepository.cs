using CerealAPI.Data;
using CerealAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CerealAPI.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly DataContext _dataContext;

    public ImageRepository(DataContext context)
    {
        _dataContext = context;
    }
    public async Task<string> GetImageFileBase64ByIdAsync(int cerealId)
    {
        var image = await _dataContext.Images.FirstOrDefaultAsync(i => i.CerealId == cerealId);
        return image.ImageBase64String; // Return the file path of the image, or null if no image is found
    }

}