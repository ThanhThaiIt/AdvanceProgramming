namespace AdvancePro;

public class Company
{
    private string companyName;
    private string taxCode;
    private double monthlyRevenue;
    private List<Employee> staffList;
    
    public Company()
    {
        staffList = new List<Employee>();
    }

    public string CompanyName
    {
        get => companyName;
        set => companyName = value;
    }

    public string TaxCode
    {
        get => taxCode;
        set => taxCode = value;
    }

    public double MonthlyRevenue
    {
        get => monthlyRevenue;
        set => monthlyRevenue = value;
    }

    public List<Employee> StaffList
    {
        get => staffList;
    }
    public override string ToString()
    {
        return $"Company: CompanyName={companyName}, TaxCode={taxCode}, MonthlyRevenue={monthlyRevenue}-";
    }
    
    
    
    public double CalculateTotalIncome(Director director)
        {
            double companyProfit = MonthlyRevenue - CalculateTotalSalary();
            return director.CalculateSalary() + (director.PercentageOfCompanyShares * companyProfit);
        }

        public void DisplayTotalIncomeOfDirectors()
        {
            Console.WriteLine("Total Income of Each Director: ");
            foreach (var staff in staffList)
            {
                if (staff is Director)
                {
                    double income = CalculateTotalIncome((Director)staff);
                    Console.WriteLine(staff.ToString() + ", Total Income: " + income);
                }
            }
        }

        public Director FindDirectorWithMostShares()
        {
            if (!staffList.Any()) return null;

            Director directorWithMostShares = null;
            foreach (var staff in staffList)
            {
                if (staff is Director)
                {
                    directorWithMostShares = (Director)staff;
                    break;
                }
                
                
            }

            foreach (var staff in staffList)
            {
                if (staff is Director)
                {
                    var director = (Director)staff;
                    if (director.PercentageOfCompanyShares > directorWithMostShares.PercentageOfCompanyShares)
                    {
                        directorWithMostShares = director;
                    }
                }
            }

            return directorWithMostShares;
        }

        public void SortStaffBySalaryDescending()
        {
            Console.WriteLine("Staff List Sorted by Salary Descending");
            staffList.Sort(new StaffComparatorBySalary());

            foreach (var staff in staffList)
            {
                Console.WriteLine(staff.ToString());
            }
        }

        public void SortStaffByName()
        {
            Console.WriteLine("Staff List Sorted by Name");
            staffList.Sort(new StaffComparatorByName());

            foreach (var staff in staffList)
            {
                Console.WriteLine(staff.ToString());
            }
        }

        public Managerr FindManagerWithMostSubordinates()
        {
            if (!staffList.Any()) return null;

            Managerr managerWithMostSubordinates = null;
            foreach (var staff in staffList)
            {
                if (staff is Managerr)
                {
                    managerWithMostSubordinates = (Managerr)staff;
                    break;
                }
            }

            foreach (var staff in staffList)
            {
                if (staff is Managerr)
                {
                    var manager = (Managerr)staff;
                    if (manager.Subordinates.Count > managerWithMostSubordinates.Subordinates.Count)
                    {
                        managerWithMostSubordinates = manager;
                    }
                }
            }

            return managerWithMostSubordinates;
        }

        public double CalculateTotalSalary()
        {
            return staffList.Sum(staff => staff.CalculateSalary());
        }

