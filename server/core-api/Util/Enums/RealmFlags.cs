namespace server.Util.Enums
{
    public enum RealmFlags
    {
        None         = 0,
        Invalid      = 1,
        Offline      = 2,
        SpecifyBuild = 4,
        Medium       = 8,
        Medium2      = 16,
        NewPlayers   = 32,
        Recommended  = 64,
        Full         = 128
    }
}