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
    PAYPAL: '"http://localhost/paypal"',
    ADMIN: '"https://localhost:44342/admin"',
    CHANGELOG: '"https://localhost:44342/changelog"',
    STATISTICS: '"https://localhost:44342/statistics"',
    CHARACTERS: '"https://localhost:44342/character"',
    SHOUTBOX: '"https://localhost:44342/shoutbox"'
  },
  SIGNALR: {
    URL: "'https://localhost:44342/signalRHub'"
  }
});
