using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.ScientificAreas.GetScientificAreas;

/// <summary>
/// Get scientific query.
/// </summary>
public class GetScientificAreasQuery : IRequest<ICollection<ScientificAreasDto>>
{
}
