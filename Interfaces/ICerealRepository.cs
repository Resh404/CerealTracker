using CerealAPI.Models;

namespace CerealAPI.Interfaces;

public interface ICerealRepository
{
    ICollection<Cereal> GetCereals();
}