const config = {

    API: {
        NEWS: 'http://localhost/news',
        STORE: 'http://localhost/store',
        STATUS: 'http://localhost/status',
        AUTH: 'https://localhost:44342/api/auth'
    },

    // This must match the data you have in your auth.realmlist table
    REALMS: [
    {
        id: 1,
        name: 'Titans League',
        chardb: 'characters'
    },
    {
        id: 2,
        name: 'Test Realm',
        chardb: 'testchar'
    }],

    VUE_APP_TITLE: 'Titans League - WoW',

    REALMLIST: 'logon.Titans-League.com'
}

export default config;
