const express = require("express");
const router = express.Router();
const pool = require("../mysql");
const asyncMiddleware = require("../utils/asyncMiddleware");

router.get(
  "/",
  asyncMiddleware(async (req, res, next) => {
    const result = await pool.query("select * from news");
    res.json(result);
  })
);

router.get(
  "/comments/:id",
  asyncMiddleware(async (req, res, next) => {
    const id = req.params.id;
    if (!id || isNaN(id)) {
      res.send("no valid id specified");
      return;
    }

    const result = await pool.query(
      "SELECT * FROM news_comments WHERE newsId = ?",
      id
    );
    res.json(result);
  })
);

router.get(
  "/comments/:id/total",
  asyncMiddleware(async (req, res, next) => {
    const id = req.params.id;
    if (!id || isNaN(id)) {
      res.send("no valid id specified");
      return;
    }

    const result = await pool.query(
      "SELECT COUNT(*) AS total FROM news_comments WHERE newsId = ?",
      id
    );

    res.json(result[0]);
  })
);

router.post(
  "/comments/new",
  asyncMiddleware(async (req, res, next) => {
    const { newsid, userid, comment } = req.body;

    if (newsid == null || userid == null || comment == null) {
      res.send("Error in adding new comment");
      return;
    }

    await pool.query(
      "INSERT INTO news_comments (NewsId, UserId, comment) VALUES (?, ?, ?)",
      [newsid, userid, comment]
    );
    const result = await pool.query(
      "SELECT * FROM news_comments WHERE newsId = ?",
      newsid
    );
    res.json(result);
  })
);

module.exports = router;
