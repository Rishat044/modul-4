using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public string EmployeeType { get; set; }
}

public abstract class SalaryCalculator
{
    public abstract double CalculateSalary(Employee employee);
}

public class PermanentSalaryCalculator : SalaryCalculator
{
    public override double CalculateSalary(Employee employee) => employee.BaseSalary * 1.2;
}

public class ContractSalaryCalculator : SalaryCalculator
{
    public override double CalculateSalary(Employee employee) => employee.BaseSalary * 1.1;
}

public class InternSalaryCalculator : SalaryCalculator
{
    public override double CalculateSalary(Employee employee) => employee.BaseSalary * 0.8;
}

public class FreelancerSalaryCalculator : SalaryCalculator
{
    public override double CalculateSalary(Employee employee) => employee.BaseSalary;
}

public class EmployeeSalaryCalculator
{
    private readonly Dictionary<string, SalaryCalculator> _calculators;

    public EmployeeSalaryCalculator()
    {
        _calculators = new Dictionary<string, SalaryCalculator>
        {
            { "Permanent", new PermanentSalaryCalculator() },
            { "Contract", new ContractSalaryCalculator() },
            { "Intern", new InternSalaryCalculator() },
            { "Freelancer", new FreelancerSalaryCalculator() }
        };
    }

    public double CalculateSalary(Employee employee)
    {
        if (_calculators.TryGetValue(employee.EmployeeType, out var calculator))
        {
            return calculator.CalculateSalary(employee);
        }

        throw new NotSupportedException("Employee type not supported");
    }
}




public class Program
{
    public static void Main(string[] args)
    {
        Employee employee1 = new Employee { Name = "fff", BaseSalary = 1000, EmployeeType = "Permanent" };
        Employee employee2 = new Employee { Name = "rrr", BaseSalary = 1000, EmployeeType = "Freelancer" };

        EmployeeSalaryCalculator salaryCalculator = new EmployeeSalaryCalculator();

        Console.WriteLine($"Salary of {employee1.Name}: {salaryCalculator.CalculateSalary(employee1)}");
        Console.WriteLine($"Salary of {employee2.Name}: {salaryCalculator.CalculateSalary(employee2)}");
    }
}

