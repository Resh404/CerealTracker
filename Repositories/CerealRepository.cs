using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Models;
using Microsoft.EntityFrameworkCore;


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
            return await _context.Cereals.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Cereal> GetCerealByIdAsync(int id)
        {
            return await _context.Cereals.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Cereal> GetCerealByNameAsync(string name)
        {
            return await _context.Cereals.Where(c => c.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Cereal> GetCerealByManufacturerAsync(string manufacturer)
        {
            return await _context.Cereals.Where(c => c.Manufacturer == manufacturer).FirstOrDefaultAsync();
        }

        public async Task<Cereal> GetCerealByTypeAsync(string type)
        {
            return await _context.Cereals.Where(c => c.Type == type).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByCaloriesAsync(int calories)
        {
            return await _context.Cereals.Where(c => c.Calories == calories).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByProteinAsync(int protein)
        {
            return await _context.Cereals.Where(c => c.Protein == protein).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByFatAsync(int fat)
        {
            return await _context.Cereals.Where(c => c.Fat == fat).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealBySodiumAsync(int sodium)
        {
            return await _context.Cereals.Where(c => c.Sodium == sodium).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByFiberAsync(float fiber)
        {
            return await _context.Cereals.Where(c => c.Fiber == fiber).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByCarbohydratesAsync(float carbohydrates)
        {
            return await _context.Cereals.Where(c => c.Carbohydrates == carbohydrates).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealBySugarsAsync(int sugars)
        {
            return await _context.Cereals.Where(c => c.Sugars == sugars).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByPotassiumAsync(int potassium)
        {
            return await _context.Cereals.Where(c => c.Potassium == potassium).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByVitaminsAsync(int vitamins)
        {
            return await _context.Cereals.Where(c => c.Vitamins == vitamins).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByShelfAsync(int shelf)
        {
            return await _context.Cereals.Where(c => c.Shelf == shelf).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByWeightAsync(float weight)
        {
            return await _context.Cereals.Where(c => c.Weight == weight).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByCupsAsync(float cups)
        {
            return await _context.Cereals.Where(c => c.Cups == cups).ToListAsync();
        }

        public async Task<ICollection<Cereal>> GetCerealByRatingAsync(string rating)
        {
            return await _context.Cereals.Where(c => c.Rating == rating).ToListAsync();
        }
    }
}