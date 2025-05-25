using Pedfast.Features.Status;

namespace Pedfast.Features.Extensions;

public static class RouteExtensions
{
    public static void MapAllRoutes(this WebApplication app)
    {
        app.MapStatusRoutes();
    }
}
