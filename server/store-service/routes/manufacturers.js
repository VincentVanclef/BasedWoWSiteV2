const express = require("express");
const router = express.Router();
const pool = require("../mysql");
const asyncHandler = require('../utils/asyncHandler');

router.get("/", asyncHandler(async (req, res, next) => {
    const result = await pool.query("select * from manufacturer");
    res.send(result);
}));

module.exports = router;