namespace Up.DataAccess.Migrations;

using FluentMigrator;
using Scripts;

[Tags("Staging", "Development")]
[Migration(2, "Staging Fill-in")]
public class StagingFillIn : Migration
{
    public override void Up()
    {
        Execute.Sql(Data.Data_staging);
    }

    public override void Down() {}
}
