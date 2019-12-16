using GraphQL;
using System.Collections.Generic;
using System.Linq;

namespace GraphqlResearch
{
	public class Query
	{
		[GraphQLMetadata("students")]
		public IEnumerable<Student> GetJedis()
		{
			return StarWarsDB.GetStudents();
		}

		[GraphQLMetadata("student")]
		public Student GetJedi(int id)
		{
			return StarWarsDB.GetStudents().FirstOrDefault(x => x.Id == id);
		}

		[GraphQLMetadata("hello")]
		public string GetHello()
		{
			return "Hello from Query class";
		}
	}
}