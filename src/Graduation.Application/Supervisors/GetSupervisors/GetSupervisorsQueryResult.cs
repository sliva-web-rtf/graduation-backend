namespace Graduation.Application.Supervisors.GetSupervisors;

public record GetSupervisorsQueryResult(IList<GetSupervisorsQuerySupervisor> Professors, int PagesCount);

public record GetSupervisorsQuerySupervisor(
    Guid Id,
    string FullName,
    string? About,
    int Limit,
    int Fullness);