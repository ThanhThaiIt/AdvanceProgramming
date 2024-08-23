namespace AdvancePro;

public  class EmployeeFactory
{
    

    public EmployeeFactory()
    {
    }

    public  Employee GetEmployee(int selection)
    {
        Employee employee = null; 

        switch (selection)
        {
            case 1:
                employee = new RegularEmployee();
                break;
            case 2:
                employee = new Managerr();
                break;
            case 3:
                employee = new Director();
                break;
            default:
                Console.WriteLine("Invalid selection.");
                break;
        }

        return employee;
    }
    
}
