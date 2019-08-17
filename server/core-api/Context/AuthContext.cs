using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server.Data.Auth;

namespace server.Context
{
    public partial class AuthContext : DbContext
    {
        public AuthContext()
        {
        }

        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountAccess> AccountAccess { get; set; }
        public virtual DbSet<AccountBanned> AccountBanned { get; set; }
        public virtual DbSet<AccountData> AccountData { get; set; }
        public virtual DbSet<AccountMuted> AccountMuted { get; set; }
        public virtual DbSet<AccountPremium> AccountPremium { get; set; }
        public virtual DbSet<Autobroadcast> Autobroadcast { get; set; }
        public virtual DbSet<IpBanned> IpBanned { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<LogsIpActions> LogsIpActions { get; set; }
        public virtual DbSet<RbacAccountPermissions> RbacAccountPermissions { get; set; }
        public virtual DbSet<RbacDefaultPermissions> RbacDefaultPermissions { get; set; }
        public virtual DbSet<RbacLinkedPermissions> RbacLinkedPermissions { get; set; }
        public virtual DbSet<RbacLinkedPermissionsOld> RbacLinkedPermissionsOld { get; set; }
        public virtual DbSet<RbacPermissions> RbacPermissions { get; set; }
        public virtual DbSet<RbacPermissionsOld> RbacPermissionsOld { get; set; }
        public virtual DbSet<Realmcharacters> Realmcharacters { get; set; }
        public virtual DbSet<Realmlist> Realmlist { get; set; }
        public virtual DbSet<Updates> Updates { get; set; }
        public virtual DbSet<UpdatesInclude> UpdatesInclude { get; set; }
        public virtual DbSet<Uptime> Uptime { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.Username)
                    .HasName("idx_username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FailedLogins)
                    .HasColumnName("failed_logins")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Joindate)
                    .HasColumnName("joindate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.LastAttemptIp)
                    .IsRequired()
                    .HasColumnName("last_attempt_ip")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.LastIp)
                    .IsRequired()
                    .HasColumnName("last_ip")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasDefaultValueSql("1970-01-01 00:00:01");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LockCountry)
                    .IsRequired()
                    .HasColumnName("lock_country")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("00");

                entity.Property(e => e.Locked)
                    .HasColumnName("locked")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Muteby)
                    .IsRequired()
                    .HasColumnName("muteby")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("null")
                    .IsUnicode(false);

                entity.Property(e => e.Mutereason)
                    .IsRequired()
                    .HasColumnName("mutereason")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("null")
                    .IsUnicode(false);

                entity.Property(e => e.Mutetime)
                    .HasColumnName("mutetime")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasColumnName("os")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("Win")
                    .IsUnicode(false);

