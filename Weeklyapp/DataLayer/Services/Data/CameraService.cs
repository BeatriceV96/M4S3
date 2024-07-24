using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class CameraService : ICameraService
    {
        private readonly List<Camera> _camere = new List<Camera>();

        public void Create(Camera camera)
        {
            _camere.Add(camera);
        }

        public void Delete(int numero)
        {
            var camera = _camere.FirstOrDefault(c => c.Numero == numero);
            if (camera != null)
            {
                _camere.Remove(camera);
            }
        }

        public Camera Read(int numero)
        {
            return _camere.FirstOrDefault(c => c.Numero == numero);
        }

        public void Update(Camera camera)
        {
            var existingCamera = _camere.FirstOrDefault(c => c.Numero == camera.Numero);
            if (existingCamera != null)
            {
                existingCamera.Descrizione = camera.Descrizione;
                existingCamera.Tipologia = camera.Tipologia;
            }
        }

        public List<Camera> ReadAll()
        {
            return _camere;
        }
    }
}
