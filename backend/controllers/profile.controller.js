const multer = require('multer');
const path = require('path');
const db = require('../models');

const storage = multer.diskStorage({
  destination: 'uploads/',
  filename: (req, file, cb) => {
    cb(null, Date.now() + path.extname(file.originalname));
  }
});

const upload = multer({ storage }).single('photo');

exports.uploadPhoto = (req, res) => {
  upload(req, res, async function (err) {
    if (err) return res.status(500).json({ error: err.message });

    const user = await db.User.findByPk(req.params.id);
    if (!user) return res.status(404).json({ message: 'User not found' });

    user.photoUrl = '/uploads/' + req.file.filename;
    await user.save();

    res.json(user.photoUrl);
  });
};
