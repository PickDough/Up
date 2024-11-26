namespace Up.Api.Controllers;

using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmployeeController(IEmployeeRepository employeeRepository) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await employeeRepository.GetById(id);
        if (employee == null)
            return NotFound();

        return Ok(employee);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPaginated([FromQuery] int offset = 0, [FromQuery] int pageSize = 25)
    {
        var employees = await employeeRepository.GetAllPaginated(offset * pageSize, pageSize);
        return Ok(employees);
    }
}
