using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("test")]
[ApiExplorerSettings(GroupName = "test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Test()
    {
        return await Task.FromResult(Ok());
    }
}