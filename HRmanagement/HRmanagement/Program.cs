// See https://aka.ms/new-console-template for more information

using HRmanagement.Models;
using HRmanagement.Services;

HRmanager hrManager = new HRmanager();

do
{
    Console.WriteLine("-------------------------HR Management---------------------------");
    Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
    Console.WriteLine("1.1 - Departameantlerin siyahisini gostermek:");
    Console.WriteLine("1.2 - Departamenet yaratmaq :");
    Console.WriteLine("1.3 - Departmanetde deyisiklik etmek :");
    Console.WriteLine("2.1 - Iscilerin siyahisini gostermek :");
    Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek: ");
    Console.WriteLine("2.3 - Isci elave etmek:");
    Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek  :");
    Console.WriteLine("2.5 - Departamentden isci silinmesi: ");
    Console.Write("Daxil Et:");
    string choose = Console.ReadLine();
    switch (choose)
    {
        case "1.1":
            getDepartments();
            break;
        case "1.2":
            AddDepartment();
            break;
        case "1.3":
            editDepartment();
            break;
        case "2.1":
            getEmployees();
            break;
        case "2.2":
            getDepartmentEmployees();
            break;
        case "2.3":
            addEmployee();
            break;
        case "2.4":
            editEployee();  
            break;
        case "2.5":
            removeDepartmentEmployee();
            break;
       default:
            break;
    }


} while (true);

void removeDepartmentEmployee()
{
    Console.Write("\nDepartament:");
    string depName=Console.ReadLine();

    Console.Write("Ishcinin nomresi:");
    string empNo=Console.ReadLine();    

    hrManager.RemoveEmployee(empNo,depName);    
}

void editEployee()
{

    Console.Write("Ishcinin nomresi :");
    string employeeNO=Console.ReadLine();

    foreach (Employee employee in hrManager.Employees)
    {
        if (employee.No == employeeNO)
        {
             Console.WriteLine($" Ad soyad: {employee.FullName},  Maasi: {employee.Salary}, vezifesi: {employee.Position} ");

            Console.Write("Ishcinin maashi:");
            double empNewSalary=Convert.ToDouble(Console.ReadLine());

            Console.Write("Ishcini vezifesi:");
            string empNewPosition=Console.ReadLine();

            hrManager.EditEmploye(employeeNO, empNewPosition, empNewSalary);
            return;
        }
    }
    Console.WriteLine($"{employeeNO} -nolu ishci tapilmadi");
}

void addEmployee()
{
    Console.Write("\nIshcinin adi soyadi: ");
    string employeeFullName=Console.ReadLine();

    Console.Write("Ishcinin vezifesi: ");
    string employeePosition=Console.ReadLine();

    Console.Write("Ishcinin maashi: ");
    double employeeSalary=Convert.ToDouble(Console.ReadLine());

    Console.Write("Ishcinin departamenti:");
    string empDepartmentName=Console.ReadLine();    

    hrManager.AddEmployee(employeeFullName, employeePosition,employeeSalary,empDepartmentName);  

}
void getDepartmentEmployees()
{
 
    Console.Write("Departamentin adi: ");
    string depNema=Console.ReadLine();

    Department[] departments = new Department[hrManager.GetDeppartments().Length];
    departments = hrManager.GetDeppartments();

    for (int i = 0; i < departments.Length; i++)
    {
        if (departments[i].Name == depNema)
        {
            if (departments[i].Employees != null)
            {
                foreach (Employee employee in departments[i].Employees)
                {
                    if (employee != null)
                    {
                        Console.WriteLine($"Nomre: {employee.No}, Ad soyad: {employee.FullName}, Departament adi : {employee.DepartmentName}, vezifesi: {employee.Position} Maasi: {employee.Salary}");
                    }
                }
                break;
            }
        }
    }

}

void getEmployees()
{
       foreach(Employee employee in hrManager.Employees)
        {

            Console.WriteLine( $"Nomre: {employee.No}, Ad soyad: {employee.FullName}, Departament adi : {employee.DepartmentName}, vezifesi: {employee.Position} Maasi: {employee.Salary}");
        }

}

void editDepartment()
{
    Console.Write("\n Duzelish etmek istediyiniz Departamaentin adi:");
    string depName=Console.ReadLine();
    Department[] departments = new Department[hrManager.GetDeppartments().Length];
    departments = hrManager.GetDeppartments();

    for (int i = 0;i<departments.Length;i++)
    {
        if (departments[i].Name == depName)
        {
            Console.WriteLine($"Departament adi:{departments[i].Name}, Ishci limiti {departments[i].WorkerLimit}, Emek haqqi limiti:{departments[i].SalaryLimit}");
            Console.Write("Departamentin yeni adi:");
            string depNewName=Console.ReadLine();
            hrManager.EditDepartment(depName,depNewName);
            return;
        }
    }
    Console.WriteLine($"Department tapilmadi:{depName}");
}
void getDepartments()
{

    Department[] departments= new Department[hrManager.GetDeppartments().Length];
    departments= hrManager.GetDeppartments();
    int employeeCount = 0;
    double avarageSalary = 0;
    for (int i = 0;i<departments.Length;i++)
    {
        employeeCount = 0;
        avarageSalary = 0;
        if (departments[i].Employees!=null)
        {
            foreach (Employee employee in departments[i].Employees)
            {
                if (employee!=null)
                { 
                    employeeCount++;
                }    
            }
            avarageSalary = departments[i].CalcSalaryAverage();
        }
        
        Console.WriteLine($"\n Department:{departments[i].Name},Ishci sayi:{employeeCount},Ortalama maash:{avarageSalary}"); 
    }

}
void AddDepartment()
{

    bool consoleread = true;
    string depName;
    int depWorkerlimit;
    double depSalarylimit;
    do
    {
        Console.Write("Departament adi:");
        depName = Console.ReadLine();
        Console.Write("Ishci say limiti:");
        depWorkerlimit = Convert.ToInt32(Console.ReadLine());
        Console.Write("Emek haqqi limiti:");
        depSalarylimit = Convert.ToDouble(Console.ReadLine());
        if (depWorkerlimit > 0 && depSalarylimit > 0)
        {
            consoleread = false;
        }

    }
    while (consoleread);
    
    hrManager.AddDepartment(depName, depWorkerlimit, depSalarylimit);
}