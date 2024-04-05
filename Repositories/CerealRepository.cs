using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Models;

namespace CerealAPI.Repositories;

public class CerealRepository : ICerealRepository
{
    private readonly DataContext _context;

    public CerealRepository(DataContext context)
    {
        _context = context;

    }

    public ICollection<Cereal> GetCereals()
    {
        return _context.Cereals.OrderBy(p => p.Id).ToList();
    }
}