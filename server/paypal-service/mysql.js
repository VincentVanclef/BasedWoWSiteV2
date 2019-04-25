const util = require('util')
const mysql = require("mysql");

const config = require("./config");

const auth_pool  = mysql.createPool({
  connectionLimit: config.auth.connectionLimit,
  host           : config.auth.host,
  user           : config.auth.user,
  password       : config.auth.password,
  database       : config.auth.database,
  port           : config.auth.port
});

const website_pool = mysql.createPool({
    connectionLimit: config.website.connectionLimit,
    host           : config.website.host,
    user           : config.website.user,
    password       : config.website.password,
    database       : config.website.database,
    port           : config.website.port
});

// Ping database to check for common exception errors.
auth_pool.getConnection((err, connection) => {
    if (err) {
        if (err.code === 'PROTOCOL_CONNECTION_LOST') {
            console.error('Database connection was closed.')
        }
        if (err.code === 'ER_CON_COUNT_ERROR') {
            console.error('Database has too many connections.')
        }
        if (err.code === 'ECONNREFUSED') {
            console.error('Database connection was refused.')
        }
    }

    if (connection) {
        connection.release()
    }

    return;
})

website_pool.getConnection((err, connection) => {
    if (err) {
        if (err.code === 'PROTOCOL_CONNECTION_LOST') {
            console.error('Database connection was closed.')
        }
        if (err.code === 'ER_CON_COUNT_ERROR') {
            console.error('Database has too many connections.')
        }
        if (err.code === 'ECONNREFUSED') {
            console.error('Database connection was refused.')
        }
    }

    if (connection) {
        connection.release()
    }

    return;
})

// Promisify for Node.js async/await.
auth_pool.query = util.promisify(auth_pool.query)
website_pool.query = util.promisify(website_pool.query)

module.exports = { auth_pool, website_pool };
