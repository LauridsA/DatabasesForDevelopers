using System;
using System.Data.SqlClient;

namespace DatabaseConsoleAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var ConnectionString = @"Server=.;Initial catalog=Company;Integrated Security;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=True; Max Pool Size=200;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                while (true)
                {
                    Console.WriteLine("Choose which stored procedure you would like to call:" +
                        "1: Get all departments" +
                        "2: Get specific department by number" +
                        "3: nigga" +
                        "4: big nigga" +
                        "5: anders er en bitch" +
                        "6: men i det mindste er han ikke fra randers");
                    int choice = Console.Read();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("okay");
                            break;
                        case 2:
                            Console.WriteLine("whatever");
                            break;
                        case 3:
                            Console.WriteLine("dude");
                            break;
                        case 4:
                            Console.WriteLine("somethihgn");
                            break;
                        case 5:
                            Console.WriteLine("man");
                            break;
                        case 6:
                            Console.WriteLine("hey");
                            break;
                    }
                    Console.WriteLine("Operation completed. Returned result was:");
                }
            }
        }
    }
}
