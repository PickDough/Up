namespace Up.Common.Domain;

using System.Text.Json.Serialization;

[JsonDerivedType(typeof(EmployeeId), typeDiscriminator: "employeeId")]
[JsonDerivedType(typeof(FirstName), typeDiscriminator: "firstName")]
[JsonDerivedType(typeof(LastName), typeDiscriminator: "lastName")]
[JsonDerivedType(typeof(Bonuses), typeDiscriminator: "bonuses")]
[JsonDerivedType(typeof(HireDate), typeDiscriminator: "hireDate")]
public abstract record EmployeeSortRule(bool Desc)
{
    public record EmployeeId(bool Desc = false) : EmployeeSortRule(Desc);

    public record FirstName(bool Desc = false) : EmployeeSortRule(Desc);

    public record LastName(bool Desc = false) : EmployeeSortRule(Desc);

    public record Bonuses(bool Desc = false) : EmployeeSortRule(Desc);

    public record HireDate(bool Desc = false) : EmployeeSortRule(Desc);
}
