const db = require('../models');
const { Op } = require('sequelize');

exports.getProjectsByUser = async (req, res) => {
  try {
    const { userId } = req.params;
    const projects = await db.Project.findAll({
      where: { UserId: userId },
      include: db.Material
    });

    const data = projects.map(p => ({
      id: p.id,
      name: p.nama,
      status: p.status,
      materials: p.Materials.map(m => ({
        nama: m.nama,
        harga: m.harga,
        jumlah: m.jumlah
      }))
    }));

    res.json(data);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};

exports.addProject = async (req, res) => {
  try {
    const project = await db.Project.create({
      ...req.body,
      tanggalMulai: new Date(),
      status: 'berjalan'
    });
    res.json(project);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};

exports.deleteProject = async (req, res) => {
  try {
    const { id } = req.params;
    const p = await db.Project.findByPk(id);
    if (!p) return res.status(404).json({ message: 'Not found' });

    await p.destroy();
    res.json({ message: 'Deleted' });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};

exports.finishProject = async (req, res) => {
  try {
    const { id } = req.params;
    const project = await db.Project.findOne({
      where: { id },
      include: db.Material
    });

    if (!project) return res.status(404).json({ message: 'Not found' });

    project.status = 'selesai';
    project.tanggalSelesai = new Date();
    await project.save();

    const total = project.Materials.reduce((acc, m) => acc + (m.harga * m.jumlah), 0);
    res.json(total);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};
