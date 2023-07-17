using api.Db;

internal static class DbInitializerExtension
{
    public static IApplicationBuilder UseItToSeedMariaDb(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<MariaDbContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return app;
    }
}