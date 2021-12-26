using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRmanagement.Models
{
    internal class Employee
    {
        public string No { get; set; }  
        public string FullName { get; set; }
        public string Position { get; set; }
        public string DepartmentName { get; set; }
        public double Salary { get; set; }  
    }
}
