using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventManagment.DataAccess;

public static class InitialiserExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        // Initialization database process when app start on dev
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<DbContextInitializer>();

        await initialiser.InitializeAsync();
    }
}

public class DbContextInitializer
{
    private readonly EventManagmentDbContext _context;

    public DbContextInitializer(EventManagmentDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            // create the database if it doesn't already exist, apply any pending migrations and apply seed data
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while initialising the database. Error: {ex.Message}");
            throw;
        }
    }
}
