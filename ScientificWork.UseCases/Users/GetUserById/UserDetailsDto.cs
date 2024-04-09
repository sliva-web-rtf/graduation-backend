namespace ScientificWork.UseCases.Users.GetUserById;

/// <summary>
/// User details.
/// </summary>
public class UserDetailsDto
{
    /// <summary>
    /// User identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// First name.
    /// </summary>
    required public string? FirstName { get; set; }

    /// <summary>
    /// Last name.
    /// </summary>
    required public string? LastName { get; set; }

    /// <summary>
    /// User email.
    /// </summary>
    required public string Email { get; set; }

    /// <summary>
    /// User role.
    /// </summary>
    required public IList<string> Roles { get; set; }

    required public bool IsRegistrationComplete { get; set; }

    /// <summary>
    /// Last login date time.
    /// </summary>
    public DateTime LastLogin { get; set; }
}
