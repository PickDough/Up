namespace Up.DataAccess.Repositories;

using Entities;

public interface IEmployeeRepository
{
    Task<Employee?> GetById(int id);
    Task<IEnumerable<Employee>> GetAllPaginated(int pffset, int pageSize);
}
