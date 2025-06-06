const router = require('express').Router();
const controller = require('../controllers/toko.controller');

router.get('/', controller.getToko);

module.exports = router;
