using MediatR;
using Microsoft.AspNetCore.Http;

namespace ScientificWork.UseCases.Students.UploadStudents;

public record UploadStudentsCommand(IFormFile File) : IRequest;
