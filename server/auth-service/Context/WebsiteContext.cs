using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using server.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace server
{
    public class WebsiteContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteSite> VoteSites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Vote>()
            .HasKey(o => new { o.UserId, o.Site });

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(e => e.Id).HasColumnName("UserId");
                entity.Property(m => m.Email).HasMaxLength(255);
                entity.Property(m => m.UserName).HasMaxLength(255);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(255);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(255);
            });

            builder.Entity<IdentityRole<Guid>>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.Property(m => m.Name).HasMaxLength(255);
                entity.Property(m => m.NormalizedName).HasMaxLength(255);
            });
            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.Property(m => m.Id).HasMaxLength(255);
                entity.Property(m => m.Name).HasMaxLength(255);
                entity.Property(m => m.NormalizedName).HasMaxLength(255);
            });
            builder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.Property(m => m.LoginProvider).HasMaxLength(255);
                entity.Property(m => m.ProviderKey).HasMaxLength(255);
            });
            builder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserToken");
                entity.Property(m => m.UserId).HasMaxLength(255);
                entity.Property(m => m.LoginProvider).HasMaxLength(255);
                entity.Property(m => m.Name).HasMaxLength(255);
            });
            builder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaim");
            });
        }
    }
}
    