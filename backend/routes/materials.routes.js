// routes/materials.routes.js
const express = require('express');
const router = express.Router();
const controller = require('../controllers/materials.controller');
const { authenticate, requireAdmin } = require('../middlewares/auth.middleware');

// Tes route sederhana (opsional, bisa dihapus kalau tidak dibutuhkan)
router.get('/test', (req, res) => {
  res.send('Materials route works!');
});

// === Akses user ===
router.post('/:projectId', authenticate, controller.addMaterial);

// === Akses admin ===
router.get('/', authenticate, requireAdmin, controller.getAll);
router.put('/:id', authenticate, requireAdmin, controller.updateMaterial);
router.delete('/:id', authenticate, requireAdmin, controller.deleteMaterial);

module.exports = router;
