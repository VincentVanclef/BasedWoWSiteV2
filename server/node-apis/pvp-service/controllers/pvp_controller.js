const { body, validationResult } = require("express-validator/check");
const char_pool = require("../mysql");
const asyncHandler = require("../utils/asyncHandler");

const MAX_ARENA_TEAMS = 5;

const controller = {
  // VALIDATION
  validate: method => {
    switch (method) {
      case "TopArenaTeams": {
        return body("database")
          .exists()
          .isString();
      }
      case "TopTeamMembers": {
        return [
          body("database")
            .exists()
            .isString(),
          body("teams")
            .exists()
            .isArray()
        ];
      }
      case "TopHKPlayers": {
        return [
          body("database")
            .exists()
            .isString(),
          body("limit")
            .exists()
            .isInt()
        ];
      }
    }
  },
  TopArenaTeams: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.send(errors.array());
      return;
    }

    const { database } = req.body;

    const query = `
    (SELECT arenaTeamId AS arenateamid, rating, rank, name, captainGuid AS captain, type FROM ??.arena_team WHERE type = '2' ORDER BY rating DESC LIMIT ${MAX_ARENA_TEAMS})
    UNION ALL
    (SELECT arenaTeamId AS arenateamid, rating, rank, name, captainGuid AS captain, type FROM ??.arena_team WHERE type = '3' ORDER BY rating DESC LIMIT ${MAX_ARENA_TEAMS})
    UNION ALL
    (SELECT arenaTeamId AS arenateamid, rating, rank, name, captainGuid AS captain, type FROM ??.arena_team WHERE type = '5' ORDER BY rating DESC LIMIT ${MAX_ARENA_TEAMS})`;

    const result = await char_pool.query(query, [database, database, database]);

    res.json(result);
  }),
  TopTeamMembers: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.send(errors.array());
      return;
    }

    const { database, teams } = req.body;

    const result = await char_pool.query(
      `SELECT 
          arena_team_member.arenaTeamId AS arenateamid, 
          arena_team_member.guid AS guid, 
          arena_team_member.personalRating AS rating,
          arena_team_member.seasonGames AS games,
          arena_team_member.seasonWins AS wins,
          characters.name AS name,
          characters.class AS class,
          characters.level AS level
      FROM ??.arena_team_member 
      RIGHT JOIN ??.characters ON ??.characters.guid = ??.arena_team_member.guid 
      WHERE ??.arena_team_member.arenateamid IN (?) ORDER BY guid ASC`,
      [database, database, database, database, database, teams]
    );

    res.json(result);
  }),
  TopHKPlayers: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.send(errors.array());
      return;
    }

    const { database, limit } = req.body;

    const result = await char_pool.query(
      `
      SET @row_number = 0;
      SELECT (@row_number:=@row_number + 1) AS rank, guid, name, level, race, class, gender, totalKills AS kills FROM ??.characters WHERE totalKills > 0 ORDER BY totalKills DESC LIMIT ?`,
      [database, parseInt(limit)]
    );

    res.json(result[1]);
  })
};

module.exports = controller;
