using AdoNetPractise.Data;
using AdoNetPractise.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetPractise.Service
{
    internal class StudentsService
    {
        private static SQL _sql;

        public StudentsService()
        {
            _sql = new SQL();
        }

        public void AddStudents(Students student)
        {
            int result = _sql.ExecuteCommand($"INSERT INTO Students VALUES ('{student.Name}', '{student.Surname}', {student.Age})");

            if (result > 0)
            {
                Console.WriteLine("Added successfully");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public List<Students> GetAll()
        {
            List<Students> students = new List<Students>();

            DataTable table = _sql.Execute("SELECT * FROM Students");

            foreach (DataRow item in table.Rows)
            {
                Students student = new Students()
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Name"],
                    Surname = (string)item["Surname"],
                    Age = (int)item["Age"]
                };

                students.Add(student);
            }
            return students;
        }

        public void Delete(int id)
        {
            int result = _sql.ExecuteCommand($"DELETE FROM Students WHERE Id = {id}");
            if(result > 0)
            {
                Console.WriteLine("Deleted successfully");
            }else
            {
                Console.WriteLine("Error");
            }
        }

        public void Update(int id, string name, string surname, int age)
        {
            int result = _sql.ExecuteCommand($"UPDATE Students SET Name = '{name}', Surname = '{surname}', Age = {age} WHERE Id = {id}");

            if(result > 0)
            {
                Console.WriteLine("Updated successfully");
            }else
            {
                Console.WriteLine("Error");
            }
        }

		public void Get(int id) { 
            
            DataTable table = _sql.Execute($"SELECT s.Id, s.Name, s.Surname, s.Age FROM Students AS s WHERE Id = {id}"); 
            
            if (table.Rows.Count > 0) 
            { 
                DataRow item = table.Rows[0]; 
                Students student = new Students() 
                { Id = (int)item["Id"],
                  Name = (string)item["Name"], 
                    Surname = (string)item["Surname"], 
                    Age = (int)item["Age"] }; 
                
                Console.WriteLine($"Id: {student.Id} Name: {student.Name} Surname: {student.Surname} Age: {student.Age}"); 
            } 
            else 
            { 
                Console.WriteLine("Student not found"); 
            } 
        }

        public void TruncateTable()
        {
           int result = _sql.ExecuteCommand("TRUNCATE TABLE Students");

			Console.WriteLine("Truncated successfully");
		}
	}
}
