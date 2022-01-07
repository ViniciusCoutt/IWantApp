using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints;

public static class ProblemDetailsExtenxions
{
    public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
                 .GroupBy(g => g.Key)
                 .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
    }

    public static Dictionary<string, string[]> ConvertToProblemDetails(this IEnumerable<IdentityError> notifications)
    {
        return notifications
                 .GroupBy(g => g.Code)
                 .ToDictionary(g => g.Key, g => g.Select(x => x.Description).ToArray());
    }
}
