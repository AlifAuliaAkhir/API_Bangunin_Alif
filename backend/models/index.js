const { Sequelize, DataTypes } = require('sequelize');
require('dotenv').config();
const express = require('express');

const PORT = process.env.PORT || 3000;
 
const sequelize = new Sequelize(
  process.env.DB_NAME,
  process.env.DB_USER,
  process.env.DB_PASS,
  {
    host: process.env.DB_HOST,
    port: process.env.DB_PORT,
    dialect: 'postgres',
    logging: false
  }
);

const db = {};
db.Sequelize = Sequelize;
db.sequelize = sequelize;

// ✅ Nama file HARUS sama dengan nama require
db.User = require('./user.model')(sequelize, DataTypes);
db.Project = require('./project.model')(sequelize, DataTypes);
db.Material = require('./material.model')(sequelize, DataTypes);
db.Toko = require('./toko.model')(sequelize, DataTypes);

Object.keys(db).forEach((modelName) => {
  if (db[modelName].associate) {
    db[modelName].associate(db);
  }
});

module.exports = db;
