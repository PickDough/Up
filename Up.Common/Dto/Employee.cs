namespace Up.Common.Dto;

using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Patronymic { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }

    [RegularExpression(@"^\d{3}-\d{4}", ErrorMessage = "Phone number must be formatted as 123-4567")]
    public required string PhoneNumber { get; set; }
    public decimal Bonuses { get; set; }

    public required Position Position { get; set; }
    public required Department Department { get; set; }
    public required Address Address { get; set; }
    public required Company Company { get; set; }

    public decimal Salary
    {
        get => Position.Salary + Bonuses;
        set {}
    }
}
