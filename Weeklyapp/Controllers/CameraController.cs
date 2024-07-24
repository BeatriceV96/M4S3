using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
using Weeklyapp.Models;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.Controllers
{
    public class CamereController : Controller
    {
        private readonly CameraService cameraService;

        public CamereController(CameraService cameraService)
        {
            this.cameraService = cameraService;
        }

        public IActionResult Index()
        {
            var camere = cameraService.GetAll();
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
                cameraService.Create(camera);
                return RedirectToAction("Index");
            }
            return View(camera);
        }
    }
}
