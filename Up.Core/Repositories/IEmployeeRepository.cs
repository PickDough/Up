namespace Up.Core.Repositories;

using Common.Dto;
using Common.Model;

public interface IEmployeeRepository
{
    Task<Employee?> GetById(int id);
    Task<IEnumerable<Employee>> GetAllPaginated(int offset, int pageSize, EmployeeSortRule sortRule);
    Task<Employee> Update(int id, Employee e);
    Task<int> Count();
}
