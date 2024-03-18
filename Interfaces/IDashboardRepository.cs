using Learning_MVC.Models;

namespace Learning_MVC.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Race>> GetAllUserRaces();

        Task<List<Club>> GetAllUserClubs();
    }
}
