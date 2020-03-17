using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConsoleAccess
{
    public class Department
    {
        public string DName { get; set; }
        public int DNumber { get; set; }
        public DateTime MgrStartDate { get; set; }
        public string MgrSSN { get; set; }
        public int numOfEmployees { get; set; }
    }
}
