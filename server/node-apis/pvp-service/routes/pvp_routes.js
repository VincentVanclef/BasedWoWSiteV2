const express = require("express");
const router = express.Router();
const controller = require("../controllers/pvp_controller");

router.post(
  "/get/TopArenaTeams",
  controller.validate("TopArenaTeams"),
  controller.TopArenaTeams
);

router.post(
  "/get/TopTeamMembers",
  controller.validate("TopTeamMembers"),
  controller.TopTeamMembers
);

router.post(
  "/get/TopHKPlayers",
  controller.validate("TopHKPlayers"),
  controller.TopHKPlayers
);

module.exports = router;
