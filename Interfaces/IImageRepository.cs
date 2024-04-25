namespace CerealAPI.Interfaces;

public interface IImageRepository
{
    Task<string> GetImageFileBase64ByIdAsync(int cerealId);
}