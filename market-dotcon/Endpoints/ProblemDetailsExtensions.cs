using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;

namespace market_dotcon.Endpoints;

public static class ProblemDetailsExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
            .GroupBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Message)
            .ToArray());
    }

    public static Dictionary<string, string[]> ConvertToProblemDetails(this IEnumerable<IdentityError> error)
    {
        return error
            .GroupBy(e => e.Code)
            .ToDictionary(e => e.Key, e => e.Select(x => x.Description)
            .ToArray());
    }
}
