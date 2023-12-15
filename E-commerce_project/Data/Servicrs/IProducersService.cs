



using E_commerce_project.Models;

namespace E_commerce_project.Data.Servicrs
{
    public interface IProducersService
    {
		Task<IEnumerable<Producer>> GetAll();
		Task<Producer> GetById(int id);
		Task add(Producer producer);
		Task<Producer> Update(Producer producer);

		Task Delete(Producer producer);
	}
}
