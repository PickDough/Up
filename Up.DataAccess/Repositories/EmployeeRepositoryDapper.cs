namespace Up.DataAccess.Repositories;

using Dapper;
using Npgsql;
using Common.Domain;
using Common.Dto;
using Up.Common.Repositories;
using Entities;

public class EmployeeRepositoryDapper(NpgsqlConnection connection) : IEmployeeRepository
{
    const string SqlSelect = """
                                 Select E."EmployeeId", 
                                 E."FirstName", E."LastName", E."Patronymic", 
                                 E."BirthDate", E."HireDate", 
                                 E."PhoneNumber", 
                                 E."Bonuses", 
                                 A."AddressId", A."Country", A."City", A."Street", A."PostalCode",
                                 C."CompanyId", C."CompanyName", C."CompanyInfo",
                                 D."DepartmentId", D."DepartmentName",
                                 P."PositionId", P."PositionName", P."Salary"
                                 from "Employee" E 
                                     inner join "Address" A on A."AddressId" = E."AddressId" 
                                 inner join public."Company" C on C."CompanyId" = E."CompanyId"
                                 inner join public."Department" D on D."DepartmentId" = E."DepartmentId"
                                 inner join public."Position" P on P."PositionId" = E."PositionId"
                             """;

    private Func<Employee, Address, Company, Department, Position, Employee> JoinMap => (e, a, c, d, p) =>
    {
        e.Address = a;
        e.Company = c;
        e.Department = d;
        e.Position = p;
        return e;
    };

    public async Task<int> Count() => await connection.ExecuteScalarAsync<int>("Select count(*) from \"Employee\"");

    public async Task<Employee?> GetById(int id)
    {
        const string sql = $"""
                                {SqlSelect}
                                where "EmployeeId" = @id
                                Limit 1
                            """;
        return (await connection
                .QueryAsync(
                    sql,
                    JoinMap,
                    new { id },
                    splitOn: "AddressId, CompanyId, DepartmentId, PositionId")
            )
            .FirstOrDefault();
    }

    public async Task<IEnumerable<Employee>> GetAllPaginated(int offset, int pageSize, EmployeeSortRule sortRule)
    {
        var sql = $"""
                       {SqlSelect}
                       order by {SortRuleToSql(sortRule)}
                       offset @offset limit @pageSize
                   """;
        return await connection
            .QueryAsync(
                sql,
                JoinMap,
                new { offset, pageSize },
                splitOn: "AddressId, CompanyId, DepartmentId, PositionId"
            );
    }

    private string SortRuleToSql(EmployeeSortRule sortRule) => sortRule switch
    {
        EmployeeSortRule.Bonuses => "E.\"Bonuses\"",
        EmployeeSortRule.EmployeeId => "E.\"EmployeeId\"",
        EmployeeSortRule.FirstName => "E.\"FirstName\"",
        EmployeeSortRule.HireDate => "E.\"HireDate\"",
        EmployeeSortRule.LastName => "E.\"LastName\"",
        _ => "E.\"EmployeeId\" desc"
    } + " " + OrderToSql(sortRule);

    private string OrderToSql(EmployeeSortRule sortRule) => sortRule.Desc switch
    {
        true => "desc",
        false => "asc"
    };
}