                entity.Property(e => e.Recruiter)
                    .HasColumnName("recruiter")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RegMail)
                    .IsRequired()
                    .HasColumnName("reg_mail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShaPassHash)
                    .IsRequired()
                    .HasColumnName("sha_pass_hash")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.V)
                    .HasColumnName("V")
                    .HasDefaultValueSql("null")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.S)
                    .HasColumnName("V")
                    .HasDefaultValueSql("null")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShaPassHash)
                    .IsRequired()
                    .HasColumnName("sha_pass_hash")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccountAccess>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RealmId });

                entity.ToTable("account_access");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RealmId)
                    .HasColumnName("RealmID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Gmlevel)
                    .HasColumnName("gmlevel")
                    .HasColumnType("tinyint(3) unsigned");
            });

            modelBuilder.Entity<AccountBanned>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Bandate });

                entity.ToTable("account_banned");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bandate)
                    .HasColumnName("bandate")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Bannedby)
                    .IsRequired()
                    .HasColumnName("bannedby")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Banreason)
                    .IsRequired()
                    .HasColumnName("banreason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unbandate)
                    .HasColumnName("unbandate")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AccountData>(entity =>
            {
                entity.ToTable("account_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dp)
                    .HasColumnName("dp")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExtraMask)
                    .HasColumnType("int(11) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Vp)
                    .HasColumnName("vp")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AccountMuted>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Mutedate });

                entity.ToTable("account_muted");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mutedate)
                    .HasColumnName("mutedate")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mutedby)
                    .IsRequired()
                    .HasColumnName("mutedby")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mutereason)
                    .IsRequired()
                    .HasColumnName("mutereason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mutetime)
                    .HasColumnName("mutetime")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AccountPremium>(entity =>
            {
                entity.HasKey(e => e.Account);

                entity.ToTable("account_premium");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Autobroadcast>(entity =>
            {
                entity.HasKey(e => new { e.Realmid, e.Id });

                entity.ToTable("autobroadcast");

                entity.Property(e => e.Realmid)
                    .HasColumnName("realmid")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("longtext");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<IpBanned>(entity =>
            {
                entity.HasKey(e => new { e.Ip, e.Bandate });

                entity.ToTable("ip_banned");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.Bandate)
                    .HasColumnName("bandate")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Bannedby)
                    .IsRequired()
                    .HasColumnName("bannedby")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("[Console]");

                entity.Property(e => e.Banreason)
                    .IsRequired()
                    .HasColumnName("banreason")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("no reason");

                entity.Property(e => e.Unbandate)
                    .HasColumnName("unbandate")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Realm)
                    .HasColumnName("realm")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.String)
                    .HasColumnName("string")
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogsIpActions>(entity =>
            {
                entity.ToTable("logs_ip_actions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CharacterGuid)
                    .HasColumnName("character_guid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.Systemnote)
                    .HasColumnName("systemnote")
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.Unixtime)
                    .HasColumnName("unixtime")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<RbacAccountPermissions>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.PermissionId, e.RealmId });

                entity.ToTable("rbac_account_permissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("fk__rbac_account_roles__rbac_permissions");

                entity.Property(e => e.AccountId)
                    .HasColumnName("accountId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permissionId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RealmId)
                    .HasColumnName("realmId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Granted)
                    .HasColumnName("granted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RbacAccountPermissions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("fk__rbac_account_permissions__account");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RbacAccountPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("fk__rbac_account_roles__rbac_permissions");
            });

            modelBuilder.Entity<RbacDefaultPermissions>(entity =>
            {
                entity.HasKey(e => new { e.SecId, e.PermissionId, e.RealmId });

                entity.ToTable("rbac_default_permissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("fk__rbac_default_permissions__rbac_permissions");

                entity.Property(e => e.SecId)
                    .HasColumnName("secId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permissionId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RealmId)
                    .HasColumnName("realmId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("-1");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RbacDefaultPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__rbac_default_permissions__rbac_permissions");
            });

            modelBuilder.Entity<RbacLinkedPermissions>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.LinkedId });

                entity.ToTable("rbac_linked_permissions");

                entity.HasIndex(e => e.Id)
                    .HasName("fk__rbac_linked_permissions__rbac_permissions1");

                entity.HasIndex(e => e.LinkedId)
                    .HasName("fk__rbac_linked_permissions__rbac_permissions2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.LinkedId)
                    .HasColumnName("linkedId")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.RbacLinkedPermissionsIdNavigation)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("fk__rbac_linked_permissions__rbac_permissions1");

                entity.HasOne(d => d.Linked)
                    .WithMany(p => p.RbacLinkedPermissionsLinked)
                    .HasForeignKey(d => d.LinkedId)
                    .HasConstraintName("fk__rbac_linked_permissions__rbac_permissions2");
            });

            modelBuilder.Entity<RbacLinkedPermissionsOld>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.LinkedId });

                entity.ToTable("rbac_linked_permissions_old");

                entity.HasIndex(e => e.Id)
                    .HasName("fk__rbac_linked_permissions__rbac_permissions1");

                entity.HasIndex(e => e.LinkedId)
                    .HasName("fk__rbac_linked_permissions__rbac_permissions2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.LinkedId)
                    .HasColumnName("linkedId")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.RbacLinkedPermissionsOldIdNavigation)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("rbac_linked_permissions_old_ibfk_1");

                entity.HasOne(d => d.Linked)
                    .WithMany(p => p.RbacLinkedPermissionsOldLinked)
                    .HasForeignKey(d => d.LinkedId)
                    .HasConstraintName("rbac_linked_permissions_old_ibfk_2");
            });

            modelBuilder.Entity<RbacPermissions>(entity =>
            {
                entity.ToTable("rbac_permissions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RbacPermissionsOld>(entity =>
            {
                entity.ToTable("rbac_permissions_old");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Realmcharacters>(entity =>
            {
                entity.HasKey(e => new { e.Realmid, e.Acctid });

                entity.ToTable("realmcharacters");

                entity.HasIndex(e => e.Acctid)
                    .HasName("acctid");

                entity.Property(e => e.Realmid)
                    .HasColumnName("realmid")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Acctid)
                    .HasColumnName("acctid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Numchars)
                    .HasColumnName("numchars")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Realmlist>(entity =>
            {
                entity.ToTable("realmlist");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.AllowedSecurityLevel)
                    .HasColumnName("allowedSecurityLevel")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.Gamebuild)
                    .HasColumnName("gamebuild")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("12340");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LocalAddress)
                    .IsRequired()
                    .HasColumnName("localAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.LocalSubnetMask)
                    .IsRequired()
                    .HasColumnName("localSubnetMask")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("255.255.255.0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Population)
                    .HasColumnName("population")
                    .HasColumnType("float unsigned");

                entity.Property(e => e.Port)
                    .HasColumnName("port")
                    .HasColumnType("smallint(5) unsigned")
                    .HasDefaultValueSql("8085");

                entity.Property(e => e.Timezone)
                    .HasColumnName("timezone")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Updates>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("updates");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasColumnType("char(40)");

                entity.Property(e => e.Speed)
                    .HasColumnName("speed")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('RELEASED','ARCHIVED')")
                    .HasDefaultValueSql("RELEASED");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UpdatesInclude>(entity =>
            {
                entity.HasKey(e => e.Path);

                entity.ToTable("updates_include");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('RELEASED','ARCHIVED')")
                    .HasDefaultValueSql("RELEASED");
            });

            modelBuilder.Entity<Uptime>(entity =>
            {
                entity.HasKey(e => new { e.Realmid, e.Starttime });

                entity.ToTable("uptime");

                entity.Property(e => e.Realmid)
                    .HasColumnName("realmid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Maxplayers)
                    .HasColumnName("maxplayers")
                    .HasColumnType("smallint(5) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnName("revision")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("Trinitycore");

                entity.Property(e => e.Uptime1)
                    .HasColumnName("uptime")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");
            });
        }
    }
}
