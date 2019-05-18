const config = {
  // This must match the data you have in your auth.realmlist table
  REALMS: [
    {
      id: 1,
      name: "Titans League",
      chardb: "characters"
    },
    {
      id: 2,
      name: "Twink Nation",
      chardb: "twink_char"
    },
    {
      id: 3,
      name: "Mount Olympus",
      chardb: "testchar"
    }
  ],

  VUE_APP_TITLE: "Titans League - WoW",

  REALMLIST: "logon.Titans-League.org"
};

export default config;
