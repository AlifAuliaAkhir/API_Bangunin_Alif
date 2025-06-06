const express = require('express');
const app = express();
const cors = require('cors');
const path = require('path');
require('dotenv').config();

app.use(cors());
app.use(express.json());
app.use('/uploads', express.static(path.join(__dirname, 'uploads')));

// Routes
app.use('/api/auth', require('./routes/auth.routes'));
app.use('/api/materials', require('./routes/materials.routes'));
app.use('/api/profile', require('./routes/profile.routes'));
app.use('/api/projects', require('./routes/projects.routes'));
app.use('/api/toko', require('./routes/toko.routes'));

// DB Sync
const db = require('./models');

db.sequelize
  .authenticate()
  .then(() => {
    console.log('✅ Koneksi database berhasil.');
    return db.sequelize.sync(); // Menyinkronkan model ke DB
  })
  .then(() => {
    console.log('✅ Sinkronisasi model berhasil.');
  })
  .catch((err) => {
    console.error('❌ Koneksi database gagal:', err.message);
  });

module.exports = app;
