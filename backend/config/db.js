const { Pool } = require('pg');
require('dotenv').config();

console.log('DB_USER:', process.env.DB_USER);
console.log('DB_PASSWORD:', process.env.DB_PASSWORD);
console.log('DB_PASSWORD type:', typeof process.env.DB_PASSWORD);

const pool = new Pool({
  user: process.env.DB_USER,
  host: process.env.DB_HOST,
  database: process.env.DB_NAME,
  password: String(process.env.DB_PASSWORD),
  port: process.env.DB_PORT,
});

pool.connect()
  .then(() => console.log('✅ Koneksi ke PostgreSQL berhasil'))
  .catch((err) => console.error('❌ Koneksi database gagal:', err.message));

module.exports = pool;
