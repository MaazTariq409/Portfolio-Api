

using Microsoft.EntityFrameworkCore;
using Portfolio_API.Models;

namespace Portfolio_API.Data
{
    public class porfolioContext : DbContext
    {
        public porfolioContext(DbContextOptions<porfolioContext> options) : base(options) 
        { 
        }

        //public DbSet<SignUp> signUp { get; set; }
        public DbSet<About> about { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Experience> experience { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<Skills> skills { get; set; }
        public DbSet<Resume> resume { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Users>()
            //    .HasOne(x => x.experience)
            //    .WithOne(x => x.users);

            //modelBuilder.Entity<Users>()
            //    .HasOne(x => x.projects)
            //    .WithOne(x => x.users);

            //modelBuilder.Entity<Users>()
            //    .HasOne(x => x.skills)
            //    .WithOne(x => x.users);
        }
    }
}
