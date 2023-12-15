

using E_commerce_project.Models;

namespace E_commerce_project.Data.Servicrs
{
	public interface IActorsService
	{
		Task <IEnumerable<Actor>> GetAll();
		Task <Actor> GetById(int id);
		Task add(Actor actor);
		Task<Actor> Update(Actor actor);

		Task Delete(Actor actor);

	}
}
