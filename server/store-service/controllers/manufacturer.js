const pool = require("../mysql");
const asyncHandler = require('../utils/asyncHandler');

const manufacturerController = {

    all: asyncHandler(async(req, res) => {
        const result = await pool.query("SELECT * FROM manufacturer");
        res.json(result);
    }),
    byId: asyncHandler(async(req, res) => {
        const id = req.params.id;
        if (!id || isNaN(id)) {
            res.send('no valid id specified');
            return;
        }
        
        const result = await pool.query("SELECT * FROM manufacturer WHERE id = ?", id);
        res.json(result);
    })
}

module.exports = manufacturerController;