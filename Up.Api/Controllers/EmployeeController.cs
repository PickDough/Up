namespace Up.Api.Controllers;

using System.Globalization;
using Common.Dto;
using Common.Model;
using Common.Requests;
using Common.Response;
using Core.Repositories;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmployeeController(IEmployeeRepository employeeRepository) : ControllerBase
{
    [HttpGet("{id:int}")] public async Task<IActionResult> GetById(int id)
    {
        var employee = await employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPatch("{id:int}")] public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
    {
        try
        {
            employee = await employeeRepository.Update(id, employee);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.ToString());
        }

        return Ok(employee);
    }

    [HttpPost] public async Task<IActionResult> SearchAll(GetAllEmployeesRequest query, [FromQuery] int offset = 0, [FromQuery] int pageSize = 10)
    {
        var employees = await employeeRepository.GetAllPaginated(offset, pageSize, query.SearchQuery, query.SortRules);
        var (count, salary) = await employeeRepository.CountAndSalarySum(query.SearchQuery);
        return Ok(new GetAllEmployeesResponse
        {
            TotalCount = count,
            TotalSalary = salary,
            Employees = employees.ToList()
        });
    }

    [HttpGet("download")] public async Task<IActionResult> Download([FromQuery] List<int> departments, [FromQuery] List<int> positions)
    {
        var query = new GetAllEmployeesRequest
        {
            SearchQuery = new EmployeeSearchQuery
            {
                Departments = departments,
                Positions = positions
            }
        };
    Response.ContentType = "text/csv";
        Response.Headers.Append("Content-Disposition", "attachment; filename=\"employees.csv\"");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",", 
            HasHeaderRecord = true 
        };

        await using var writer = new StreamWriter(Response.Body);
        await using var csv = new CsvWriter(writer, config);
        
        const int pageSize = 1000; 
        var offset = 0;
        var employees = (await employeeRepository.GetAllPaginated(offset, pageSize, query.SearchQuery, query.SortRules)).ToList();
        while (employees.Count != 0)
        {
            await csv.WriteRecordsAsync(employees);
            await writer.FlushAsync();

            offset += pageSize;
            employees = (await employeeRepository.GetAllPaginated(offset, pageSize, query.SearchQuery, query.SortRules)).ToList();
        }

        return new EmptyResult();
    }
}
