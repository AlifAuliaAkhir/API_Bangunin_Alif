const db = require('../models');

// 1️⃣ Menambahkan material ke dalam sebuah project berdasarkan ID project (user dan admin)
exports.addMaterial = async (req, res) => {
  try {
    const { projectId } = req.params;

    const material = await db.Material.create({
      ...req.body,
      ProjectId: projectId
    });

    res.json(material);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};

// 2️⃣ (Admin) Menampilkan semua material
exports.getAll = async (req, res) => {
  try {
    const materials = await db.Material.findAll();
    res.json(materials);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};

// 3️⃣ (Admin) Mengupdate data material berdasarkan ID
exports.updateMaterial = async (req, res) => {
  try {
    const { id } = req.params;
    const material = await db.Material.findByPk(id);
    if (!material) return res.status(404).json({ message: 'Material not found' });

    Object.assign(material, req.body);
    await material.save();

    res.json(material);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};

// 4️⃣ (Admin) Menghapus material berdasarkan ID
exports.deleteMaterial = async (req, res) => {
  try {
    const { id } = req.params;
    const material = await db.Material.findByPk(id);
    if (!material) return res.status(404).json({ message: 'Material not found' });

    await material.destroy();
    res.json({ message: 'Material deleted successfully' });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
};
