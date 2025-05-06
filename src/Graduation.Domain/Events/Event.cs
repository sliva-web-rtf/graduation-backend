using System.ComponentModel.DataAnnotations.Schema;
using Graduation.Domain.Common;

namespace Graduation.Domain.Events;

public class Event : Entity<Guid>
{
    private Event(Guid id) : base(id)
    {
    }

    private Event()
    {
    }

    public string? Path { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public string? Message { get; set; }

    [Column(TypeName = "jsonb")]
    public object? Data { get; set; }

    public string? Exception { get; set; }

    public static Event Create(Guid userId, string? path, string? message, object? data, string? exception = null)
    {
        return new Event(Guid.NewGuid())
        {
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Path = path,
            Message = message,
            Data = data,
            Exception = exception
        };
    }
}