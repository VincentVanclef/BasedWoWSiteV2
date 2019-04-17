const express = require("express");
const router = express.Router();
const manufacturerController = require('../controllers/manufacturer');

router.get("/", manufacturerController.all);

router.get("/:id", manufacturerController.byId);

module.exports = router;