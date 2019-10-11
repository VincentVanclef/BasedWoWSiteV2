namespace server.Util.Enums
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
}
