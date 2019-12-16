using GraphQL;
using GraphQL.Types;
using System;

namespace GraphqlResearch
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var schema = Schema.For(@"
				type Student {
					name: String
					score: Float,
					id: ID
				}
				type Query {
					hello: String
					students: [Student]
					student(id: ID): Student
				}
			",
			builder =>
			{
				builder.Types.Include<Query>();
			});

			var json = schema.Execute(config =>
			{
				config.Query = "{ students {id, name, score } hello student(id: 1) { score } }";
			});

			Console.WriteLine(json);
		}
	}
}