namespace Up.Core.Repositories;

using Common.Dto;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAll();
}
