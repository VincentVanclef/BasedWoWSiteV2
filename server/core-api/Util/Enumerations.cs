namespace server.Util
{
    public enum AtLoginFlags
    {
        AtLoginNone            = 0,
        AtLoginRename          = 1,
        AtLoginResetSpells     = 2,
        AtLoginResetTalents    = 4,
        AtLoginCustomize       = 8,
        AtLoginResetPetTalents = 16,
        AtLoginFirst           = 32,
        AtLoginChangeFaction   = 64,
        AtLoginChangeRace      = 128,
        AtLoginResurrect       = 256
    }

    public enum RealmType
    {
        TitansLeague = 1,
        TwinkNation  = 2,
        MountOlympus = 3,
        Helios       = 4
    }

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

    public enum GameRoles
    {
        Player     = 0,
        Trial      = 1,
        GameMaster = 2,
        Admin      = 3,
    }
}
