using GraphQL;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
	public class CarvedRockSchema : Schema
	{
		public CarvedRockSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
		{
			Query = dependencyResolver.Resolve<CarvedRockQuery>();
		}
	}
}