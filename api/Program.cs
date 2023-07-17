using api.Interfaces;
using api.Repositories;
using api.Db;
using api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<MariaDbContext>();

builder.Services.AddTransient<IUserRepository, UserRepository>();

var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
builder.Services.AddSingleton(jwtOptions);

JwtRepository.ConfigureAuth(builder, jwtOptions);
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseItToSeedMariaDb();    //custom extension method to seed the DB
    //configure other services
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
