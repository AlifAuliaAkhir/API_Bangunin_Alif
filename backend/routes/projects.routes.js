const router = require('express').Router();
const controller = require('../controllers/project.controller');

router.get('/user/:userId', controller.getProjectsByUser);
router.post('/', controller.addProject);
router.delete('/:id', controller.deleteProject);
router.put('/selesaikan/:id', controller.finishProject);

module.exports = router;
