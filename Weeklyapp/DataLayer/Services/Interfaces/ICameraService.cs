using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.DataLayer.Services.Interfaces
{
    public interface ICameraService
    {
        void Create(Camera camera);
        void Delete(int numero);
        Camera Read(int numero);
        void Update(Camera camera);
        List<Camera> ReadAll();
    }
}
