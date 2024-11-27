using Up.Common.Dto;

namespace Up.Common.Repositories;

using Domain;

public interface IEmployeeRepository
{
    Task<Employee?> GetById(int id);
    Task<IEnumerable<Employee>> GetAllPaginated(int offset, int pageSize, EmployeeSortRule sortRule);
    Task<int> Count();
}
