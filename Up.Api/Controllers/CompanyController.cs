namespace Up.Api.Controllers;

using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CompanyController(ICompanyRepository companyRepository) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> Get()
    {
        return Ok(await companyRepository.Get());
    }
}
