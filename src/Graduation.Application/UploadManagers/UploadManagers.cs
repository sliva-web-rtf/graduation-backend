using MediatR;
using Microsoft.AspNetCore.Http;

namespace Graduation.Application.UploadManagers;

public record UploadManagersCommand(IFormFile File) : IRequest;