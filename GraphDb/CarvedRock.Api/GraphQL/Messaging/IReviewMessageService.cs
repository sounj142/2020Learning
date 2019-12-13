using System;
using CarvedRock.Api.Data.Entities;

namespace CarvedRock.Api.GraphQL.Messaging
{
    public interface IReviewMessageService
    {
        ReviewAddedMessage AddReviewAddedMessage(ProductReview review);
        IObservable<ReviewAddedMessage> GetMessages();
    }
}
