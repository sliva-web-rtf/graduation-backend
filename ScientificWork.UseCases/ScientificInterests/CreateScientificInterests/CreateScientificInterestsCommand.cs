using MediatR;
using Microsoft.AspNetCore.Http;

namespace ScientificWork.UseCases.ScientificInterests.CreateScientificInterests;

public class CreateScientificInterestsCommand : IRequest
{
    /// <summary>
    /// Excel file.
    /// </summary>
    required public IFormFile File { get; init; }
}
