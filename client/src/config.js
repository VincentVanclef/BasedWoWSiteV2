const config = {

    API: {
        NEWS: 'http://localhost/news',
        STORE: 'http://localhost/store',
        STATUS: 'http://localhost/status'
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
        chardb: 'testchars'
    }],


    VUE_APP_TITLE: 'Titans League - WoW'
}

export default config;
