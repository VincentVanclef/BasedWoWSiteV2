using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server.Data.Website;

namespace server.Context
{
    public class WebsiteContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteSite> VoteSites { get; set; }
        public virtual DbSet<UnstuckLocation> UnstuckLocations { get; set; }
        public virtual DbSet<Changelog> Changelogs { get; set; }
        public virtual DbSet<ChangelogCategory> ChangelogCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Vote>()
            .HasKey(o => new { o.UserId, o.Site, o.UnsetTimer });

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

            builder.Entity<UnstuckLocation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("unstuck_locations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RealmId)
                    .HasColumnName("realmId")
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text unsigned")
                    .HasDefaultValueSql("Unknown");
            });

            builder.Entity<Changelog>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("changelog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Realm)
                    .HasColumnName("realm")
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category")
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("text")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("0");
            });

            builder.Entity<ChangelogCategory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("changelog_categories");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("text")
                    .HasDefaultValueSql("title");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("text")
                    .HasDefaultValueSql("ffffff");
            });
        }
    }
}
    