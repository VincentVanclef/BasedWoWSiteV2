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

    public enum GameRoles
    {
        Player     = 0,
        Trial      = 1,
        GameMaster = 2,
        Admin      = 3,
    }
}
