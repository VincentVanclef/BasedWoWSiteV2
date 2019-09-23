"use strict";
const merge = require("webpack-merge");
const prodEnv = require("./prod.env");

module.exports = merge(prodEnv, {
  NODE_ENV: '"development"',
  API: {
    NEWS: '"https://localhost:44342/news"',
    STATUS: '"https://localhost:44342/status"',
    AUTH: '"https://localhost:44342/auth"',
    ACCOUNT: '"https://localhost:44342/account"',
    VOTE: '"https://localhost:44342/vote"',
    DONATE: '"https://localhost:44342/paypal"',
    ADMIN: '"https://localhost:44342/admin"',
    ROLES: '"https://localhost:44342/role"',
    CHANGELOG: '"https://localhost:44342/changelog"',
    STATISTICS: '"https://localhost:44342/statistics"',
    CHARACTERS: '"https://localhost:44342/character"',
    GUILDS: '"https://localhost:44342/guild"',
    SHOUTBOX: '"https://localhost:44342/shoutbox"',
    REALMS: '"https://localhost:44342/realm"',
    ARMORY: '"https://localhost:44342/armory"',
  },
  SIGNALR: {
    URL: "'https://localhost:44342/signalRHub'"
  }
});
