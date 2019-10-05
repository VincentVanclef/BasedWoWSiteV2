namespace server.Data.Characters
{
    public class CustomItemUpgradeSets
    {
        public CustomItemUpgradeSets()
        {
            
        }

        public CustomItemUpgradeSets(int owner, byte setId, string setName)
        {
            Owner = owner;
            SetId = setId;
            SetName = setName;
        }

        public int Owner { get; set; }
        public byte SetId { get; set; }
        public string SetName { get; set; }
    }
}
