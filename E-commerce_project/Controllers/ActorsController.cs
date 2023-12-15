using E_commerce_project.Data.Servicrs;
using E_commerce_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace E_commerce_project.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ActorsController : Controller
    {
       
        
        private readonly IActorsService _service;
		public ActorsController( IActorsService service)
		{
			
			_service = service;
		}

		public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  async Task <IActionResult> Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
               await _service.add(actor);
                return RedirectToAction("index");

            }
            return View(actor);
            
        }

        public async Task<IActionResult> Details(int id)
        {
            var ac=await _service.GetById(id);
            if (ac == null)
            {
                return View("NotFound");
            }
            return View(ac);

        }

        public async Task<IActionResult> Update(int id)
        {
            var actor=await _service.GetById(id);
            if (actor == null) { return View("NotFound"); }
            return View(actor);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Update(actor);
            return RedirectToAction("index");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var actor=await _service.GetById(id);
            if (actor == null) { return View("NotFound"); }
            return View(actor);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Actor actor)
        {
            await _service.Delete(actor);
            return RedirectToAction("index");
        }
    }
}
