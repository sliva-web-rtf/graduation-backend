using MediatR;
using Microsoft.AspNetCore.Http;

namespace Graduation.Application.UploadReinstatedStudents;

public record UploadReinstatedStudentsCommand(IFormFile File) : IRequest;