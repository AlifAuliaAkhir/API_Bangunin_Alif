const db = require('../models');

exports.getToko = async (req, res) => {
  try {
    const data = await db.Toko.findAll();
    res.json(data);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};
