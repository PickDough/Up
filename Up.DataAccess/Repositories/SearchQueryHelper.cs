namespace Up.DataAccess.Repositories;

using Common.Model;

internal static class SearchQueryHelper
{
    internal static string ToSql(this EmployeeSearchQuery query)
    {
        var sql = "";
        if (query.Departments.Count > 0)
        {
            sql = "where E.\"DepartmentId\" in (" + string.Join(",", query.Departments) + ")";
        }
        if (query.Positions.Count > 0)
        {
            if (sql.Length > 0)
            {
                sql += " and E.\"PositionId\" in (" + string.Join(",", query.Positions) + ")";
            }
            else
            {
                sql = "where E.\"PositionId\" in (" + string.Join(",", query.Positions) + ")";
            }
        }

        return sql;
    }
}
