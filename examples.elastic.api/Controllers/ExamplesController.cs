using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace examples.elastic.api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExampleController : ControllerBase
{
    private readonly ILogger _logger;
    
    public ExampleController(ILogger logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Info()
    {
        _logger.Information("exaples info {rand}", new Random().Next());
        return Ok("Hello Info");
    }
    
    [HttpGet]
    public IActionResult Warn()
    {
        _logger.Warning("exaples warn {rand}", new Random().Next());
        return Ok("Hello Warn");
    }
    
    [HttpGet]
    public IActionResult Error()
    {
        _logger.Error("exaples error {rand}", new Random().Next());
        return Ok("Hello Error");
    }
}