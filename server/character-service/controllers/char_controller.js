const { body, validationResult } = require("express-validator/check");
const char_pool = require("../mysql");
const asyncHandler = require("../utils/asyncHandler");

const controller = {
  // VALIDATION
  validate: method => {
    switch (method) {
      case "GetCharacters": {
        return [
          body("database")
            .exists()
            .isString(),
          body("accountId")
            .exists()
            .isInt()
        ];
      }
      case "GetUnstuckPositions": {
        return body("database")
          .exists()
          .isString();
      }
      case "Teleport": {
        return [
          body("database")
            .exists()
            .isString(),
          body("guid")
            .exists()
            .isInt(),
          body("location")
            .exists()
            .isInt()
        ];
      }
    }
  },
  GetUnstuckPositions: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.send(errors.array());
      return;
    }

    const { database } = req.body;

    const result = await char_pool.query(
      "SELECT id, position_x, position_y, position_z, map, name FROM ??.unstuck_locations",
      [database]
    );

    res.json(result);
  }),
  GetCharacters: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.send(errors.array());
      return;
    }

    const { database, accountId } = req.body;

    const result = await char_pool.query(
      "SELECT guid, name, class, level FROM ??.characters WHERE account = ?",
      [database, accountId]
    );

    res.json(result);
  }),

  Character: {
    Teleport: asyncHandler(async (req, res) => {
      const errors = validationResult(req);

      if (!errors.isEmpty()) {
        res.send(errors.array());
        return;
      }

      const { database, guid, location } = req.body;

      const locResult = await char_pool.query(
        "SELECT position_x, position_y, position_z, map FROM ??.unstuck_locations WHERE id = ?",
        [database, location]
      );

      if (locResult.length == 0) {
        res.status(404).json({ error: "Unable to find teleport location." });
        return;
      }

      const result = await char_pool.query(
        "UPDATE ??.characters SET position_x = ?, position_y = ?, position_z = ?, map = ? WHERE guid = ?",
        [
          database,
          locResult[0].position_x,
          locResult[0].position_y,
          locResult[0].position_z,
          locResult[0].map,
          guid
        ]
      );

      res.status(200).send();
    })
  }
};

module.exports = controller;
