using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.Domain.Requests.Enums;

namespace ScientificWork.UseCases.Requests.RespondRequest;

public class RespondRequestCommand : IRequest
{
    /// <summary>
    /// Request id.
    /// </summary>
    [Required]
    required public Guid RequestId { get; init; }

    /// <summary>
    /// Respond enum (Agree, Disagree).
    /// </summary>
    required public RespondEnum RespondEnum { get; init; }
}
