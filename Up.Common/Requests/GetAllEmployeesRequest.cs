namespace Up.Common.Requests;

using Model;

public class GetAllEmployeesRequest
{
    public EmployeeSortRule SortRules { get; init; } = new EmployeeSortRule.EmployeeId();
    public EmployeeSearchQuery SearchQuery { get; init; } = new();
}
