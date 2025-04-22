using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubTrackr.Domain.Entities;
using SubTrackr.Infrastructure.Data;

namespace SubTrackr.API.Endpoints;

public static class SubscriptionEndpoints
{
    public static RouteGroupBuilder MapSubscriptionsEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (HttpContext http, AppDbContext db) =>
        {
            var userId = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return Results.Unauthorized();
            }

            var subscriptions = await db.Subscriptions
                .Where(s => s.UserId == userId)
                .ToListAsync();

            return Results.Ok(subscriptions);
        });

        group.MapPost("/", async ([FromBody] Subscription model, HttpContext http, AppDbContext db) =>
        {
            var userId = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return Results.Unauthorized();

            model.UserId = userId;
            db.Subscriptions.Add(model);
            await db.SaveChangesAsync();

            return Results.Created($"/api/subscriptions/{model.Id}", model);
        });

        group.MapPut("/{id}", async (int id, [FromBody] Subscription input, HttpContext http, AppDbContext db) =>
        {
            var userId = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return Results.Unauthorized();

            var sub = await db.Subscriptions.FindAsync(id);
            if (sub is null || sub.UserId != userId) 
                return Results.NotFound();

            sub.Name = input.Name;
            sub.Price = input.Price;
            sub.BillingCycle = input.BillingCycle;
            sub.NextBillingDate = input.NextBillingDate;

            await db.SaveChangesAsync();
            return Results.Ok(sub);
        });

        group.MapDelete("/{id}", async (int id, HttpContext http, AppDbContext db) =>
        {
            var userId = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null) 
                return Results.Unauthorized();

            var sub = await db.Subscriptions.FindAsync(id);
            if (sub is null || sub.UserId != userId) 
                return Results.NotFound();

            db.Subscriptions.Remove(sub);
            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}
