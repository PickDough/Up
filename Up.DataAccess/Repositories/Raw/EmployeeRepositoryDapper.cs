namespace Up.DataAccess.Repositories.Raw;

using Dapper;
using Entities;
using Npgsql;

public class EmployeeRepositoryDapper(NpgsqlConnection connection) : IEmployeeRepository
{
    public async Task<Employee?> GetById(int id)
    {
        const string sql = """Select * from "Employee" where "EmployeeId" = @id;""";
        return await connection.QuerySingleOrDefaultAsync<Employee>(sql, new { id });
    }

    public async Task<IEnumerable<Employee>> GetAllPaginated(int offset, int pageSize)
    {
        const string sql = """Select * from "Employee" limit @pageSize offset @offset;""";
        return await connection.QueryAsync<Employee>(sql, new { pageSize, offset });
    }
}
