namespace Up.Common.Requests;

using Model;

public class GetAllEmployeesRequest
{
    public EmployeeSortRule? SortRules { get; init; }
}
