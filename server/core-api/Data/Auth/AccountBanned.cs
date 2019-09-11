using Newtonsoft.Json;

namespace server.Data.Auth
{
    public partial class AccountBanned
    {
        public int AccountId { get; set; }
        public int Bandate { get; set; }
        public int Unbandate { get; set; }
        public string Bannedby { get; set; }
        public string Banreason { get; set; }
        public byte Active { get; set; }
    }
}
