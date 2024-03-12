using Learning_MVC.Data;
using Learning_MVC.Data.Interfaces;
using Learning_MVC.Models;
using Learning_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning_MVC.Controllers
{
    public class RaceController : Controller
    {
       
        private readonly IRaceRepository _raceRepository;

        public RaceController(ApplicationDB context, IRaceRepository raceRepository)
        {
           
            _raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }
        public async Task<IActionResult>  Detail(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }
    }
}
