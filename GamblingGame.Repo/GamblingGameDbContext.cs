using GamblingGame.Domain.Models;
using GamblingGame.Repo.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GamblingGame.Repo
{
    public class GamblingGameDbContext : DbContext
    {
        public GamblingGameDbContext(DbContextOptions<GamblingGameDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}
