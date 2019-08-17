const express = require("express");
const router = express.Router();
const pool = require("../mysql");
const asyncMiddleware = require("../utils/asyncMiddleware");

router.get(
  "/",
  asyncMiddleware(async (req, res, next) => {
    const result = await pool.query("SELECT * FROM news ORDER BY ID DESC");
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

router.post(
  "/delete",
  asyncMiddleware(async (req, res, next) => {
    const { id } = req.body;

    if (id == null || id <= 0) {
      res.send("Unable to delete news");
      return;
    }

    await pool.query("DELETE FROM news_comments WHERE newsId = ?", [id]);
    const result = await pool.query("DELETE FROM news WHERE id = ?", [id]);
    let response = "";
    if (result.affectedRows >= 1) {
      response = "success";
    } else {
      response = "No news with the id " + id + " exists.";
    }
    res.send(response);
  })
);

router.post(
  "/create",
  asyncMiddleware(async (req, res, next) => {
    const { title, content, author, image } = req.body;

    if (title == null || content == null || author == null || image == null) {
      res.send("Unable to create news");
      return;
    }

    const result = await pool.query(
      "INSERT INTO news (title, content, author, image) VALUES (?, ?, ?, ?)",
      [title, content, author, image]
    );
    if (result.insertId >= 1) {
      res.json({ newsid: result.insertId });
    } else {
      console.log(result);
      res.send("Unable to create news");
    }
  })
);

router.post(
  "/edit",
  asyncMiddleware(async (req, res, next) => {
    const { id, title, content, author, image } = req.body;

    if (
      id == null ||
      title == null ||
      content == null ||
      author == null ||
      image == null
    ) {
      res.send("Unable to edit news");
      return;
    }

    const result = await pool.query(
      "UPDATE news SET title = ?, content = ?, author = ?, image = ? WHERE id = ?",
      [title, content, author, image, id]
    );
    if (result.affectedRows >= 1) {
      res.send("success");
    } else {
      console.log(result);
      res.send("Unable to edit news");
    }
  })
);

module.exports = router;
