using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace server.Data.World
{
    public class ItemTemplate
    {
        public int Entry { get; set; }
        public byte Class { get; set; }
        public byte Subclass { get; set; }

        [NotMapped]
        [JsonIgnore]
        public byte SoundOverrideSubclass { get; set; }
        public string Name { get; set; }
        public int DisplayId { get; set; }
        public byte Quality { get; set; }
        public int Flags { get; set; }
        public int FlagsExtra { get; set; }
        public byte BuyCount { get; set; }
        public long BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public byte InventoryType { get; set; }
        public int AllowableClass { get; set; }
        public int AllowableRace { get; set; }
        public short ItemLevel { get; set; }
        public byte RequiredLevel { get; set; }
        public short RequiredSkill { get; set; }
        public short RequiredSkillRank { get; set; }
        public int RequiredSpell { get; set; }
        public int RequiredHonorRank { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int RequiredCityRank { get; set; }

        public short RequiredReputationFaction { get; set; }
        public short RequiredReputationRank { get; set; }
        public int MaxCount { get; set; }
        public int? StackAble { get; set; }
        public byte ContainerSlots { get; set; }
        public byte StatsCount { get; set; }
        public byte StatType1 { get; set; }
        public int StatValue1 { get; set; }
        public byte StatType2 { get; set; }
        public int StatValue2 { get; set; }
        public byte StatType3 { get; set; }
        public int StatValue3 { get; set; }
        public byte StatType4 { get; set; }
        public int StatValue4 { get; set; }
        public byte StatType5 { get; set; }
        public int StatValue5 { get; set; }
        public byte StatType6 { get; set; }
        public int StatValue6 { get; set; }
        public byte StatType7 { get; set; }
        public int StatValue7 { get; set; }
        public byte StatType8 { get; set; }
        public int StatValue8 { get; set; }
        public byte StatType9 { get; set; }
        public int StatValue9 { get; set; }
        public byte StatType10 { get; set; }
        public int StatValue10 { get; set; }
        public short ScalingStatDistribution { get; set; }
        public int ScalingStatValue { get; set; }
        public float DmgMin1 { get; set; }
        public float DmgMax1 { get; set; }
        public byte DmgType1 { get; set; }
        public float DmgMin2 { get; set; }
        public float DmgMax2 { get; set; }
        public byte DmgType2 { get; set; }
        public int Armor { get; set; }
        public byte HolyRes { get; set; }
        public byte FireRes { get; set; }
        public byte NatureRes { get; set; }
        public byte FrostRes { get; set; }
        public byte ShadowRes { get; set; }
        public byte ArcaneRes { get; set; }
        public short Delay { get; set; }
        public byte AmmoType { get; set; }

        [NotMapped]
        [JsonIgnore]
        public float RangedModRange { get; set; }

        public int SpellId1 { get; set; }
        public byte SpellTrigger1 { get; set; }
        public short SpellCharges1 { get; set; }

        [NotMapped]
        [JsonIgnore]
        public float SpellPpmRate1 { get; set; }
        public int SpellCooldown1 { get; set; }
        public short SpellCategory1 { get; set; }
        public int SpellCategoryCooldown1 { get; set; }
        public int SpellId2 { get; set; }
        public byte SpellTrigger2 { get; set; }
        public short SpellCharges2 { get; set; }

        [NotMapped]
        [JsonIgnore]
        public float SpellPpmRate2 { get; set; }
        public int SpellCooldown2 { get; set; }
        public short SpellCategory2 { get; set; }
        public int SpellCategoryCooldown2 { get; set; }
        public int SpellId3 { get; set; }
        public byte SpellTrigger3 { get; set; }
        public short SpellCharges3 { get; set; }

        [NotMapped]
        [JsonIgnore]
        public float SpellPpmRate3 { get; set; }
        public int SpellCooldown3 { get; set; }
        public short SpellCategory3 { get; set; }
        public int SpellCategoryCooldown3 { get; set; }
        public int SpellId4 { get; set; }
        public byte SpellTrigger4 { get; set; }
        public short SpellCharges4 { get; set; }

        [NotMapped]
        [JsonIgnore]
        public float SpellPpmRate4 { get; set; }
        public int SpellCooldown4 { get; set; }
        public short SpellCategory4 { get; set; }
        public int SpellCategoryCooldown4 { get; set; }
        public int SpellId5 { get; set; }
        public byte SpellTrigger5 { get; set; }
        public short SpellCharges5 { get; set; }

        [NotMapped]
        [JsonIgnore]
        public float SpellPpmRate5 { get; set; }
        public int SpellCooldown5 { get; set; }
        public short SpellCategory5 { get; set; }
        public int SpellCategoryCooldown5 { get; set; }
        public byte Bonding { get; set; }
        public string Description { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int PageText { get; set; }

        [NotMapped]
        [JsonIgnore]
        public byte LanguageId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public byte PageMaterial { get; set; }
        public int StartQuest { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int LockId { get; set; }
        public byte Material { get; set; }

        [NotMapped]
        [JsonIgnore]
        public byte Sheath { get; set; }
        public int RandomProperty { get; set; }
        public int RandomSuffix { get; set; }
        public int Block { get; set; }
        public int ItemSet { get; set; }
        public short MaxDurability { get; set; }
        public int Area { get; set; }
        public short Map { get; set; }
        public int BagFamily { get; set; }
        public int TotemCategory { get; set; }
        public byte SocketColor1 { get; set; }
        public int SocketContent1 { get; set; }
        public byte SocketColor2 { get; set; }
        public int SocketContent2 { get; set; }
        public byte SocketColor3 { get; set; }
        public int SocketContent3 { get; set; }
        public int SocketBonus { get; set; }
        public int GemProperties { get; set; }

        [NotMapped]
        [JsonIgnore]
        public short RequiredDisenchantSkill { get; set; }

        [NotMapped]
        [JsonIgnore]
        public float ArmorDamageModifier { get; set; }
        public int Duration { get; set; }

        [NotMapped]
        [JsonIgnore]
        public short ItemLimitCategory { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int HolidayId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string ScriptName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int DisenchantId { get; set; }
        public byte FoodType { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int MinMoneyLoot { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int MaxMoneyLoot { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int FlagsCustom { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int Cond { get; set; }
    }
}
