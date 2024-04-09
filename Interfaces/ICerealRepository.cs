using CerealAPI.Dto;
using CerealAPI.Models;

namespace CerealAPI.Interfaces;

public interface ICerealRepository
{
    Task<ICollection<Cereal>> GetCerealsAsync();
    Task<Cereal> GetCerealByIdAsync(int id);
    Task<Cereal> GetCerealByNameAsync(string name);
    Task<Cereal> GetCerealByManufacturerAsync(string manufacturer);
    Task<Cereal> GetCerealByTypeAsync(string type);
    Task<ICollection<Cereal>> GetCerealByCaloriesAsync(int calories);
    Task<ICollection<Cereal>> GetCerealByProteinAsync(int protein);
    Task<ICollection<Cereal>> GetCerealByFatAsync(int fat);
    Task<ICollection<Cereal>> GetCerealBySodiumAsync(int sodium);
    Task<ICollection<Cereal>> GetCerealByFiberAsync(float fiber);
    Task<ICollection<Cereal>> GetCerealByCarbohydratesAsync(float carbohydrates);
    Task<ICollection<Cereal>> GetCerealBySugarsAsync(int sugars);
    Task<ICollection<Cereal>> GetCerealByPotassiumAsync(int potassium);
    Task<ICollection<Cereal>> GetCerealByVitaminsAsync(int vitamins);
    Task<ICollection<Cereal>> GetCerealByShelfAsync(int shelf);
    Task<ICollection<Cereal>> GetCerealByWeightAsync(float weight);
    Task<ICollection<Cereal>> GetCerealByCupsAsync(float cups);
    Task<ICollection<Cereal>> GetCerealByRatingAsync(string rating);
    Task<bool> AddCerealAsync(Cereal cereal);
    Task<bool> CerealExistsAsync(int cerealId);
    Task<bool> UpdateCerealAsync(Cereal updatedCereal);
    Task<bool> DeleteCerealAsync(int cerealId);
    Task<bool> SaveChangesAsync();
}