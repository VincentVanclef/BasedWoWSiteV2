const { body, validationResult } = require("express-validator/check");
const { auth_pool, website_pool } = require("../mysql");
const PayPalExtractor = require("../utils/PayPalExtractor");
const asyncHandler = require("../utils/asyncHandler");
const paypal = require("paypal-rest-sdk");
const config = require("../config");

paypal.configure({
  mode: "live", //sandbox or live
  client_id: config.CLIENT_ID,
  client_secret: config.SECRET_ID
});

const create_payment_json = (name, price, quantity) => {
  const payment_json = {
    intent: "sale",
    payer: {
      payment_method: "paypal"
    },
    redirect_urls: {
      return_url: config.RETURN_URL,
      cancel_url: config.CANCEL_URL
    },
    transactions: [
      {
        item_list: {
          items: [
            {
              name: name,
              sku: "item",
              price: price,
              currency: "USD",
              quantity: quantity
            }
          ]
        },
        amount: {
          currency: "USD",
          total: quantity * price
        },
        description: "This is the payment description."
      }
    ]
  };
  return payment_json;
};

const paypalController = {
  // VALIDATION
  validate: method => {
    switch (method) {
      case "donate": {
        return body("donationpoint")
          .exists()
          .isInt();
      }
      case "success": {
        return [
          body("userId")
            .exists()
            .isString(),
          body("accountId")
            .exists()
            .isInt(),
          body("payerId")
            .exists()
            .isString(),
          body("paymentId")
            .exists()
            .isString()
        ];
      }
    }
  },
  // POST
  donate: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.json(errors.array());
      return;
    }

    const { donationpoint } = req.body;

    const payment_json = create_payment_json(
      "Donation Point",
      1,
      donationpoint
    );

    paypal.payment.create(payment_json, function(error, payment) {
      if (error) {
        res.json(error);
      } else {
        for (const link of payment.links) {
          if (link.rel === "approval_url") {
            res.send(link.href);
          }
        }
      }
    });
  }),
  success: asyncHandler(async (req, res) => {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      res.json(errors.array());
      return;
    }

    const { userId, accountId, payerId, paymentId } = req.body;

    const check_result = await website_pool.query(
      "SELECT * FROM paypal_logs WHERE PaymentId = ?",
      [paymentId]
    );
    if (check_result.length !== 0) {
      res.json(check_result[0]);
      return;
    }

    const execute_payment_json = { payer_id: payerId };

    paypal.payment.execute(paymentId, execute_payment_json, async function(
      error,
      payment
    ) {
      if (error) {
        res.json(error.response);
      } else {
        const extractor = new PayPalExtractor(payment);
        const Date = payment.create_time;
        const payerData = await extractor.PayerData;
        const shippingData = await extractor.ShippingData;
        const transactionData = await extractor.TransactionData;
        const itemsData = await extractor.ItemsData;

        // All results are arrays cuz paypal is meh
        const data = {
          Date,
          ...payerData[0],
          ...shippingData[0],
          ...transactionData[0],
          ...itemsData[0]
        };

        website_pool.query(
          `INSERT INTO paypal_logs (UserId, PaymentId, PayerId, PayerEmail, PayerFirstName, PayerLastName, Total, Item, Quantity, Currency, Price) 
              VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)`,
          [
            userId,
            paymentId,
            payerId,
            data.PayerEmail,
            data.PayerFirstName,
            data.PayerLastName,
            data.Total,
            data.Item,
            data.Quantity,
            data.Currency,
            data.Price
          ],
          (err, results, fields) => {
            if (err) {
              res.json({ error: err.sqlMessage });
            } else {
              // Only increase here
              data.Dp = data.Quantity;
              res.json(data);
            }
          }
        );

        auth_pool.query(
          `UPDATE account_data SET Dp = Dp + ? WHERE Id = ?`,
          [data.Quantity, accountId],
          (err, results, fields) => {
            if (err) {
              res.json({ error: err.sqlMessage });
            }
          }
        );
      }
    });
  }),
  test: asyncHandler(async (req, res) => {})
};

module.exports = paypalController;
