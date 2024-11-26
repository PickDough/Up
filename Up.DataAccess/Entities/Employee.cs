namespace Up.DataAccess.Entities;

public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Bonuses { get; set; }
    public int PositionId { get; set; }
    public int DepartmentId { get; set; }
    public int AddressId { get; set; }
    public int CompanyId { get; set; }
}
