



using E_commerce_project.Data;
using E_commerce_project.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_project.Data.Servicrs
{
	public class CinemasService : ICinemasService
	{
		private readonly ApplicationDbContext _db;

		public CinemasService(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task add(Cinema cinema)
		{
			await _db.AddAsync(cinema);
			_db.SaveChanges();
		}

		public async Task Delete(Cinema cinema)
		{
			_db.Cinemas.Remove(cinema);
			_db.SaveChanges();
		}

		public async Task<IEnumerable<Cinema>> GetAll()
		{
			return await _db.Cinemas.ToListAsync();
		}

		public async Task<Cinema> GetById(int id)
		{
			var cinema=await _db.Cinemas.FirstOrDefaultAsync(m=>m.Id==id);
			return cinema;
		}

		public async Task<Cinema> Update(Cinema cinema)
		{
			_db.Cinemas.Update(cinema);
			_db.SaveChanges();
			return  cinema;
		}
	}
}
