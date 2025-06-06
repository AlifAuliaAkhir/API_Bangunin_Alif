require('dotenv').config(); // Harus di baris paling atas!

const express = require('express');
const app = express();

// Gunakan variabel dari .env
const PORT = process.env.PORT || 3000;

app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
