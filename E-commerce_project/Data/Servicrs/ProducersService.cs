
using E_commerce_project.Data;
using E_commerce_project.Data.Servicrs;
using E_commerce_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_tickets.Data.Servicrs
{
	public class ProducersService : IProducersService
	{
		private readonly ApplicationDbContext _db;

		public ProducersService(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task add(Producer producer)
		{
			await _db.AddAsync(producer);
			_db.SaveChanges();
		}

		public async Task Delete(Producer producer)
		{
			 _db.Remove(producer);
			_db.SaveChanges();
		}

		public async Task<IEnumerable<Producer>> GetAll()
		{
			return await _db.Producers.ToListAsync();
		}

		public async Task<Producer> GetById(int id)
		{
			return await _db.Producers.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<Producer> Update(Producer producer)
		{
			_db.Producers.Update(producer); 
			_db.SaveChanges();
			return  producer;
		}
	}
}
