using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Character
{
    public class TopHKPlayerStatistic
    {
        public TopHKPlayerStatistic()
        {
            
        }

        public TopHKPlayerStatistic(TopHKPlayerStatistic statistic, int rank)
        {
            Rank = rank;
            Guid = statistic.Guid;
            Name = statistic.Name;
            Level = statistic.Level;
            Race = statistic.Race;
            Class = statistic.Class;
            Gender = statistic.Gender;
            Kills = statistic.Kills;
            AccountId = statistic.AccountId;
        }

        public int Rank   { get; set; }
        public int Guid   { get; set; }
        public string Name   { get; set; }
        public int Level  { get; set; }
        public int Race   { get; set; }
        public int Class  { get; set; }
        public int Gender { get; set; }
        public int Kills  { get; set; }
        public int AccountId { get; set; }
    }            
}
