module.exports = (sequelize, DataTypes) => {
  const User = sequelize.define('User', {
    email: {
      type: DataTypes.STRING,
      unique: true,
      allowNull: false,
      validate: {
        isEmail: true
      }
    },
    password: {
      type: DataTypes.STRING,
      allowNull: false
    },
    role: {
      type: DataTypes.STRING,
      defaultValue: 'user'
    },
    photoUrl: DataTypes.STRING
  });

  // Relasi satu ke banyak dengan Project
  User.associate = models => {
    User.hasMany(models.Project, {
      foreignKey: 'UserId',
      onDelete: 'CASCADE'
    });
  };

  return User;
};
