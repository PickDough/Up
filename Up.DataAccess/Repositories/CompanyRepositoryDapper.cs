namespace Up.DataAccess.Repositories;

using Common.Dto;
using Core.Repositories;
using Dapper;
using Npgsql;

public class CompanyRepositoryDapper(NpgsqlConnection connection) : ICompanyRepository
{
    public async Task<Company> Get()
    {
        const string sql = """
                           Select "CompanyId", "CompanyName", "CompanyInfo"
                           from "Company"
                           """;

        return await connection.QuerySingleAsync<Company>(sql);
    }
}
