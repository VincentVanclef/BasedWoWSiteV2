const express = require("express");
const router = express.Router();
const pool = require("../mysql");

/* GET users listing. */
router.get("/user", function(req, res, next) {
  res.send("respond with a resource");
});

router.get("/customers", async (req, res) => {
  try {
    const result = await pool.query("select * from news");
    res.send(result);
  } catch (err) {
    res.status(500);
    res.send(err.message);
  }
});

module.exports = router;
