﻿using Learning_MVC.Data;
using Learning_MVC.Data.Interfaces;
using Learning_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Learning_MVC.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDB _context;
        public ClubRepository(Data.ApplicationDB context)
        {
            _context=context;
        }
        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
           
            _context.Remove(club);
            return Save();
        }

        public async  Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(i => i.Address).FirstOrDefaultAsync(c => c.Id == id);
        } 


        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(c => c.Address.City.Contains(city)).ToArrayAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); 
            return saved > 0? true : false ;
        }

        public bool Update(Club club)
        {
            _context.Update(club);
            return Save();
        }
    }
}