namespace AdvancePro;

public class StaffComparatorByName : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        return x.FullName.CompareTo(y.FullName);
    }
}