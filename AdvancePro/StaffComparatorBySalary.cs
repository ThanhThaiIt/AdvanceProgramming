namespace AdvancePro;

public class StaffComparatorBySalary : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        return y.CalculateSalary().CompareTo(x.CalculateSalary()); // Descending order
    }
}