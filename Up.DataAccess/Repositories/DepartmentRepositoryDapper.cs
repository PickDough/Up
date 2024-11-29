using Dapper;
using Npgsql;

namespace Up.DataAccess.Repositories;

using Common.Dto;
using Core.Repositories;

public class DepartmentRepositoryDapper(NpgsqlConnection connection) : IDepartmentRepository
{
    public async Task<IEnumerable<Department>> GetAll()
    {
        const string sql = """
                           Select "DepartmentId", "DepartmentName"
                           from "Department"
                           """;

        return await connection.QueryAsync<Department>(sql);
    }
}
