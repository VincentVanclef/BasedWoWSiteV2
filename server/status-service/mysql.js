const util = require("util");
const mysql = require("mysql");

const config = require("./config");

const auth_pool = mysql.createPool({
  connectionLimit: config.auth.connectionLimit,
  host: config.auth.host,
  user: config.auth.user,
  password: config.auth.password,
  database: config.auth.database,
  port: config.auth.port
});

const char_pool = mysql.createPool({
  connectionLimit: config.char.connectionLimit,
  host: config.char.host,
  user: config.char.user,
  password: config.char.password,
  database: config.char.database,
  port: config.char.port
});

// Ping database to check for common exception errors.
auth_pool.getConnection((err, connection) => {
  if (err) {
    if (err.code === "PROTOCOL_CONNECTION_LOST") {
      console.error("Database connection was closed.");
    }
    if (err.code === "ER_CON_COUNT_ERROR") {
      console.error("Database has too many connections.");
    }
    if (err.code === "ECONNREFUSED") {
      console.error("Database connection was refused.");
    }
  }

  if (connection) {
    connection.release();
  }

  return;
});

char_pool.getConnection((err, connection) => {
  if (err) {
    if (err.code === "PROTOCOL_CONNECTION_LOST") {
      console.error("Database connection was closed.");
    }
    if (err.code === "ER_CON_COUNT_ERROR") {
      console.error("Database has too many connections.");
    }
    if (err.code === "ECONNREFUSED") {
      console.error("Database connection was refused.");
    }
  }

  if (connection) {
    connection.release();
  }

  return;
});

// Promisify for Node.js async/await.
auth_pool.query = util.promisify(auth_pool.query);
char_pool.query = util.promisify(char_pool.query);

module.exports = { auth_pool, char_pool };
