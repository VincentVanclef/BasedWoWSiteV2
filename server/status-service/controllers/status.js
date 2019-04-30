const { body, validationResult } = require("express-validator/check");
const { auth_pool, char_pool } = require("../mysql");
const asyncHandler = require("../utils/asyncHandler");

const statusController = {
  // VALIDATION
  validate: method => {
    switch (method) {
      case "online": {
        return body("database")
          .exists()
          .isString();
      }
    }
  },
  // GET
  all: asyncHandler(async (req, res) => {
    const auth_result = await auth_pool.query(
      "select id, name from realmlist order by id asc"
    );
    res.json(auth_result);
  }),
  // POST
  online: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.send(errors.array());
      return;
    }

    const { database } = req.body;

    const char_result = await char_pool.query(
      `select race from ${database}.characters where online = 1`
    );

    let allianceOnline = 0;
    let hordeOnline = 0;

    char_result.forEach(player => {
      switch (parseInt(player.race, 10)) {
        case 2:
        case 5:
        case 6:
        case 8:
        case 9:
        case 10:
          ++hordeOnline;
          break;
        case 1:
        case 3:
        case 4:
        case 7:
        case 11:
          ++allianceOnline;
          break;
      }
    });

    res.json({ aonline: allianceOnline, honline: hordeOnline });
  }),
  onlineplayers: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.send(errors.array());
      return;
    }

    const { database } = req.body;

    const result = await char_pool.query(
      `select name, race, class, level, zone, gender from ${database}.characters where online = 1`
    );

    res.json({ result });
  })
};

module.exports = statusController;
