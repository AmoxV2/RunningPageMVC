using Learning_MVC.Data;
using Learning_MVC.Data.Interfaces;
using Learning_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_MVC.Repository
{
    public class RaceRepository :IRaceRepository
    {
        private readonly ApplicationDB _context;
        public RaceRepository(ApplicationDB context)
        {
            _context = context;
        }

        public bool Add(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(c => c.Address.City.Contains(city)).ToArrayAsync();
        }

        public async  Task<Race> GetByIdAsync(int id)
        {
            return await _context.Races.Include(i => i.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            _context.Update(race);
            return Save();
        }
    }
}
