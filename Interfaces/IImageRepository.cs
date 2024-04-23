namespace CerealAPI.Interfaces;

public interface IImageRepository
{
    Task<string> GetImageFilePathAsync(int cerealId);
}