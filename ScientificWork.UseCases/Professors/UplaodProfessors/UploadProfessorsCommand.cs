using MediatR;
using Microsoft.AspNetCore.Http;

namespace ScientificWork.UseCases.Professors.UplaodProfessors;

public record UploadProfessorsCommand(IFormFile File) : IRequest;
