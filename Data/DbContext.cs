

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
        public DbSet<About> about { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Experience> experience { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<Skills> skills { get; set; }
        public DbSet<Resume> resume { get; set; }
    }
}
