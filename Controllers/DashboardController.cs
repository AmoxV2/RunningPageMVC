using Learning_MVC.Data;
using Learning_MVC.Interfaces;
using Learning_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Learning_MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository )
        {
            _dashboardRepository = dashboardRepository;
        }
        public  async Task<IActionResult> Index()
        {
           var userRaces=await _dashboardRepository.GetAllUserRaces();
           var userClubs=await _dashboardRepository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                Races = userRaces,
                Clubs = userClubs
            };
            return View(dashboardViewModel);
        }
    }
}
