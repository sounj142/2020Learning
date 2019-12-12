using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarvedRock.Api.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly CarvedRockDbContext _dbContext;

		public ProductRepository(CarvedRockDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task<List<Product>> GetAll()
		{
			return _dbContext.Products.ToListAsync();
		}

		public Task<Product> GetById(int id)
		{
			return _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}