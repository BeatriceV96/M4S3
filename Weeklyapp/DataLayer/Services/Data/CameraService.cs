using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DAO;
using System.Collections.Generic;

namespace Weeklyapp.Services
{
    public class CameraService
    {
        private readonly CameraDao _cameraDao;

        public CameraService(CameraDao cameraDao)
        {
            _cameraDao = cameraDao;
        }

        public IEnumerable<CameraEntity> GetAll()
        {
            return _cameraDao.GetAll();
        }

        public void Create(CameraEntity camera)
        {
            _cameraDao.Create(camera);
        }

        public void Update(CameraEntity camera)
        {
            _cameraDao.Update(camera);
        }

        public void Delete(int numero)
        {
            _cameraDao.Delete(numero);
        }
    }
}
