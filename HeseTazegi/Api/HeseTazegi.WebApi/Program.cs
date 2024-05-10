using HeseTazegi.Database;
using HeseTazegi.Read.Context.Models;
using HeseTazegi.WebApi.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder);

var app = builder.Build();

if (app.Environment.EnvironmentName == "Development")
{
    using (var scope = app.Services.CreateAsyncScope())
    {
        var write = scope.ServiceProvider.GetRequiredService<HeseTazegiDbContext>();
        var read = scope.ServiceProvider.GetRequiredService<HeseTazegiReadContext>();
        await write.Database.MigrateAsync();
        var seed = new DataSeeder(read);
        await seed.SeedDataAsync();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
