const sql = require("mssql");

// Connection string parameters.
const config = {
  user: "root",
  password: "q2w3e4r5",
  server: "localhost",
  database: "skole",
  port: 1433
};

const poolPromise = new sql.ConnectionPool(config)
  .connect()
  .then(pool => {
    console.log("Connected to MSSQL");
    return pool;
  })
  .catch(err => console.log("Database Connection Failed! Bad Config: ", err));

module.exports = {
  sql,
  poolPromise
};
