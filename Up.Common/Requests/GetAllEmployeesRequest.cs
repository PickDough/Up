namespace Up.Common.Requests;

using Domain;

public class GetAllEmployeesRequest {
    public EmployeeSortRule? SortRules { get; init; }
}
