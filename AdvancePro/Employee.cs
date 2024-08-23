namespace AdvancePro;

public abstract class Employee
{
    protected int employeeId;
    protected string fullName;
    protected int phoneNumber;
    protected int workingDays;
    protected double dailyWage;

    protected Employee()
    {
    }
    public int EmployeeId
    {
        get { return employeeId; }
        set { employeeId = value; }
    }

    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }

    public int PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    public int WorkingDays
    {
        get { return workingDays; }
        set { workingDays = value; }
    }

    public double DailyWage
    {
        get { return dailyWage; }
        set { dailyWage = value; }
    }

    public abstract double CalculateSalary();

    public virtual void EnterEmployeeDetails()
    {
        Console.WriteLine("Enter employee ID:");
        employeeId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter employee's full name:");
        fullName = Console.ReadLine();

        Console.WriteLine("Enter employee's phone number:");
        phoneNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number of working days:");
        workingDays = int.Parse(Console.ReadLine());
    }

    public override string ToString()
    {
        return $"Employee: ID={employeeId}, FullName={fullName}, PhoneNumber={phoneNumber}, WorkingDays={workingDays}, DailyWage={dailyWage}";
    }
}