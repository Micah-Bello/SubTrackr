using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubTrackr.Domain.Entities;

namespace SubTrackr.Infrastructure.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base (options)
    {
    }

    public DbSet<Subscription> Subscriptions => Set<Subscription>();
}