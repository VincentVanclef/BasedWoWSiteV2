const express = require("express");
const router = express.Router();
const productController = require('../controllers/product');

router.get("/all", productController.all);

router.get("/:id", productController.byId);

router.post('/create', productController.validate('create'), productController.create);

module.exports = router;
