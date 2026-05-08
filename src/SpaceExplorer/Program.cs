using SpaceExplorer;
using SpaceExplorer.Models;
using SpaceExplorer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CosmosService>();

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    name = "🚀 Space Explorer API",
    version = "1.0.0",
    endpoints = new[] { "/planets", "/missions", "/astronauts", "/health", "/seed" }
}));

app.MapGet("/health", () => Results.Ok(new { status = "healthy", utc = DateTime.UtcNow }));

// --- Planets ---
app.MapGet("/planets", async (CosmosService cosmos) =>
{
    var planets = await cosmos.GetAllAsync<Planet>("planets");
    return Results.Ok(planets);
});

app.MapGet("/planets/{id}", async (string id, CosmosService cosmos) =>
{
    var planet = await cosmos.GetByIdAsync<Planet>("planets", id, "rocky")
              ?? await cosmos.GetByIdAsync<Planet>("planets", id, "gas-giant")
              ?? await cosmos.GetByIdAsync<Planet>("planets", id, "ice-giant");

    return planet is not null ? Results.Ok(planet) : Results.NotFound(new { message = $"Planet '{id}' not found." });
});

// --- Missions ---
app.MapGet("/missions", async (CosmosService cosmos) =>
{
    var missions = await cosmos.GetAllAsync<Mission>("missions");
    return Results.Ok(missions);
});

app.MapGet("/missions/{id}", async (string id, string agency, CosmosService cosmos) =>
{
    var mission = await cosmos.GetByIdAsync<Mission>("missions", id, agency);
    return mission is not null ? Results.Ok(mission) : Results.NotFound(new { message = $"Mission '{id}' not found." });
});

// --- Astronauts ---
app.MapGet("/astronauts", async (CosmosService cosmos) =>
{
    var astronauts = await cosmos.GetAllAsync<Astronaut>("astronauts");
    return Results.Ok(astronauts);
});

app.MapGet("/astronauts/{id}", async (string id, string nationality, CosmosService cosmos) =>
{
    var astronaut = await cosmos.GetByIdAsync<Astronaut>("astronauts", id, nationality);
    return astronaut is not null ? Results.Ok(astronaut) : Results.NotFound(new { message = $"Astronaut '{id}' not found." });
});

// --- Seed ---
app.MapPost("/seed", async (CosmosService cosmos) =>
{
    var alreadySeeded = !(await cosmos.IsDatabaseEmptyAsync("planets"));
    if (alreadySeeded)
        return Results.Conflict(new { message = "Data already seeded. Use POST /seed/force to re-seed." });

    await SeedData.RunAsync(cosmos);
    return Results.Ok(new { message = "🌌 Universe seeded successfully!", items = SeedData.Summary });
});

app.MapPost("/seed/force", async (CosmosService cosmos) =>
{
    await SeedData.RunAsync(cosmos);
    return Results.Ok(new { message = "🌌 Universe re-seeded successfully!", items = SeedData.Summary });
});

app.Run();
