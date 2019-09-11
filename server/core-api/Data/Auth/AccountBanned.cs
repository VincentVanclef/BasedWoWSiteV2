namespace server.Data.Auth
{
    public class AccountBanned
    {
        public int AccountId { get; set; }
        public int BanDate { get; set; }
        public int UnbanDate { get; set; }
        public string BannedBy { get; set; }
        public string BanReason { get; set; }
        public byte Active { get; set; }
    }
}
