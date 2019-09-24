using Microsoft.EntityFrameworkCore;
using server.Data.Characters;

namespace server.Context
{
    public abstract class CharacterContext : DbContext
    {
        protected CharacterContext(DbContextOptions options)
            : base(options)
        {
        }
        
        public virtual DbSet<AccountData> AccountData { get; set; }
        public virtual DbSet<AccountInstanceTimes> AccountInstanceTimes { get; set; }
        public virtual DbSet<AccountTutorial> AccountTutorials { get; set; }
        public virtual DbSet<Addon> Addons { get; set; }
        public virtual DbSet<ArenaTeam> ArenaTeam { get; set; }
        public virtual DbSet<ArenaTeamMember> ArenaTeamMember { get; set; }
        public virtual DbSet<Auctionbidders> AuctionBidders { get; set; }
        public virtual DbSet<Auctionhouse> AuctionHouses { get; set; }
        public virtual DbSet<BannedAddons> BannedAddons { get; set; }
        public virtual DbSet<BattlegroundDeserters> BattlegroundDeserters { get; set; }
        public virtual DbSet<Bounties> Bounties { get; set; }
        public virtual DbSet<Bugreport> Bugreport { get; set; }
        public virtual DbSet<CalendarEvents> CalendarEvents { get; set; }
        public virtual DbSet<CalendarInvites> CalendarInvites { get; set; }
        public virtual DbSet<Channels> Channels { get; set; }
        public virtual DbSet<CharacterAccountData> CharacterAccountData { get; set; }
        public virtual DbSet<CharacterAchievement> CharacterAchievement { get; set; }
        public virtual DbSet<CharacterAchievementProgress> CharacterAchievementProgress { get; set; }
        public virtual DbSet<CharacterAction> CharacterAction { get; set; }
        public virtual DbSet<CharacterArenaStats> CharacterArenaStats { get; set; }
        public virtual DbSet<CharacterAura> CharacterAura { get; set; }
        public virtual DbSet<CharacterBanned> CharacterBanned { get; set; }
        public virtual DbSet<CharacterBattlegroundData> CharacterBattlegroundData { get; set; }
        public virtual DbSet<CharacterBattlegroundRandom> CharacterBattlegroundRandom { get; set; }
        public virtual DbSet<CharacterBoost> CharacterBoost { get; set; }
        public virtual DbSet<CharacterCurrencies> CharacterCurrencies { get; set; }
        public virtual DbSet<CharacterDeclinedname> CharacterDeclinedname { get; set; }
        public virtual DbSet<CharacterEquipmentsets> CharacterEquipmentsets { get; set; }
        public virtual DbSet<CharacterFishingsteps> CharacterFishingsteps { get; set; }
        public virtual DbSet<CharacterGifts> CharacterGifts { get; set; }
        public virtual DbSet<CharacterGlyphs> CharacterGlyphs { get; set; }
        public virtual DbSet<CharacterGuildXpGiven> CharacterGuildXpGiven { get; set; }
        public virtual DbSet<CharacterHomebind> CharacterHomebind { get; set; }
        public virtual DbSet<CharacterInstance> CharacterInstance { get; set; }
        public virtual DbSet<CharacterInventory> CharacterInventory { get; set; }
        public virtual DbSet<CharacterPet> CharacterPet { get; set; }
        public virtual DbSet<CharacterPetDeclinedname> CharacterPetDeclinedname { get; set; }
        public virtual DbSet<CharacterQueststatus> CharacterQueststatus { get; set; }
        public virtual DbSet<CharacterQueststatusDaily> CharacterQueststatusDaily { get; set; }
        public virtual DbSet<CharacterQueststatusMonthly> CharacterQueststatusMonthly { get; set; }
        public virtual DbSet<CharacterQueststatusRewarded> CharacterQueststatusRewarded { get; set; }
        public virtual DbSet<CharacterQueststatusSeasonal> CharacterQueststatusSeasonal { get; set; }
        public virtual DbSet<CharacterQueststatusWeekly> CharacterQueststatusWeekly { get; set; }
        public virtual DbSet<CharacterReputation> CharacterReputation { get; set; }
        public virtual DbSet<CharacterSkills> CharacterSkills { get; set; }
        public virtual DbSet<CharacterSocial> CharacterSocial { get; set; }
        public virtual DbSet<CharacterSpell> CharacterSpell { get; set; }
        public virtual DbSet<CharacterSpellCooldown> CharacterSpellCooldown { get; set; }
        public virtual DbSet<CharacterStats> CharacterStats { get; set; }
        public virtual DbSet<CharacterTalent> CharacterTalent { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Corpse> Corpse { get; set; }
        public virtual DbSet<CustomItemUpgradeSets> CustomItemUpgradeSets { get; set; }
        public virtual DbSet<CustomItemUpgrades> CustomItemUpgrades { get; set; }
        public virtual DbSet<CustomTransmogrification> CustomTransmogrification { get; set; }
        public virtual DbSet<CustomTransmogrificationSets> CustomTransmogrificationSets { get; set; }
        public virtual DbSet<GameEventConditionSave> GameEventConditionSave { get; set; }
        public virtual DbSet<GameEventSave> GameEventSave { get; set; }
        public virtual DbSet<GmSubsurvey> GmSubsurvey { get; set; }
        public virtual DbSet<GmSurvey> GmSurvey { get; set; }
        public virtual DbSet<GmTicket> GmTicket { get; set; }
        public virtual DbSet<GroupInstance> GroupInstance { get; set; }
        public virtual DbSet<GroupMember> GroupMember { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Guild> Guilds { get; set; }
        public virtual DbSet<GuildBankEventLog> GuildBankEventLogs { get; set; }
        public virtual DbSet<GuildBankItem> GuildBankItems { get; set; }
        public virtual DbSet<GuildBankRight> GuildBankRight { get; set; }
        public virtual DbSet<GuildBankTab> GuildBankTabs { get; set; }
        public virtual DbSet<GuildEventLog> GuildEventLogs { get; set; }
        public virtual DbSet<GuildMember> GuildMembers { get; set; }
        public virtual DbSet<GuildMemberWithdraw> GuildMemberWithdraw { get; set; }
        public virtual DbSet<GuildRank> GuildRank { get; set; }
        public virtual DbSet<Instance> Instance { get; set; }
        public virtual DbSet<InstanceReset> InstanceReset { get; set; }
        public virtual DbSet<ItemInstance> ItemInstance { get; set; }
        public virtual DbSet<ItemLootItems> ItemLootItems { get; set; }
        public virtual DbSet<ItemLootMoney> ItemLootMoney { get; set; }
        public virtual DbSet<ItemRefundInstance> ItemRefundInstance { get; set; }
        public virtual DbSet<ItemSoulboundTradeData> ItemSoulboundTradeData { get; set; }
        public virtual DbSet<LagReports> LagReports { get; set; }
        public virtual DbSet<LfgData> LfgData { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<MailItems> MailItems { get; set; }
        public virtual DbSet<NpcVendorRestock> NpcVendorRestock { get; set; }
        public virtual DbSet<PetAura> PetAura { get; set; }
        public virtual DbSet<PetSpell> PetSpell { get; set; }
        public virtual DbSet<PetSpellCooldown> PetSpellCooldown { get; set; }
        public virtual DbSet<Petition> Petition { get; set; }
        public virtual DbSet<PetitionSign> PetitionSign { get; set; }
        public virtual DbSet<PoolQuestSave> PoolQuestSave { get; set; }
        public virtual DbSet<PvpstatsBattlegrounds> PvpstatsBattlegrounds { get; set; }
        public virtual DbSet<PvpstatsPlayers> PvpstatsPlayers { get; set; }
        public virtual DbSet<QuestTracker> QuestTracker { get; set; }
        public virtual DbSet<RaceEvent> RaceEvent { get; set; }
        public virtual DbSet<ReservedName> ReservedName { get; set; }
        public virtual DbSet<Respawn> Respawn { get; set; }
        public virtual DbSet<Shootemup> Shootemup { get; set; }
        public virtual DbSet<Updates> Updates { get; set; }
        public virtual DbSet<UpdatesInclude> UpdatesInclude { get; set; }
        public virtual DbSet<WardenAction> WardenAction { get; set; }
        public virtual DbSet<Worldstates> Worldstates { get; set; }
        public virtual DbSet<ZombieEvent> ZombieEvent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AccountData>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.Type });

                entity.ToTable("account_data");

                entity.Property(e => e.AccountId)
                    .HasColumnName("accountId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("blob");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AccountInstanceTimes>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.InstanceId });

                entity.ToTable("account_instance_times");

                entity.Property(e => e.AccountId)
                    .HasColumnName("accountId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.InstanceId)
                    .HasColumnName("instanceId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReleaseTime)
                    .HasColumnName("releaseTime")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AccountTutorial>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("account_tutorial");

                entity.Property(e => e.AccountId)
                    .HasColumnName("accountId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tut0)
                    .HasColumnName("tut0")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tut1)
                    .HasColumnName("tut1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tut2)
                    .HasColumnName("tut2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tut3)
                    .HasColumnName("tut3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tut4)
                    .HasColumnName("tut4")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tut5)
                    .HasColumnName("tut5")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tut6)
                    .HasColumnName("tut6")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tut7)
                    .HasColumnName("tut7")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Addon>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("addons");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Crc)
                    .HasColumnName("crc")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ArenaTeam>(entity =>
            {
                entity.ToTable("arena_team");

                entity.Property(e => e.ArenaTeamId)
                    .HasColumnName("arenaTeamId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BackgroundColor)
                    .HasColumnName("backgroundColor")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BorderColor)
                    .HasColumnName("borderColor")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BorderStyle)
                    .HasColumnName("borderStyle")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CaptainGuid)
                    .HasColumnName("captainGuid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmblemColor)
                    .HasColumnName("emblemColor")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmblemStyle)
                    .HasColumnName("emblemStyle")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeasonGames)
                    .HasColumnName("seasonGames")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeasonWins)
                    .HasColumnName("seasonWins")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.WeekGames)
                    .HasColumnName("weekGames")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.WeekWins)
                    .HasColumnName("weekWins")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ArenaTeamMember>(entity =>
            {
                entity.HasKey(e => new { e.ArenaTeamId, e.Guid });

                entity.ToTable("arena_team_member");

                entity.Property(e => e.ArenaTeamId)
                    .HasColumnName("arenaTeamId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PersonalRating)
                    .HasColumnName("personalRating")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeasonGames)
                    .HasColumnName("seasonGames")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeasonWins)
                    .HasColumnName("seasonWins")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.WeekGames)
                    .HasColumnName("weekGames")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.WeekWins)
                    .HasColumnName("weekWins")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Auctionbidders>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Bidderguid });

                entity.ToTable("auctionbidders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bidderguid)
                    .HasColumnName("bidderguid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Auctionhouse>(entity =>
            {
                entity.ToTable("auctionhouse");

                entity.HasIndex(e => e.Itemguid)
                    .HasName("item_guid")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Buyguid)
                    .HasColumnName("buyguid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Buyoutprice)
                    .HasColumnName("buyoutprice")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Deposit)
                    .HasColumnName("deposit")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Houseid)
                    .HasColumnName("houseid")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("7");

                entity.Property(e => e.Itemguid)
                    .HasColumnName("itemguid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemowner)
                    .HasColumnName("itemowner")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lastbid)
                    .HasColumnName("lastbid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Startbid)
                    .HasColumnName("startbid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<BannedAddons>(entity =>
            {
                entity.ToTable("banned_addons");

                entity.HasIndex(e => new { e.Name, e.Version })
                    .HasName("idx_name_ver")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BattlegroundDeserters>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Datetime });

                entity.ToTable("battleground_deserters");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Datetime).HasColumnName("datetime");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<Bounties>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("bounties");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("bigint(25) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Expiretime)
                    .HasColumnName("expiretime")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Money)
                    .HasColumnName("money")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Posterguid)
                    .HasColumnName("posterguid")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<Bugreport>(entity =>
            {
                entity.ToTable("bugreport");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("longtext");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<CalendarEvents>(entity =>
            {
                entity.ToTable("calendar_events");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Creator)
                    .HasColumnName("creator")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dungeon)
                    .HasColumnName("dungeon")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Eventtime)
                    .HasColumnName("eventtime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Time2)
                    .HasColumnName("time2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("4");
            });

            modelBuilder.Entity<CalendarInvites>(entity =>
            {
                entity.ToTable("calendar_invites");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Event)
                    .HasColumnName("event")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Invitee)
                    .HasColumnName("invitee")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Statustime)
                    .HasColumnName("statustime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Channels>(entity =>
            {
                entity.HasKey(e => new { e.Name, e.Team });

                entity.ToTable("channels");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Team)
                    .HasColumnName("team")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Announce)
                    .HasColumnName("announce")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.BannedList)
                    .HasColumnName("bannedList")
                    .IsUnicode(false);

                entity.Property(e => e.LastUsed)
                    .HasColumnName("lastUsed")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Ownership)
                    .HasColumnName("ownership")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CharacterAccountData>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Type });

                entity.ToTable("character_account_data");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("blob");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterAchievement>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Achievement });

                entity.ToTable("character_achievement");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Achievement)
                    .HasColumnName("achievement")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterAchievementProgress>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Criteria });

                entity.ToTable("character_achievement_progress");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Criteria)
                    .HasColumnName("criteria")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Counter)
                    .HasColumnName("counter")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterAction>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Spec, e.Button });

                entity.ToTable("character_action");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spec)
                    .HasColumnName("spec")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Button)
                    .HasColumnName("button")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterArenaStats>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Slot });

                entity.ToTable("character_arena_stats");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Slot)
                    .HasColumnName("slot")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MatchMakerRating)
                    .HasColumnName("matchMakerRating")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterAura>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.CasterGuid, e.ItemGuid, e.Spell, e.EffectMask });

                entity.ToTable("character_aura");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CasterGuid)
                    .HasColumnName("casterGuid")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemGuid)
                    .HasColumnName("itemGuid")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMask)
                    .HasColumnName("effectMask")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Amount0)
                    .HasColumnName("amount0")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Amount1)
                    .HasColumnName("amount1")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Amount2)
                    .HasColumnName("amount2")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ApplyResilience)
                    .HasColumnName("applyResilience")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BaseAmount0)
                    .HasColumnName("base_amount0")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BaseAmount1)
                    .HasColumnName("base_amount1")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BaseAmount2)
                    .HasColumnName("base_amount2")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CritChance)
                    .HasColumnName("critChance")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxDuration)
                    .HasColumnName("maxDuration")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RecalculateMask)
                    .HasColumnName("recalculateMask")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RemainCharges)
                    .HasColumnName("remainCharges")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RemainTime)
                    .HasColumnName("remainTime")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StackCount)
                    .HasColumnName("stackCount")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<CharacterBanned>(entity =>
            {
                entity.HasKey(e => new { Guid = e.CharacterId, e.BanDate });

                entity.ToTable("character_banned");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BanDate)
                    .HasColumnName("bandate")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.BannedBy)
                    .IsRequired()
                    .HasColumnName("bannedby")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BanReason)
                    .IsRequired()
                    .HasColumnName("banreason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnbanDate)
                    .HasColumnName("unbandate")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterBattlegroundData>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("character_battleground_data");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.InstanceId)
                    .HasColumnName("instanceId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.JoinMapId)
                    .HasColumnName("joinMapId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.JoinO)
                    .HasColumnName("joinO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.JoinX)
                    .HasColumnName("joinX")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.JoinY)
                    .HasColumnName("joinY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.JoinZ)
                    .HasColumnName("joinZ")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MountSpell)
                    .HasColumnName("mountSpell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TaxiEnd)
                    .HasColumnName("taxiEnd")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TaxiStart)
                    .HasColumnName("taxiStart")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Team)
                    .HasColumnName("team")
                    .HasColumnType("smallint unsigned");
            });

            modelBuilder.Entity<CharacterBattlegroundRandom>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("character_battleground_random");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterBoost>(entity =>
            {
                entity.HasKey(e => new { e.Owner, e.BoostType });

                entity.ToTable("character_boost");

                entity.Property(e => e.Owner)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BoostType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.BoostModifier)
                    .HasColumnType("float(4,2)")
                    .HasDefaultValueSql("1.00");

                entity.Property(e => e.UnsetDate)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterCurrencies>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("character_currencies");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BattleRoyaleTotal)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BattleRoyaleWins)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DailyQuestAmount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DailyQuestTimer)
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.KillingSpree)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.KingOfTheHillStreak)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastManStandingTotal)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastManStandingWins)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RankPoints).HasDefaultValueSql("0");

                entity.Property(e => e.ShowGuildLevel)
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.TopRankPoints).HasDefaultValueSql("0");

                entity.Property(e => e.TopWinStreak)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalUpgradeRank)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.WinStreak)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterDeclinedname>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("character_declinedname");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Accusative)
                    .IsRequired()
                    .HasColumnName("accusative")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Dative)
                    .IsRequired()
                    .HasColumnName("dative")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Genitive)
                    .IsRequired()
                    .HasColumnName("genitive")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Instrumental)
                    .IsRequired()
                    .HasColumnName("instrumental")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Prepositional)
                    .IsRequired()
                    .HasColumnName("prepositional")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CharacterEquipmentsets>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Setindex });

                entity.ToTable("character_equipmentsets");

                entity.HasIndex(e => e.Setindex)
                    .HasName("Idx_setindex");

                entity.HasIndex(e => new { e.Guid, e.Setindex })
                    .HasName("idx_set")
                    .IsUnique();

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Setindex)
                    .HasColumnName("setindex")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Iconname)
                    .IsRequired()
                    .HasColumnName("iconname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IgnoreMask)
                    .HasColumnName("ignore_mask")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item0)
                    .HasColumnName("item0")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item1)
                    .HasColumnName("item1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item10)
                    .HasColumnName("item10")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item11)
                    .HasColumnName("item11")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item12)
                    .HasColumnName("item12")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item13)
                    .HasColumnName("item13")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item14)
                    .HasColumnName("item14")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item15)
                    .HasColumnName("item15")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item16)
                    .HasColumnName("item16")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item17)
                    .HasColumnName("item17")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item18)
                    .HasColumnName("item18")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item2)
                    .HasColumnName("item2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item3)
                    .HasColumnName("item3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item4)
                    .HasColumnName("item4")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item5)
                    .HasColumnName("item5")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item6)
                    .HasColumnName("item6")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item7)
                    .HasColumnName("item7")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item8)
                    .HasColumnName("item8")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item9)
                    .HasColumnName("item9")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Setguid)
                    .HasColumnName("setguid")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterFishingsteps>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("character_fishingsteps");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FishingSteps)
                    .HasColumnName("fishingSteps")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterGifts>(entity =>
            {
                entity.HasKey(e => e.ItemGuid);

                entity.ToTable("character_gifts");

                entity.HasIndex(e => e.Guid)
                    .HasName("idx_guid");

                entity.Property(e => e.ItemGuid)
                    .HasColumnName("item_guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterGlyphs>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.TalentGroup });

                entity.ToTable("character_glyphs");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.TalentGroup)
                    .HasColumnName("talentGroup")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Glyph1)
                    .HasColumnName("glyph1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Glyph2)
                    .HasColumnName("glyph2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Glyph3)
                    .HasColumnName("glyph3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Glyph4)
                    .HasColumnName("glyph4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Glyph5)
                    .HasColumnName("glyph5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Glyph6)
                    .HasColumnName("glyph6")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterGuildXpGiven>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("character_guild_xp_given");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Xp)
                    .HasColumnName("xp")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterHomebind>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("character_homebind");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnName("mapId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosX)
                    .HasColumnName("posX")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosY)
                    .HasColumnName("posY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosZ)
                    .HasColumnName("posZ")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zoneId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterInstance>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Instance });

                entity.ToTable("character_instance");

                entity.HasIndex(e => e.Instance)
                    .HasName("instance");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Instance)
                    .HasColumnName("instance")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExtendState)
                    .HasColumnName("extendState")
                    .HasColumnType("tinyint(2) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Permanent)
                    .HasColumnName("permanent")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterInventory>(entity =>
            {
                entity.HasKey(e => e.Item);

                entity.ToTable("character_inventory");

                entity.HasIndex(e => e.Guid)
                    .HasName("idx_guid");

                entity.HasIndex(e => new { e.Guid, e.Bag, e.Slot })
                    .HasName("guid")
                    .IsUnique();

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bag)
                    .HasColumnName("bag")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Slot)
                    .HasColumnName("slot")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterPet>(entity =>
            {
                entity.ToTable("character_pet");

                entity.HasIndex(e => e.Owner)
                    .HasName("owner");

                entity.HasIndex(e => e.Slot)
                    .HasName("idx_slot");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Abdata)
                    .HasColumnName("abdata")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBySpell)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Curhappiness)
                    .HasColumnName("curhappiness")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Curhealth)
                    .HasColumnName("curhealth")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Curmana)
                    .HasColumnName("curmana")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Exp)
                    .HasColumnName("exp")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Modelid)
                    .HasColumnName("modelid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("Pet");

                entity.Property(e => e.Owner)
                    .HasColumnName("owner")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PetType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reactstate)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Renamed)
                    .HasColumnName("renamed")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Savetime)
                    .HasColumnName("savetime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Slot)
                    .HasColumnName("slot")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterPetDeclinedname>(entity =>
            {
                entity.ToTable("character_pet_declinedname");

                entity.HasIndex(e => e.Owner)
                    .HasName("owner_key");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Accusative)
                    .IsRequired()
                    .HasColumnName("accusative")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Dative)
                    .IsRequired()
                    .HasColumnName("dative")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Genitive)
                    .IsRequired()
                    .HasColumnName("genitive")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Instrumental)
                    .IsRequired()
                    .HasColumnName("instrumental")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Owner)
                    .HasColumnName("owner")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prepositional)
                    .IsRequired()
                    .HasColumnName("prepositional")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CharacterQueststatus>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Quest });

                entity.ToTable("character_queststatus");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Explored)
                    .HasColumnName("explored")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemcount1)
                    .HasColumnName("itemcount1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemcount2)
                    .HasColumnName("itemcount2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemcount3)
                    .HasColumnName("itemcount3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemcount4)
                    .HasColumnName("itemcount4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemcount5)
                    .HasColumnName("itemcount5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemcount6)
                    .HasColumnName("itemcount6")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mobcount1)
                    .HasColumnName("mobcount1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mobcount2)
                    .HasColumnName("mobcount2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mobcount3)
                    .HasColumnName("mobcount3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mobcount4)
                    .HasColumnName("mobcount4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Playercount)
                    .HasColumnName("playercount")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Timer)
                    .HasColumnName("timer")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterQueststatusDaily>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Quest });

                entity.ToTable("character_queststatus_daily");

                entity.HasIndex(e => e.Guid)
                    .HasName("idx_guid");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterQueststatusMonthly>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Quest });

                entity.ToTable("character_queststatus_monthly");

                entity.HasIndex(e => e.Guid)
                    .HasName("idx_guid");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterQueststatusRewarded>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Quest });

                entity.ToTable("character_queststatus_rewarded");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<CharacterQueststatusSeasonal>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Quest });

                entity.ToTable("character_queststatus_seasonal");

                entity.HasIndex(e => e.Guid)
                    .HasName("idx_guid");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Event)
                    .HasColumnName("event")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterQueststatusWeekly>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Quest });

                entity.ToTable("character_queststatus_weekly");

                entity.HasIndex(e => e.Guid)
                    .HasName("idx_guid");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterReputation>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Faction });

                entity.ToTable("character_reputation");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Faction)
                    .HasColumnName("faction")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Standing)
                    .HasColumnName("standing")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterSkills>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Skill });

                entity.ToTable("character_skills");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Skill)
                    .HasColumnName("skill")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Max)
                    .HasColumnName("max")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("smallint unsigned");
            });

            modelBuilder.Entity<CharacterSocial>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Friend, e.Flags });

                entity.ToTable("character_social");

                entity.HasIndex(e => e.Friend)
                    .HasName("friend");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Friend)
                    .HasColumnName("friend")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(48)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CharacterSpell>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Spell });

                entity.ToTable("character_spell");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Disabled)
                    .HasColumnName("disabled")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterSpellCooldown>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Spell });

                entity.ToTable("character_spell_cooldown");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CategoryEnd)
                    .HasColumnName("categoryEnd")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterStats>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("character_stats");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Agility)
                    .HasColumnName("agility")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Armor)
                    .HasColumnName("armor")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttackPower)
                    .HasColumnName("attackPower")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BlockPct)
                    .HasColumnName("blockPct")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CritPct)
                    .HasColumnName("critPct")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DodgePct)
                    .HasColumnName("dodgePct")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Intellect)
                    .HasColumnName("intellect")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxHealth)
                    .HasColumnName("maxhealth")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mana)
                    .HasColumnName("maxpower1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rage)
                    .HasColumnName("maxpower2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Focus)
                    .HasColumnName("maxpower3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Energy)
                    .HasColumnName("maxpower4")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Happiness)
                    .HasColumnName("maxpower5")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Runes)
                    .HasColumnName("maxpower6")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RunicPower)
                    .HasColumnName("maxpower7")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ParryPct)
                    .HasColumnName("parryPct")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RangedAttackPower)
                    .HasColumnName("rangedAttackPower")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RangedCritPct)
                    .HasColumnName("rangedCritPct")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResArcane)
                    .HasColumnName("resArcane")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResFire)
                    .HasColumnName("resFire")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResFrost)
                    .HasColumnName("resFrost")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResHoly)
                    .HasColumnName("resHoly")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResNature)
                    .HasColumnName("resNature")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResShadow)
                    .HasColumnName("resShadow")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Resilience)
                    .HasColumnName("resilience")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Expertise)
                    .HasColumnName("expertise")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defense)
                    .HasColumnName("defense")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MeleeHit)
                    .HasColumnName("meleeHit")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellHit)
                    .HasColumnName("spellHit")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RangedHit)
                    .HasColumnName("rangedHit")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MeleeHaste)
                    .HasColumnName("meleeHaste")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellHaste)
                    .HasColumnName("spellHaste")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RangedHaste)
                    .HasColumnName("rangedHaste")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCritPct)
                    .HasColumnName("spellCritPct")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellPower)
                    .HasColumnName("spellPower")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spirit)
                    .HasColumnName("spirit")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Stamina)
                    .HasColumnName("stamina")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Strength)
                    .HasColumnName("strength")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinBaseDamage)
                    .HasColumnName("minDmgBaseAttack")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxBaseDamage)
                    .HasColumnName("maxDmgBaseAttack")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinOffDamage)
                    .HasColumnName("minDmgOffAttack")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxOffDamage)
                    .HasColumnName("maxDmgOffAttack")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinRangedDamage)
                    .HasColumnName("minDmgRangeAttack")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxRangedDamage)
                    .HasColumnName("maxDmgRangeAttack")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ManaRegen)
                    .HasColumnName("manaRegen")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ArmorPenetration)
                    .HasColumnName("armorPen")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellPenetration)
                    .HasColumnName("spellPen")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CharacterTalent>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Spell, e.TalentGroup });

                entity.ToTable("character_talent");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.TalentGroup)
                    .HasColumnName("talentGroup")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("characters");

                entity.HasIndex(e => e.Account)
                    .HasName("idx_account");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_name");

                entity.HasIndex(e => e.Online)
                    .HasName("idx_online");

                entity.Property(e => e.Id)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                //entity.Property(e => e.ActionBars)
                //    .HasColumnName("actionBars")
                //    .HasColumnType("tinyint unsigned")
                //    .HasDefaultValueSql("0");
                //
                //entity.Property(e => e.ActiveTalentGroup)
                //    .HasColumnName("activeTalentGroup")
                //    .HasColumnType("tinyint unsigned")
                //    .HasDefaultValueSql("0");

              //  entity.Property(e => e.AmmoId)
              //      .HasColumnName("ammoId")
              //      .HasColumnType("int unsigned")
              //      .HasDefaultValueSql("0");

                entity.Property(e => e.ArenaPoints)
                    .HasColumnName("arenaPoints")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AtLogin)
                    .HasColumnName("at_login")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                //entity.Property(e => e.BankSlots)
                //    .HasColumnName("bankSlots")
                //    .HasColumnType("tinyint unsigned")
                //    .HasDefaultValueSql("0");

                entity.Property(e => e.ChosenTitle)
                    .HasColumnName("chosenTitle")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

             //  entity.Property(e => e.Cinematic)
             //      .HasColumnName("cinematic")
             //      .HasColumnType("tinyint unsigned")
             //      .HasDefaultValueSql("0");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

             //   entity.Property(e => e.DeathExpireTime)
             //       .HasColumnName("death_expire_time")
             //       .HasColumnType("int unsigned")
             //       .HasDefaultValueSql("0");
             //
               // entity.Property(e => e.DeleteDate)
               //     .HasColumnName("deleteDate")
               //     .HasColumnType("int unsigned");
               //
               // entity.Property(e => e.DeleteInfosAccount)
               //     .HasColumnName("deleteInfos_Account")
               //     .HasColumnType("int unsigned");
               //
               // entity.Property(e => e.DeleteInfosName)
               //     .HasColumnName("deleteInfos_Name")
               //     .HasMaxLength(12)
               //     .IsUnicode(false);
               //
               // entity.Property(e => e.Drunk)
               //     .HasColumnName("drunk")
               //     .HasColumnType("tinyint unsigned")
               //     .HasDefaultValueSql("0");

              // entity.Property(e => e.EquipmentCache)
              //     .HasColumnName("equipmentCache")
              //     .HasColumnType("longtext");

                entity.Property(e => e.ExploredZones)
                    .HasColumnName("exploredZones")
                    .HasColumnType("longtext");

             //   entity.Property(e => e.ExtraFlags)
             //       .HasColumnName("extra_flags")
             //       .HasColumnType("smallint unsigned")
             //       .HasDefaultValueSql("0");
             //
               //entity.Property(e => e.Face)
               //    .HasColumnName("face")
               //    .HasColumnType("tinyint unsigned")
               //    .HasDefaultValueSql("0");
               //
               //entity.Property(e => e.FacialStyle)
               //    .HasColumnName("facialStyle")
               //    .HasColumnType("tinyint unsigned")
               //    .HasDefaultValueSql("0");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

            //    entity.Property(e => e.GrantableLevels)
            //        .HasColumnName("grantableLevels")
            //        .HasColumnType("tinyint unsigned")
            //        .HasDefaultValueSql("0");
            //
            //    entity.Property(e => e.HairColor)
            //        .HasColumnName("hairColor")
            //        .HasColumnType("tinyint unsigned")
            //        .HasDefaultValueSql("0");
            //
             //   entity.Property(e => e.HairStyle)
             //       .HasColumnName("hairStyle")
             //       .HasColumnType("tinyint unsigned")
             //       .HasDefaultValueSql("0");
             //
                entity.Property(e => e.Health)
                    .HasColumnName("health")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

           //    entity.Property(e => e.InstanceId)
           //        .HasColumnName("instance_id")
           //        .HasColumnType("int unsigned")
           //        .HasDefaultValueSql("0");
           //
           //    entity.Property(e => e.InstanceModeMask)
           //        .HasColumnName("instance_mode_mask")
           //        .HasColumnType("tinyint unsigned")
           //        .HasDefaultValueSql("0");

            //   entity.Property(e => e.IsLogoutResting)
            //       .HasColumnName("is_logout_resting")
            //       .HasColumnType("tinyint unsigned")
            //       .HasDefaultValueSql("0");

                entity.Property(e => e.KnownCurrencies)
                    .HasColumnName("knownCurrencies")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.KnownTitles)
                    .HasColumnName("knownTitles")
                    .HasColumnType("longtext");

                entity.Property(e => e.Latency)
                    .HasColumnName("latency")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Leveltime)
                    .HasColumnName("leveltime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LogoutTime)
                    .HasColumnName("logout_time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Money)
                    .HasColumnName("money")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Orientation)
                    .HasColumnName("orientation")
                    .HasDefaultValueSql("0");

             //   entity.Property(e => e.PlayerFlags)
             //       .HasColumnName("playerFlags")
             //       .HasColumnType("int unsigned")
             //       .HasDefaultValueSql("0");

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mana)
                    .HasColumnName("power1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rage)
                    .HasColumnName("power2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Focus)
                    .HasColumnName("power3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Energy)
                    .HasColumnName("power4")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Happiness)
                    .HasColumnName("power5")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Runes)
                    .HasColumnName("power6")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RunicPower)
                    .HasColumnName("power7")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestPlayersSlain)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

            //    entity.Property(e => e.ResettalentsCost)
            //        .HasColumnName("resettalents_cost")
            //        .HasColumnType("int unsigned")
            //        .HasDefaultValueSql("0");
            //
            //    entity.Property(e => e.ResettalentsTime)
            //        .HasColumnName("resettalents_time")
            //        .HasColumnType("int unsigned")
            //        .HasDefaultValueSql("0");
            //
            //    entity.Property(e => e.RestBonus)
            //        .HasColumnName("rest_bonus")
            //        .HasDefaultValueSql("0");
            //
            // //   entity.Property(e => e.RestState)
             //       .HasColumnName("restState")
             //       .HasColumnType("tinyint unsigned")
             //       .HasDefaultValueSql("0");
             //
             //   entity.Property(e => e.Skin)
             //       .HasColumnName("skin")
             //       .HasColumnType("tinyint unsigned")
             //       .HasDefaultValueSql("0");
             //
             //   entity.Property(e => e.StableSlots)
             //       .HasColumnName("stable_slots")
             //       .HasColumnType("tinyint unsigned")
             //       .HasDefaultValueSql("0");
             //
             //   entity.Property(e => e.TalentGroupsCount)
             //       .HasColumnName("talentGroupsCount")
             //       .HasColumnType("tinyint unsigned")
             //       .HasDefaultValueSql("1");

                /*entity.Property(e => e.TaxiPath)
                    .HasColumnName("taxi_path")
                    .IsUnicode(false);*/

            //  entity.Property(e => e.Taximask)
            //      .IsRequired()
            //      .HasColumnName("taximask")
            //      .IsUnicode(false);

                entity.Property(e => e.TodayHonorPoints)
                    .HasColumnName("todayHonorPoints")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TodayKills)
                    .HasColumnName("todayKills")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalHonorPoints)
                    .HasColumnName("totalHonorPoints")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalKills)
                    .HasColumnName("totalKills")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Totaltime)
                    .HasColumnName("totaltime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                /*entity.Property(e => e.TransO)
                    .HasColumnName("trans_o")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TransX)
                    .HasColumnName("trans_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TransY)
                    .HasColumnName("trans_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TransZ)
                    .HasColumnName("trans_z")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Transguid)
                    .HasColumnName("transguid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.WatchedFaction)
                    .HasColumnName("watchedFaction")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");*/

                entity.Property(e => e.Xp)
                    .HasColumnName("xp")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.YesterdayHonorPoints)
                    .HasColumnName("yesterdayHonorPoints")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.YesterdayKills)
                    .HasColumnName("yesterdayKills")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Zone)
                    .HasColumnName("zone")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Corpse>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("corpse");

                entity.HasIndex(e => e.CorpseType)
                    .HasName("idx_type");

                entity.HasIndex(e => e.InstanceId)
                    .HasName("idx_instance");

                entity.HasIndex(e => e.Time)
                    .HasName("idx_time");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bytes1)
                    .HasColumnName("bytes1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bytes2)
                    .HasColumnName("bytes2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CorpseType)
                    .HasColumnName("corpseType")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DisplayId)
                    .HasColumnName("displayId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DynFlags)
                    .HasColumnName("dynFlags")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guildId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.InstanceId)
                    .HasColumnName("instanceId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemCache)
                    .IsRequired()
                    .HasColumnName("itemCache")
                    .IsUnicode(false);

                entity.Property(e => e.MapId)
                    .HasColumnName("mapId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Orientation)
                    .HasColumnName("orientation")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PhaseMask)
                    .HasColumnName("phaseMask")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.PosX)
                    .HasColumnName("posX")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosY)
                    .HasColumnName("posY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosZ)
                    .HasColumnName("posZ")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomItemUpgradeSets>(entity =>
            {
                entity.HasKey(e => new { e.Owner, e.SetId });

                entity.ToTable("custom_item_upgrade_sets");

                entity.HasIndex(e => e.Owner)
                    .HasName("Owner");

                entity.Property(e => e.Owner)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SetId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SetName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomItemUpgrades>(entity =>
            {
                entity.HasKey(e => new { e.ItemGuid, e.OwnerGuid, e.SetId });

                entity.ToTable("custom_item_upgrades");

                entity.HasIndex(e => e.OwnerGuid)
                    .HasName("OwnerGuid");

                entity.Property(e => e.ItemGuid)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OwnerGuid)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SetId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ArcaneResId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ArmorId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgId1)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgId2)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FireResId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FrostResId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HolyResId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NatureResId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quality)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.ShadowResId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId1)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId10)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId2)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId3)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId4)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId5)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId6)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId7)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId8)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatId9)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UpgradeLevel)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomTransmogrification>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.FakeOwner, e.FakeEntry });

                entity.ToTable("custom_transmogrification");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FakeOwner)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FakeEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomTransmogrificationSets>(entity =>
            {
                entity.HasKey(e => new { e.Owner, e.PresetId });

                entity.ToTable("custom_transmogrification_sets");

                entity.Property(e => e.Owner).HasColumnType("int unsigned");

                entity.Property(e => e.PresetId)
                    .HasColumnName("PresetID")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.SetData).IsUnicode(false);

                entity.Property(e => e.SetName).IsUnicode(false);
            });

            modelBuilder.Entity<GameEventConditionSave>(entity =>
            {
                entity.HasKey(e => new { e.EventEntry, e.ConditionId });

                entity.ToTable("game_event_condition_save");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.ConditionId)
                    .HasColumnName("condition_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Done)
                    .HasColumnName("done")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventSave>(entity =>
            {
                entity.HasKey(e => e.EventEntry);

                entity.ToTable("game_event_save");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.NextStart)
                    .HasColumnName("next_start")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<GmSubsurvey>(entity =>
            {
                entity.HasKey(e => new { e.SurveyId, e.QuestionId });

                entity.ToTable("gm_subsurvey");

                entity.Property(e => e.SurveyId)
                    .HasColumnName("surveyId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.QuestionId)
                    .HasColumnName("questionId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AnswerComment)
                    .IsRequired()
                    .HasColumnName("answerComment")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GmSurvey>(entity =>
            {
                entity.HasKey(e => e.SurveyId);

                entity.ToTable("gm_survey");

                entity.Property(e => e.SurveyId)
                    .HasColumnName("surveyId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasColumnType("longtext");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MainSurvey)
                    .HasColumnName("mainSurvey")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GmTicket>(entity =>
            {
                entity.ToTable("gm_ticket");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.AssignedTo)
                    .HasColumnName("assignedTo")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ClosedBy)
                    .HasColumnName("closedBy")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Completed)
                    .HasColumnName("completed")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Escalated)
                    .HasColumnName("escalated")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("lastModifiedTime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnName("mapId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.NeedMoreHelp)
                    .HasColumnName("needMoreHelp")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PlayerGuid)
                    .HasColumnName("playerGuid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosX)
                    .HasColumnName("posX")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosY)
                    .HasColumnName("posY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosZ)
                    .HasColumnName("posZ")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResolvedBy)
                    .HasColumnName("resolvedBy")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Response)
                    .IsRequired()
                    .HasColumnName("response")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Viewed)
                    .HasColumnName("viewed")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GroupInstance>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Instance });

                entity.ToTable("group_instance");

                entity.HasIndex(e => e.Instance)
                    .HasName("instance");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Instance)
                    .HasColumnName("instance")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Permanent)
                    .HasColumnName("permanent")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.HasKey(e => e.MemberGuid);

                entity.ToTable("group_member");

                entity.Property(e => e.MemberGuid)
                    .HasColumnName("memberGuid")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.MemberFlags)
                    .HasColumnName("memberFlags")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Roles)
                    .HasColumnName("roles")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Subgroup)
                    .HasColumnName("subgroup")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("groups");

                entity.HasIndex(e => e.LeaderGuid)
                    .HasName("leaderGuid");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Difficulty)
                    .HasColumnName("difficulty")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GroupType)
                    .HasColumnName("groupType")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Icon1)
                    .HasColumnName("icon1")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Icon2)
                    .HasColumnName("icon2")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Icon3)
                    .HasColumnName("icon3")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Icon4)
                    .HasColumnName("icon4")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Icon5)
                    .HasColumnName("icon5")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Icon6)
                    .HasColumnName("icon6")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Icon7)
                    .HasColumnName("icon7")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Icon8)
                    .HasColumnName("icon8")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.LeaderGuid)
                    .HasColumnName("leaderGuid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.LootMethod)
                    .HasColumnName("lootMethod")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.LootThreshold)
                    .HasColumnName("lootThreshold")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.LooterGuid)
                    .HasColumnName("looterGuid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.MasterLooterGuid)
                    .HasColumnName("masterLooterGuid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.RaidDifficulty)
                    .HasColumnName("raidDifficulty")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Guild>(entity =>
            {
                entity.ToTable("guild");

                entity.Property(e => e.Id)
                    .HasColumnName("guildid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BackgroundColor)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BankMoney)
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BorderColor)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BorderStyle)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createdate")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmblemColor)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmblemStyle)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Exp)
                    .HasColumnName("Exp")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnName("info")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LeaderGuid)
                    .HasColumnName("leaderguid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Level)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Motd)
                    .IsRequired()
                    .HasColumnName("motd")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(24)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GuildBankEventLog>(entity =>
            {
                entity.HasKey(e => new { e.GuildId, e.LogGuid, e.TabId });

                entity.ToTable("guild_bank_eventlog");

                entity.HasIndex(e => e.GuildId)
                    .HasName("guildid_key");

                entity.HasIndex(e => e.LogGuid)
                    .HasName("Idx_LogGuid");

                entity.HasIndex(e => e.PlayerGuid)
                    .HasName("Idx_PlayerGuid");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guildid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LogGuid)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TabId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DestTabId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemOrMoney)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemStackCount)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PlayerGuid)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GuildBankItem>(entity =>
            {
                entity.HasKey(e => new { e.GuildId, e.TabId, e.SlotId });

                entity.ToTable("guild_bank_item");

                entity.HasIndex(e => e.GuildId)
                    .HasName("guildid_key");

                entity.HasIndex(e => e.ItemGuid)
                    .HasName("Idx_item_guid");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guildid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TabId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SlotId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemGuid)
                    .HasColumnName("item_guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GuildBankRight>(entity =>
            {
                entity.HasKey(e => new { e.GuildId, e.TabId, e.Rid });

                entity.ToTable("guild_bank_right");

                entity.HasIndex(e => e.GuildId)
                    .HasName("guildid_key");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guildid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TabId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rid)
                    .HasColumnName("rid")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Gbright)
                    .HasColumnName("gbright")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SlotPerDay)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GuildBankTab>(entity =>
            {
                entity.HasKey(e => new { e.GuildÍd, e.TabId });

                entity.ToTable("guild_bank_tab");

                entity.HasIndex(e => e.GuildÍd)
                    .HasName("guildid_key");

                entity.Property(e => e.GuildÍd)
                    .HasColumnName("guildid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TabId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TabIcon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TabName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.TabText)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GuildEventLog>(entity =>
            {
                entity.HasKey(e => new { e.GuildId, e.LogGuid });

                entity.ToTable("guild_eventlog");

                entity.HasIndex(e => e.LogGuid)
                    .HasName("Idx_LogGuid");

                entity.HasIndex(e => e.PlayerGuid1)
                    .HasName("Idx_PlayerGuid1");

                entity.HasIndex(e => e.PlayerGuid2)
                    .HasName("Idx_PlayerGuid2");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guildid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.LogGuid).HasColumnType("int unsigned");

                entity.Property(e => e.EventType).HasColumnType("tinyint unsigned");

                entity.Property(e => e.NewRank).HasColumnType("tinyint unsigned");

                entity.Property(e => e.PlayerGuid1).HasColumnType("int unsigned");

                entity.Property(e => e.PlayerGuid2).HasColumnType("int unsigned");

                entity.Property(e => e.TimeStamp).HasColumnType("int unsigned");
            });

            modelBuilder.Entity<GuildMember>(entity =>
            {
                entity.HasKey(e => new { e.GuildId, Guid = e.CharacterId });

                entity.ToTable("guild_member");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("guid_key")
                    .IsUnique();

                entity.HasIndex(e => e.GuildId)
                    .HasName("guildid_key");

                entity.HasIndex(e => new { e.GuildId, e.RankId })
                    .HasName("guildid_rank_key");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guildid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.OffNote)
                    .IsRequired()
                    .HasColumnName("offnote")
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Pnote)
                    .IsRequired()
                    .HasColumnName("pnote")
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.RankId)
                    .HasColumnName("rank")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<GuildMemberWithdraw>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("guild_member_withdraw");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Money)
                    .HasColumnName("money")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tab0)
                    .HasColumnName("tab0")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tab1)
                    .HasColumnName("tab1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tab2)
                    .HasColumnName("tab2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tab3)
                    .HasColumnName("tab3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tab4)
                    .HasColumnName("tab4")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tab5)
                    .HasColumnName("tab5")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GuildRank>(entity =>
            {
                entity.HasKey(e => new { e.GuildId, Rid = e.Id });

                entity.ToTable("guild_rank");

                entity.HasIndex(e => e.Id)
                    .HasName("Idx_rid");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guildid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("rid")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.BankMoneyPerDay)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rights)
                    .HasColumnName("rights")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RankName)
                    .IsRequired()
                    .HasColumnName("rname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Instance>(entity =>
            {
                entity.ToTable("instance");

                entity.HasIndex(e => e.Difficulty)
                    .HasName("difficulty");

                entity.HasIndex(e => e.Map)
                    .HasName("map");

                entity.HasIndex(e => e.Resettime)
                    .HasName("resettime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CompletedEncounters)
                    .HasColumnName("completedEncounters")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Difficulty)
                    .HasColumnName("difficulty")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Resettime)
                    .HasColumnName("resettime")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<InstanceReset>(entity =>
            {
                entity.HasKey(e => new { e.Mapid, e.Difficulty });

                entity.ToTable("instance_reset");

                entity.HasIndex(e => e.Difficulty)
                    .HasName("difficulty");

                entity.Property(e => e.Mapid)
                    .HasColumnName("mapid")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Difficulty)
                    .HasColumnName("difficulty")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Resettime)
                    .HasColumnName("resettime")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ItemInstance>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("item_instance");

                entity.HasIndex(e => e.OwnerGuid)
                    .HasName("idx_owner_guid");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Charges)
                    .HasColumnName("charges")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.CreatorGuid)
                    .HasColumnName("creatorGuid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Durability)
                    .HasColumnName("durability")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Enchantments)
                    .IsRequired()
                    .HasColumnName("enchantments")
                    .IsUnicode(false);

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GiftCreatorGuid)
                    .HasColumnName("giftCreatorGuid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemEntry)
                    .HasColumnName("itemEntry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OwnerGuid)
                    .HasColumnName("owner_guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PlayedTime)
                    .HasColumnName("playedTime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RandomPropertyId)
                    .HasColumnName("randomPropertyId")
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .IsUnicode(false);

                entity.Property(e => e.Transmog)
                    .HasColumnName("transmog")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ItemLootItems>(entity =>
            {
                entity.HasKey(e => new { e.ContainerId, e.ItemId });

                entity.ToTable("item_loot_items");

                entity.Property(e => e.ContainerId)
                    .HasColumnName("container_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Blocked)
                    .HasColumnName("blocked")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Counted)
                    .HasColumnName("counted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ffa)
                    .HasColumnName("ffa")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FollowRules)
                    .HasColumnName("follow_rules")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemCount)
                    .HasColumnName("item_count")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NeedsQuest)
                    .HasColumnName("needs_quest")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RndProp)
                    .HasColumnName("rnd_prop")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RndSuffix)
                    .HasColumnName("rnd_suffix")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnderThreshold)
                    .HasColumnName("under_threshold")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ItemLootMoney>(entity =>
            {
                entity.HasKey(e => e.ContainerId);

                entity.ToTable("item_loot_money");

                entity.Property(e => e.ContainerId)
                    .HasColumnName("container_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Money)
                    .HasColumnName("money")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ItemRefundInstance>(entity =>
            {
                entity.HasKey(e => new { e.ItemGuid, e.PlayerGuid });

                entity.ToTable("item_refund_instance");

                entity.Property(e => e.ItemGuid)
                    .HasColumnName("item_guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.PlayerGuid)
                    .HasColumnName("player_guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.PaidExtendedCost)
                    .HasColumnName("paidExtendedCost")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PaidMoney)
                    .HasColumnName("paidMoney")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ItemSoulboundTradeData>(entity =>
            {
                entity.HasKey(e => e.ItemGuid);

                entity.ToTable("item_soulbound_trade_data");

                entity.Property(e => e.ItemGuid)
                    .HasColumnName("itemGuid")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowedPlayers)
                    .IsRequired()
                    .HasColumnName("allowedPlayers")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LagReports>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.ToTable("lag_reports");

                entity.Property(e => e.ReportId)
                    .HasColumnName("reportId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LagType)
                    .HasColumnName("lagType")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Latency)
                    .HasColumnName("latency")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnName("mapId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosX)
                    .HasColumnName("posX")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosY)
                    .HasColumnName("posY")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosZ)
                    .HasColumnName("posZ")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<LfgData>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("lfg_data");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dungeon)
                    .HasColumnName("dungeon")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Mail>(entity =>
            {
                entity.ToTable("mail");

                entity.HasIndex(e => e.Receiver)
                    .HasName("idx_receiver");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("longtext");

                entity.Property(e => e.Checked)
                    .HasColumnName("checked")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cod)
                    .HasColumnName("cod")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DeliverTime)
                    .HasColumnName("deliver_time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExpireTime)
                    .HasColumnName("expire_time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HasItems)
                    .HasColumnName("has_items")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MailTemplateId)
                    .HasColumnName("mailTemplateId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MessageType)
                    .HasColumnName("messageType")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Money)
                    .HasColumnName("money")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Receiver)
                    .HasColumnName("receiver")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Stationery)
                    .HasColumnName("stationery")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("41");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<MailItems>(entity =>
            {
                entity.HasKey(e => e.ItemGuid);

                entity.ToTable("mail_items");

                entity.HasIndex(e => e.MailId)
                    .HasName("idx_mail_id");

                entity.HasIndex(e => e.Receiver)
                    .HasName("idx_receiver");

                entity.Property(e => e.ItemGuid)
                    .HasColumnName("item_guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MailId)
                    .HasColumnName("mail_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Receiver)
                    .HasColumnName("receiver")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<NpcVendorRestock>(entity =>
            {
                entity.HasKey(e => new { e.OwnerGuid, e.VendorEntry, e.ItemEntry });

                entity.ToTable("npc_vendor_restock");

                entity.Property(e => e.OwnerGuid)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VendorEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemEntry).HasColumnType("int unsigned");

                entity.Property(e => e.Count)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NextIncrementTime)
                    .HasColumnName("nextIncrementTime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PetAura>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.CasterGuid, e.Spell, e.EffectMask });

                entity.ToTable("pet_aura");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CasterGuid)
                    .HasColumnName("casterGuid")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMask)
                    .HasColumnName("effectMask")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Amount0)
                    .HasColumnName("amount0")
                    .HasColumnType("mediumint");

                entity.Property(e => e.Amount1)
                    .HasColumnName("amount1")
                    .HasColumnType("mediumint");

                entity.Property(e => e.Amount2)
                    .HasColumnName("amount2")
                    .HasColumnType("mediumint");

                entity.Property(e => e.ApplyResilience)
                    .HasColumnName("applyResilience")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BaseAmount0)
                    .HasColumnName("base_amount0")
                    .HasColumnType("mediumint");

                entity.Property(e => e.BaseAmount1)
                    .HasColumnName("base_amount1")
                    .HasColumnType("mediumint");

                entity.Property(e => e.BaseAmount2)
                    .HasColumnName("base_amount2")
                    .HasColumnType("mediumint");

                entity.Property(e => e.CritChance)
                    .HasColumnName("critChance")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxDuration)
                    .HasColumnName("maxDuration")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RecalculateMask)
                    .HasColumnName("recalculateMask")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RemainCharges)
                    .HasColumnName("remainCharges")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RemainTime)
                    .HasColumnName("remainTime")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StackCount)
                    .HasColumnName("stackCount")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<PetSpell>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Spell });

                entity.ToTable("pet_spell");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PetSpellCooldown>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Spell });

                entity.ToTable("pet_spell_cooldown");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CategoryEnd)
                    .HasColumnName("categoryEnd")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Petition>(entity =>
            {
                entity.HasKey(e => new { e.Ownerguid, e.Type });

                entity.ToTable("petition");

                entity.HasIndex(e => new { e.Ownerguid, e.Petitionguid })
                    .HasName("index_ownerguid_petitionguid")
                    .IsUnique();

                entity.Property(e => e.Ownerguid)
                    .HasColumnName("ownerguid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Petitionguid)
                    .HasColumnName("petitionguid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PetitionSign>(entity =>
            {
                entity.HasKey(e => new { e.Petitionguid, e.Playerguid });

                entity.ToTable("petition_sign");

                entity.HasIndex(e => e.Ownerguid)
                    .HasName("Idx_ownerguid");

                entity.HasIndex(e => e.Playerguid)
                    .HasName("Idx_playerguid");

                entity.Property(e => e.Petitionguid)
                    .HasColumnName("petitionguid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Playerguid)
                    .HasColumnName("playerguid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ownerguid)
                    .HasColumnName("ownerguid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.PlayerAccount)
                    .HasColumnName("player_account")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PoolQuestSave>(entity =>
            {
                entity.HasKey(e => new { e.PoolId, e.QuestId });

                entity.ToTable("pool_quest_save");

                entity.Property(e => e.PoolId)
                    .HasColumnName("pool_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestId)
                    .HasColumnName("quest_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PvpstatsBattlegrounds>(entity =>
            {
                entity.ToTable("pvpstats_battlegrounds");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.BracketId)
                    .HasColumnName("bracket_id")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.WinnerFaction)
                    .HasColumnName("winner_faction")
                    .HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<PvpstatsPlayers>(entity =>
            {
                entity.HasKey(e => new { e.BattlegroundId, e.CharacterGuid });

                entity.ToTable("pvpstats_players");

                entity.Property(e => e.BattlegroundId)
                    .HasColumnName("battleground_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CharacterGuid)
                    .HasColumnName("character_guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Attr1)
                    .HasColumnName("attr_1")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Attr2)
                    .HasColumnName("attr_2")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Attr3)
                    .HasColumnName("attr_3")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Attr4)
                    .HasColumnName("attr_4")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Attr5)
                    .HasColumnName("attr_5")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScoreBonusHonor)
                    .HasColumnName("score_bonus_honor")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.ScoreDamageDone)
                    .HasColumnName("score_damage_done")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.ScoreDeaths)
                    .HasColumnName("score_deaths")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.ScoreHealingDone)
                    .HasColumnName("score_healing_done")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.ScoreHonorableKills)
                    .HasColumnName("score_honorable_kills")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.ScoreKillingBlows)
                    .HasColumnName("score_killing_blows")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.Winner)
                    .HasColumnName("winner")
                    .HasColumnType("mediumint unsigned");
            });

            modelBuilder.Entity<QuestTracker>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CharacterGuid });

                entity.ToTable("quest_tracker");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CharacterGuid)
                    .HasColumnName("character_guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CompletedByGm)
                    .HasColumnName("completed_by_gm")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CoreHash)
                    .IsRequired()
                    .HasColumnName("core_hash")
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CoreRevision)
                    .IsRequired()
                    .HasColumnName("core_revision")
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestAbandonTime).HasColumnName("quest_abandon_time");

                entity.Property(e => e.QuestAcceptTime).HasColumnName("quest_accept_time");

                entity.Property(e => e.QuestCompleteTime).HasColumnName("quest_complete_time");
            });

            modelBuilder.Entity<RaceEvent>(entity =>
            {
                entity.HasKey(e => e.Owner);

                entity.ToTable("race_event");

                entity.Property(e => e.Owner)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Total)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Wins)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ReservedName>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("reserved_name");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Respawn>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.SpawnId, e.InstanceId });

                entity.ToTable("respawn");

                entity.HasIndex(e => e.InstanceId)
                    .HasName("idx_instance");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.SpawnId)
                    .HasColumnName("spawnId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.InstanceId)
                    .HasColumnName("instanceId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.MapId)
                    .HasColumnName("mapId")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.RespawnTime)
                    .HasColumnName("respawnTime")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<Shootemup>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("shootemup");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Round)
                    .HasColumnName("round")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Won)
                    .HasColumnName("won")
                    .HasColumnType("bigint(30) unsigned")
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
                    .HasColumnType("int unsigned")
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

            modelBuilder.Entity<WardenAction>(entity =>
            {
                entity.HasKey(e => e.WardenId);

                entity.ToTable("warden_action");

                entity.Property(e => e.WardenId)
                    .HasColumnName("wardenId")
                    .HasColumnType("smallint unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<Worldstates>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("worldstates");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ZombieEvent>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("zombie_event");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Round)
                    .HasColumnName("round")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Won)
                    .HasColumnName("won")
                    .HasColumnType("bigint(30) unsigned")
                    .HasDefaultValueSql("0");
            });
        }
    }
}
