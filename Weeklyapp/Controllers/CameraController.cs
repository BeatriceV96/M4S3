using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;

namespace Weeklyapp.Controllers
{
    [Authorize]
    public class CamereController : Controller
    {
        private readonly ICameraService _cameraService;

        public CamereController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public IActionResult Index()
        {
            var camere = _cameraService.ReadAll();
            return View(camere);
        }

        public IActionResult Details(int id)
        {
            var camera = _cameraService.Read(id);
            if (camera == null)
            {
                return NotFound();
            }
            return View(camera);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Camera camera)
        {
            if (ModelState.IsValid)
            {
                _cameraService.Create(camera);
                return RedirectToAction(nameof(Index));
            }
            return View(camera);
        }

        public IActionResult Edit(int id)
        {
            var camera = _cameraService.Read(id);
            if (camera == null)
            {
                return NotFound();
            }
            return View(camera);
        }

        [HttpPost]
        public IActionResult Edit(int id, Camera camera)
        {
            if (id != camera.Numero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _cameraService.Update(camera);
                return RedirectToAction(nameof(Index));
            }
            return View(camera);
        }

        public IActionResult Delete(int id)
        {
            var camera = _cameraService.Read(id);
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
            return RedirectToAction(nameof(Index));
        }
    }
}
