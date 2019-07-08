const { body, validationResult } = require("express-validator/check");
const website_pool = require("../mysql");
const asyncHandler = require("../utils/asyncHandler");

const controller = {
  // VALIDATION
  validate: method => {
    switch (method) {
      case "add-change": {
        return [
          body("realm")
            .exists()
            .isInt(),
          body("category")
            .exists()
            .isInt(),
          body("content")
            .exists()
            .isString()
        ];
      }
      case "add-category": {
        return body("title")
          .exists()
          .isString();
      }
      case "delete-change": {
        return body("id")
          .exists()
          .isInt();
      }
      case "delete-category": {
        return body("id")
          .exists()
          .isInt();
      }
      case "update-change": {
        return [
          body("id")
            .exists()
            .isInt(),
          body("category")
            .exists()
            .isInt(),
          body("title")
            .exists()
            .isString(),
          body("content")
            .exists()
            .isString()
        ];
      }
    }
  },
  // GET
  all: {
    changes: asyncHandler(async (req, res) => {
      const result = await website_pool.query(
        "SELECT id, realm, category, title, content, date FROM changelog ORDER BY id ASC"
      );
      res.json(result);
    }),
    categories: asyncHandler(async (req, res) => {
      const result = await website_pool.query(
        "SELECT id, title FROM changelog_category ORDER BY id ASC"
      );
      res.json(result);
    })
  },
  add: {
    change: asyncHandler(async (req, res) => {
      const errors = validationResult(req);

      if (!errors.isEmpty()) {
        res.send(errors.array());
        return;
      }

      const { realm, category, content } = req.body;

      const result = await website_pool.query(
        "INSERT INTO changelog (realm, category, content) VALUES (?, ?, ?)",
        [realm, category, content]
      );

      const success = result.affectedRows == 1 ? "success" : "error";
      res.json({ status: success });
    }),
    category: asyncHandler(async (req, res) => {
      const errors = validationResult(req);

      if (!errors.isEmpty()) {
        res.send(errors.array());
        return;
      }

      const { title } = req.body;

      const result = await website_pool.query(
        "INSERT INTO changelog_category (title) VALUES (?)",
        [title.toUpperCase()]
      );

      const success = result.affectedRows == 1 ? "success" : "error";
      res.json({ status: success });
    })
  },
  delete: {
    change: asyncHandler(async (req, res) => {
      const errors = validationResult(req);

      if (!errors.isEmpty()) {
        res.send(errors.array());
        return;
      }

      const { id } = req.body;

      const result = await website_pool.query(
        "DELETE FROM changelog WHERE id = ?",
        [id]
      );

      const success = result.affectedRows == 1 ? "success" : "error";
      res.json({ status: success });
    }),
    category: asyncHandler(async (req, res) => {
      const errors = validationResult(req);

      if (!errors.isEmpty()) {
        res.send(errors.array());
        return;
      }

      const { id } = req.body;

      const result = await website_pool.query(
        "DELETE FROM changelog_category WHERE id = ?",
        [id]
      );

      const success = result.affectedRows == 1 ? "success" : "error";
      res.json({ status: success });
    })
  },
  update: {
    change: asyncHandler(async (req, res) => {
      const errors = validationResult(req);

      if (!errors.isEmpty()) {
        res.send(errors.array());
        return;
      }

      const { id, category, title, content } = req.body;

      const result = await website_pool.query(
        "UPDATE changelog SET category = ?, title = ?, content = ? WHERE id = ?",
        [category, title, content, id]
      );

      const success = result.affectedRows == 1 ? "success" : "error";
      res.json({ status: success });
    })
  }
};

module.exports = controller;
