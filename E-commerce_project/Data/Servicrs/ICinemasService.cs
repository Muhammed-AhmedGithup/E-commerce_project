



using E_commerce_project.Models;

namespace E_commerce_project.Data.Servicrs
{
    public interface ICinemasService
    {
		Task<IEnumerable<Cinema>> GetAll();
		Task<Cinema> GetById(int id);
		Task add(Cinema cinema);
		Task<Cinema> Update(Cinema cinema);

		Task Delete(Cinema cinema);
	}
}
