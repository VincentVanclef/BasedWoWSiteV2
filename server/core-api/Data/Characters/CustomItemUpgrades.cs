namespace server.Data.Characters
{
    public class CustomItemUpgrades
    {
        public int ItemGuid { get; set; }
        public int OwnerGuid { get; set; }
        public int StatId1 { get; set; }
        public int StatId2 { get; set; }
        public int StatId3 { get; set; }
        public int StatId4 { get; set; }
        public int StatId5 { get; set; }
        public int StatId6 { get; set; }
        public int StatId7 { get; set; }
        public int StatId8 { get; set; }
        public int StatId9 { get; set; }
        public int StatId10 { get; set; }
        public int ArmorId { get; set; }
        public int DmgId1 { get; set; }
        public int DmgId2 { get; set; }
        public int HolyResId { get; set; }
        public int FireResId { get; set; }
        public int NatureResId { get; set; }
        public int FrostResId { get; set; }
        public int ShadowResId { get; set; }
        public int ArcaneResId { get; set; }
        public string Name { get; set; }
        public sbyte Quality { get; set; }
        public byte SetId { get; set; }
        public byte Active { get; set; }
        public int UpgradeLevel { get; set; }

        public bool IsActive()
        {
            return Active == 1;
        }
    }
}
