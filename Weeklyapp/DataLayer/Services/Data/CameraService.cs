using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;
using Weeklyapp.Models;

namespace Weeklyapp.Services
{
    public class CameraService
    {
        private readonly CameraDao cameraDao;

        public CameraService(CameraDao cameraDao)
        {
            this.cameraDao = cameraDao;
        }

        public IEnumerable<CameraEntity> GetAll()
        {
            return cameraDao.GetAll();
        }

        public void Create(CameraEntity camera)
        {
            cameraDao.Create(camera);
        }
    }
}
