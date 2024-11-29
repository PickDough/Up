namespace Up.Common.Model;

public record EmployeeSearchQuery
{
    public List<int> Departments { get; init; } = [];
    public List<int> Positions { get; init; } = [];
}
