module.exports = (sequelize, DataTypes) => {
  const Project = sequelize.define('Project', {
    nama: DataTypes.STRING,
    tanggalMulai: DataTypes.DATE,
    tanggalSelesai: DataTypes.DATE,
    status: {
      type: DataTypes.STRING,
      defaultValue: 'berjalan'
    }
  });

  Project.associate = (models) => {
    Project.belongsTo(models.User, {
      foreignKey: 'UserId',
      onDelete: 'CASCADE'
    });

    Project.hasMany(models.Material, {
      foreignKey: 'ProjectId',
      onDelete: 'CASCADE'
    });
  };

  return Project;
};
