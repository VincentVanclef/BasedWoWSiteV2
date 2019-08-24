using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server.Data.Auth;
using server.Data.Website;

namespace server.Context
{
    public class WebsiteContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
                                  ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
                                  ApplicationRoleClaim, ApplicationUserToken>
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> options) : base(options)
        {
        }

        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteSite> VoteSites { get; set; }
        public virtual DbSet<UnstuckLocation> UnstuckLocations { get; set; }
        public virtual DbSet<Changelog> Changelogs { get; set; }
        public virtual DbSet<ChangelogCategory> ChangelogCategories { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> NewsComments { get; set; }
        public virtual DbSet<ShoutBox> ShoutBox { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(e => e.Id).HasColumnName("UserId");
                entity.Property(m => m.Email).HasMaxLength(255);
                entity.Property(m => m.UserName).HasMaxLength(255);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(255);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(255);

                //// Each User can have many UserLogins
                //entity.HasMany(e => e.Logins)
                //    .WithOne(e => e.User)
                //    .HasForeignKey(ul => ul.UserId)
                //    .IsRequired();

                //// Each User can have many UserTokens
                //entity.HasMany(e => e.Tokens)
                //    .WithOne(e => e.User)
                //    .HasForeignKey(ut => ut.UserId)
                //    .IsRequired();

                // Each User can have many entries in the UserRole join table
                entity.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable("Roles");
                entity.Property(m => m.Id).HasMaxLength(255);
                entity.Property(m => m.Name).HasMaxLength(255);
                entity.Property(m => m.NormalizedName).HasMaxLength(255);

                // Each Role can have many entries in the UserRole join table
                entity.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                //// Each Role can have many associated RoleClaims
                //entity.HasMany(e => e.RoleClaims)
                //    .WithOne(e => e.Role)
                //    .HasForeignKey(rc => rc.RoleId)
                //    .IsRequired();
            });

            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("UserRoles");

                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            builder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.Property(m => m.LoginProvider).HasMaxLength(255);
                entity.Property(m => m.ProviderKey).HasMaxLength(255);
            });

            builder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("UserToken");
                entity.Property(m => m.UserId).HasMaxLength(255);
                entity.Property(m => m.LoginProvider).HasMaxLength(255);
                entity.Property(m => m.Name).HasMaxLength(255);
            });

            builder.Entity<ApplicationRoleClaim>(entity =>
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
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
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

            builder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("news");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("text")
                    .HasDefaultValueSql("title");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasDefaultValueSql("title");

                entity.Property(e => e.Author)
                    .HasColumnName("author");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("text")
                    .HasDefaultValueSql("https://avatarfiles.alphacoders.com/151/151182.jpg");
            });

            builder.Entity<NewsComment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("news_comments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.NewsId)
                    .HasColumnName("newsId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Author)
                    .HasColumnName("userId");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("text")
                    .HasDefaultValueSql("no comment");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("lastEdited")
                    .HasColumnType("datetime");
            });

            builder.Entity<ShoutBox>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("shoutbox");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.User)
                    .HasColumnName("user");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            builder.Entity<Vote>()
                .HasKey(o => new { o.UserId, o.Site, o.UnsetTimer });
        }
    }
}
