using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.GraphQL.Messaging;
using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
	public class CarvedRockMutation : ObjectGraphType
	{
		public CarvedRockMutation(IProductReviewRepository productReviewRepository, IReviewMessageService messageService)
		{
			FieldAsync<ProductReviewType>(
				"createReview",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "review" }),
				resolve: async context =>
				{
					var review = context.GetArgument<ProductReview>("review");
					var result = await productReviewRepository.AddReview(review);
					messageService.AddReviewAddedMessage(result);
					return result;
				}
			);
		}
	}
}