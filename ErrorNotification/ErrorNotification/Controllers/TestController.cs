using Microsoft.AspNetCore.Mvc;

namespace ErrorNotification.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    
    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> TestOkay()
    {
        try
        {
            _logger.LogInformation("Testing Okay");
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> TestNotOkay()
    {
        try
        {
            throw new ArgumentNullException(nameof(TestNotOkay));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}