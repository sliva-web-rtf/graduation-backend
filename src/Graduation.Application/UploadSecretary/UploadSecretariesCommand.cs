using MediatR;
using Microsoft.AspNetCore.Http;

namespace Graduation.Application.UploadSecretary;

public record UploadSecretariesCommand(IFormFile File) : IRequest;