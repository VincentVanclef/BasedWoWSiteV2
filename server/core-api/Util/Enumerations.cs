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
        Helios       = 4,
        Max          = 4
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

    public enum TimeConstants
    {
        MINUTE          = 60,
        HOUR            = MINUTE * 60,
        DAY             = HOUR * 24,
        WEEK            = DAY * 7,
        MONTH           = DAY * 30,
        YEAR            = MONTH * 12,
        IN_MILLISECONDS = 1000
    }

    public enum EquipmentSlots
    {
        EQUIPMENT_SLOT_START = 0,
        EQUIPMENT_SLOT_HEAD = 0,
        EQUIPMENT_SLOT_NECK = 1,
        EQUIPMENT_SLOT_SHOULDERS = 2,
        EQUIPMENT_SLOT_BODY = 3,
        EQUIPMENT_SLOT_CHEST = 4,
        EQUIPMENT_SLOT_WAIST = 5,
        EQUIPMENT_SLOT_LEGS = 6,
        EQUIPMENT_SLOT_FEET = 7,
        EQUIPMENT_SLOT_WRISTS = 8,
        EQUIPMENT_SLOT_HANDS = 9,
        EQUIPMENT_SLOT_FINGER1 = 10,
        EQUIPMENT_SLOT_FINGER2 = 11,
        EQUIPMENT_SLOT_TRINKET1 = 12,
        EQUIPMENT_SLOT_TRINKET2 = 13,
        EQUIPMENT_SLOT_BACK = 14,
        EQUIPMENT_SLOT_MAINHAND = 15,
        EQUIPMENT_SLOT_OFFHAND = 16,
        EQUIPMENT_SLOT_RANGED = 17,
        EQUIPMENT_SLOT_TABARD = 18,
        EQUIPMENT_SLOT_END = 19
    };

    public enum InventoryType
    {
        INVTYPE_NON_EQUIP = 0,
        INVTYPE_HEAD = 1,
        INVTYPE_NECK = 2,
        INVTYPE_SHOULDERS = 3,
        INVTYPE_BODY = 4,
        INVTYPE_CHEST = 5,
        INVTYPE_WAIST = 6,
        INVTYPE_LEGS = 7,
        INVTYPE_FEET = 8,
        INVTYPE_WRISTS = 9,
        INVTYPE_HANDS = 10,
        INVTYPE_FINGER = 11,
        INVTYPE_TRINKET = 12,
        INVTYPE_WEAPON = 13,
        INVTYPE_SHIELD = 14,
        INVTYPE_RANGED = 15,
        INVTYPE_CLOAK = 16,
        INVTYPE_TWOHANDWEAPON = 17,
        INVTYPE_BAG = 18,
        INVTYPE_TABARD = 19,
        INVTYPE_ROBE = 20,
        INVTYPE_WEAPONMAINHAND = 21,
        INVTYPE_WEAPONOFFHAND = 22,
        INVTYPE_HOLDABLE = 23,
        INVTYPE_AMMO = 24,
        INVTYPE_THROWN = 25,
        INVTYPE_RANGEDRIGHT = 26,
        INVTYPE_QUIVER = 27,
        INVTYPE_RELIC = 28
    };

    public enum ItemClass
    {
        ITEM_CLASS_CONSUMABLE = 0,
        ITEM_CLASS_CONTAINER = 1,
        ITEM_CLASS_WEAPON = 2,
        ITEM_CLASS_GEM = 3,
        ITEM_CLASS_ARMOR = 4,
        ITEM_CLASS_REAGENT = 5,
        ITEM_CLASS_PROJECTILE = 6,
        ITEM_CLASS_TRADE_GOODS = 7,
        ITEM_CLASS_GENERIC = 8,
        ITEM_CLASS_RECIPE = 9,
        ITEM_CLASS_MONEY = 10,
        ITEM_CLASS_QUIVER = 11,
        ITEM_CLASS_QUEST = 12,
        ITEM_CLASS_KEY = 13,
        ITEM_CLASS_PERMANENT = 14,
        ITEM_CLASS_MISC = 15,
        ITEM_CLASS_GLYPH = 16
    };
}
