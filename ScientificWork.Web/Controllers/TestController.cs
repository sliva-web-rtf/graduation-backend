using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Admins;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
namespace ScientificWork.Web.Controllers;

[ApiController]
[Route("test")]
[ApiExplorerSettings(GroupName = "test")]
[Authorize(Roles = nameof(SystemAdmin))]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Test(IEmailSender emailSender)
    {
        await emailSender.SendEmailAsync("", $"Ваш код для подтверждения регистрации: {123456}",
            "Ваш код OTP");
        return Ok();
    }
}