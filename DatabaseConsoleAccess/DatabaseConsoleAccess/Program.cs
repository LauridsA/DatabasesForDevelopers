using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;

namespace DatabaseConsoleAccess
{
    class Program
    {
        static string ConnectionString = @"Server=.;Initial catalog=Company;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=True; Max Pool Size=200;";
        static List<Department> list = new List<Department>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose which stored procedure you would like to call:\n" +
                    "1: Get all departments\n" +
                    "2: Get specific department by department-number\n" +
                    "3: Delete a Depart by department-number\n" +
                    "4: Create a department by department-number\n" +
                    "5: Update the name of a department (by department-number and desired new name)\n" +
                    "6: Update the acting manager of a department (by department-number and SSN of desired new manager)\n" +
                    "7: Exit Program\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Retrieving all departments...\n");
                        GetAllDepartments();
                        Console.WriteLine(JsonSerializer.Serialize(list));
                        break;
                    case "2":
                        Console.WriteLine("whatever\n");
                        break;
                    case "3":
                        Console.WriteLine("dude\n");
                        break;
                    case "4":
                        Console.WriteLine("somethihgn\n");
                        break;
                    case "5":
                        Console.WriteLine("man\n");
                        break;
                    case "6":
                        Console.WriteLine("hey\n");
                        break;
                    case "7":
                        return;
                }
            }


            static void ReadFromTable()
            {
                //foobar


            }
        }

        private static void GetAllDepartments()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                list.Clear();
                string cmd = "EXEC usp_GetAllDepartments";
                SqlCommand command = new SqlCommand(cmd, connection);
                try
                {
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Department d = new Department();
                        var dname = reader["DName"].ToString();
                        var dnumber = (int)reader["DNumber"];
                        var mgrSSN = reader["MgrSSN"].ToString();
                        var numOfEmployees = (int)reader["Employees"];
                        var mgrStartDate = (DateTime)reader["MgrStartDate"];
                        d.DName = dname;
                        d.DNumber = dnumber;
                        d.numOfEmployees = numOfEmployees;
                        d.MgrSSN = mgrSSN;
                        d.MgrStartDate = mgrStartDate;
                        list.Add(d);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
