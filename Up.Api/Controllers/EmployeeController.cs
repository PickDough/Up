namespace Up.Api.Controllers;

using Common.Model;
using Common.Requests;
using Common.Response;
using Core.Repositories;
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

    [HttpPost] public async Task<IActionResult> GetAll(GetAllEmployeesRequest query, [FromQuery] int offset = 0, [FromQuery] int pageSize = 10)
    {
        var employees = await employeeRepository.GetAllPaginated(offset, pageSize, query.SortRules ?? new EmployeeSortRule.EmployeeId(false));

        return Ok(new GetAllEmployeesResponse
        {
            TotalCount = await employeeRepository.Count(),
            Employees = employees.ToList()
        });
    }
}
