using CerealAPI.Models;

namespace CerealAPI.Interfaces;

public interface ICerealRepository
{
    Task<ICollection<Cereal>> GetCerealsAsync();
}