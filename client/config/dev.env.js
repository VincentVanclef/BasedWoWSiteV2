"use strict";
const merge = require("webpack-merge");
const prodEnv = require("./prod.env");

module.exports = merge(prodEnv, {
  NODE_ENV: '"development"',
  API: {
    NEWS: '"http://localhost/news"',
    STORE: '"http://localhost/store"',
    STATUS: '"http://localhost/status"',
    AUTH: '"https://localhost:44342/auth"',
    ACCOUNT: '"https://localhost:44342/account"',
    VOTE: '"https://localhost:44342/vote"',
    PAYPAL: '"http://localhost/paypal"',
    ADMIN: '"https://localhost:44342/admin"',
    CHANGELOG: '"http://localhost/changelog"',
    PVPSTATS: '"http://localhost/pvp"',
  }
});
