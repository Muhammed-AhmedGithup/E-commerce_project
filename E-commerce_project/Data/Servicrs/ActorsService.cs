using E_commerce_project.Data;

using E_commerce_project.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_project.Data.Servicrs
{
	public class ActorsService : IActorsService
	{
		private readonly ApplicationDbContext _service;

		public ActorsService(ApplicationDbContext service)
		{
			_service = service;
		}

		public async Task add(Actor actor)
		{
		 await	_service.AddAsync(actor);
		 await	_service.SaveChangesAsync();
		}

		

        public async Task Delete(Actor actor)
        {
            _service.Remove(actor);
			await _service.SaveChangesAsync();
        }

        public   async Task <IEnumerable<Actor>> GetAll()
		{

			var data = await _service.Actors.ToListAsync();
			return data;
		}

		public async Task<Actor> GetById(int id)
		{
			var ac=await _service.Actors.FirstOrDefaultAsync(n=>n.Id==id);
			return ac;
		}

        public async Task<Actor> Update( Actor actor)
        {
             _service.Update(actor);
		 	 _service.SaveChanges();
			return actor;
        }
    }
}
