const express = require("express");
const router = express.Router();
const controller = require("../controllers/changelog");

router.get("/all/changes", controller.all.changes);

router.get("/all/categories", controller.all.categories);

router.post("/add/change", controller.validate("add-change"), controller.add.change);

router.post("/add/category", controller.validate("add-category"), controller.add.category);

router.post("/delete/change", controller.validate("delete-change"), controller.delete.change);

router.post("/delete/category", controller.validate("delete-category"), controller.delete.change);

router.post("/update/change", controller.validate("update-change"), controller.update.change);

module.exports = router;
