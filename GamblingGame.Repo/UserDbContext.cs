using GamblingGame.Domain.Models;
using GamblingGame.Repo.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GamblingGame.Repo
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
