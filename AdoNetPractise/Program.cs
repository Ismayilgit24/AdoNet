using AdoNetPractise.Models;
using AdoNetPractise.Service;
using System.Data.SqlClient;

namespace AdoNetPractise
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StudentsService studentsService = new StudentsService();

			Students student = new Students
			{
				Name = "James",
				Surname = "Smith",
				Age = 25
			};
			Students student2 = new Students
			{
				Name = "Isabella",
				Surname = "Taylor",
				Age = 17
			};
			Students student3 = new Students
			{
				Name = "Daniel",
				Surname = "Miller",
				Age = 21
			};

			//studentsService.AddStudents(student2);
			//studentsService.AddStudents(student3);


			//studentsService.Update(1, "Charlie", "Spring", 15);
			//studentsService.Update(3, "Elizabeth", "Graner", 37);

			//studentsService.Delete(2);




			//List<Students> students = studentsService.GetAll();

			//foreach (var item in students)
			//{
			//	Console.WriteLine(string.Concat(item.Id, " ", item.Name, " ", item.Surname, " ", item.Age));
			//}


			//studentsService.Get(3);

			//studentsService.TruncateTable();
		}
	}
}
