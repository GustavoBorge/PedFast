using Microsoft.EntityFrameworkCore;
using Pedfast.Entities;

namespace Pedfast.Features.Status;

public static class StatusRoute
{
    public static void MapStatusRoutes(this WebApplication app)
    {
        var group = app.MapGroup("/stutus").WithTags("Status");

        group.MapGet("/", async (StatusService service) =>
        {
            var response = await service.GetStatus();

            return Results.Ok(response);
        });
    }
}