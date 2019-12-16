namespace CarvedRock.Api.GraphQL.Messaging
{
	public class ReviewAddedMessage
	{
		public int ProductId { get; set; }
		public string Title { get; set; }
		public string Review { get; set; }
	}
}