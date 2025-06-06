module.exports = (sequelize, DataTypes) => {
  const Material = sequelize.define('Material', {
    nama: DataTypes.STRING,
    harga: DataTypes.INTEGER,
    jumlah: DataTypes.INTEGER
  });

  Material.associate = (models) => {
    Material.belongsTo(models.Project, {
      foreignKey: 'ProjectId',
      onDelete: 'CASCADE'
    });
  };

  return Material;
};
