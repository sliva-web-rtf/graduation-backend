using MediatR;
using Microsoft.AspNetCore.Http;

namespace Graduation.Application.UploadExperts;

public record UploadExpertsCommand(IFormFile File) : IRequest;