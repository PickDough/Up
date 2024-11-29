using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Up.DataAccess.Repositories;

using Common.Dto;
using Core.Repositories;

public class PositionRepositoryDapper(NpgsqlConnection connection) : IPositionRepository
{

    public async Task<IEnumerable<Position>> GetAll()
    {
        const string sql = """
                           Select "PositionId", "PositionName", "Salary"
                           from "Position"
                           """;

        return await connection.QueryAsync<Position>(sql);
    }
}
