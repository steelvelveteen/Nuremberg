using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nuremberg.Data;
using Nuremberg.Interfaces;
using Nuremberg.Models;

namespace Nuremberg.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<TestController> _logger;
    private readonly ICacheService _cache;

    public TestController(ILogger<TestController> logger, ApplicationDbContext dbContext, ICacheService cache)
    {
        _logger = logger;
        _dbContext = dbContext;
        _cache = cache;
    }

    [HttpGet]
    [Route("GetTestsModels")]
    public async Task<ActionResult<IEnumerable<TestModel>>> getTestModelsAsync()
    {
        var result = await _dbContext.TestModels.ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetSingleTestModel")]
    public async Task<ActionResult<TestModel>> GetSingleTestModelAsync()
    {
        var name = "Sec name";
        var cached = await _cache.Get<TestModel>(name);

        if (cached != null) return cached;
        else
        {
            // var result = await _dbContext.TestModels
            // .AnyAsync(t => t.Id == id);
            var result = _dbContext.TestModels
                .AsNoTracking()
                .SingleOrDefault(t => t.TestModelName == name);

            if (result != null)
                await _cache.Set<TestModel>(name, result);

            return Ok(result);
        }
    }
}