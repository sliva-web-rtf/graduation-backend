using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Professor controller.
/// </summary>
[ApiController]
[Route("api/professor")]
[ApiExplorerSettings(GroupName = "professor")]
public class ProfessorController
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ProfessorController(IMediator mediator)
    {
        this.mediator = mediator;
    }


}
