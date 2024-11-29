using System.Text.Json.Serialization;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Npgsql;
using Up.Core.Repositories;
using Up.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Api Configuration
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c => c.EnableAnnotations(true, true));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(opts => opts.AddDefaultPolicy(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()));

// Json Configuration
builder
    .Services.AddControllers()
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");
builder
    .Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres()
        .WithGlobalConnectionString(connectionString)
        .ScanIn(typeof(InitialCreate).Assembly)
        .For.Migrations())
    .Configure<RunnerOptions>(options => options.Tags = [builder.Environment.EnvironmentName]);

// Repositories
builder.Services.AddScoped<NpgsqlConnection>(_ => new NpgsqlConnection(connectionString));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoryDapper>();
builder.Services.AddScoped<IPositionRepository, PositionRepositoryDapper>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepositoryDapper>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepositoryDapper>();

var app = builder.Build();
app.UseCors();
app.MapControllers();

// Database Migration
using var scope = app.Services.CreateScope();
scope
    .ServiceProvider.GetRequiredService<IMigrationRunner>()
    .MigrateUp();

// Api Documentation
if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseHttpsRedirection();
}

app.Run();
