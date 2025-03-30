using MediatR;
using Microsoft.AspNetCore.Http;

namespace Graduation.Application.UploadTopics;

public record UploadTopicsCommand(IFormFile File) : IRequest;