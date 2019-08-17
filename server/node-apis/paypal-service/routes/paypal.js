const express = require("express");
const router = express.Router();
const paypalController = require('../controllers/paypal');
const cors = require('cors')

router.post("/donate", paypalController.validate('donate'), paypalController.donate);

router.post("/success", paypalController.validate('success'), paypalController.success);

router.get("/test", paypalController.test);

module.exports = router;
