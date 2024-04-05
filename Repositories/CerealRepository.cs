using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CerealAPI.Repositories
{
    public class CerealRepository : ICerealRepository
    {
        private readonly DataContext _context;

        public CerealRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Cereal>> GetCerealsAsync()
        {
            return await _context.Cereals.OrderBy(p => p.Id).ToListAsync();
        }
    }
}