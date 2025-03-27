using MediatR;
using Microsoft.AspNetCore.Http;

namespace Graduation.Application.UploadStudents;

public record UploadStudentsCommand(IFormFile File) : IRequest;