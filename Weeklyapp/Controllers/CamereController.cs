using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.Controllers
{
    public class CamereController : Controller
    {
        private readonly CameraService _cameraService;

        public CamereController(CameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public IActionResult Index()
        {
            var camere = _cameraService.GetAll();
            return View(camere);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CameraEntity camera)
        {
            if (ModelState.IsValid)
            {
                _cameraService.Create(camera);
                return RedirectToAction("Index");
            }
            return View(camera);
        }

        public IActionResult Edit(int id)
        {
            var camera = _cameraService.GetAll().FirstOrDefault(c => c.Numero == id);
            if (camera == null)
            {
                return NotFound();
            }
            return View(camera);
        }

        [HttpPost]
        public IActionResult Edit(int id, CameraEntity camera)
        {
            if (id != camera.Numero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _cameraService.Update(camera);
                return RedirectToAction("Index");
            }
            return View(camera);
        }

        public IActionResult Delete(int id)
        {
            var camera = _cameraService.GetAll().FirstOrDefault(c => c.Numero == id);
            if (camera == null)
            {
                return NotFound();
            }

            return View(camera);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _cameraService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
