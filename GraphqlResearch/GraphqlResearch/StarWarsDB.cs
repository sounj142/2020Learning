using System.Collections.Generic;

namespace GraphqlResearch
{
	public class StarWarsDB
	{
		public static IEnumerable<Student> GetStudents()
		{
			return new List<Student>() {
				new Student { Name ="Luke", Score=9.2, Id = 1},
				new Student { Name ="Yoda", Score=7.7, Id = 2},
				new Student { Name ="Darth Vader", Score=3.4, Id = 3},
			};
		}
	}
}