const express = require("express");
const router = express.Router();
const statusController = require("../controllers/status");

router.get("/all", statusController.all);

router.post(
  "/online",
  statusController.validate("online"),
  statusController.online
);

router.post(
  "/online/players",
  statusController.validate("online"),
  statusController.onlineplayers
);

module.exports = router;
