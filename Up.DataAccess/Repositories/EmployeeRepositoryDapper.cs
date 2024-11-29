namespace Up.DataAccess.Repositories;

using Common.Dto;
using Common.Model;
using Core.Exceptions;
using Dapper;
using Npgsql;
using Core.Repositories;

public class EmployeeRepositoryDapper(NpgsqlConnection connection) : IEmployeeRepository
{
    private static string SqlSelect(string from = "from \"Employee\" E ")
        => $"""
            Select E."EmployeeId", 
            E."FirstName", E."LastName", E."Patronymic", 
            E."BirthDate", E."HireDate", 
            E."PhoneNumber", 
            E."Bonuses", 
            A."AddressId", A."Country", A."City", A."Street", A."PostalCode",
            C."CompanyId", C."CompanyName", C."CompanyInfo",
            D."DepartmentId", D."DepartmentName",
            P."PositionId", P."PositionName", P."Salary",
            E."Bonuses" + P."Salary" as "TotalSalary"
            {from}
                inner join "Address" A on A."EmployeeId" = E."EmployeeId" 
                inner join public."Company" C on C."CompanyId" = E."CompanyId"
                inner join public."Department" D on D."DepartmentId" = E."DepartmentId"
                inner join public."Position" P on P."PositionId" = E."PositionId"
            """;

    private Func<Employee, Address, Company, Department, Position, Employee> JoinMap
        => (e, a, c, d, p) =>
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
        var sql = $"""
                   {SqlSelect()}
                   where E."EmployeeId" = @id
                   Limit 1
                   """;

        return (await connection.QueryAsync(
                sql,
                JoinMap,
                new { id },
                splitOn: "AddressId, CompanyId, DepartmentId, PositionId")
            ).FirstOrDefault();
    }

    public async Task<IEnumerable<Employee>> GetAllPaginated(int offset, int pageSize, EmployeeSortRule sortRule)
    {
        var sql = $"""
                   {SqlSelect()}
                   order by {sortRule.SortRuleToSql()}
                   offset @offset limit @pageSize
                   """;
        return await connection.QueryAsync(sql, JoinMap, new { offset, pageSize }, splitOn: "AddressId, CompanyId, DepartmentId, PositionId");
    }

    public async Task<Employee> Update(int id, Employee e)
    {
        await connection.OpenAsync();
        await using var transaction = await connection.BeginTransactionAsync();
        try
        {
            await ExecuteUpdateAddressQuery(e, transaction);
            var employees = await ExecuteEmployeeUpdateQuery(id, e, transaction);
            await transaction.CommitAsync();
            return employees.First();
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    async private Task<IEnumerable<Employee>> ExecuteEmployeeUpdateQuery(int id, Employee e, NpgsqlTransaction transaction)
    {
        var sqlEmployee = $"""
                           WITH updated_employee AS (
                               UPDATE "Employee"
                               SET
                                   "FirstName" = @FirstName,
                                   "LastName" = @LastName,
                                   "Patronymic" = @Patronymic,
                                   "BirthDate" = @BirthDate,
                                   "HireDate" = @HireDate,
                                   "PhoneNumber" = @PhoneNumber,
                                   "Bonuses" = @Bonuses,
                                   "PositionId" = @PositionId,
                                   "DepartmentId" = @DepartmentId
                               WHERE
                                   "EmployeeId" = @id
                               RETURNING *
                           )
                           {SqlSelect("from updated_employee E ")}
                           Limit 1
                           """;

        var @params = new
        {
            e.FirstName, e.LastName, e.Patronymic,
            e.BirthDate, e.HireDate, e.PhoneNumber, e.Bonuses,
            e.Position.PositionId, e.Department.DepartmentId, e.Address.AddressId,
            id
        };
        try
        {
            var employees = await connection.QueryAsync(
                sqlEmployee,
                JoinMap,
                @params,
                transaction,
                splitOn: "AddressId, CompanyId, DepartmentId, PositionId"
            );
            return employees;
        }
        catch (Exception exception) when (exception is InvalidOperationException or PostgresException)
        {
            throw new InvalidOperationCoreException<Employee>
            {
                Value = e,
                Operation = "update"
            };
        }
    }
    async private Task ExecuteUpdateAddressQuery(Employee e, NpgsqlTransaction transaction)
    {

        const string sqlAddresses = """
                                    UPDATE "Address"
                                    SET
                                        "Country" = @Country,
                                        "City" = @City,
                                        "Street" = @Street,
                                        "PostalCode" = @PostalCode
                                    WHERE
                                        "AddressId" = @AddressId
                                    RETURNING *
                                    """;

        var addressParams = new
        {
            e.Address.Country,
            e.Address.City,
            e.Address.Street,
            e.Address.PostalCode,
            e.Address.AddressId
        };
        try
        {
            await connection.QuerySingleAsync<Address>(sqlAddresses, addressParams, transaction);
        }
        catch (Exception exception) when (exception is InvalidOperationException or PostgresException)
        {
            throw new InvalidOperationCoreException<Address>
            {
                Value = e.Address,
                Operation = "update",
            };
        }
    }
}
