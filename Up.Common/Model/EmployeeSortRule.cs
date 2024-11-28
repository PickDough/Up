namespace Up.Common.Model;

using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$sortRule")]
[JsonDerivedType(typeof(EmployeeId), "employeeId")]
[JsonDerivedType(typeof(FirstName), "firstName")]
[JsonDerivedType(typeof(LastName), "lastName")]
[JsonDerivedType(typeof(TotalSalary), "bonuses")]
[JsonDerivedType(typeof(HireDate), "hireDate")]
public abstract record EmployeeSortRule(bool Desc)
{
    public record EmployeeId(bool Desc = false) : EmployeeSortRule(Desc);

    public record FirstName(bool Desc = false) : EmployeeSortRule(Desc);

    public record LastName(bool Desc = false) : EmployeeSortRule(Desc);

    public record TotalSalary(bool Desc = false) : EmployeeSortRule(Desc);

    public record HireDate(bool Desc = false) : EmployeeSortRule(Desc);
}
