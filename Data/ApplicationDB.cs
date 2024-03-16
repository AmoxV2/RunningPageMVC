using Learning_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Learning_MVC.Data
{
    public class ApplicationDB : IdentityDbContext<AppUser>
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {
            
        }

        public DbSet<Race> Races{ get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
