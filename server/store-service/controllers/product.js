const { body, validationResult } = require('express-validator/check');
const pool = require('../mysql');
const asyncHandler = require('../utils/asyncHandler');

const productController = {
    // VALIDATION
    validate: (method) => {
    switch (method) {
        case "update":
        case "create": {
            return [
                body('name')
                .exists()
                .isLength({ min: 3 })
                .isAlpha(),
                body('image')
                .exists()
                .isLength({ min: 3 }),
                body('price')
                .exists()
                .isDecimal(),
                body('manufacturer')
                .exists()
                .isInt()
            ];
            }
        }
    },
    // GET
    all: asyncHandler(async (req, res) => {
        const result = await pool.query("select * from products");
        res.send(result);
    }),
    // GET
    byId: asyncHandler(async (req, res) => {

        const errors = validationResult(req);

        if (!errors.isEmpty()) {
            res.send(errors.array());
            return;
        }
        
        const idParam = req.params.id;
        const result = await pool.query("select * from products where id = ?", idParam);
        res.send(result);
    }),
    // POST
    create: asyncHandler(async (req, res) => {
        
        const errors = validationResult(req);

        if (!errors.isEmpty()) {
            res.send(errors.array());
            return;
        }

        const { name, image, price, manufacturer } = req.body;
        const result = await pool.query(`INSERT INTO products (name, image, price, manufacturer)
                                        VALUES (?, ?, ?, ?)`, [name, image, price, manufacturer]);

        // Send back newly created product object
        res.json({
            id: result.insertId,
            name: name,
            image: image,
            price: price,
            manufacturer: manufacturer
            });
    }),
    update: asyncHandler(async (req, res) => {

        const errors = validationResult(req);

        if (!errors.isEmpty()) {
            res.send(errors.array());
            return;
        }

        const id = req.params.id;
        const { name, image, price, manufacturer } = req.body;
        const result = await pool.query(`UPDATE products SET name = ?, image = ?, price = ?, manufacturer = ? WHERE id = ?`,
                                         [name, image, price, manufacturer, id]);

        res.json({ result: result.affectedRows })
    }),
    delete: asyncHandler(async (req, res) => {

        const id = req.params.id;
        if (!id || isNaN(id)) {
            res.send('no valid id specified');
            return;
        }
        
        const result = await pool.query(`DELETE FROM products WHERE id = ?`, id);

        res.json({ result: result.affectedRows })
    })
}

module.exports = productController;
