using CarvedRock.Api.Data.Entities;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace CarvedRock.Api.GraphQL.Messaging
{
	public class ReviewMessageService : IReviewMessageService
	{
		private readonly ISubject<ReviewAddedMessage> _messageStream = new ReplaySubject<ReviewAddedMessage>(1);

		public ReviewAddedMessage AddReviewAddedMessage(ProductReview review)
		{
			var message = new ReviewAddedMessage
			{
				ProductId = review.ProductId,
				Title = review.Title,
				Review = review.Review
			};
			_messageStream.OnNext(message);
			return message;
		}

		public IObservable<ReviewAddedMessage> GetMessages()
		{
			return _messageStream.AsObservable();
		}
	}
}