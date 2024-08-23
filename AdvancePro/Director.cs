namespace AdvancePro;

public class Director : Employee
{
    private double percentageOfCompanyShares;

    public Director()
    {
        // Set default daily wage for Director
        base.DailyWage = 300;
    }
    
    
    public double PercentageOfCompanyShares
    {
        get => percentageOfCompanyShares / 100;
        set => percentageOfCompanyShares = value;
    }
    
    public void EnterSharePercentage()
    {
        bool isValidInput = false;

        while (!isValidInput)
        {
            Console.WriteLine("Enter the percentage of shares for the Director (0 to 100):");
            if (double.TryParse(Console.ReadLine(), out double percentage))
            {
                if (percentage >= 0 && percentage <= 100)
                {
                    percentageOfCompanyShares = percentage;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("The share percentage must be between 0 and 100. Please enter again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
    
    public override void EnterEmployeeDetails()
    {
        base.EnterEmployeeDetails();
        EnterSharePercentage();
    }
    
    public override double CalculateSalary()
    {
        return base.DailyWage * WorkingDays;
    }
    
    public override string ToString()
    {
        return $"{base.ToString()}, Share Percentage: {PercentageOfCompanyShares * 100}% - Monthly Salary: {CalculateSalary()}";
    }
}