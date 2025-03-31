using MediatR;
using Microsoft.AspNetCore.Http;

namespace Graduation.Application.UploadSecretaries;

public record UploadSecretariesCommand(IFormFile File) : IRequest;