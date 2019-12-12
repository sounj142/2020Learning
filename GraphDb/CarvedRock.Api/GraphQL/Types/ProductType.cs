using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Security.Claims;

namespace CarvedRock.Api.GraphQL.Types
{
	public class ProductType : ObjectGraphType<Product>
	{
		public ProductType(IProductReviewRepository productReviewRepository, IDataLoaderContextAccessor dataLoaderAccessor)
		{
			Field(t => t.Id);
			Field(t => t.Name);
			Field(t => t.Description);
			Field(t => t.IntroducedAt).Description("When the product was first introduced in the catalog");
			Field(t => t.PhotoFileName).Description("The file name of the photo so the client can render it");
			Field(t => t.Price);
			Field(t => t.Rating).Description("The (max 5) star customer rating");
			Field(t => t.Stock);
			Field<ProductTypeEnumType>("Type", "Product type 111");
			Field<ListGraphType<ProductReviewType>>(
				"reviews",
				resolve: context =>
				{
					var user = context.UserContext as ClaimsPrincipal;
					var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
						"GetReviewsByProductIds", productReviewRepository.GetByProductIds);
					return loader.LoadAsync(context.Source.Id);
				}
			);
		}
	}
}