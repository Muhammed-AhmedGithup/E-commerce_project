using E_commerce_project.Data.Servicrs;
using E_commerce_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace E_commerce_project.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CinemasController : Controller
    {
		private readonly ICinemasService _service;

		public CinemasController(ICinemasService service)
		{
			_service = service;
		}

		public async Task <IActionResult> Index()
        {
            var data= await _service.GetAll();
            return View(data);
        }
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Cinema cinema)
		{
			if (ModelState.IsValid)
			{
				await _service.add(cinema);
				return RedirectToAction("index");

			}
			return View(cinema);

		}

		public async Task<IActionResult> Details(int id)
		{
			var cinema = await _service.GetById(id);
			if (cinema == null)
			{
				return View("NotFound");
			}
			return View(cinema);

		}

		public async Task<IActionResult> Update(int id)
		{
			var cinema = await _service.GetById(id);
			if (cinema == null) { return View("NotFound"); }
			return View(cinema);

		}

		[HttpPost]
		public async Task<IActionResult> Update(Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return View(cinema);
			}
			await _service.Update(cinema);
			return RedirectToAction("index");

		}

		public async Task<IActionResult> Delete(int id)
		{
			var actor = await _service.GetById(id);
			if (actor == null) { return View("NotFound"); }
			return View(actor);

		}
		[HttpPost]
		public async Task<IActionResult> Delete(Cinema cinema)
		{
			await _service.Delete(cinema);
			return RedirectToAction("index");
		}
	}
}
