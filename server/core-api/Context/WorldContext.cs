using Microsoft.EntityFrameworkCore;
using server.Data.World;

namespace server.Context
{
    public abstract class WorldContext : DbContext
    {
        protected WorldContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<AccessRequirement> AccessRequirement { get; set; }
        public virtual DbSet<AchievementCriteriaData> AchievementCriteriaData { get; set; }
        public virtual DbSet<AchievementDbc> AchievementDbc { get; set; }
        public virtual DbSet<AchievementReward> AchievementReward { get; set; }
        public virtual DbSet<AchievementRewardLocale> AchievementRewardLocale { get; set; }
        public virtual DbSet<AreatriggerInvolvedrelation> AreatriggerInvolvedrelation { get; set; }
        public virtual DbSet<AreatriggerScripts> AreatriggerScripts { get; set; }
        public virtual DbSet<AreatriggerTavern> AreatriggerTavern { get; set; }
        public virtual DbSet<AreatriggerTeleport> AreatriggerTeleport { get; set; }
        public virtual DbSet<ArenaLogsReport> ArenaLogsReport { get; set; }
        public virtual DbSet<BattlegroundTemplate> BattlegroundTemplate { get; set; }
        public virtual DbSet<BattlemasterEntry> BattlemasterEntry { get; set; }
        public virtual DbSet<BroadcastText> BroadcastText { get; set; }
        public virtual DbSet<BroadcastTextLocale> BroadcastTextLocale { get; set; }
        public virtual DbSet<CheckDonationPurchases> CheckDonationPurchases { get; set; }
        public virtual DbSet<Command> Command { get; set; }
        public virtual DbSet<Conditions> Conditions { get; set; }
        public virtual DbSet<ConfigBool> ConfigBool { get; set; }
        public virtual DbSet<ConfigFloat> ConfigFloat { get; set; }
        public virtual DbSet<ConfigInt> ConfigInt { get; set; }
        public virtual DbSet<ConfigLocations> ConfigLocations { get; set; }
        public virtual DbSet<ConfigRates> ConfigRates { get; set; }
        public virtual DbSet<ConfigString> ConfigString { get; set; }
        public virtual DbSet<Creature> Creature { get; set; }
        public virtual DbSet<CreatureAddon> CreatureAddon { get; set; }
        public virtual DbSet<CreatureClasslevelstats> CreatureClasslevelstats { get; set; }
        public virtual DbSet<CreatureDefaultTrainer> CreatureDefaultTrainer { get; set; }
        public virtual DbSet<CreatureEquipTemplate> CreatureEquipTemplate { get; set; }
        public virtual DbSet<CreatureFormations> CreatureFormations { get; set; }
        public virtual DbSet<CreatureLootTemplate> CreatureLootTemplate { get; set; }
        public virtual DbSet<CreatureModelInfo> CreatureModelInfo { get; set; }
        public virtual DbSet<CreatureMovementOverride> CreatureMovementOverride { get; set; }
        public virtual DbSet<CreatureOnkillReputation> CreatureOnkillReputation { get; set; }
        public virtual DbSet<CreatureQuestender> CreatureQuestender { get; set; }
        public virtual DbSet<CreatureQuestitem> CreatureQuestitem { get; set; }
        public virtual DbSet<CreatureQueststarter> CreatureQueststarter { get; set; }
        public virtual DbSet<CreatureTemplate> CreatureTemplate { get; set; }
        public virtual DbSet<CreatureTemplateAddon> CreatureTemplateAddon { get; set; }
        public virtual DbSet<CreatureTemplateLocale> CreatureTemplateLocale { get; set; }
        public virtual DbSet<CreatureTemplateMovement> CreatureTemplateMovement { get; set; }
        public virtual DbSet<CreatureTemplateResistance> CreatureTemplateResistance { get; set; }
        public virtual DbSet<CreatureTemplateSpell> CreatureTemplateSpell { get; set; }
        public virtual DbSet<CreatureText> CreatureText { get; set; }
        public virtual DbSet<CreatureTextLocale> CreatureTextLocale { get; set; }
        public virtual DbSet<CustomBattlegroundquests> CustomBattlegroundquests { get; set; }
        public virtual DbSet<CustomBossData> CustomBossData { get; set; }
        public virtual DbSet<CustomConditionInfo> CustomConditionInfo { get; set; }
        public virtual DbSet<CustomConditions> CustomConditions { get; set; }
        public virtual DbSet<CustomEnchanter> CustomEnchanter { get; set; }
        public virtual DbSet<CustomFfaAreas> CustomFfaAreas { get; set; }
        public virtual DbSet<CustomItemUpgrades> CustomItemUpgrades { get; set; }
        public virtual DbSet<CustomNoFlyAreas> CustomNoFlyAreas { get; set; }
        public virtual DbSet<CustomNoGroupAreas> CustomNoGroupAreas { get; set; }
        public virtual DbSet<CustomRanks> CustomRanks { get; set; }
        public virtual DbSet<CustomRewards> CustomRewards { get; set; }
        public virtual DbSet<CustomRewardsType> CustomRewardsType { get; set; }
        public virtual DbSet<CustomSanctuaryAreas> CustomSanctuaryAreas { get; set; }
        public virtual DbSet<CustomSharedLoot> CustomSharedLoot { get; set; }
        public virtual DbSet<CustomTeleporter> CustomTeleporter { get; set; }
        public virtual DbSet<Dailyquests> Dailyquests { get; set; }
        public virtual DbSet<Disables> Disables { get; set; }
        public virtual DbSet<DisenchantLootTemplate> DisenchantLootTemplate { get; set; }
        public virtual DbSet<ExplorationBasexp> ExplorationBasexp { get; set; }
        public virtual DbSet<FishingLootTemplate> FishingLootTemplate { get; set; }
        public virtual DbSet<GameEvent> GameEvent { get; set; }
        public virtual DbSet<GameEventBattlegroundHoliday> GameEventBattlegroundHoliday { get; set; }
        public virtual DbSet<GameEventCondition> GameEventCondition { get; set; }
        public virtual DbSet<GameEventCreature> GameEventCreature { get; set; }
        public virtual DbSet<GameEventCreatureQuest> GameEventCreatureQuest { get; set; }
        public virtual DbSet<GameEventGameobject> GameEventGameobject { get; set; }
        public virtual DbSet<GameEventGameobjectQuest> GameEventGameobjectQuest { get; set; }
        public virtual DbSet<GameEventModelEquip> GameEventModelEquip { get; set; }
        public virtual DbSet<GameEventNpcVendor> GameEventNpcVendor { get; set; }
        public virtual DbSet<GameEventNpcflag> GameEventNpcflag { get; set; }
        public virtual DbSet<GameEventPool> GameEventPool { get; set; }
        public virtual DbSet<GameEventPrerequisite> GameEventPrerequisite { get; set; }
        public virtual DbSet<GameEventQuestCondition> GameEventQuestCondition { get; set; }
        public virtual DbSet<GameEventSeasonalQuestrelation> GameEventSeasonalQuestrelation { get; set; }
        public virtual DbSet<GameTele> GameTele { get; set; }
        public virtual DbSet<GameWeather> GameWeather { get; set; }
        public virtual DbSet<Gameobject> Gameobject { get; set; }
        public virtual DbSet<GameobjectAddon> GameobjectAddon { get; set; }
        public virtual DbSet<GameobjectLootTemplate> GameobjectLootTemplate { get; set; }
        public virtual DbSet<GameobjectOverrides> GameobjectOverrides { get; set; }
        public virtual DbSet<GameobjectQuestender> GameobjectQuestender { get; set; }
        public virtual DbSet<GameobjectQuestitem> GameobjectQuestitem { get; set; }
        public virtual DbSet<GameobjectQueststarter> GameobjectQueststarter { get; set; }
        public virtual DbSet<GameobjectTemplate> GameobjectTemplate { get; set; }
        public virtual DbSet<GameobjectTemplateAddon> GameobjectTemplateAddon { get; set; }
        public virtual DbSet<GameobjectTemplateLocale> GameobjectTemplateLocale { get; set; }
        public virtual DbSet<GossipMenu> GossipMenu { get; set; }
        public virtual DbSet<GossipMenuOption> GossipMenuOption { get; set; }
        public virtual DbSet<GossipMenuOptionLocale> GossipMenuOptionLocale { get; set; }
        public virtual DbSet<GraveyardZone> GraveyardZone { get; set; }
        public virtual DbSet<GuildBonusInfo> GuildBonusInfo { get; set; }
        public virtual DbSet<GuildXpRequiredForLevel> GuildXpRequiredForLevel { get; set; }
        public virtual DbSet<HolidayDates> HolidayDates { get; set; }
        public virtual DbSet<InstanceEncounters> InstanceEncounters { get; set; }
        public virtual DbSet<InstanceSpawnGroups> InstanceSpawnGroups { get; set; }
        public virtual DbSet<InstanceTemplate> InstanceTemplate { get; set; }
        public virtual DbSet<ItemEnchantmentTemplate> ItemEnchantmentTemplate { get; set; }
        public virtual DbSet<ItemLootTemplate> ItemLootTemplate { get; set; }
        public virtual DbSet<ItemSetNames> ItemSetNames { get; set; }
        public virtual DbSet<ItemSetNamesLocale> ItemSetNamesLocale { get; set; }
        public virtual DbSet<ItemTemplate> ItemTemplate { get; set; }
        public virtual DbSet<ItemTemplateLocale> ItemTemplateLocale { get; set; }
        public virtual DbSet<LfgDungeonRewards> LfgDungeonRewards { get; set; }
        public virtual DbSet<LfgDungeonTemplate> LfgDungeonTemplate { get; set; }
        public virtual DbSet<LinkedRespawn> LinkedRespawn { get; set; }
        public virtual DbSet<MailLevelReward> MailLevelReward { get; set; }
        public virtual DbSet<MailLootTemplate> MailLootTemplate { get; set; }
        public virtual DbSet<MillingLootTemplate> MillingLootTemplate { get; set; }
        public virtual DbSet<NpcSpellclickSpells> NpcSpellclickSpells { get; set; }
        public virtual DbSet<NpcText> NpcText { get; set; }
        public virtual DbSet<NpcTextLocale> NpcTextLocale { get; set; }
        public virtual DbSet<NpcVendor> NpcVendor { get; set; }
        public virtual DbSet<OutdoorpvpTemplate> OutdoorpvpTemplate { get; set; }
        public virtual DbSet<PageText> PageText { get; set; }
        public virtual DbSet<PageTextLocale> PageTextLocale { get; set; }
        public virtual DbSet<PetLevelstats> PetLevelstats { get; set; }
        public virtual DbSet<PetNameGeneration> PetNameGeneration { get; set; }
        public virtual DbSet<PickpocketingLootTemplate> PickpocketingLootTemplate { get; set; }
        public virtual DbSet<PlayerClasslevelstats> PlayerClasslevelstats { get; set; }
        public virtual DbSet<PlayerFactionchangeAchievement> PlayerFactionchangeAchievement { get; set; }
        public virtual DbSet<PlayerFactionchangeItems> PlayerFactionchangeItems { get; set; }
        public virtual DbSet<PlayerFactionchangeQuests> PlayerFactionchangeQuests { get; set; }
        public virtual DbSet<PlayerFactionchangeReputations> PlayerFactionchangeReputations { get; set; }
        public virtual DbSet<PlayerFactionchangeSpells> PlayerFactionchangeSpells { get; set; }
        public virtual DbSet<PlayerFactionchangeTitles> PlayerFactionchangeTitles { get; set; }
        public virtual DbSet<PlayerLevelstats> PlayerLevelstats { get; set; }
        public virtual DbSet<PlayerTotemModel> PlayerTotemModel { get; set; }
        public virtual DbSet<PlayerXpForLevel> PlayerXpForLevel { get; set; }
        public virtual DbSet<Playercreateinfo> Playercreateinfo { get; set; }
        public virtual DbSet<PlayercreateinfoAction> PlayercreateinfoAction { get; set; }
        public virtual DbSet<PlayercreateinfoItem> PlayercreateinfoItem { get; set; }
        public virtual DbSet<PlayercreateinfoSkills> PlayercreateinfoSkills { get; set; }
        public virtual DbSet<PlayercreateinfoSpellCustom> PlayercreateinfoSpellCustom { get; set; }
        public virtual DbSet<PlayerhouseAreaModifier> PlayerhouseAreaModifier { get; set; }
        public virtual DbSet<PlayerhouseMembers> PlayerhouseMembers { get; set; }
        public virtual DbSet<PlayerhouseNpcShop> PlayerhouseNpcShop { get; set; }
        public virtual DbSet<PlayerhouseSpawnTypes> PlayerhouseSpawnTypes { get; set; }
        public virtual DbSet<PlayerhouseSpawns> PlayerhouseSpawns { get; set; }
        public virtual DbSet<PlayerhouseVendor> PlayerhouseVendor { get; set; }
        public virtual DbSet<Playerhouses> Playerhouses { get; set; }
        public virtual DbSet<PointsOfInterest> PointsOfInterest { get; set; }
        public virtual DbSet<PointsOfInterestLocale> PointsOfInterestLocale { get; set; }
        public virtual DbSet<PoolMembers> PoolMembers { get; set; }
        public virtual DbSet<PoolTemplate> PoolTemplate { get; set; }
        public virtual DbSet<ProspectingLootTemplate> ProspectingLootTemplate { get; set; }
        public virtual DbSet<PvpdifficultyDbc> PvpdifficultyDbc { get; set; }
        public virtual DbSet<QuestDetails> QuestDetails { get; set; }
        public virtual DbSet<QuestGreeting> QuestGreeting { get; set; }
        public virtual DbSet<QuestGreetingLocale> QuestGreetingLocale { get; set; }
        public virtual DbSet<QuestMailSender> QuestMailSender { get; set; }
        public virtual DbSet<QuestOfferReward> QuestOfferReward { get; set; }
        public virtual DbSet<QuestOfferRewardLocale> QuestOfferRewardLocale { get; set; }
        public virtual DbSet<QuestPoi> QuestPoi { get; set; }
        public virtual DbSet<QuestPoiPoints> QuestPoiPoints { get; set; }
        public virtual DbSet<QuestPoolMembers> QuestPoolMembers { get; set; }
        public virtual DbSet<QuestPoolTemplate> QuestPoolTemplate { get; set; }
        public virtual DbSet<QuestRequestItems> QuestRequestItems { get; set; }
        public virtual DbSet<QuestRequestItemsLocale> QuestRequestItemsLocale { get; set; }
        public virtual DbSet<QuestTemplate> QuestTemplate { get; set; }
        public virtual DbSet<QuestTemplateAddon> QuestTemplateAddon { get; set; }
        public virtual DbSet<QuestTemplateLocale> QuestTemplateLocale { get; set; }
        public virtual DbSet<RaceEventChopperlocations> RaceEventChopperlocations { get; set; }
        public virtual DbSet<RaceEventData> RaceEventData { get; set; }
        public virtual DbSet<RaceEventStartlocations> RaceEventStartlocations { get; set; }
        public virtual DbSet<RandomBossSpawns> RandomBossSpawns { get; set; }
        public virtual DbSet<RandomPigSpawns> RandomPigSpawns { get; set; }
        public virtual DbSet<ReferenceLootTemplate> ReferenceLootTemplate { get; set; }
        public virtual DbSet<ReputationRewardRate> ReputationRewardRate { get; set; }
        public virtual DbSet<ReputationSpilloverTemplate> ReputationSpilloverTemplate { get; set; }
        public virtual DbSet<ScriptSplineChainMeta> ScriptSplineChainMeta { get; set; }
        public virtual DbSet<ScriptSplineChainWaypoints> ScriptSplineChainWaypoints { get; set; }
        public virtual DbSet<ScriptWaypoint> ScriptWaypoint { get; set; }
        public virtual DbSet<SkillDiscoveryTemplate> SkillDiscoveryTemplate { get; set; }
        public virtual DbSet<SkillExtraItemTemplate> SkillExtraItemTemplate { get; set; }
        public virtual DbSet<SkillFishingBaseLevel> SkillFishingBaseLevel { get; set; }
        public virtual DbSet<SkillPerfectItemTemplate> SkillPerfectItemTemplate { get; set; }
        public virtual DbSet<SkinningLootTemplate> SkinningLootTemplate { get; set; }
        public virtual DbSet<SmartScripts> SmartScripts { get; set; }
        public virtual DbSet<SpawnGroup> SpawnGroup { get; set; }
        public virtual DbSet<SpawnGroupTemplate> SpawnGroupTemplate { get; set; }
        public virtual DbSet<SpellArea> SpellArea { get; set; }
        public virtual DbSet<SpellBonusData> SpellBonusData { get; set; }
        public virtual DbSet<SpellCustomAttr> SpellCustomAttr { get; set; }
        public virtual DbSet<SpellDbc> SpellDbc { get; set; }
        public virtual DbSet<SpellEnchantProcData> SpellEnchantProcData { get; set; }
        public virtual DbSet<SpellGroup> SpellGroup { get; set; }
        public virtual DbSet<SpellGroupStackRules> SpellGroupStackRules { get; set; }
        public virtual DbSet<SpellLearnSpell> SpellLearnSpell { get; set; }
        public virtual DbSet<SpellLootTemplate> SpellLootTemplate { get; set; }
        public virtual DbSet<SpellPetAuras> SpellPetAuras { get; set; }
        public virtual DbSet<SpellProc> SpellProc { get; set; }
        public virtual DbSet<SpellRanks> SpellRanks { get; set; }
        public virtual DbSet<SpellRequired> SpellRequired { get; set; }
        public virtual DbSet<SpellTargetPosition> SpellTargetPosition { get; set; }
        public virtual DbSet<SpellThreat> SpellThreat { get; set; }
        public virtual DbSet<SpelldifficultyDbc> SpelldifficultyDbc { get; set; }
        public virtual DbSet<Spellregulator> Spellregulator { get; set; }
        public virtual DbSet<Trainer> Trainer { get; set; }
        public virtual DbSet<TrainerLocale> TrainerLocale { get; set; }
        public virtual DbSet<TrainerSpell> TrainerSpell { get; set; }
        public virtual DbSet<Transports> Transports { get; set; }
        public virtual DbSet<TrinityString> TrinityString { get; set; }
        public virtual DbSet<Updates> Updates { get; set; }
        public virtual DbSet<UpdatesInclude> UpdatesInclude { get; set; }
        public virtual DbSet<VehicleAccessory> VehicleAccessory { get; set; }
        public virtual DbSet<VehicleTemplateAccessory> VehicleTemplateAccessory { get; set; }
        public virtual DbSet<WardenChecks> WardenChecks { get; set; }
        public virtual DbSet<WaypointData> WaypointData { get; set; }
        public virtual DbSet<WaypointScripts> WaypointScripts { get; set; }
        public virtual DbSet<Waypoints> Waypoints { get; set; }
        public virtual DbSet<ZombieDeathmatchRewards> ZombieDeathmatchRewards { get; set; }
        public virtual DbSet<ZombieDeathmatchRounds> ZombieDeathmatchRounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AccessRequirement>(entity =>
            {
                entity.HasKey(e => new { e.MapId, e.Difficulty });

                entity.ToTable("access_requirement");

                entity.Property(e => e.MapId)
                    .HasColumnName("mapId")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.Difficulty)
                    .HasColumnName("difficulty")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.CompletedAchievement)
                    .HasColumnName("completed_achievement")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cond)
                    .HasColumnName("cond")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item2)
                    .HasColumnName("item2")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemLevel)
                    .HasColumnName("item_level")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LevelMax)
                    .HasColumnName("level_max")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LevelMin)
                    .HasColumnName("level_min")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestDoneA)
                    .HasColumnName("quest_done_A")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestDoneH)
                    .HasColumnName("quest_done_H")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestFailedText)
                    .HasColumnName("quest_failed_text")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AchievementCriteriaData>(entity =>
            {
                entity.HasKey(e => new { e.CriteriaId, e.Type });

                entity.ToTable("achievement_criteria_data");

                entity.Property(e => e.CriteriaId)
                    .HasColumnName("criteria_id")
                    .HasColumnType("mediumint");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasColumnType("char(64)");

                entity.Property(e => e.Value1)
                    .HasColumnName("value1")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Value2)
                    .HasColumnName("value2")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AchievementDbc>(entity =>
            {
                entity.ToTable("achievement_dbc");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnName("mapID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RefAchievement)
                    .HasColumnName("refAchievement")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredFaction)
                    .HasColumnName("requiredFaction")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");
            });

            modelBuilder.Entity<AchievementReward>(entity =>
            {
                entity.ToTable("achievement_reward");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MailTemplateId)
                    .HasColumnName("MailTemplateID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sender)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TitleA)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TitleH)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AchievementRewardLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("achievement_reward_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.Subject).IsUnicode(false);
            });

            modelBuilder.Entity<AreatriggerInvolvedrelation>(entity =>
            {
                entity.ToTable("areatrigger_involvedrelation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AreatriggerScripts>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("areatrigger_scripts");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint")
                    .ValueGeneratedNever();

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasColumnType("char(64)");
            });

            modelBuilder.Entity<AreatriggerTavern>(entity =>
            {
                entity.ToTable("areatrigger_tavern");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AreatriggerTeleport>(entity =>
            {
                entity.ToTable("areatrigger_teleport");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.TargetMap)
                    .HasColumnName("target_map")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetOrientation)
                    .HasColumnName("target_orientation")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetPositionX)
                    .HasColumnName("target_position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetPositionY)
                    .HasColumnName("target_position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetPositionZ)
                    .HasColumnName("target_position_z")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ArenaLogsReport>(entity =>
            {
                entity.ToTable("arena_logs_report");

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.LoserTeamId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.WinnerTeamId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<BattlegroundTemplate>(entity =>
            {
                entity.ToTable("battleground_template");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AllianceStartLoc).HasColumnType("mediumint unsigned");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnType("char(32)");

                entity.Property(e => e.HordeStartLoc).HasColumnType("mediumint unsigned");

                entity.Property(e => e.MaxLvl)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxPlayersPerTeam)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinLvl)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinPlayersPerTeam)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasColumnType("char(64)");

                entity.Property(e => e.StartMaxDist).HasDefaultValueSql("0");

                entity.Property(e => e.Weight)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<BattlemasterEntry>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("battlemaster_entry");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BgTemplate)
                    .HasColumnName("bg_template")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<BroadcastText>(entity =>
            {
                entity.ToTable("broadcast_text");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay0)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay1)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay2)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteId0)
                    .HasColumnName("EmoteID0")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteId1)
                    .HasColumnName("EmoteID1")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteId2)
                    .HasColumnName("EmoteID2")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FemaleText).HasColumnType("longtext");

                entity.Property(e => e.Language)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaleText).HasColumnType("longtext");

                entity.Property(e => e.SoundId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Unk1)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Unk2)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<BroadcastTextLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("broadcast_text_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FemaleText).IsUnicode(false);

                entity.Property(e => e.MaleText).IsUnicode(false);
            });

            modelBuilder.Entity<CheckDonationPurchases>(entity =>
            {
                entity.ToTable("check_donation_purchases");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.AccId)
                    .HasColumnName("accId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("int");

                entity.Property(e => e.CharName)
                    .IsRequired()
                    .HasColumnName("charName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("int");
            });

            modelBuilder.Entity<Command>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("command");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Help)
                    .HasColumnName("help")
                    .HasColumnType("longtext");

                entity.Property(e => e.Permission)
                    .HasColumnName("permission")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Conditions>(entity =>
            {
                entity.HasKey(e => new { e.SourceTypeOrReferenceId, e.SourceGroup, e.SourceEntry, e.SourceId, e.ElseGroup, e.ConditionTypeOrReference, e.ConditionTarget, e.ConditionValue1, e.ConditionValue2, e.ConditionValue3 });

                entity.ToTable("conditions");

                entity.Property(e => e.SourceTypeOrReferenceId)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SourceGroup)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SourceEntry)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SourceId)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ElseGroup)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ConditionTypeOrReference)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ConditionTarget)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ConditionValue1)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ConditionValue2)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ConditionValue3)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorTextId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ErrorType)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NegativeCondition)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasColumnType("char(64)");
            });

            modelBuilder.Entity<ConfigBool>(entity =>
            {
                entity.ToTable("config_bool");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnName("config")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ConfigFloat>(entity =>
            {
                entity.ToTable("config_float");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnName("config")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ConfigInt>(entity =>
            {
                entity.ToTable("config_int");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnName("config")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ConfigLocations>(entity =>
            {
                entity.HasKey(e => e.Config);

                entity.ToTable("config_locations");

                entity.Property(e => e.Config)
                    .HasColumnName("config")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.O)
                    .HasColumnName("o")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ConfigRates>(entity =>
            {
                entity.ToTable("config_rates");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnName("config")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ConfigString>(entity =>
            {
                entity.ToTable("config_string");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnName("config")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Creature>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("creature");

                entity.HasIndex(e => e.Id)
                    .HasName("idx_id");

                entity.HasIndex(e => e.Map)
                    .HasName("idx_map");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Curhealth)
                    .HasColumnName("curhealth")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Curmana)
                    .HasColumnName("curmana")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Currentwaypoint)
                    .HasColumnName("currentwaypoint")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dynamicflags)
                    .HasColumnName("dynamicflags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EquipmentId)
                    .HasColumnName("equipment_id")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modelid)
                    .HasColumnName("modelid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MovementType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Npcflag)
                    .HasColumnName("npcflag")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Orientation)
                    .HasColumnName("orientation")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PhaseMask)
                    .HasColumnName("phaseMask")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScriptName).HasColumnType("char(64)");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpawnMask)
                    .HasColumnName("spawnMask")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Spawndist)
                    .HasColumnName("spawndist")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spawntimesecs)
                    .HasColumnName("spawntimesecs")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("120");

                entity.Property(e => e.UnitFlags)
                    .HasColumnName("unit_flags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zoneId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureAddon>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("creature_addon");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Auras)
                    .HasColumnName("auras")
                    .IsUnicode(false);

                entity.Property(e => e.Bytes1)
                    .HasColumnName("bytes1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bytes2)
                    .HasColumnName("bytes2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote)
                    .HasColumnName("emote")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mount)
                    .HasColumnName("mount")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PathId)
                    .HasColumnName("path_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VisibilityDistanceType)
                    .HasColumnName("visibilityDistanceType")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureClasslevelstats>(entity =>
            {
                entity.HasKey(e => new { e.Level, e.Class });

                entity.ToTable("creature_classlevelstats");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Attackpower)
                    .HasColumnName("attackpower")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Basearmor)
                    .HasColumnName("basearmor")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Basehp0)
                    .HasColumnName("basehp0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Basehp1)
                    .HasColumnName("basehp1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Basehp2)
                    .HasColumnName("basehp2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Basemana)
                    .HasColumnName("basemana")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.DamageBase)
                    .HasColumnName("damage_base")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DamageExp1)
                    .HasColumnName("damage_exp1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DamageExp2)
                    .HasColumnName("damage_exp2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rangedattackpower)
                    .HasColumnName("rangedattackpower")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureDefaultTrainer>(entity =>
            {
                entity.HasKey(e => e.CreatureId);

                entity.ToTable("creature_default_trainer");

                entity.Property(e => e.CreatureId)
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.TrainerId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureEquipTemplate>(entity =>
            {
                entity.HasKey(e => new { e.CreatureId, e.Id });

                entity.ToTable("creature_equip_template");

                entity.Property(e => e.CreatureId)
                    .HasColumnName("CreatureID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ItemId1)
                    .HasColumnName("ItemID1")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemId2)
                    .HasColumnName("ItemID2")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemId3)
                    .HasColumnName("ItemID3")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureFormations>(entity =>
            {
                entity.HasKey(e => e.MemberGuid);

                entity.ToTable("creature_formations");

                entity.Property(e => e.MemberGuid)
                    .HasColumnName("memberGUID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Angle)
                    .HasColumnName("angle")
                    .HasColumnType("float unsigned");

                entity.Property(e => e.Dist)
                    .HasColumnName("dist")
                    .HasColumnType("float unsigned");

                entity.Property(e => e.GroupAi)
                    .HasColumnName("groupAI")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.LeaderGuid)
                    .HasColumnName("leaderGUID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Point1)
                    .HasColumnName("point_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Point2)
                    .HasColumnName("point_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("creature_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureModelInfo>(entity =>
            {
                entity.HasKey(e => e.DisplayId);

                entity.ToTable("creature_model_info");

                entity.Property(e => e.DisplayId)
                    .HasColumnName("DisplayID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BoundingRadius).HasDefaultValueSql("0");

                entity.Property(e => e.CombatReach).HasDefaultValueSql("0");

                entity.Property(e => e.DisplayIdOtherGender)
                    .HasColumnName("DisplayID_Other_Gender")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Gender)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("2");
            });

            modelBuilder.Entity<CreatureMovementOverride>(entity =>
            {
                entity.HasKey(e => e.SpawnId);

                entity.ToTable("creature_movement_override");

                entity.Property(e => e.SpawnId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chase)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flight)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ground)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Random)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rooted)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Swim)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<CreatureOnkillReputation>(entity =>
            {
                entity.HasKey(e => e.CreatureId);

                entity.ToTable("creature_onkill_reputation");

                entity.Property(e => e.CreatureId)
                    .HasColumnName("creature_id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsTeamAward1)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsTeamAward2)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxStanding1)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxStanding2)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewOnKillRepFaction1)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewOnKillRepFaction2)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewOnKillRepValue1)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewOnKillRepValue2)
                    .HasColumnType("mediumint(9)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TeamDependent)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureQuestender>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Quest });

                entity.ToTable("creature_questender");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureQuestitem>(entity =>
            {
                entity.HasKey(e => new { e.CreatureEntry, e.Idx });

                entity.ToTable("creature_questitem");

                entity.Property(e => e.CreatureEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Idx)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureQueststarter>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Quest });

                entity.ToTable("creature_queststarter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureTemplate>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("creature_template");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_name");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ainame)
                    .IsRequired()
                    .HasColumnName("AIName")
                    .HasColumnType("char(64)");

                entity.Property(e => e.ArmorModifier).HasDefaultValueSql("1");

                entity.Property(e => e.BaseAttackTime)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BaseVariance).HasDefaultValueSql("1");

                entity.Property(e => e.DamageModifier).HasDefaultValueSql("1");

                entity.Property(e => e.DifficultyEntry1)
                    .HasColumnName("difficulty_entry_1")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DifficultyEntry2)
                    .HasColumnName("difficulty_entry_2")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DifficultyEntry3)
                    .HasColumnName("difficulty_entry_3")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dmgschool)
                    .HasColumnName("dmgschool")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dynamicflags)
                    .HasColumnName("dynamicflags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Exp)
                    .HasColumnName("exp")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExperienceModifier).HasDefaultValueSql("1");

                entity.Property(e => e.Faction)
                    .HasColumnName("faction")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Family)
                    .HasColumnName("family")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FlagsExtra)
                    .HasColumnName("flags_extra")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GossipMenuId)
                    .HasColumnName("gossip_menu_id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HealthModifier).HasDefaultValueSql("1");

                entity.Property(e => e.HoverHeight).HasDefaultValueSql("1");

                entity.Property(e => e.IconName).HasColumnType("char(100)");

                entity.Property(e => e.KillCredit1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.KillCredit2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lootid)
                    .HasColumnName("lootid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ManaModifier).HasDefaultValueSql("1");

                entity.Property(e => e.Maxgold)
                    .HasColumnName("maxgold")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Maxlevel)
                    .HasColumnName("maxlevel")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MechanicImmuneMask)
                    .HasColumnName("mechanic_immune_mask")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mingold)
                    .HasColumnName("mingold")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Minlevel)
                    .HasColumnName("minlevel")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Modelid1)
                    .HasColumnName("modelid1")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modelid2)
                    .HasColumnName("modelid2")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modelid3)
                    .HasColumnName("modelid3")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modelid4)
                    .HasColumnName("modelid4")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MovementId)
                    .HasColumnName("movementId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MovementType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(100)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Npcflag)
                    .HasColumnName("npcflag")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PetSpellDataId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pickpocketloot)
                    .HasColumnName("pickpocketloot")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RacialLeader)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RangeAttackTime)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RangeVariance).HasDefaultValueSql("1");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RegenHealth)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Scale)
                    .HasColumnName("scale")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasColumnType("char(64)");

                entity.Property(e => e.Skinloot)
                    .HasColumnName("skinloot")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpeedRun)
                    .HasColumnName("speed_run")
                    .HasDefaultValueSql("1.14286");

                entity.Property(e => e.SpeedWalk)
                    .HasColumnName("speed_walk")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SpellSchoolImmuneMask)
                    .HasColumnName("spell_school_immune_mask")
                    .HasColumnType("int(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Subname)
                    .HasColumnName("subname")
                    .HasColumnType("char(100)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TypeFlags)
                    .HasColumnName("type_flags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitClass)
                    .HasColumnName("unit_class")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitFlags)
                    .HasColumnName("unit_flags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitFlags2)
                    .HasColumnName("unit_flags2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureTemplateAddon>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("creature_template_addon");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Auras)
                    .HasColumnName("auras")
                    .IsUnicode(false);

                entity.Property(e => e.Bytes1)
                    .HasColumnName("bytes1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bytes2)
                    .HasColumnName("bytes2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote)
                    .HasColumnName("emote")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mount)
                    .HasColumnName("mount")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PathId)
                    .HasColumnName("path_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VisibilityDistanceType)
                    .HasColumnName("visibilityDistanceType")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureTemplateLocale>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Locale });

                entity.ToTable("creature_template_locale");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<CreatureTemplateMovement>(entity =>
            {
                entity.HasKey(e => e.CreatureId);

                entity.ToTable("creature_template_movement");

                entity.Property(e => e.CreatureId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chase)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flight)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ground)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Random)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rooted)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Swim)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<CreatureTemplateResistance>(entity =>
            {
                entity.HasKey(e => new { e.CreatureId, e.School });

                entity.ToTable("creature_template_resistance");

                entity.Property(e => e.CreatureId)
                    .HasColumnName("CreatureID")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.School).HasColumnType("tinyint(6) unsigned");

                entity.Property(e => e.Resistance).HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<CreatureTemplateSpell>(entity =>
            {
                entity.HasKey(e => new { e.CreatureId, e.Index });

                entity.ToTable("creature_template_spell");

                entity.Property(e => e.CreatureId)
                    .HasColumnName("CreatureID")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.Index)
                    .HasColumnType("tinyint(6) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spell).HasColumnType("mediumint unsigned");
            });

            modelBuilder.Entity<CreatureText>(entity =>
            {
                entity.HasKey(e => new { e.CreatureId, e.GroupId, e.Id });

                entity.ToTable("creature_text");

                entity.Property(e => e.CreatureId)
                    .HasColumnName("CreatureID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupID")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId)
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Language)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Probability)
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sound)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Text).HasColumnType("longtext");

                entity.Property(e => e.TextRange)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CreatureTextLocale>(entity =>
            {
                entity.HasKey(e => new { e.CreatureId, e.GroupId, e.Id });

                entity.ToTable("creature_text_locale");

                entity.Property(e => e.CreatureId)
                    .HasColumnName("CreatureID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupID")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Text).IsUnicode(false);
            });

            modelBuilder.Entity<CustomBattlegroundquests>(entity =>
            {
                entity.HasKey(e => new { e.MapId, e.QuestId, e.MonsterCredit, e.Type });

                entity.ToTable("custom_battlegroundquests");

                entity.Property(e => e.MapId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MonsterCredit)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomBossData>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.SpellId });

                entity.ToTable("custom_boss_data");

                entity.Property(e => e.Entry).HasColumnType("int unsigned");

                entity.Property(e => e.SpellId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsPct)
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpellMaxDamage)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellMinDamage)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TimeBetweenCast)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("20");
            });

            modelBuilder.Entity<CustomConditionInfo>(entity =>
            {
                entity.HasKey(e => e.ConditionType);

                entity.ToTable("custom_condition_info");

                entity.Property(e => e.ConditionType)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ConditionInformation).IsUnicode(false);
            });

            modelBuilder.Entity<CustomConditions>(entity =>
            {
                entity.ToTable("custom_conditions");

                entity.HasIndex(e => e.CondReqType)
                    .HasName("FK_COND_TYPES");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CondReqEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CondReqType)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CondReqValue)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CondReqTypeNavigation)
                    .WithMany(p => p.CustomConditions)
                    .HasForeignKey(d => d.CondReqType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("custom_conditions_ibfk_1");
            });

            modelBuilder.Entity<CustomEnchanter>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SpellId, e.Slot });

                entity.ToTable("custom_enchanter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SpellId)
                    .HasColumnName("SpellID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Slot)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cond)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RequiredItemLevel)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sort)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomFfaAreas>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("custom_ffa_areas");

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomItemUpgrades>(entity =>
            {
                entity.ToTable("custom_item_upgrades");

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.AllowableInvTypes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ConditionId)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredLevel)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatLevel)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomNoFlyAreas>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("custom_no_fly_areas");

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomNoGroupAreas>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("custom_no_group_areas");

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomRanks>(entity =>
            {
                entity.HasKey(e => e.RankPointsNeeded);

                entity.ToTable("custom_ranks");

                entity.Property(e => e.RankPointsNeeded)
                    .HasColumnName("rankPointsNeeded")
                    .HasColumnType("smallint unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.RankColor)
                    .IsRequired()
                    .HasColumnName("rankColor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RankIconA)
                    .IsRequired()
                    .HasColumnName("rankIconA")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RankIconH)
                    .IsRequired()
                    .HasColumnName("rankIconH")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RankNameA)
                    .IsRequired()
                    .HasColumnName("rankNameA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RankNameH)
                    .IsRequired()
                    .HasColumnName("rankNameH")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomRewards>(entity =>
            {
                entity.HasKey(e => new { e.Target, e.Entry, e.Count, e.Type });

                entity.ToTable("custom_rewards");

                entity.HasIndex(e => e.Type)
                    .HasName("Type");

                entity.Property(e => e.Target)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Entry).HasColumnType("int unsigned");

                entity.Property(e => e.Count)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.CustomRewards)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("custom_rewards_ibfk_1");
            });

            modelBuilder.Entity<CustomRewardsType>(entity =>
            {
                entity.ToTable("custom_rewards_type");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomSanctuaryAreas>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("custom_sanctuary_areas");

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomSharedLoot>(entity =>
            {
                entity.HasKey(e => new { e.CreatureEntry, e.ItemEntry });

                entity.ToTable("custom_shared_loot");

                entity.Property(e => e.CreatureEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("0");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinCount)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<CustomTeleporter>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Map, e.X });

                entity.ToTable("custom_teleporter");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Near)
                    .HasColumnName("near")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.O).HasColumnName("o");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.Property(e => e.Z).HasColumnName("z");
            });

            modelBuilder.Entity<Dailyquests>(entity =>
            {
                entity.HasKey(e => e.QuestId);

                entity.ToTable("dailyquests");

                entity.Property(e => e.QuestId)
                    .HasColumnName("questId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Disables>(entity =>
            {
                entity.HasKey(e => new { e.SourceType, e.Entry });

                entity.ToTable("disables");

                entity.Property(e => e.SourceType)
                    .HasColumnName("sourceType")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("smallint");

                entity.Property(e => e.Params0)
                    .IsRequired()
                    .HasColumnName("params_0")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Params1)
                    .IsRequired()
                    .HasColumnName("params_1")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DisenchantLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("disenchant_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ExplorationBasexp>(entity =>
            {
                entity.HasKey(e => e.Level);

                entity.ToTable("exploration_basexp");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Basexp)
                    .HasColumnName("basexp")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<FishingLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("fishing_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEvent>(entity =>
            {
                entity.HasKey(e => e.EventEntry);

                entity.ToTable("game_event");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Announce)
                    .HasColumnName("announce")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.Holiday)
                    .HasColumnName("holiday")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HolidayStage)
                    .HasColumnName("holidayStage")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("2592000");

                entity.Property(e => e.Occurence)
                    .HasColumnName("occurence")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("5184000");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.WorldEvent)
                    .HasColumnName("world_event")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventBattlegroundHoliday>(entity =>
            {
                entity.HasKey(e => e.EventEntry);

                entity.ToTable("game_event_battleground_holiday");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Bgflag)
                    .HasColumnName("bgflag")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventCondition>(entity =>
            {
                entity.HasKey(e => new { e.EventEntry, e.ConditionId });

                entity.ToTable("game_event_condition");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.ConditionId)
                    .HasColumnName("condition_id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DoneWorldStateField)
                    .HasColumnName("done_world_state_field")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxWorldStateField)
                    .HasColumnName("max_world_state_field")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqNum)
                    .HasColumnName("req_num")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventCreature>(entity =>
            {
                entity.HasKey(e => new { e.EventEntry, e.Guid });

                entity.ToTable("game_event_creature");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<GameEventCreatureQuest>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Quest });

                entity.ToTable("game_event_creature_quest");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<GameEventGameobject>(entity =>
            {
                entity.HasKey(e => new { e.EventEntry, e.Guid });

                entity.ToTable("game_event_gameobject");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<GameEventGameobjectQuest>(entity =>
            {
                entity.HasKey(e => new { e.EventEntry, e.Id, e.Quest });

                entity.ToTable("game_event_gameobject_quest");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventModelEquip>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("game_event_model_equip");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EquipmentId)
                    .HasColumnName("equipment_id")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Modelid)
                    .HasColumnName("modelid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventNpcVendor>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Item });

                entity.ToTable("game_event_npc_vendor");

                entity.HasIndex(e => e.Slot)
                    .HasName("slot");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.ExtendedCost)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Incrtime)
                    .HasColumnName("incrtime")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Maxcount)
                    .HasColumnName("maxcount")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Slot)
                    .HasColumnName("slot")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventNpcflag>(entity =>
            {
                entity.HasKey(e => new { e.EventEntry, e.Guid });

                entity.ToTable("game_event_npcflag");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Npcflag)
                    .HasColumnName("npcflag")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventPool>(entity =>
            {
                entity.HasKey(e => e.PoolEntry);

                entity.ToTable("game_event_pool");

                entity.Property(e => e.PoolEntry)
                    .HasColumnName("pool_entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<GameEventPrerequisite>(entity =>
            {
                entity.HasKey(e => new { e.EventEntry, e.PrerequisiteEvent });

                entity.ToTable("game_event_prerequisite");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.PrerequisiteEvent)
                    .HasColumnName("prerequisite_event")
                    .HasColumnType("mediumint unsigned");
            });

            modelBuilder.Entity<GameEventQuestCondition>(entity =>
            {
                entity.HasKey(e => e.Quest);

                entity.ToTable("game_event_quest_condition");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ConditionId)
                    .HasColumnName("condition_id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameEventSeasonalQuestrelation>(entity =>
            {
                entity.HasKey(e => new { e.QuestId, e.EventEntry });

                entity.ToTable("game_event_seasonal_questrelation");

                entity.HasIndex(e => e.QuestId)
                    .HasName("idx_quest");

                entity.Property(e => e.QuestId)
                    .HasColumnName("questId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.EventEntry)
                    .HasColumnName("eventEntry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameTele>(entity =>
            {
                entity.ToTable("game_tele");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Orientation)
                    .HasColumnName("orientation")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameWeather>(entity =>
            {
                entity.HasKey(e => e.Zone);

                entity.ToTable("game_weather");

                entity.Property(e => e.Zone)
                    .HasColumnName("zone")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FallRainChance)
                    .HasColumnName("fall_rain_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.FallSnowChance)
                    .HasColumnName("fall_snow_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.FallStormChance)
                    .HasColumnName("fall_storm_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasColumnType("char(64)");

                entity.Property(e => e.SpringRainChance)
                    .HasColumnName("spring_rain_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.SpringSnowChance)
                    .HasColumnName("spring_snow_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.SpringStormChance)
                    .HasColumnName("spring_storm_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.SummerRainChance)
                    .HasColumnName("summer_rain_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.SummerSnowChance)
                    .HasColumnName("summer_snow_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.SummerStormChance)
                    .HasColumnName("summer_storm_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.WinterRainChance)
                    .HasColumnName("winter_rain_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.WinterSnowChance)
                    .HasColumnName("winter_snow_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");

                entity.Property(e => e.WinterStormChance)
                    .HasColumnName("winter_storm_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("25");
            });

            modelBuilder.Entity<Gameobject>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("gameobject");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Animprogress)
                    .HasColumnName("animprogress")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Orientation)
                    .HasColumnName("orientation")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PhaseMask)
                    .HasColumnName("phaseMask")
                    .HasColumnType("int")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rotation0)
                    .HasColumnName("rotation0")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rotation1)
                    .HasColumnName("rotation1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rotation2)
                    .HasColumnName("rotation2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rotation3)
                    .HasColumnName("rotation3")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScriptName).HasColumnType("char(64)");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpawnMask)
                    .HasColumnName("spawnMask")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Spawntimesecs)
                    .HasColumnName("spawntimesecs")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zoneId")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameobjectAddon>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("gameobject_addon");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.InvisibilityType)
                    .HasColumnName("invisibilityType")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.InvisibilityValue)
                    .HasColumnName("invisibilityValue")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ParentRotation0)
                    .HasColumnName("parent_rotation0")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ParentRotation1)
                    .HasColumnName("parent_rotation1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ParentRotation2)
                    .HasColumnName("parent_rotation2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ParentRotation3)
                    .HasColumnName("parent_rotation3")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<GameobjectLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("gameobject_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameobjectOverrides>(entity =>
            {
                entity.HasKey(e => e.SpawnId);

                entity.ToTable("gameobject_overrides");

                entity.Property(e => e.SpawnId)
                    .HasColumnName("spawnId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Faction)
                    .HasColumnName("faction")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameobjectQuestender>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Quest });

                entity.ToTable("gameobject_questender");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameobjectQuestitem>(entity =>
            {
                entity.HasKey(e => new { e.GameObjectEntry, e.Idx });

                entity.ToTable("gameobject_questitem");

                entity.Property(e => e.GameObjectEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Idx)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameobjectQueststarter>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Quest });

                entity.ToTable("gameobject_queststarter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameobjectTemplate>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("gameobject_template");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_name");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ainame)
                    .IsRequired()
                    .HasColumnName("AIName")
                    .HasColumnType("char(64)");

                entity.Property(e => e.CastBarCaption)
                    .IsRequired()
                    .HasColumnName("castBarCaption")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Data0)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data1)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data10)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data11)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data12)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data13)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data14)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data15)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data16)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data17)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data18)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data19)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data20)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data21)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data22)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data23)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data4)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data5)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data6)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data7)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data8)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Data9)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DisplayId)
                    .HasColumnName("displayId")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IconName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Unk1)
                    .IsRequired()
                    .HasColumnName("unk1")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameobjectTemplateAddon>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("gameobject_template_addon");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Faction)
                    .HasColumnName("faction")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Maxgold)
                    .HasColumnName("maxgold")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mingold)
                    .HasColumnName("mingold")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GameobjectTemplateLocale>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Locale });

                entity.ToTable("gameobject_template_locale");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CastBarCaption)
                    .HasColumnName("castBarCaption")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GossipMenu>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.TextId });

                entity.ToTable("gossip_menu");

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TextId)
                    .HasColumnName("TextID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GossipMenuOption>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.OptionId });

                entity.ToTable("gossip_menu_option");

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OptionId)
                    .HasColumnName("OptionID")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionMenuId)
                    .HasColumnName("ActionMenuID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionPoiId)
                    .HasColumnName("ActionPoiID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BoxBroadcastTextId)
                    .HasColumnName("BoxBroadcastTextID")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BoxCoded)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BoxMoney)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BoxText).IsUnicode(false);

                entity.Property(e => e.OptionBroadcastTextId)
                    .HasColumnName("OptionBroadcastTextID")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OptionIcon)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OptionNpcFlag)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OptionText).IsUnicode(false);

                entity.Property(e => e.OptionType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GossipMenuOptionLocale>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.OptionId, e.Locale });

                entity.ToTable("gossip_menu_option_locale");

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .HasColumnType("smallint(6) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OptionId)
                    .HasColumnName("OptionID")
                    .HasColumnType("smallint(6) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.BoxText).IsUnicode(false);

                entity.Property(e => e.OptionText).IsUnicode(false);
            });

            modelBuilder.Entity<GraveyardZone>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.GhostZone });

                entity.ToTable("graveyard_zone");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GhostZone)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.Faction)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GuildBonusInfo>(entity =>
            {
                entity.HasKey(e => new { e.Level, e.Bonus });

                entity.ToTable("guild_bonus_info");

                entity.Property(e => e.Level)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bonus)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Multiplier).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GuildXpRequiredForLevel>(entity =>
            {
                entity.HasKey(e => e.Level);

                entity.ToTable("guild_xp_required_for_level");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.XpRequired)
                    .HasColumnName("xp_required")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<HolidayDates>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.DateId });

                entity.ToTable("holiday_dates");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.DateId)
                    .HasColumnName("date_id")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.DateValue)
                    .HasColumnName("date_value")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<InstanceEncounters>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("instance_encounters");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreditEntry)
                    .HasColumnName("creditEntry")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreditType)
                    .HasColumnName("creditType")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastEncounterDungeon)
                    .HasColumnName("lastEncounterDungeon")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<InstanceSpawnGroups>(entity =>
            {
                entity.HasKey(e => new { e.InstanceMapId, e.BossStateId, e.BossStates, e.SpawnGroupId });

                entity.ToTable("instance_spawn_groups");

                entity.Property(e => e.InstanceMapId)
                    .HasColumnName("instanceMapId")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.BossStateId)
                    .HasColumnName("bossStateId")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.BossStates)
                    .HasColumnName("bossStates")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.SpawnGroupId)
                    .HasColumnName("spawnGroupId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<InstanceTemplate>(entity =>
            {
                entity.HasKey(e => e.Map);

                entity.ToTable("instance_template");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("smallint unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowMount)
                    .HasColumnName("allowMount")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Parent)
                    .HasColumnName("parent")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnName("script")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemEnchantmentTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Ench });

                entity.ToTable("item_enchantment_template");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ench)
                    .HasColumnName("ench")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance)
                    .HasColumnName("chance")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ItemLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("item_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ItemSetNames>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("item_set_names");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.InventoryType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemSetNamesLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("item_set_names_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ItemTemplate>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("item_template");

                entity.HasIndex(e => e.Class)
                    .HasName("items_index");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_name");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AllowableClass)
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.AllowableRace)
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.AmmoType)
                    .HasColumnName("ammo_type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ArcaneRes)
                    .HasColumnName("arcane_res")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Armor)
                    .HasColumnName("armor")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ArmorDamageModifier).HasDefaultValueSql("0");

                entity.Property(e => e.BagFamily)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Block)
                    .HasColumnName("block")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bonding)
                    .HasColumnName("bonding")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BuyCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.BuyPrice)
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cond)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ContainerSlots)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Delay)
                    .HasColumnName("delay")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1000");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DisenchantId)
                    .HasColumnName("DisenchantID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DisplayId)
                    .HasColumnName("displayid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgMax1)
                    .HasColumnName("dmg_max1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgMax2)
                    .HasColumnName("dmg_max2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgMin1)
                    .HasColumnName("dmg_min1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgMin2)
                    .HasColumnName("dmg_min2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgType1)
                    .HasColumnName("dmg_type1")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgType2)
                    .HasColumnName("dmg_type2")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FireRes)
                    .HasColumnName("fire_res")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FlagsCustom)
                    .HasColumnName("flagsCustom")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FlagsExtra)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FoodType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FrostRes)
                    .HasColumnName("frost_res")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GemProperties)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HolidayId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HolyRes)
                    .HasColumnName("holy_res")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.InventoryType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemLevel)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemLimitCategory)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemSet)
                    .HasColumnName("itemset")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LockId)
                    .HasColumnName("lockid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Material)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxDurability)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxMoneyLoot)
                    .HasColumnName("maxMoneyLoot")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxCount)
                    .HasColumnName("maxcount")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinMoneyLoot)
                    .HasColumnName("minMoneyLoot")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NatureRes)
                    .HasColumnName("nature_res")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PageMaterial)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PageText)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quality)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RandomProperty)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RandomSuffix)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RangedModRange).HasDefaultValueSql("0");

                entity.Property(e => e.RequiredCityRank)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredDisenchantSkill)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.RequiredLevel)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredReputationFaction)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredReputationRank)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredSkill)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredSkillRank)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredHonorRank)
                    .HasColumnName("requiredhonorrank")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredSpell)
                    .HasColumnName("requiredspell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScalingStatDistribution)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScalingStatValue)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SellPrice)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ShadowRes)
                    .HasColumnName("shadow_res")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sheath)
                    .HasColumnName("sheath")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SocketBonus)
                    .HasColumnName("socketBonus")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SocketColor1)
                    .HasColumnName("socketColor_1")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SocketColor2)
                    .HasColumnName("socketColor_2")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SocketColor3)
                    .HasColumnName("socketColor_3")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SocketContent1)
                    .HasColumnName("socketContent_1")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SocketContent2)
                    .HasColumnName("socketContent_2")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SocketContent3)
                    .HasColumnName("socketContent_3")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SoundOverrideSubclass)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCategory1)
                    .HasColumnName("spellcategory_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCategory2)
                    .HasColumnName("spellcategory_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCategory3)
                    .HasColumnName("spellcategory_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCategory4)
                    .HasColumnName("spellcategory_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCategory5)
                    .HasColumnName("spellcategory_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCategoryCooldown1)
                    .HasColumnName("spellcategorycooldown_1")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCategoryCooldown2)
                    .HasColumnName("spellcategorycooldown_2")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCategoryCooldown3)
                    .HasColumnName("spellcategorycooldown_3")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCategoryCooldown4)
                    .HasColumnName("spellcategorycooldown_4")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCategoryCooldown5)
                    .HasColumnName("spellcategorycooldown_5")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCharges1)
                    .HasColumnName("spellcharges_1")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCharges2)
                    .HasColumnName("spellcharges_2")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCharges3)
                    .HasColumnName("spellcharges_3")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCharges4)
                    .HasColumnName("spellcharges_4")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCharges5)
                    .HasColumnName("spellcharges_5")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellCooldown1)
                    .HasColumnName("spellcooldown_1")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCooldown2)
                    .HasColumnName("spellcooldown_2")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCooldown3)
                    .HasColumnName("spellcooldown_3")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCooldown4)
                    .HasColumnName("spellcooldown_4")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellCooldown5)
                    .HasColumnName("spellcooldown_5")
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.SpellId1)
                    .HasColumnName("spellid_1")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellId2)
                    .HasColumnName("spellid_2")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellId3)
                    .HasColumnName("spellid_3")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellId4)
                    .HasColumnName("spellid_4")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellId5)
                    .HasColumnName("spellid_5")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellPpmRate1)
                    .HasColumnName("spellppmRate_1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellPpmRate2)
                    .HasColumnName("spellppmRate_2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellPpmRate3)
                    .HasColumnName("spellppmRate_3")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellPpmRate4)
                    .HasColumnName("spellppmRate_4")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellPpmRate5)
                    .HasColumnName("spellppmRate_5")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellTrigger1)
                    .HasColumnName("spelltrigger_1")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellTrigger2)
                    .HasColumnName("spelltrigger_2")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellTrigger3)
                    .HasColumnName("spelltrigger_3")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellTrigger4)
                    .HasColumnName("spelltrigger_4")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellTrigger5)
                    .HasColumnName("spelltrigger_5")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StackAble)
                    .HasColumnName("stackable")
                    .HasColumnType("int")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.StartQuest)
                    .HasColumnName("startquest")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType1)
                    .HasColumnName("stat_type1")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType10)
                    .HasColumnName("stat_type10")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType2)
                    .HasColumnName("stat_type2")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType3)
                    .HasColumnName("stat_type3")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType4)
                    .HasColumnName("stat_type4")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType5)
                    .HasColumnName("stat_type5")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType6)
                    .HasColumnName("stat_type6")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType7)
                    .HasColumnName("stat_type7")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType8)
                    .HasColumnName("stat_type8")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatType9)
                    .HasColumnName("stat_type9")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue1)
                    .HasColumnName("stat_value1")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue10)
                    .HasColumnName("stat_value10")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue2)
                    .HasColumnName("stat_value2")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue3)
                    .HasColumnName("stat_value3")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue4)
                    .HasColumnName("stat_value4")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue5)
                    .HasColumnName("stat_value5")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue6)
                    .HasColumnName("stat_value6")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue7)
                    .HasColumnName("stat_value7")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue8)
                    .HasColumnName("stat_value8")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatValue9)
                    .HasColumnName("stat_value9")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StatsCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Subclass)
                    .HasColumnName("subclass")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotemCategory)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ItemTemplateLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("item_template_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<LfgDungeonRewards>(entity =>
            {
                entity.HasKey(e => new { e.DungeonId, e.MaxLevel });

                entity.ToTable("lfg_dungeon_rewards");

                entity.Property(e => e.DungeonId)
                    .HasColumnName("dungeonId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxLevel)
                    .HasColumnName("maxLevel")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FirstQuestId)
                    .HasColumnName("firstQuestId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OtherQuestId)
                    .HasColumnName("otherQuestId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<LfgDungeonTemplate>(entity =>
            {
                entity.HasKey(e => e.DungeonId);

                entity.ToTable("lfg_dungeon_template");

                entity.Property(e => e.DungeonId)
                    .HasColumnName("dungeonId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Orientation)
                    .HasColumnName("orientation")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<LinkedRespawn>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.LinkType });

                entity.ToTable("linked_respawn");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.LinkType)
                    .HasColumnName("linkType")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LinkedGuid)
                    .HasColumnName("linkedGuid")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<MailLevelReward>(entity =>
            {
                entity.HasKey(e => new { e.Level, e.RaceMask });

                entity.ToTable("mail_level_reward");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RaceMask)
                    .HasColumnName("raceMask")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MailTemplateId)
                    .HasColumnName("mailTemplateId")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SenderEntry)
                    .HasColumnName("senderEntry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<MailLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("mail_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<MillingLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("milling_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<NpcSpellclickSpells>(entity =>
            {
                entity.HasKey(e => new { e.NpcEntry, e.SpellId });

                entity.ToTable("npc_spellclick_spells");

                entity.Property(e => e.NpcEntry)
                    .HasColumnName("npc_entry")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CastFlags)
                    .HasColumnName("cast_flags")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<NpcText>(entity =>
            {
                entity.ToTable("npc_text");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId0)
                    .HasColumnName("BroadcastTextID0")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId1)
                    .HasColumnName("BroadcastTextID1")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId2)
                    .HasColumnName("BroadcastTextID2")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId3)
                    .HasColumnName("BroadcastTextID3")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId4)
                    .HasColumnName("BroadcastTextID4")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId5)
                    .HasColumnName("BroadcastTextID5")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId6)
                    .HasColumnName("BroadcastTextID6")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BroadcastTextId7)
                    .HasColumnName("BroadcastTextID7")
                    .HasColumnType("mediumint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em00)
                    .HasColumnName("em0_0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em01)
                    .HasColumnName("em0_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em02)
                    .HasColumnName("em0_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em03)
                    .HasColumnName("em0_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em04)
                    .HasColumnName("em0_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em05)
                    .HasColumnName("em0_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em10)
                    .HasColumnName("em1_0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em11)
                    .HasColumnName("em1_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em12)
                    .HasColumnName("em1_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em13)
                    .HasColumnName("em1_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em14)
                    .HasColumnName("em1_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em15)
                    .HasColumnName("em1_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em20)
                    .HasColumnName("em2_0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em21)
                    .HasColumnName("em2_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em22)
                    .HasColumnName("em2_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em23)
                    .HasColumnName("em2_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em24)
                    .HasColumnName("em2_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em25)
                    .HasColumnName("em2_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em30)
                    .HasColumnName("em3_0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em31)
                    .HasColumnName("em3_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em32)
                    .HasColumnName("em3_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em33)
                    .HasColumnName("em3_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em34)
                    .HasColumnName("em3_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em35)
                    .HasColumnName("em3_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em40)
                    .HasColumnName("em4_0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em41)
                    .HasColumnName("em4_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em42)
                    .HasColumnName("em4_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em43)
                    .HasColumnName("em4_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em44)
                    .HasColumnName("em4_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em45)
                    .HasColumnName("em4_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em50)
                    .HasColumnName("em5_0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em51)
                    .HasColumnName("em5_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em52)
                    .HasColumnName("em5_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em53)
                    .HasColumnName("em5_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em54)
                    .HasColumnName("em5_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em55)
                    .HasColumnName("em5_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em60)
                    .HasColumnName("em6_0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em61)
                    .HasColumnName("em6_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em62)
                    .HasColumnName("em6_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em63)
                    .HasColumnName("em6_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em64)
                    .HasColumnName("em6_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em65)
                    .HasColumnName("em6_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em70)
                    .HasColumnName("em7_0")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em71)
                    .HasColumnName("em7_1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em72)
                    .HasColumnName("em7_2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em73)
                    .HasColumnName("em7_3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em74)
                    .HasColumnName("em7_4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Em75)
                    .HasColumnName("em7_5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang0)
                    .HasColumnName("lang0")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang1)
                    .HasColumnName("lang1")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang2)
                    .HasColumnName("lang2")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang3)
                    .HasColumnName("lang3")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang4)
                    .HasColumnName("lang4")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang5)
                    .HasColumnName("lang5")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang6)
                    .HasColumnName("lang6")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang7)
                    .HasColumnName("lang7")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Probability0).HasDefaultValueSql("0");

                entity.Property(e => e.Probability1).HasDefaultValueSql("0");

                entity.Property(e => e.Probability2).HasDefaultValueSql("0");

                entity.Property(e => e.Probability3).HasDefaultValueSql("0");

                entity.Property(e => e.Probability4).HasDefaultValueSql("0");

                entity.Property(e => e.Probability5).HasDefaultValueSql("0");

                entity.Property(e => e.Probability6).HasDefaultValueSql("0");

                entity.Property(e => e.Probability7).HasDefaultValueSql("0");

                entity.Property(e => e.Text00)
                    .HasColumnName("text0_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text01)
                    .HasColumnName("text0_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text10)
                    .HasColumnName("text1_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text11)
                    .HasColumnName("text1_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text20)
                    .HasColumnName("text2_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text21)
                    .HasColumnName("text2_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text30)
                    .HasColumnName("text3_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text31)
                    .HasColumnName("text3_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text40)
                    .HasColumnName("text4_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text41)
                    .HasColumnName("text4_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text50)
                    .HasColumnName("text5_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text51)
                    .HasColumnName("text5_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text60)
                    .HasColumnName("text6_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text61)
                    .HasColumnName("text6_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text70)
                    .HasColumnName("text7_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text71)
                    .HasColumnName("text7_1")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<NpcTextLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("npc_text_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Text00)
                    .HasColumnName("Text0_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text01)
                    .HasColumnName("Text0_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text10)
                    .HasColumnName("Text1_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text11)
                    .HasColumnName("Text1_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text20)
                    .HasColumnName("Text2_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text21)
                    .HasColumnName("Text2_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text30)
                    .HasColumnName("Text3_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text31)
                    .HasColumnName("Text3_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text40)
                    .HasColumnName("Text4_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text41)
                    .HasColumnName("Text4_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text50)
                    .HasColumnName("Text5_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text51)
                    .HasColumnName("Text5_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text60)
                    .HasColumnName("Text6_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text61)
                    .HasColumnName("Text6_1")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text70)
                    .HasColumnName("Text7_0")
                    .HasColumnType("longtext");

                entity.Property(e => e.Text71)
                    .HasColumnName("Text7_1")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<NpcVendor>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item, e.ExtendedCost, e.BuyCount });

                entity.ToTable("npc_vendor");

                entity.HasIndex(e => e.Slot)
                    .HasName("slot");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExtendedCost)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BuyCount)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BuyPrice)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cond)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Incrtime)
                    .HasColumnName("incrtime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Maxcount)
                    .HasColumnName("maxcount")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Slot)
                    .HasColumnName("slot")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<OutdoorpvpTemplate>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("outdoorpvp_template");

                entity.Property(e => e.TypeId).HasColumnType("tinyint unsigned");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasColumnType("char(64)");
            });

            modelBuilder.Entity<PageText>(entity =>
            {
                entity.ToTable("page_text");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NextPageId)
                    .HasColumnName("NextPageID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<PageTextLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("page_text_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Text).IsUnicode(false);
            });

            modelBuilder.Entity<PetLevelstats>(entity =>
            {
                entity.HasKey(e => new { e.CreatureEntry, e.Level });

                entity.ToTable("pet_levelstats");

                entity.Property(e => e.CreatureEntry)
                    .HasColumnName("creature_entry")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Agi)
                    .HasColumnName("agi")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Armor)
                    .HasColumnName("armor")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Hp)
                    .HasColumnName("hp")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Inte)
                    .HasColumnName("inte")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Mana)
                    .HasColumnName("mana")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.MaxDmg)
                    .HasColumnName("max_dmg")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinDmg)
                    .HasColumnName("min_dmg")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spi)
                    .HasColumnName("spi")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Sta)
                    .HasColumnName("sta")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Str)
                    .HasColumnName("str")
                    .HasColumnType("smallint unsigned");
            });

            modelBuilder.Entity<PetNameGeneration>(entity =>
            {
                entity.ToTable("pet_name_generation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Half)
                    .HasColumnName("half")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasColumnName("word")
                    .HasColumnType("tinytext");
            });

            modelBuilder.Entity<PickpocketingLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("pickpocketing_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PlayerClasslevelstats>(entity =>
            {
                entity.HasKey(e => new { e.Class, e.Level });

                entity.ToTable("player_classlevelstats");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Basehp)
                    .HasColumnName("basehp")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Basemana)
                    .HasColumnName("basemana")
                    .HasColumnType("smallint unsigned");
            });

            modelBuilder.Entity<PlayerFactionchangeAchievement>(entity =>
            {
                entity.HasKey(e => new { e.AllianceId, e.HordeId });

                entity.ToTable("player_factionchange_achievement");

                entity.Property(e => e.AllianceId)
                    .HasColumnName("alliance_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.HordeId)
                    .HasColumnName("horde_id")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<PlayerFactionchangeItems>(entity =>
            {
                entity.HasKey(e => new { e.AllianceId, e.HordeId });

                entity.ToTable("player_factionchange_items");

                entity.Property(e => e.AllianceId)
                    .HasColumnName("alliance_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.HordeId)
                    .HasColumnName("horde_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CommentA)
                    .HasColumnName("commentA")
                    .IsUnicode(false);

                entity.Property(e => e.CommentH)
                    .HasColumnName("commentH")
                    .IsUnicode(false);

                entity.Property(e => e.RaceA)
                    .HasColumnName("race_A")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.RaceH)
                    .HasColumnName("race_H")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<PlayerFactionchangeQuests>(entity =>
            {
                entity.HasKey(e => new { e.AllianceId, e.HordeId });

                entity.ToTable("player_factionchange_quests");

                entity.HasIndex(e => e.AllianceId)
                    .HasName("alliance_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.HordeId)
                    .HasName("horde_uniq")
                    .IsUnique();

                entity.Property(e => e.AllianceId)
                    .HasColumnName("alliance_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.HordeId)
                    .HasColumnName("horde_id")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<PlayerFactionchangeReputations>(entity =>
            {
                entity.HasKey(e => new { e.AllianceId, e.HordeId });

                entity.ToTable("player_factionchange_reputations");

                entity.Property(e => e.AllianceId)
                    .HasColumnName("alliance_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.HordeId)
                    .HasColumnName("horde_id")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<PlayerFactionchangeSpells>(entity =>
            {
                entity.HasKey(e => new { e.AllianceId, e.HordeId });

                entity.ToTable("player_factionchange_spells");

                entity.Property(e => e.AllianceId)
                    .HasColumnName("alliance_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.HordeId)
                    .HasColumnName("horde_id")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<PlayerFactionchangeTitles>(entity =>
            {
                entity.HasKey(e => new { e.AllianceId, e.HordeId });

                entity.ToTable("player_factionchange_titles");

                entity.Property(e => e.AllianceId)
                    .HasColumnName("alliance_id")
                    .HasColumnType("int(8)");

                entity.Property(e => e.HordeId)
                    .HasColumnName("horde_id")
                    .HasColumnType("int(8)");
            });

            modelBuilder.Entity<PlayerLevelstats>(entity =>
            {
                entity.HasKey(e => new { e.Race, e.Class, e.Level });

                entity.ToTable("player_levelstats");

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Agi)
                    .HasColumnName("agi")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Inte)
                    .HasColumnName("inte")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Spi)
                    .HasColumnName("spi")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Sta)
                    .HasColumnName("sta")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Str)
                    .HasColumnName("str")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<PlayerTotemModel>(entity =>
            {
                entity.HasKey(e => new { e.TotemSlot, e.RaceId });

                entity.ToTable("player_totem_model");

                entity.Property(e => e.TotemSlot).HasColumnType("tinyint unsigned");

                entity.Property(e => e.RaceId).HasColumnType("tinyint unsigned");

                entity.Property(e => e.DisplayId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PlayerXpForLevel>(entity =>
            {
                entity.HasKey(e => e.Level);

                entity.ToTable("player_xp_for_level");

                entity.Property(e => e.Level).HasColumnType("tinyint unsigned");

                entity.Property(e => e.Experience).HasColumnType("int unsigned");
            });

            modelBuilder.Entity<Playercreateinfo>(entity =>
            {
                entity.HasKey(e => new { e.Race, e.Class });

                entity.ToTable("playercreateinfo");

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Orientation)
                    .HasColumnName("orientation")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Zone)
                    .HasColumnName("zone")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PlayercreateinfoAction>(entity =>
            {
                entity.HasKey(e => new { e.Race, e.Class, e.Button });

                entity.ToTable("playercreateinfo_action");

                entity.HasIndex(e => new { e.Race, e.Class })
                    .HasName("playercreateinfo_race_class_index");

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Button)
                    .HasColumnName("button")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PlayercreateinfoItem>(entity =>
            {
                entity.HasKey(e => new { e.Race, e.Class, e.Itemid });

                entity.ToTable("playercreateinfo_item");

                entity.HasIndex(e => new { e.Race, e.Class })
                    .HasName("playercreateinfo_race_class_index");

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemid)
                    .HasColumnName("itemid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<PlayercreateinfoSkills>(entity =>
            {
                entity.HasKey(e => new { e.RaceMask, e.ClassMask, e.Skill });

                entity.ToTable("playercreateinfo_skills");

                entity.Property(e => e.RaceMask)
                    .HasColumnName("raceMask")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.ClassMask)
                    .HasColumnName("classMask")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Skill)
                    .HasColumnName("skill")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PlayercreateinfoSpellCustom>(entity =>
            {
                entity.HasKey(e => new { e.Racemask, e.Classmask, e.Spell });

                entity.ToTable("playercreateinfo_spell_custom");

                entity.Property(e => e.Racemask)
                    .HasColumnName("racemask")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Classmask)
                    .HasColumnName("classmask")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spell)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlayerhouseAreaModifier>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("playerhouse_area_modifier");

                entity.Property(e => e.AreaId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PlayerhouseMembers>(entity =>
            {
                entity.HasKey(e => new { e.HouseId, e.MemberGuid });

                entity.ToTable("playerhouse_members");

                entity.Property(e => e.HouseId).HasColumnType("int unsigned");

                entity.Property(e => e.MemberGuid)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Permissions)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PlayerhouseNpcShop>(entity =>
            {
                entity.HasKey(e => e.NpcId);

                entity.ToTable("playerhouse_npc_shop");

                entity.Property(e => e.NpcId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExtendedCostId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PlayerhouseSpawnTypes>(entity =>
            {
                entity.HasKey(e => e.SpawnType);

                entity.ToTable("playerhouse_spawn_types");

                entity.Property(e => e.SpawnType).HasColumnType("tinyint(2) unsigned");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlayerhouseSpawns>(entity =>
            {
                entity.HasKey(e => new { e.HouseId, e.SpawnType, e.SpawnGuid });

                entity.ToTable("playerhouse_spawns");

                entity.HasIndex(e => e.SpawnType)
                    .HasName("FK_PH_SPAWN_TYPES");

                entity.Property(e => e.HouseId)
                    .HasColumnType("int unsigned")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SpawnType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpawnGuid)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpawnEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.SpawnTypeNavigation)
                    .WithMany(p => p.PlayerhouseSpawns)
                    .HasForeignKey(d => d.SpawnType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playerhouse_spawns_ibfk_1");
            });

            modelBuilder.Entity<PlayerhouseVendor>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item, e.ExtendedCost, e.BuyCount });

                entity.ToTable("playerhouse_vendor");

                entity.HasIndex(e => e.Slot)
                    .HasName("slot");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExtendedCost)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BuyCount)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.BuyPrice)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cond)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Incrtime)
                    .HasColumnName("incrtime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Maxcount)
                    .HasColumnName("maxcount")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Slot)
                    .HasColumnName("slot")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Playerhouses>(entity =>
            {
                entity.HasKey(e => e.HouseId);

                entity.ToTable("playerhouses");

                entity.Property(e => e.HouseId)
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BuyPrice)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Height).HasDefaultValueSql("0");

                entity.Property(e => e.HouseName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxNpcs)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxObjects)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OwnerGuid)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PosX).HasDefaultValueSql("0");

                entity.Property(e => e.PosY).HasDefaultValueSql("0");

                entity.Property(e => e.PosZ).HasDefaultValueSql("0");

                entity.Property(e => e.ZoneId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PointsOfInterest>(entity =>
            {
                entity.ToTable("points_of_interest");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Icon)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Importance)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PositionX).HasDefaultValueSql("0");

                entity.Property(e => e.PositionY).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PointsOfInterestLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("points_of_interest_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<PoolMembers>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.SpawnId });

                entity.ToTable("pool_members");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.SpawnId)
                    .HasColumnName("spawnId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Chance)
                    .HasColumnName("chance")
                    .HasColumnType("double unsigned");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PoolSpawnId)
                    .HasColumnName("poolSpawnId")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<PoolTemplate>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("pool_template");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaxLimit)
                    .HasColumnName("max_limit")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ProspectingLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("prospecting_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PvpdifficultyDbc>(entity =>
            {
                entity.ToTable("pvpdifficulty_dbc");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.BracketId)
                    .HasColumnName("bracketId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Difficulty)
                    .HasColumnName("difficulty")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnName("mapId")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxUpgrades)
                    .HasColumnName("maxUpgrades")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinUpgrades)
                    .HasColumnName("minUpgrades")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestDetails>(entity =>
            {
                entity.ToTable("quest_details");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote1)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote2)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote3)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote4)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay4)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestGreeting>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Type });

                entity.ToTable("quest_greeting");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GreetEmoteDelay)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GreetEmoteType)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Greeting).IsUnicode(false);

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestGreetingLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Type });

                entity.ToTable("quest_greeting_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Greeting).IsUnicode(false);

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestMailSender>(entity =>
            {
                entity.HasKey(e => e.QuestId);

                entity.ToTable("quest_mail_sender");

                entity.Property(e => e.QuestId)
                    .HasColumnType("int(5) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardMailSenderEntry)
                    .HasColumnType("int(5) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestOfferReward>(entity =>
            {
                entity.ToTable("quest_offer_reward");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote1)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote2)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote3)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Emote4)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteDelay4)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardText).IsUnicode(false);

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestOfferRewardLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("quest_offer_reward_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.RewardText).IsUnicode(false);

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestPoi>(entity =>
            {
                entity.HasKey(e => new { e.QuestId, e.Id });

                entity.ToTable("quest_poi");

                entity.HasIndex(e => new { e.QuestId, e.Id })
                    .HasName("idx");

                entity.Property(e => e.QuestId)
                    .HasColumnName("QuestID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Floor)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnName("MapID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ObjectiveIndex)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Priority)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.WorldMapAreaId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestPoiPoints>(entity =>
            {
                entity.HasKey(e => new { e.QuestId, e.Idx1, e.Idx2 });

                entity.ToTable("quest_poi_points");

                entity.HasIndex(e => new { e.QuestId, e.Idx1 })
                    .HasName("questId_id");

                entity.Property(e => e.QuestId)
                    .HasColumnName("QuestID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Idx1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Idx2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.X)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Y)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestPoolMembers>(entity =>
            {
                entity.HasKey(e => e.QuestId);

                entity.ToTable("quest_pool_members");

                entity.Property(e => e.QuestId)
                    .HasColumnName("questId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PoolId)
                    .HasColumnName("poolId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.PoolIndex)
                    .HasColumnName("poolIndex")
                    .HasColumnType("tinyint(2) unsigned");
            });

            modelBuilder.Entity<QuestPoolTemplate>(entity =>
            {
                entity.HasKey(e => e.PoolId);

                entity.ToTable("quest_pool_template");

                entity.Property(e => e.PoolId)
                    .HasColumnName("poolId")
                    .HasColumnType("mediumint unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumActive)
                    .HasColumnName("numActive")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<QuestRequestItems>(entity =>
            {
                entity.ToTable("quest_request_items");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CompletionText).IsUnicode(false);

                entity.Property(e => e.EmoteOnComplete)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmoteOnIncomplete)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestRequestItemsLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("quest_request_items_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CompletionText).IsUnicode(false);

                entity.Property(e => e.VerifiedBuild)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestTemplate>(entity =>
            {
                entity.ToTable("quest_template");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AllowableRaces)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AreaDescription).IsUnicode(false);

                entity.Property(e => e.Flags)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemDrop1)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemDrop2)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemDrop3)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemDrop4)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemDropQuantity1)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemDropQuantity2)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemDropQuantity3)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemDropQuantity4)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LogDescription).IsUnicode(false);

                entity.Property(e => e.LogTitle).IsUnicode(false);

                entity.Property(e => e.MinLevel)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ObjectiveText1).IsUnicode(false);

                entity.Property(e => e.ObjectiveText2).IsUnicode(false);

                entity.Property(e => e.ObjectiveText3).IsUnicode(false);

                entity.Property(e => e.ObjectiveText4).IsUnicode(false);

                entity.Property(e => e.Poicontinent)
                    .HasColumnName("POIContinent")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Poipriority)
                    .HasColumnName("POIPriority")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Poix)
                    .HasColumnName("POIx")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Poiy)
                    .HasColumnName("POIy")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestCompletionLog).IsUnicode(false);

                entity.Property(e => e.QuestDescription).IsUnicode(false);

                entity.Property(e => e.QuestInfoId)
                    .HasColumnName("QuestInfoID")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestLevel)
                    .HasColumnType("smallint(3)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestSortId)
                    .HasColumnName("QuestSortID")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestType)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.RequiredFactionId1)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredFactionId2)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredFactionValue1)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredFactionValue2)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemCount1)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemCount2)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemCount3)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemCount4)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemCount5)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemCount6)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemId1)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemId2)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemId3)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemId4)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemId5)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredItemId6)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredNpcOrGo1)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredNpcOrGo2)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredNpcOrGo3)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredNpcOrGo4)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredNpcOrGoCount1)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredNpcOrGoCount2)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredNpcOrGoCount3)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredNpcOrGoCount4)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredPlayerKills)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardAmount1)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardAmount2)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardAmount3)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardAmount4)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardArenaPoints)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardBonusMoney)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemId1)
                    .HasColumnName("RewardChoiceItemID1")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemId2)
                    .HasColumnName("RewardChoiceItemID2")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemId3)
                    .HasColumnName("RewardChoiceItemID3")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemId4)
                    .HasColumnName("RewardChoiceItemID4")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemId5)
                    .HasColumnName("RewardChoiceItemID5")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemId6)
                    .HasColumnName("RewardChoiceItemID6")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemQuantity1)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemQuantity2)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemQuantity3)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemQuantity4)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemQuantity5)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardChoiceItemQuantity6)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardDisplaySpell)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionId1)
                    .HasColumnName("RewardFactionID1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionId2)
                    .HasColumnName("RewardFactionID2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionId3)
                    .HasColumnName("RewardFactionID3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionId4)
                    .HasColumnName("RewardFactionID4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionId5)
                    .HasColumnName("RewardFactionID5")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionOverride1)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionOverride2)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionOverride3)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionOverride4)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionOverride5)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionValue1)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionValue2)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionValue3)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionValue4)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardFactionValue5)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardHonor)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardItem1)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardItem2)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardItem3)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardItem4)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardKillHonor).HasDefaultValueSql("0");

                entity.Property(e => e.RewardMoney)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardNextQuest)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardSpell)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardTalents)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardTitle)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardXpdifficulty)
                    .HasColumnName("RewardXPDifficulty")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StartItem)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SuggestedGroupNum)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TimeAllowed)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Unknown0)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestTemplateAddon>(entity =>
            {
                entity.ToTable("quest_template_addon");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AllowableClasses)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BreadcrumbForQuestId)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExclusiveGroup)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxLevel)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NextQuestId)
                    .HasColumnName("NextQuestID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PrevQuestId)
                    .HasColumnName("PrevQuestID")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProvidedItemCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredMaxRepFaction)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredMaxRepValue)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredMinRepFaction)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredMinRepValue)
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredSkillId)
                    .HasColumnName("RequiredSkillID")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredSkillPoints)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardMailDelay)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RewardMailTemplateId)
                    .HasColumnName("RewardMailTemplateID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SourceSpellId)
                    .HasColumnName("SourceSpellID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpecialFlags)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<QuestTemplateLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("quest_template_locale");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CompletedText).IsUnicode(false);

                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.EndText).IsUnicode(false);

                entity.Property(e => e.ObjectiveText1).IsUnicode(false);

                entity.Property(e => e.ObjectiveText2).IsUnicode(false);

                entity.Property(e => e.ObjectiveText3).IsUnicode(false);

                entity.Property(e => e.ObjectiveText4).IsUnicode(false);

                entity.Property(e => e.Objectives).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<RaceEventChopperlocations>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.Index });

                entity.ToTable("race_event_chopperlocations");

                entity.Property(e => e.EventId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Index)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.RaceEventChopperlocations)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("race_event_chopperlocations_ibfk_1");
            });

            modelBuilder.Entity<RaceEventData>(entity =>
            {
                entity.ToTable("race_event_data");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CheckPointEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GossipIcon)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Laps)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxPlayers)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MinPlayers)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RaceEventStartlocations>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.Index });

                entity.ToTable("race_event_startlocations");

                entity.Property(e => e.EventId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Index)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.RaceEventStartlocations)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLAYER_EVENT_ID");
            });

            modelBuilder.Entity<RandomBossSpawns>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("random_boss_spawns");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hint)
                    .HasColumnName("hint")
                    .IsUnicode(false);

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.Property(e => e.Z).HasColumnName("z");
            });

            modelBuilder.Entity<RandomPigSpawns>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.X, e.Y, e.Z });

                entity.ToTable("random_pig_spawns");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.Property(e => e.Z).HasColumnName("z");

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<ReferenceLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("reference_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ReputationRewardRate>(entity =>
            {
                entity.HasKey(e => e.Faction);

                entity.ToTable("reputation_reward_rate");

                entity.Property(e => e.Faction)
                    .HasColumnName("faction")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreatureRate)
                    .HasColumnName("creature_rate")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestDailyRate)
                    .HasColumnName("quest_daily_rate")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestMonthlyRate)
                    .HasColumnName("quest_monthly_rate")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRate)
                    .HasColumnName("quest_rate")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRepeatableRate)
                    .HasColumnName("quest_repeatable_rate")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestWeeklyRate)
                    .HasColumnName("quest_weekly_rate")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SpellRate)
                    .HasColumnName("spell_rate")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<ReputationSpilloverTemplate>(entity =>
            {
                entity.HasKey(e => e.Faction);

                entity.ToTable("reputation_spillover_template");

                entity.Property(e => e.Faction)
                    .HasColumnName("faction")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Faction1)
                    .HasColumnName("faction1")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Faction2)
                    .HasColumnName("faction2")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Faction3)
                    .HasColumnName("faction3")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Faction4)
                    .HasColumnName("faction4")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rank1)
                    .HasColumnName("rank_1")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rank2)
                    .HasColumnName("rank_2")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rank3)
                    .HasColumnName("rank_3")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rank4)
                    .HasColumnName("rank_4")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rate1)
                    .HasColumnName("rate_1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rate2)
                    .HasColumnName("rate_2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rate3)
                    .HasColumnName("rate_3")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rate4)
                    .HasColumnName("rate_4")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ScriptSplineChainMeta>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.ChainId, e.SplineId });

                entity.ToTable("script_spline_chain_meta");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.ChainId)
                    .HasColumnName("chainId")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.SplineId)
                    .HasColumnName("splineId")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.ExpectedDuration)
                    .HasColumnName("expectedDuration")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.MsUntilNext)
                    .HasColumnName("msUntilNext")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Velocity)
                    .HasColumnName("velocity")
                    .HasColumnType("float unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ScriptSplineChainWaypoints>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.ChainId, e.SplineId, e.WpId });

                entity.ToTable("script_spline_chain_waypoints");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.ChainId)
                    .HasColumnName("chainId")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.SplineId)
                    .HasColumnName("splineId")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.WpId)
                    .HasColumnName("wpId")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.Property(e => e.Z).HasColumnName("z");
            });

            modelBuilder.Entity<ScriptWaypoint>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Pointid });

                entity.ToTable("script_waypoint");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pointid)
                    .HasColumnName("pointid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LocationX)
                    .HasColumnName("location_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LocationY)
                    .HasColumnName("location_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LocationZ)
                    .HasColumnName("location_z")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PointComment)
                    .HasColumnName("point_comment")
                    .IsUnicode(false);

                entity.Property(e => e.Waittime)
                    .HasColumnName("waittime")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SkillDiscoveryTemplate>(entity =>
            {
                entity.HasKey(e => new { e.SpellId, e.ReqSpell });

                entity.ToTable("skill_discovery_template");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spellId")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqSpell)
                    .HasColumnName("reqSpell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance)
                    .HasColumnName("chance")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqSkillValue)
                    .HasColumnName("reqSkillValue")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SkillExtraItemTemplate>(entity =>
            {
                entity.HasKey(e => e.SpellId);

                entity.ToTable("skill_extra_item_template");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spellId")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AdditionalCreateChance)
                    .HasColumnName("additionalCreateChance")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AdditionalMaxNum)
                    .HasColumnName("additionalMaxNum")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredSpecialization)
                    .HasColumnName("requiredSpecialization")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SkillFishingBaseLevel>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("skill_fishing_base_level");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Skill)
                    .HasColumnName("skill")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SkillPerfectItemTemplate>(entity =>
            {
                entity.HasKey(e => e.SpellId);

                entity.ToTable("skill_perfect_item_template");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spellId")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PerfectCreateChance)
                    .HasColumnName("perfectCreateChance")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PerfectItemType)
                    .HasColumnName("perfectItemType")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiredSpecialization)
                    .HasColumnName("requiredSpecialization")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SkinningLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("skinning_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SmartScripts>(entity =>
            {
                entity.HasKey(e => new { e.Entryorguid, e.SourceType, e.Id, e.Link });

                entity.ToTable("smart_scripts");

                entity.Property(e => e.Entryorguid)
                    .HasColumnName("entryorguid")
                    .HasColumnType("int");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionParam1)
                    .HasColumnName("action_param1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionParam2)
                    .HasColumnName("action_param2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionParam3)
                    .HasColumnName("action_param3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionParam4)
                    .HasColumnName("action_param4")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionParam5)
                    .HasColumnName("action_param5")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionParam6)
                    .HasColumnName("action_param6")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionType)
                    .HasColumnName("action_type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.EventChance)
                    .HasColumnName("event_chance")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("100");

                entity.Property(e => e.EventFlags)
                    .HasColumnName("event_flags")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventParam1)
                    .HasColumnName("event_param1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventParam2)
                    .HasColumnName("event_param2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventParam3)
                    .HasColumnName("event_param3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventParam4)
                    .HasColumnName("event_param4")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventParam5)
                    .HasColumnName("event_param5")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventPhaseMask)
                    .HasColumnName("event_phase_mask")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EventType)
                    .HasColumnName("event_type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetO)
                    .HasColumnName("target_o")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetParam1)
                    .HasColumnName("target_param1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetParam2)
                    .HasColumnName("target_param2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetParam3)
                    .HasColumnName("target_param3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetParam4)
                    .HasColumnName("target_param4")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetType)
                    .HasColumnName("target_type")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetX)
                    .HasColumnName("target_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetY)
                    .HasColumnName("target_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetZ)
                    .HasColumnName("target_z")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpawnGroup>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.SpawnType, e.SpawnId });

                entity.ToTable("spawn_group");

                entity.Property(e => e.GroupId)
                    .HasColumnName("groupId")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.SpawnType)
                    .HasColumnName("spawnType")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.SpawnId)
                    .HasColumnName("spawnId")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<SpawnGroupTemplate>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("spawn_group_template");

                entity.Property(e => e.GroupId)
                    .HasColumnName("groupId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupFlags)
                    .HasColumnName("groupFlags")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("groupName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpellArea>(entity =>
            {
                entity.HasKey(e => new { e.Spell, e.Area, e.QuestStart, e.AuraSpell, e.Racemask, e.Gender });

                entity.ToTable("spell_area");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestStart)
                    .HasColumnName("quest_start")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AuraSpell)
                    .HasColumnName("aura_spell")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Racemask)
                    .HasColumnName("racemask")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.Autocast)
                    .HasColumnName("autocast")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestEnd)
                    .HasColumnName("quest_end")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QuestEndStatus)
                    .HasColumnName("quest_end_status")
                    .HasColumnType("int")
                    .HasDefaultValueSql("11");

                entity.Property(e => e.QuestStartStatus)
                    .HasColumnName("quest_start_status")
                    .HasColumnType("int")
                    .HasDefaultValueSql("64");
            });

            modelBuilder.Entity<SpellBonusData>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("spell_bonus_data");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ApBonus)
                    .HasColumnName("ap_bonus")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ApDotBonus)
                    .HasColumnName("ap_dot_bonus")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DirectBonus)
                    .HasColumnName("direct_bonus")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DotBonus)
                    .HasColumnName("dot_bonus")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellCustomAttr>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("spell_custom_attr");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Attributes)
                    .HasColumnName("attributes")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellDbc>(entity =>
            {
                entity.ToTable("spell_dbc");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaGroupId)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Attributes)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttributesEx)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttributesEx2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttributesEx3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttributesEx4)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttributesEx5)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttributesEx6)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttributesEx7)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AuraInterruptFlags)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BaseLevel)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CastingTimeIndex)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Dispel)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgClass)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DmgMultiplier1).HasDefaultValueSql("0");

                entity.Property(e => e.DmgMultiplier2).HasDefaultValueSql("0");

                entity.Property(e => e.DmgMultiplier3).HasDefaultValueSql("0");

                entity.Property(e => e.DurationIndex)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Effect1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Effect2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Effect3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectAmplitude1)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectAmplitude2)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectAmplitude3)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectApplyAuraName1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectApplyAuraName2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectApplyAuraName3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectBasePoints1)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectBasePoints2)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectBasePoints3)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectDieSides1)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectDieSides2)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectDieSides3)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectImplicitTargetA1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectImplicitTargetA2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectImplicitTargetA3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectImplicitTargetB1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectImplicitTargetB2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectImplicitTargetB3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectItemType1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectItemType2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectItemType3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMechanic1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMechanic2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMechanic3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMiscValue1)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMiscValue2)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMiscValue3)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMiscValueB1)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMiscValueB2)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMiscValueB3)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectMultipleValue1).HasDefaultValueSql("0");

                entity.Property(e => e.EffectMultipleValue2).HasDefaultValueSql("0");

                entity.Property(e => e.EffectMultipleValue3).HasDefaultValueSql("0");

                entity.Property(e => e.EffectRadiusIndex1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectRadiusIndex2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectRadiusIndex3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectRealPointsPerLevel1).HasDefaultValueSql("0");

                entity.Property(e => e.EffectRealPointsPerLevel2).HasDefaultValueSql("0");

                entity.Property(e => e.EffectRealPointsPerLevel3).HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskA1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskA2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskA3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskB1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskB2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskB3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskC1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskC2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectSpellClassMaskC3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectTriggerSpell1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectTriggerSpell2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectTriggerSpell3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EquippedItemClass)
                    .HasColumnType("int")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.EquippedItemInventoryTypeMask)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EquippedItemSubClassMask)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxAffectedTargets)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxLevel)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxTargetLevel)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mechanic)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PreventionType)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProcChance)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProcCharges)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProcFlags)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RangeIndex)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SchoolMask)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellFamilyFlags1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellFamilyFlags2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellFamilyFlags3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellFamilyName)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellLevel)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StackAmount)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Stances)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StancesNot)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Targets)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellEnchantProcData>(entity =>
            {
                entity.HasKey(e => e.EnchantId);

                entity.ToTable("spell_enchant_proc_data");

                entity.Property(e => e.EnchantId)
                    .HasColumnName("EnchantID")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.AttributesMask)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("0");

                entity.Property(e => e.HitMask)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProcsPerMinute).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellGroup>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SpellId });

                entity.ToTable("spell_group");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_id")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellGroupStackRules>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("spell_group_stack_rules");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StackRule)
                    .HasColumnName("stack_rule")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellLearnSpell>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.SpellId });

                entity.ToTable("spell_learn_spell");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellId)
                    .HasColumnName("SpellID")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SpellLootTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Item });

                entity.ToTable("spell_loot_template");

                entity.Property(e => e.Entry)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Item)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("100");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LootMode)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MaxCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.MinCount)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.QuestRequired)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellPetAuras>(entity =>
            {
                entity.HasKey(e => new { e.Spell, e.EffectId, e.Pet });

                entity.ToTable("spell_pet_auras");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.EffectId)
                    .HasColumnName("effectId")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pet)
                    .HasColumnName("pet")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Aura)
                    .HasColumnName("aura")
                    .HasColumnType("mediumint unsigned");
            });

            modelBuilder.Entity<SpellProc>(entity =>
            {
                entity.HasKey(e => e.SpellId);

                entity.ToTable("spell_proc");

                entity.Property(e => e.SpellId)
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AttributesMask)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Chance).HasDefaultValueSql("0");

                entity.Property(e => e.Charges)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cooldown)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DisableEffectsMask)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HitMask)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProcFlags)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProcsPerMinute).HasDefaultValueSql("0");

                entity.Property(e => e.SchoolMask)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellFamilyMask0)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellFamilyMask1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellFamilyMask2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellFamilyName)
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellPhaseMask)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellTypeMask)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellRanks>(entity =>
            {
                entity.HasKey(e => new { e.FirstSpellId, e.Rank });

                entity.ToTable("spell_ranks");

                entity.HasIndex(e => e.SpellId)
                    .HasName("spell_id")
                    .IsUnique();

                entity.Property(e => e.FirstSpellId)
                    .HasColumnName("first_spell_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellRequired>(entity =>
            {
                entity.HasKey(e => new { e.SpellId, e.ReqSpell });

                entity.ToTable("spell_required");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_id")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqSpell)
                    .HasColumnName("req_spell")
                    .HasColumnType("mediumint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellTargetPosition>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.EffectIndex });

                entity.ToTable("spell_target_position");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EffectIndex)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnName("MapID")
                    .HasColumnType("smallint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Orientation).HasDefaultValueSql("0");

                entity.Property(e => e.PositionX).HasDefaultValueSql("0");

                entity.Property(e => e.PositionY).HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SpellThreat>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("spell_threat");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApPctMod)
                    .HasColumnName("apPctMod")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FlatMod)
                    .HasColumnName("flatMod")
                    .HasColumnType("int");

                entity.Property(e => e.PctMod)
                    .HasColumnName("pctMod")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SpelldifficultyDbc>(entity =>
            {
                entity.ToTable("spelldifficulty_dbc");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spellid0)
                    .HasColumnName("spellid0")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spellid1)
                    .HasColumnName("spellid1")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spellid2)
                    .HasColumnName("spellid2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Spellid3)
                    .HasColumnName("spellid3")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Spellregulator>(entity =>
            {
                entity.HasKey(e => e.SpellId);

                entity.ToTable("spellregulator");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spellId")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasDefaultValueSql("100");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("trainer");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Greeting).IsUnicode(false);

                entity.Property(e => e.Requirement)
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(2) unsigned")
                    .HasDefaultValueSql("2");
            });

            modelBuilder.Entity<TrainerLocale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Locale });

                entity.ToTable("trainer_locale");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.GreetingLang)
                    .HasColumnName("Greeting_lang")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrainerSpell>(entity =>
            {
                entity.HasKey(e => new { e.TrainerId, e.SpellId });

                entity.ToTable("trainer_spell");

                entity.Property(e => e.TrainerId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SpellId)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MoneyCost)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqAbility1)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqAbility2)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqAbility3)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqLevel)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqSkillLine)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReqSkillRank)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Transports>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("transports");

                entity.HasIndex(e => e.Entry)
                    .HasName("idx_entry")
                    .IsUnique();

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasColumnType("char(64)");
            });

            modelBuilder.Entity<TrinityString>(entity =>
            {
                entity.HasKey(e => e.Entry);

                entity.ToTable("trinity_string");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ContentDefault)
                    .IsRequired()
                    .HasColumnName("content_default")
                    .IsUnicode(false);

                entity.Property(e => e.ContentLoc1)
                    .HasColumnName("content_loc1")
                    .IsUnicode(false);

                entity.Property(e => e.ContentLoc2)
                    .HasColumnName("content_loc2")
                    .IsUnicode(false);

                entity.Property(e => e.ContentLoc3)
                    .HasColumnName("content_loc3")
                    .IsUnicode(false);

                entity.Property(e => e.ContentLoc4)
                    .HasColumnName("content_loc4")
                    .IsUnicode(false);

                entity.Property(e => e.ContentLoc5)
                    .HasColumnName("content_loc5")
                    .IsUnicode(false);

                entity.Property(e => e.ContentLoc6)
                    .HasColumnName("content_loc6")
                    .IsUnicode(false);

                entity.Property(e => e.ContentLoc7)
                    .HasColumnName("content_loc7")
                    .IsUnicode(false);

                entity.Property(e => e.ContentLoc8)
                    .HasColumnName("content_loc8")
                    .IsUnicode(false);
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

            modelBuilder.Entity<VehicleAccessory>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.SeatId });

                entity.ToTable("vehicle_accessory");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeatId)
                    .HasColumnName("seat_id")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AccessoryEntry)
                    .HasColumnName("accessory_entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Minion)
                    .HasColumnName("minion")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Summontimer)
                    .HasColumnName("summontimer")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("30000");

                entity.Property(e => e.Summontype)
                    .HasColumnName("summontype")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("6");
            });

            modelBuilder.Entity<VehicleTemplateAccessory>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.SeatId });

                entity.ToTable("vehicle_template_accessory");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeatId)
                    .HasColumnName("seat_id")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AccessoryEntry)
                    .HasColumnName("accessory_entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Minion)
                    .HasColumnName("minion")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Summontimer)
                    .HasColumnName("summontimer")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("30000");

                entity.Property(e => e.Summontype)
                    .HasColumnName("summontype")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("6");
            });

            modelBuilder.Entity<WardenChecks>(entity =>
            {
                entity.ToTable("warden_checks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("smallint unsigned");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Str)
                    .HasColumnName("str")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<WaypointData>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Point });

                entity.ToTable("waypoint_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Point)
                    .HasColumnName("point")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ActionChance)
                    .HasColumnName("action_chance")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("100");

                entity.Property(e => e.Delay)
                    .HasColumnName("delay")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MoveType)
                    .HasColumnName("move_type")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Orientation)
                    .HasColumnName("orientation")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Wpguid)
                    .HasColumnName("wpguid")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<WaypointScripts>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("waypoint_scripts");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Command)
                    .HasColumnName("command")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dataint)
                    .HasColumnName("dataint")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Datalong)
                    .HasColumnName("datalong")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Datalong2)
                    .HasColumnName("datalong2")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Delay)
                    .HasColumnName("delay")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.O)
                    .HasColumnName("o")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Waypoints>(entity =>
            {
                entity.HasKey(e => new { e.Entry, e.Pointid });

                entity.ToTable("waypoints");

                entity.Property(e => e.Entry)
                    .HasColumnName("entry")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pointid)
                    .HasColumnName("pointid")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PointComment)
                    .HasColumnName("point_comment")
                    .IsUnicode(false);

                entity.Property(e => e.PositionX)
                    .HasColumnName("position_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionY)
                    .HasColumnName("position_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PositionZ)
                    .HasColumnName("position_z")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ZombieDeathmatchRewards>(entity =>
            {
                entity.HasKey(e => new { e.Round, e.Entry });

                entity.ToTable("zombie_deathmatch_rewards");

                entity.Property(e => e.Round)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Entry).HasColumnType("int unsigned");

                entity.Property(e => e.Count)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ZombieDeathmatchRounds>(entity =>
            {
                entity.HasKey(e => new { e.Round, e.ZombieEntry });

                entity.ToTable("zombie_deathmatch_rounds");

                entity.Property(e => e.Round)
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ZombieEntry)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BaseCount)
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("0");
            });
        }
    }
}
