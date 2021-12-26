using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRmanagement.Models
{
    internal class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; } 
        public Employee[] Employees { get; set; }    

        public double CalcSalaryAverage()
        {
            double avarage = 0;
            double sum = 0;
            int empCount = 0;
            foreach (Employee emp in this.Employees)
            {
                if (emp != null)
                {
                    sum += emp.Salary;
                    empCount++;
                }
            }
            if (empCount>0)
            {
                avarage=sum/empCount;
            }
            return avarage; 
        }
    }
}
