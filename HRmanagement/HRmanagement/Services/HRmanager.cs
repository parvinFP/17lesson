using HRmanagement.Interface;
using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRmanagement.Services
{
    internal class HRmanager : IHumanResourceManager
    {
        private Department[] _departments;
        private Employee[] _employees;

        public Department[] Departments => _departments;    
        public Employee[] Employees => _employees;  
        

        public HRmanager()
        {
            _departments = new Department[0];
            _employees = new Employee[0];
        }

        
        public void AddDepartment(string depName ,int depWorkerlimit,double depSalarylimit)
        {
            Department department = new Department() { Name=depName,SalaryLimit=depSalarylimit,WorkerLimit=depWorkerlimit,Employees = { } };
            Array.Resize(ref _departments, _departments.Length + 1);
           _departments[_departments.Length - 1] = department;
     
        }
        
        public void AddEmployee( string employeeFullName, string employeePosition, double employeeSalary, string empDepartmentName)
        {            
           
            for ( int i=0;i < _departments.Length;i++)
            {
               if (_departments[i].Name == empDepartmentName)
                {
                    Employee[] employee2;
                    int empCount = 0;
                    if (_departments[i].Employees!=null)
                    {
                        empCount = _departments[i].Employees.Length;
                    }
                    employee2 = new Employee[empCount]; 
                    if (empCount>0)
                    {
                        employee2 = _departments[i].Employees;
                    }
                    Array.Resize(ref employee2, employee2.Length + 1);

                    int empNumber = 1000 +  employee2.Length;
                    string employeeNO = empDepartmentName.Substring(0, 2) + empNumber.ToString();

                    Employee employee = new Employee() { No = employeeNO, FullName = employeeFullName, Position = employeePosition, Salary = employeeSalary, DepartmentName = empDepartmentName };
                    Array.Resize(ref _employees, _employees.Length + 1);
                    _employees[_employees.Length - 1] = employee;

                    employee2[employee2.Length - 1] = employee;
                    _departments[i].Employees = employee2;

                    return;
                }
            }
        }

        public void EditDepartment(string oldName, string newName )
        {
            for (int i=0;i<_departments.Length;i++)
            {
               if (_departments[i].Name == oldName)
                {

                    _departments[i].Name = newName;

                    return;
                }
            }          
        }


        public void EditEmploye(string employeeNO,  string employeePosition, double employeeSalary)
        {
            for (int i = 0; i < _employees.Length; i++)
            {
                if (_employees[i].No == employeeNO)
                {

                    _employees[i].Salary=employeeSalary;
                    _employees[i].Position=employeePosition;
                    return;
                }
            }
        }
 
        public Department[] GetDeppartments()
        {
            return _departments;
        }

        public void RemoveEmployee(string employeeNO, string departmentName)
        {
            for (int i =0;i< _departments.Length;i++)
            {
                if (_departments[i].Name == departmentName) 
                {
                    for(int j=0;j<_departments[i].Employees.Length;j++)
                    {
                        if (_departments[i].Employees[j].No==employeeNO)
                        {
                            _departments[i].Employees[j] = null;
                            return;
                        }
                    }
                }
            }
        }
    }
}
