const express = require("express");
const router = express.Router();
const { poolPromise } = require("../db");

/* GET users listing. */
router.get("/user", function(req, res, next) {
  res.send("respond with a resource");
});

router.get("/customers", async (req, res) => {
  try {
    const pool = await poolPromise;
    console.log(pool);
    const request = await pool.request();
    const result = await request.query("select * from customers");
    res.json(result.recordset);
  } catch (err) {
    res.status(500);
    res.send(err.message);
  }
});

module.exports = router;
