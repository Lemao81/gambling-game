using GamblingGame.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamblingGame.Repo.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.PasswordHash).HasMaxLength(256).IsRequired();

            builder.HasOne(u => u.Account).WithOne(a => a.User).HasForeignKey<Account>(u => u.UserId);
        }
    }
}
