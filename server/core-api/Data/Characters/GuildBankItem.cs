namespace server.Data.Characters
{
    public class GuildBankItem
    {
        public int GuildId { get; set; }
        public byte TabId { get; set; }
        public byte SlotId { get; set; }
        public int ItemGuid { get; set; }
    }
}
