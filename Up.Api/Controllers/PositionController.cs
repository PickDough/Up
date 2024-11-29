using Microsoft.AspNetCore.Mvc;

namespace Up.Api.Controllers;

using Core.Repositories;

[ApiController]
[Route("[controller]")]
public class PositionController(IPositionRepository positionRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPositions()
    {
        var positions = await positionRepository.GetAll();

        return Ok(positions);
    }
}
