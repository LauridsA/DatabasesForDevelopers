using System;

namespace DatabaseConsoleAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionstring = @"Server=.;Database=migration_bordas_production;Integrated Security;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=True; Max Pool Size=200;";
               Console.WriteLine("Hello World!");
        }
    }
}
