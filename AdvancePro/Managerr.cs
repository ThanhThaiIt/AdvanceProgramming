namespace AdvancePro;

public class Managerr : Employee
{
    private int numberOfSubordinates;
    private List<RegularEmployee> subordinates;

    public Managerr()
    {
        base.DailyWage = 200;
        this.numberOfSubordinates = 0;
        this.subordinates = new List<RegularEmployee>();
    }
    public int NumberOfSubordinates
    {
        get { return numberOfSubordinates; }
        set { numberOfSubordinates = value; }
    }

    public List<RegularEmployee> Subordinates
    {
        get { return subordinates; }
        set { subordinates = value; }
    }
    
    public int GetNumberOfEmployees()
    {
        return this.subordinates.Count;
    }
    
    public void DisplaySubordinates()
    {
        Console.WriteLine("List of Subordinates:");
        int i = 0;
        foreach (var subordinate in subordinates)
        {
            i++;
            Console.WriteLine($"{i}. {subordinate.ToString()}");
            Console.WriteLine();
        }
    }
    public void AddSubordinate(RegularEmployee subordinate)
    {
        subordinates.Add(subordinate);
    }
    public override double CalculateSalary()
    {
        return DailyWage * WorkingDays + (100 * numberOfSubordinates);
    }
    
    
    public override string ToString()
    {
        return $"{base.ToString()}, Number of Subordinates: {GetNumberOfEmployees()} - Monthly Salary: {CalculateSalary()}";
    }
}