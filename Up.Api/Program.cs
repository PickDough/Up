using System.Text.Json.Serialization;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Npgsql;
using Up.DataAccess.Repositories;
using Up.DataAccess.Repositories.Raw;

var builder = WebApplication.CreateBuilder(args);

// Api Configuration
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(opts => opts.AddDefaultPolicy(policy => policy
    .WithOrigins("up.client")
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
builder.Services.AddSingleton(new NpgsqlConnection(connectionString));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoryDapper>();

var app = builder.Build();
app.MapControllers();
app
    .Services.GetRequiredService<IMigrationRunner>()
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