        public void RemoveStaff()
        {
            // Display the list of employees
            for (int i = 0; i < staffList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {staffList[i].ToString()}");
            }

            // Select employee to remove
            Console.WriteLine("Select Employee to Remove:");
            int indexToRemove = int.Parse(Console.ReadLine()) - 1;

            if (indexToRemove < 0 || indexToRemove >= staffList.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var employeeToRemove = staffList[indexToRemove];
            int employeeIdToRemove = employeeToRemove.EmployeeId;

            if (employeeToRemove is Managerr managerToRemove)
            {
                // Remove this manager from any regular employees
                foreach (var staff in staffList.OfType<RegularEmployee>())
                {
                    if (staff.Managerr != null && staff.Managerr.EmployeeId == employeeIdToRemove)
                    {
                        staff.Managerr = null;
                    }
                }
            }
            else if (employeeToRemove is RegularEmployee regularEmployeeToRemove)
            {
                // Remove this regular employee from any manager's list
                foreach (var staff in staffList.OfType<Managerr>())
                {
                    staff.Subordinates.Remove(regularEmployeeToRemove);
                }
            }

            // Remove the employee from the list
            staffList.RemoveAt(indexToRemove);
        }
        


        public void CheckValidStaff(Employee staff)
        {
            bool idExists = staffList.Any(existingStaff => existingStaff.EmployeeId == staff.EmployeeId);

            if (idExists)
            {
                Console.WriteLine("This ID already exists in the list. Please choose another ID.");
            }
            else
            {
                staffList.Add(staff);
            }
        }

        public void InputCompanyInfo()
        {
           

 Console.WriteLine("Enter Company Name:");
            CompanyName = Console.ReadLine();
            Console.WriteLine("Enter Tax Code:");
            TaxCode = Console.ReadLine();
            Console.WriteLine("Enter Monthly Revenue:");
            MonthlyRevenue = double.Parse(Console.ReadLine());
        }

        public void DisplayCompanyInfo()
        {
            Console.WriteLine(ToString());
            foreach (var staff in staffList)
            {
                Console.WriteLine(staff.ToString());
            }
        }

        public Employee FindHighestPaidStaff()
        {
            if (!staffList.Any()) return null;

            Employee highestPaidStaff = staffList[0];
            foreach (var staff in staffList)
            {
                if (staff.CalculateSalary() > highestPaidStaff.CalculateSalary())
                {
                    highestPaidStaff = staff;
                }
            }

            return highestPaidStaff;
        }
        
                public void ShowMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("1. Enter company information");
                Console.WriteLine("2. Enter Staff and Assign Staff to Manager");
                Console.WriteLine("3. Remove a staff member");
                Console.WriteLine("4. Display all company information");
                Console.WriteLine("5. Calculate and display total salary for the company");
                Console.WriteLine("6. Find the highest-paid staff member");
                Console.WriteLine("7. Find the manager with the most subordinates");
                Console.WriteLine("8. Sort staff by name");
                Console.WriteLine("9. Sort staff by salary descending");
                Console.WriteLine("10. Find the director with the most shares");
                Console.WriteLine("11. Calculate and display total income of each director");
                Console.WriteLine("0. Exit the program");
                Console.Write("Select an option (0-11): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InputCompanyInfo();
                        break;
                                        case 2:
                        Console.WriteLine("===== Choose 1 of 3 staff types to add =====");
                        Console.WriteLine("1. Regular Employee");
                        Console.WriteLine("2. Manager");
                        Console.WriteLine("3. Director");
                        int selectPos = int.Parse(Console.ReadLine());

                        EmployeeFactory employeeFactory = new EmployeeFactory();
                        Employee employee = employeeFactory.GetEmployee(selectPos);

                        if (employee != null)
                        {
                            employee.EnterEmployeeDetails(); // Gọi hàm chung cho tất cả các loại nhân viên
    
                            if (employee is Managerr manager)
                            {
                                int addMore = 1;
                                do
                                {
                                    Console.WriteLine("Do you want to add subordinates (1: Yes, 0: No)");
                                    addMore = int.Parse(Console.ReadLine());

                                    if (addMore == 0)
                                    {
                                        Console.WriteLine("Manager has been added");
                                        break;
                                    }

                                    var regularEmployees = new List<RegularEmployee>();
                                    if (addMore == 1)
                                    {
                                        Console.WriteLine("Select Employee to Add ");
                                        int indexRegularEmployee = 0;
                                        for (int i = 0; i < staffList.Count; i++)
                                        {
                                            if (staffList[i] is RegularEmployee)
                                            {
                                                Console.WriteLine(
                                                    $"{indexRegularEmployee + 1} : ID: {staffList[i].EmployeeId}, Name: {staffList[i].FullName}");
                                                indexRegularEmployee++;
                                                regularEmployees.Add((RegularEmployee)staffList[i]);
                                            }
                                        }

                                        int choiceIdx = int.Parse(Console.ReadLine()) - 1;
                                        manager.AddSubordinate(regularEmployees[choiceIdx]);
                                        regularEmployees[choiceIdx].Managerr = manager;
                                    }
                                } while (addMore != 0);
                            }

                            CheckValidStaff(employee);
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                        break;
                    case 3:
                        RemoveStaff();
                        break;
                    case 4:
                        DisplayCompanyInfo();
                        break;
                    case 5:
                        DisplayCompanyInfo();
                        Console.WriteLine("Total Salary for the Company: " + CalculateTotalSalary());
                        break;
                    case 6:
                        Console.WriteLine("Highest Paid Staff in Company " + CompanyName + " is: ");
                        Console.WriteLine(FindHighestPaidStaff().ToString());
                        break;
                    case 7:
                        Console.WriteLine("Manager with Most Subordinates: ");
                        Console.WriteLine(FindManagerWithMostSubordinates().ToString());
                        break;
                    case 8:
                        SortStaffByName();
                        break;
                    case 9:
                        SortStaffBySalaryDescending();
                        break;
                    case 10:
                        Console.WriteLine("Director with Most Shares: ");
                        Console.WriteLine(FindDirectorWithMostShares().ToString());
                        break;
                    case 11:
                        DisplayTotalIncomeOfDirectors();
                        break;
                    case 0:
                        Console.WriteLine("Exited the program.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
}