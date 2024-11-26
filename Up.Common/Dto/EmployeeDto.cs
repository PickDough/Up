namespace Up.Common.Dto;

using DataAccess.Entities;

public class EmployeeDto
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime HireDate { get; set; }

    public string PhoneNumber { get; set; }

    public decimal Bonuses { get; set; }

    public PositionDto Position { get; set; }

    public DepartmentDto Department { get; set; }

    public AddressDto Address { get; set; }

    public CompanyDto Company { get; set; }
}
