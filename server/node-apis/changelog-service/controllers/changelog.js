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
          body("title")
            .exists()
            .isString(),
          body("category")
            .exists()
            .isInt(),
          body("content")
            .exists()
            .isString()
        ];
      }
      case "add-category": {
        return [
          body("title")
            .exists()
            .isString(),
          body("color")
            .exists()
            .isString()
        ];
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
  get: {
    changes: asyncHandler(async (req, res) => {
      const result = await website_pool.query(
        "SELECT id, realm, category, title, content, date FROM changelog ORDER BY id DESC"
      );
      res.json(result);
    }),
    categories: asyncHandler(async (req, res) => {
      const result = await website_pool.query(
        "SELECT id, title, color FROM changelog_category ORDER BY id ASC"
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

      const { realm, title, category, content } = req.body;

      const result = await website_pool.query(
        "INSERT INTO changelog (realm, title, category, content) VALUES (?, ?, ?, ?)",
        [realm, title, category, content]
      );

      res.json({ NewId: result.insertId });
    }),
    category: asyncHandler(async (req, res) => {
      const errors = validationResult(req);

      if (!errors.isEmpty()) {
        res.send(errors.array());
        return;
      }

      const { title, color } = req.body;

      const result = await website_pool.query(
        "INSERT INTO changelog_category (title, color) VALUES (?, ?)",
        [title.toUpperCase(), color]
      );

      res.json({ NewId: result.insertId });
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

      const check = await website_pool.query(
        "SELECT COUNT(*) as total FROM changelog WHERE category = ?",
        [id]
      );

      const check_total = check[0].total;
      if (check_total > 0) {
        res.json({
          status: `There are ${check_total} changes that uses this category, please remove them or change their category.`
        });
        return;
      }

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
