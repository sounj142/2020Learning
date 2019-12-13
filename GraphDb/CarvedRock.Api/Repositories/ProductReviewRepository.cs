using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Repositories
{
	public class ProductReviewRepository : IProductReviewRepository
	{
		private readonly CarvedRockDbContext _dbContext;

		public ProductReviewRepository(CarvedRockDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<ProductReview>> GetByProductId(int productId)
		{
			return await _dbContext.ProductReviews.Where(p => p.ProductId == productId).ToListAsync();
		}

		public async Task<ILookup<int, ProductReview>> GetByProductIds(IEnumerable<int> productIds)
		{
			var list = await _dbContext.ProductReviews.Where(r => productIds.Contains(r.ProductId)).ToListAsync();
			return list.ToLookup(r => r.ProductId);
		}

        public async Task<ProductReview> AddReview(ProductReview review)
        {
            _dbContext.ProductReviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
    }
}