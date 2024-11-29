namespace Up.Common.Model;

public record EmployeeSearchQuery
{
    List<int> Departments { get; init; } = [];
    List<int> Positions { get; init; } = [];
}
