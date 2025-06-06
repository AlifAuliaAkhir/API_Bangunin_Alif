module.exports = (sequelize, DataTypes) => {
  const Toko = sequelize.define('Toko', {
    nama: DataTypes.STRING,
    latitude: DataTypes.DOUBLE,
    longitude: DataTypes.DOUBLE
  });

  return Toko;
};
