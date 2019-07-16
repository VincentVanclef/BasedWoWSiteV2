const express = require("express");
const router = express.Router();
const controller = require("../controllers/char_controller");

router.post(
  "/get/unstuck_locations",
  controller.validate("GetUnstuckPositions"),
  controller.GetUnstuckPositions
);

router.post(
  "/get/characters",
  controller.validate("GetCharacters"),
  controller.GetCharacters
);

router.post(
  "/character/teleport",
  controller.validate("Teleport"),
  controller.Character.Teleport
);

module.exports = router;
