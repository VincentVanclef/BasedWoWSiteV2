const express = require("express");
const router = express.Router();
const pool = require("../mysql");
const asyncMiddleware = require('../utils/asyncMiddleware');

router.get("/", asyncMiddleware(async (req, res, next) => {
    const result = await pool.query("select * from manufacturer");
    res.send(result);
}));

module.exports = router;