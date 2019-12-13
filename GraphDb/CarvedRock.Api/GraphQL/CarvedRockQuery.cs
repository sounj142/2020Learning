using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
	public class CarvedRockQuery : ObjectGraphType
	{
		public CarvedRockQuery(IProductRepository productRepository, IProductReviewRepository productReviewRepository)
		{
			Field<ListGraphType<ProductType>>(
				"products",
				resolve: context => productRepository.GetAll()
			);

			Field<ProductType>(
				"product",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
				resolve: context =>
				{
					//var user = context.UserContext as ClaimsPrincipal;
					//if (user?.Identity == null || !user.Identity.IsAuthenticated)
					//{
					//	throw new UnauthorizedAccessException("You don't have permission to access product");
					//}

					var id = context.GetArgument<int>("id");
					return productRepository.GetById(id);
				}
			);

            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("productId");
                    return productReviewRepository.GetByProductId(productId);
                }
            );
        }
	}
}