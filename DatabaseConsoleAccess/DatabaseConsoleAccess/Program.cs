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

            }
                Console.WriteLine("Hello World!");
        }
    }
}
