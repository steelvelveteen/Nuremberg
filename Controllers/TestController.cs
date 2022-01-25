using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nuremberg.Data;
using Nuremberg.Models;

namespace Nuremberg.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("GetTestsModels")]
    public async Task<ActionResult<IEnumerable<TestModel>>> getTestModelsAsync()
    {
        var result = await _dbContext.TestModels.ToListAsync();
        return Ok(result);
    }
}