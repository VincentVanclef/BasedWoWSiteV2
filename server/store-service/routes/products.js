const express = require("express");
const router = express.Router();
const productController = require('../controllers/product');

router.get("/all", productController.all);

router.get("/:id", productController.byId);

router.post('/create', productController.validate('create'), productController.create);

router.put('/update/:id', productController.update);

router.delete('/delete/:id', productController.delete);


/*router.put('/update'), productController.validate('update'), productController.update);

router.delete('/delete/'), productController.validate('delete'), productController.update);*/

module.exports = router;
