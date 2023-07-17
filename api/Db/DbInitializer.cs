using api.Db;
using api.Seeds;

internal class DbInitializer
{
    internal static void Initialize(MariaDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        dbContext.Database.EnsureCreated();
        Console.WriteLine(dbContext.Users.Any());
        if (dbContext.Users.Any()) return;

        new UsersSeeds(dbContext);
    }
}