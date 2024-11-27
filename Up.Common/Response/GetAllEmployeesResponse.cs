namespace Up.Common.Response;

using Dto;

public class GetAllEmployeesResponse
{
    public int TotalCount { get; init; }
    public List<Employee> Employees { get; init; } = [];
}
