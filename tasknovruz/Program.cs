namespace tasknovruz
{
    internal class Program
    {
        class Employee
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public string DepartmentName { get; set; }
            public double Salary { get; set; }
        }

        class Department
        {
            private List<Employee> employees = new List<Employee>();

            public void AddEmployee(Employee employee)
            {
                employees.Add(employee);
            }

            public void ListEmployees()
            {
                if (employees.Count == 0)
                {
                    Console.WriteLine("Bu departamentdə heç bir işçi yoxdur.");
                }
                else
                {
                    Console.WriteLine("Departmentdəki bütün işçilərin məlumatları:");
                    for (int i = 0; i < employees.Count; i++)
                    {
                        Employee employee = employees[i];
                        Console.WriteLine($"Ad: {employee.Name}, Soyad: {employee.Surname}, Yaş: {employee.Age}, " +
                                          $"Departament adı: {employee.DepartmentName}, Maaş: {employee.Salary}");
                    }
                }
            }

            public void SearchBySalaryRange(double minSalary, double maxSalary)
            {
                bool found = false;
                Console.WriteLine($"{minSalary} ilə {maxSalary} aralığında maaşa uyğun işçilərin siyahısı:");
                for (int i = 0; i < employees.Count; i++)
                {
                    Employee employee = employees[i];
                    if (employee.Salary >= minSalary && employee.Salary <= maxSalary)
                    {
                        Console.WriteLine($"Ad: {employee.Name}, Soyad: {employee.Surname}, Maaş: {employee.Salary}");
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Belirtilən maaş aralığında işçi tapılmadı.");
                }
            }
        }

        class B
        {
            static void Main(string[] args)
            {
                Department department = new Department();

                while (true)
                {
                    Console.WriteLine("\n1. İşçi elave et");
                    Console.WriteLine("2. Bütün işçilere bax");
                    Console.WriteLine("3. Maaş aralığına göre işçiləri axtarış et");
                    Console.WriteLine("0. Proqramı bitir");

                    Console.Write("Zehmət olmasa seçim edin: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Adı daxil edin: ");
                            string name = Console.ReadLine();
                            Console.Write("Soyadı daxil edin: ");
                            string surname = Console.ReadLine();
                            Console.Write("Yaşı daxil edin: ");
                            int age = int.Parse(Console.ReadLine());
                            Console.Write("Departament adını daxil edin: ");
                            string departmentName = Console.ReadLine();
                            Console.Write("Maaşı daxil edin: ");
                            double salary = double.Parse(Console.ReadLine());
                            Employee newEmployee = new Employee
                            {
                                Name = name,
                                Surname = surname,
                                Age = age,
                                DepartmentName = departmentName,
                                Salary = salary
                            };
                            department.AddEmployee(newEmployee);
                            break;
                        case "2":
                            department.ListEmployees();
                            break;
                        case "3":
                            Console.Write("Minimum maaşı daxil edin: ");
                            double minSalary = double.Parse(Console.ReadLine());
                            Console.Write("Maksimum maaşı daxil edin: ");
                            double maxSalary = double.Parse(Console.ReadLine());
                            department.SearchBySalaryRange(minSalary, maxSalary);
                            break;
                        case "0":
                            Console.WriteLine("Proqram bitirildi.");
                            return;
                        default:
                            Console.WriteLine("Düzgün bir seçim edin.");
                            break;
                    }
                }
            }
        }

    }
}
