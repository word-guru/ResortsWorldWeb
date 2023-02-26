using Microsoft.AspNetCore.Mvc;
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
/*app.MapGet("/all", async (HttpContext context, ApplicationDbContext db) =>
{
    //await context.Response.WriteAsJsonAsync(db.EntityResports.ToListAsync());

    return await db.Resports.ToListAsync();
});

app.MapPost("/add", async (HttpContext context, ApplicationDbContext db) =>
{
    var entityResport = await context.Request.ReadFromJsonAsync<Resport>();

    if(entityResport != null)
    {
        db.Resports.Add(entityResport);
        db.SaveChanges();
    }
    return entityResport;
});*/

//                                 -=== Resport ===-

app.MapGet("/get_resports", async (
    HttpContext context,
    ApplicationDbContext db
    ) => await db.Resports.ToListAsync());

app.MapGet("/get_resport", async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id
    ) => await db.Resports.FirstOrDefaultAsync(p => p.Id == id));


app.MapPost("/add_resport", async (
    HttpContext context,
    ApplicationDbContext db) =>
    {
        var resport = await context.Request.ReadFromJsonAsync<Resport>();
        
        if (resport != null)
        {
            db.Resports.Add(resport);
            db.SaveChanges();
        }
        return resport!.ToString();
    });

app.MapPost("/delete_resport",async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id) =>
    {
        var current = await db.Resports.FindAsync(id);
        db.Resports.Remove(current!);
        await db.SaveChangesAsync();
    });

app.MapPost("/update_resport",async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id, string description,string name, float raiting,int countriesId) =>
    {
        var update = await db.Resports.FindAsync(id);
        update!.Description = description;
        update!.Name = name;
        update!.Rating = raiting;
        update!.CountriesId = countriesId;

        await db.SaveChangesAsync();
    });

//                                 -=== COUNTRY ===-

app.MapGet("/get_coutries", async (
    HttpContext context,
    ApplicationDbContext db
    ) => await db.Countries.ToListAsync());

app.MapGet("/get_country", async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id
    ) => await db.Countries.FirstOrDefaultAsync(p => p.Id == id));


app.MapPost("/add_country", async (
    HttpContext context,
    ApplicationDbContext db) =>
{
    var country = await context.Request.ReadFromJsonAsync<Country>();

    if (country != null)
    {
        db.Countries.Add(country);
        db.SaveChanges();
    }
    return country!.ToString();
});

app.MapPost("/delete_country", async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id) =>
{
    var current = await db.Countries.FindAsync(id);
    db.Countries.Remove(current!);
    await db.SaveChangesAsync();
});

app.MapPost("/update_country", async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id, string name, int partOfTheWorldId) =>
{
    var update = await db.Countries.FindAsync(id);
    update!.Name = name;
    update!.PartOfTheWorldId = partOfTheWorldId;

    await db.SaveChangesAsync();
});

//                                 -=== PART OF THE WORLD ===-

app.MapGet("/get_partsworld", async (
    HttpContext context,
    ApplicationDbContext db
    ) => await db.PartOfTheWorlds.ToListAsync());

app.MapGet("/get_partworld", async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id
    ) => await db.PartOfTheWorlds.FirstOrDefaultAsync(p => p.Id == id));

app.MapPost("/add_partworld", async (
    HttpContext context,
    ApplicationDbContext db) =>
{
    var partOfTheWorld = await context.Request.ReadFromJsonAsync<PartOfTheWorld>();

    if (partOfTheWorld != null)
    {
        db.PartOfTheWorlds.Add(partOfTheWorld);
        db.SaveChanges();
    }
    return partOfTheWorld!.ToString();
});

app.MapPost("/delete_partworld", async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id) =>
{
    var current = await db.PartOfTheWorlds.FindAsync(id);
    db.PartOfTheWorlds.Remove(current!);
    await db.SaveChangesAsync();
});

app.MapPost("/update_partworld", async (
    [FromServices] ApplicationDbContext db,
    [FromQuery] int id, string name) =>
{
    var update = await db.PartOfTheWorlds.FindAsync(id);
    update!.Name = name;

    await db.SaveChangesAsync();
});


app.Run();
