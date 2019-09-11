using Newtonsoft.Json;

namespace server.Data.Auth
{
    public partial class AccountMuted
    {
        public int AccountId { get; set; }
        public int MuteDate { get; set; }
        public int MuteTime { get; set; }
        public string MutedBy { get; set; }
        public string MuteReason { get; set; }
    }
}
