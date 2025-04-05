namespace Graduation.Application.Students.GetStudent;

public record GetStudentQueryResult(
    string FullName,
    string? AcademicGroup,
    string? AcademicProgram,
    string? Contacts,
    string? About);