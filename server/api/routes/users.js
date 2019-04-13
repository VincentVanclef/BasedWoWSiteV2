var express = require("express");
var router = express.Router();
var sql = require("mssql");

/* GET users listing. */
router.get("/user", function(req, res, next) {
  res.send("respond with a resource");
});

// Connection string parameters.
var sqlConfig = {
  user: "root",
  password: "root",
  server: "localhost",
  database: "skole",
  port: 1433
};

router.get("/customers", function(req, res) {
  // config for your database
  var config = {
    user: "root",
    password: "q2w3e4r5",
    server: "localhost",
    database: "skole",
    port: 1433
  };

  // connect to your database
  sql.connect(config, function(err) {
    if (err) console.log(err);

    // create Request object
    var request = new sql.Request();

    // query to the database and get the records
    request.query("select * from customers", function(err, recordset) {
      if (err) console.log(err);

      // send records as a response
      res.send(recordset);
    });
  });
});

module.exports = router;
