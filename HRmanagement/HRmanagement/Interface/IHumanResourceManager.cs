using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRmanagement.Interface
{
    internal interface IHumanResourceManager
    {
        Department[] Departments { get; }      
        void AddDepartment(string depName, int depWorkerlimit, double depSalarylimit);
        Department[] GetDeppartments();
        void EditDepartment (string oldName, string newName);    
        void AddEmployee (string employeeFullName,string employeePosition,double employeeSalary,string empDepartmentName);
        void RemoveEmployee(string employeeNO,string departmentName);
        void EditEmploye(string employeeNO,  string employeePosition,double employeeSalary);

        


    }
}
