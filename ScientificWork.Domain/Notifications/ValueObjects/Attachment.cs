using ScientificWork.Domain.Common;

namespace ScientificWork.Domain.Notifications.ValueObjects;

public sealed class Attachment : ValueObject
{
    public string AgreeLink { get; private set; }

    public string DisagreeLink { get; private set; }

    private Attachment(string agreeLink, string disagreeLink)
    {
        AgreeLink = agreeLink;
        DisagreeLink = disagreeLink;
    }

    public static Attachment Create(string agreeLink, string disagreeLink)
    {
        if (agreeLink is null)
        {
            throw new ArgumentNullException(nameof(agreeLink));
        }

        if (disagreeLink is null)
        {
            throw new ArgumentNullException(nameof(disagreeLink));
        }

        return new Attachment(agreeLink, disagreeLink);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return AgreeLink;
        yield return DisagreeLink;
    }
}
