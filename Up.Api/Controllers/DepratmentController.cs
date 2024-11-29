using Microsoft.AspNetCore.Mvc;

namespace Up.Api.Controllers;

using Core.Repositories;

[ApiController]
[Route("[controller]")]
public class DepartmentController(IDepartmentRepository departmentRepository) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> GetAllDepartments()
    {
        var departments = await departmentRepository.GetAll();

        return Ok(departments);
    }
}
