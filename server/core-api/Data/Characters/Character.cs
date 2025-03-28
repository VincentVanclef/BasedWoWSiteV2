﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace server.Data.Characters
{
    public class Character
    {
        public Character()
        {
            
        }

        public Character(Character character)
        {
            Id = character.Id;
            Account = character.Account;
            Name = character.Name;
            Race = character.Race;
            Class = character.Class;
            Level = character.Level;
            Gender = character.Gender;
            AtLogin = character.AtLogin;
            Xp = character.Xp;
            ArenaPoints = character.ArenaPoints;
            TotalHonorPoints = character.TotalHonorPoints;
            TodayHonorPoints = character.TodayHonorPoints;
            Map = character.Map;
            Zone = character.Zone;
            Money = character.Money;
            Online = character.Online;
            YesterdayHonorPoints = character.YesterdayHonorPoints;
            KnownTitles = character.KnownTitles;
            PositionX = character.PositionX;
            PositionY = character.PositionY;
            PositionZ = character.PositionZ;
            Orientation = character.Orientation;
            Totaltime = character.Totaltime;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("guid")]
        public int Id { get; set; }
        public int Account { get; set; }
        public string Name { get; set; }
        public byte Race { get; set; }
        public byte Class { get; set; }
        public byte Gender { get; set; }
        public byte Level { get; set; }
        public int Xp { get; set; }
        public int Money { get; set; }
        /*public byte Skin { get; set; }
        public byte Face { get; set; }
        public byte HairStyle { get; set; }
        public byte HairColor { get; set; }
        public byte FacialStyle { get; set; }
        public byte BankSlots { get; set; }
        public byte RestState { get; set; }
        public int PlayerFlags { get; set; }*/
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public short Map { get; set; }
        //public int InstanceId { get; set; }
        //public byte InstanceModeMask { get; set; }
        public float Orientation { get; set; }
        // public string Taximask { get; set; }
        public byte Online { get; set; }
        //public byte Cinematic { get; set; }
        public int Totaltime { get; set; }
        public int Leveltime { get; set; }
        public int LogoutTime { get; set; }
        //public byte IsLogoutResting { get; set; }
        //public float RestBonus { get; set; }
        //public int ResettalentsCost { get; set; }
        //public int ResettalentsTime { get; set; }
        /*public float TransX { get; set; }
        public float TransY { get; set; }
        public float TransZ { get; set; }
        public float TransO { get; set; }
        public int Transguid { get; set; }
        public short ExtraFlags { get; set; }*/
        //public byte StableSlots { get; set; }
        public short AtLogin { get; set; }
        public short Zone { get; set; }
        //public int DeathExpireTime { get; set; }
        //public string TaxiPath { get; set; }
        public int ArenaPoints { get; set; }
        public int TotalHonorPoints { get; set; }
        public int TodayHonorPoints { get; set; }
        public int YesterdayHonorPoints { get; set; }
        public int TotalKills { get; set; }
        public short TodayKills { get; set; }
        public short YesterdayKills { get; set; }
        public int ChosenTitle { get; set; }
        public long KnownCurrencies { get; set; }
        //public int WatchedFaction { get; set; }
        //public byte Drunk { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int Health { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int Mana { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int Rage { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int Focus { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int Energy { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int Happiness { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int Runes { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int RunicPower { get; set; }

        public int Latency { get; set; }
        //public byte TalentGroupsCount { get; set; }
        //public byte ActiveTalentGroup { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string ExploredZones { get; set; }
        //public string EquipmentCache { get; set; }
        //public int AmmoId { get; set; }
        public string KnownTitles { get; set; }
        //public byte ActionBars { get; set; }
        //public byte GrantableLevels { get; set; }
        //public int? DeleteInfosAccount { get; set; }
        //public string DeleteInfosName { get; set; }
        //public int? DeleteDate { get; set; }
        public int QuestPlayersSlain { get; set; }

        public bool IsOnline()
        {
            return Online == 1;
        }

        public virtual List<CharacterBanned> CharacterBanned { get; set; }

        [NotMapped]
        public Guild Guild { get; set; }
    }
}
