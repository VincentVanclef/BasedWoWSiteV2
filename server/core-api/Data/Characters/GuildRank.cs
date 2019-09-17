namespace server.Data.Characters
{
    public class GuildRank
    {
        public int GuildId { get; set; }
        public byte Id { get; set; }
        public string RankName { get; set; }
        public int Rights { get; set; }
        public int BankMoneyPerDay { get; set; }
    }
}
