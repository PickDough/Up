namespace Up.DataAccess.Repositories;

using Common.Model;

internal static class SortRuleHelper
{
    internal static string SortRuleToSql(this EmployeeSortRule sortRule) => sortRule switch
    {
        EmployeeSortRule.TotalSalary => "\"TotalSalary\"",
        EmployeeSortRule.EmployeeId => "E.\"EmployeeId\"",
        EmployeeSortRule.FirstName => "E.\"FirstName\"",
        EmployeeSortRule.HireDate => "E.\"HireDate\"",
        EmployeeSortRule.LastName => "E.\"LastName\"",
        _ => "E.\"EmployeeId\" desc"
    } + " " + sortRule.OrderToSql();

    internal static string OrderToSql(this EmployeeSortRule sortRule) => sortRule.Desc switch
    {
        true => "desc",
        false => "asc"
    };
}
