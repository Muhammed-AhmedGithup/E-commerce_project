using E_commerce_project.Data.Servicrs;
using E_commerce_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace E_commerce_project.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task <IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                await _service.add(producer);
                return RedirectToAction("index");

            }
            return View(producer);

        }

        public async Task<IActionResult> Details(int id)
        {
            var pro = await _service.GetById(id);
            if (pro == null)
            {
                return View("NotFound");
            }
            return View(pro);

        }

        public async Task<IActionResult> Update(int id)
        {
            var pro = await _service.GetById(id);
            if (pro == null) { return View("NotFound"); }
            return View(pro);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.Update(producer);
            return RedirectToAction("index");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _service.GetById(id);
            if (actor == null) { return View("NotFound"); }
            return View(actor);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Producer producer)
        {
            await _service.Delete(producer);
            return RedirectToAction("index");
        }
    }
}
