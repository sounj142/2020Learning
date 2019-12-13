using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockMutation: ObjectGraphType
    {
        public CarvedRockMutation(IProductReviewRepository productReviewRepository)
        {
            FieldAsync<ProductReviewType>(
                "createReview",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "review" }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    return await context.TryAsyncResolve(async c => await productReviewRepository.AddReview(review));
                }
            );

            //Field<ProductReviewType>(
            //    "createReview",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "review" }),
            //    resolve: context =>
            //    {
            //        var review = context.GetArgument<ProductReview>("review");
            //        return context.TryAsyncResolve(c => productReviewRepository.AddReview(review));
            //    }
            //);
        }
    }
}
