

using Microsoft.EntityFrameworkCore;
using Portfolio_API.Models;

namespace Portfolio_API.Data
{
    public class porfolioContext : DbContext
    {
        public porfolioContext(DbContextOptions<porfolioContext> options) : base(options) 
        { 
        }

        public DbSet<SignUp> signUp { get; set; }
    }
}
