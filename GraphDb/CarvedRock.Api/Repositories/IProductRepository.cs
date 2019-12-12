using CarvedRock.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarvedRock.Api.Repositories
{
	public interface IProductRepository
	{
		Task<List<Product>> GetAll();

		Task<Product> GetById(int id);
	}
}