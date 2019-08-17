const config = {
  auth: {
    connectionLimit: 10,
    host: "localhost",
    user: "root",
    password: "root",
    database: "auth",
    port: 3306
  },
  char: {
    connectionLimit: 10,
    host: "localhost",
    user: "root",
    password: "root",
    //database: "characters",
    port: 3306
  }
};

module.exports = config;
