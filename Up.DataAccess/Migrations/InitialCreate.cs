using FluentMigrator;

[Tags("Development", "Staging", "Production")]
[Migration(1, "Initial Create")]
public class InitialCreate : Migration
{
    public override void Up()
    {
        // Creating Department table
        Create.Table("Department")
            .WithColumn("DepartmentId").AsInt32().PrimaryKey().Identity()
            .WithColumn("DepartmentName").AsString(255).NotNullable().Indexed();

        // Creating Position table
        Create.Table("Position")
            .WithColumn("PositionId").AsInt32().PrimaryKey().Identity()
            .WithColumn("PositionName").AsString(255).NotNullable()
            .WithColumn("Salary").AsDecimal(15, 2).NotNullable().Indexed();

        // Creating Company table
        Create.Table("Company")
            .WithColumn("CompanyId").AsInt32().PrimaryKey().Identity()
            .WithColumn("CompanyName").AsString(255).NotNullable().Indexed()
            .WithColumn("CompanyInfo").AsString().Nullable();

        // Creating Address table
        Create.Table("Address")
            .WithColumn("AddressId").AsInt32().PrimaryKey().Identity()
            .WithColumn("Country").AsString(100).NotNullable().Indexed()
            .WithColumn("City").AsString(100).NotNullable().Indexed()
            .WithColumn("Street").AsString(255).NotNullable()
            .WithColumn("PostalCode").AsString(20).NotNullable();

        // Creating Employee table
        Create.Table("Employee")
            .WithColumn("EmployeeId").AsInt32().PrimaryKey().Identity()
            .WithColumn("FirstName").AsString(100).NotNullable()
            .WithColumn("LastName").AsString(100).NotNullable().Indexed()
            .WithColumn("Patronymic").AsString(100).Nullable()
            .WithColumn("BirthDate").AsDate().NotNullable()
            .WithColumn("HireDate").AsDate().NotNullable().Indexed()
            .WithColumn("PhoneNumber").AsString(20).Unique().NotNullable()
            .WithColumn("Bonuses").AsDecimal(15, 2).NotNullable()
            .WithColumn("PositionId").AsInt32().NotNullable().ForeignKey("Position", "PositionId")
            .WithColumn("DepartmentId").AsInt32().NotNullable().ForeignKey("Department", "DepartmentId")
            .WithColumn("AddressId").AsInt32().NotNullable().ForeignKey("Address", "AddressId")
            .WithColumn("CompanyId").AsInt32().NotNullable().ForeignKey("Company", "CompanyId");
    }

    public override void Down()
    {
        Delete.Table("Employee");
        Delete.Table("Address");
        Delete.Table("Company");
        Delete.Table("Position");
        Delete.Table("Department");
    }
}
