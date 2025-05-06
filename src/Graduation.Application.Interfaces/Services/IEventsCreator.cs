namespace Graduation.Application.Interfaces.Services;

public interface IEventsCreator
{
    public Task Create(string message, object? data = null, string? exception = null);
}