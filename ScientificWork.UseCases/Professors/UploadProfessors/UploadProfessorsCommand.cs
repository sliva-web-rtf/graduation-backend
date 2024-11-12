using MediatR;
using Microsoft.AspNetCore.Http;

namespace ScientificWork.UseCases.Professors.UploadProfessors;

public record UploadProfessorsCommand(IFormFile File) : IRequest;
