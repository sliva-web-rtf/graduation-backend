namespace Graduation.Application.Supervisors.GetSupervisor;

public record GetSupervisorQueryResult(
    string FullName,
    string? Contacts,
    string? About,
    int Limit,
    int Fullness);