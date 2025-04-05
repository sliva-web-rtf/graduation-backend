namespace Graduation.Application.Students.GetStudents;

public record GetStudentsQueryResult(IList<GetStudentsQueryStudent> Students, int PagesCount);

public record GetStudentsQueryStudent(
    Guid Id,
    string FullName,
    string? AcademicGroup,
    string? AcademicProgram,
    string? About);