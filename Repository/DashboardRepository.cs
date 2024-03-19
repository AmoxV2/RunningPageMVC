using Learning_MVC.Data;
using Learning_MVC.Interfaces;
using Learning_MVC.Models;

namespace Learning_MVC.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDB _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDB context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser=_httpContextAccessor.HttpContext?.User.GetUserId();
            var userClubs=  _context.Clubs.Where(r=> r.AppUser.Id ==curUser);
            return userClubs.ToList();
        }

        public async  Task<List<Race>> GetAllUserRaces()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userRaces = _context.Races.Where(r => r.AppUser.Id == curUser);
            return userRaces.ToList();
        }
    }
}
