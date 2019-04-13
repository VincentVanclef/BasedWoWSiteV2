const express = require("express");
const router = express.Router();
const pool = require("../mysql");
const asyncMiddleware = require('../utils/asyncMiddleware');

router.get("/", asyncMiddleware(async (req, res, next) => {
    const result = await pool.query("select * from products");
    res.send(result);
}));

router.get("/:id", asyncMiddleware(async (req, res, next) => {
    const idParam = req.params.id;
    const result = await pool.query("select * from products where id = ?", idParam);
    res.send(result);
}));

module.exports = router;