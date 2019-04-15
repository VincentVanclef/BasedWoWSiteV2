const express = require("express");
const router = express.Router();
const statusController = require('../controllers/status');

router.get("/all", statusController.all);

router.post("/online", statusController.validate('online'), statusController.online);

module.exports = router;
