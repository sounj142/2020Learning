using CarvedRock.Api.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Repositories
{
	public interface IProductReviewRepository
	{
		Task<IEnumerable<ProductReview>> GetByProductId(int productId);

		Task<ILookup<int, ProductReview>> GetByProductIds(IEnumerable<int> productIds);
	}
}