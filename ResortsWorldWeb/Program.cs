using Microsoft.EntityFrameworkCore;
using ResortsWorldWeb.Model;
using ResortsWorldWeb.Model.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/ping", async (context) =>
{
    await context.Response.WriteAsync("pong");
});

//CRUD
app.MapGet("/all", async (HttpContext context, ApplicationDbContext db) =>
{
    //await context.Response.WriteAsJsonAsync(db.EntityResports.ToListAsync());

    return await db.EntityResports.ToListAsync();
});

app.MapPost("/add", async (HttpContext context, ApplicationDbContext db) =>
{
    var entityResport = await context.Request.ReadFromJsonAsync<EntityResport>();

    if(entityResport != null)
    {
        db.EntityResports.Add(entityResport);
        db.SaveChanges();
    }
    return entityResport;
});

app.Run();
