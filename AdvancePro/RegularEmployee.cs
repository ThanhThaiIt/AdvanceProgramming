namespace AdvancePro;

public class RegularEmployee  : Employee
{
    private Managerr managerr;
    
    
    public RegularEmployee()
    {
        // Set default daily wage
        base.DailyWage = 100;
    }

    
    public Managerr Managerr
    {
        get => managerr;
        set
        {
            if (value == null)
            {
                
                managerr = null;
            }
            else
            {
                managerr = value;
            }
        }
    }

    public override double CalculateSalary()
    {
        return DailyWage * WorkingDays;
    }
    
    public override string ToString()
    {
        if (managerr == null)
        {
            return $"{base.ToString()} - Monthly Salary: {CalculateSalary()}, Manager ID: Null";
        }
        return $"{base.ToString()} - Monthly Salary: {CalculateSalary()}, Manager ID: {managerr.EmployeeId}, Manager Name: {managerr.FullName}";
    }
}