using API_pets.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<zozo_context>();
builder.Services.AddDbContext<zozo_context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("miconexion")));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapGet("/users", async (zozo_context context) =>
{
    return await context.users.ToListAsync();
});

app.MapGet("/pets", async (zozo_context context) =>
{
    return await context.pets.ToListAsync();
});

app.MapGet("/request", async (zozo_context context) =>
{
    return await context.request_Adoptions.ToListAsync();
});





//repasar a profundidad esto
app.MapPost("/users", async (User nuevoUsuario, zozo_context context) =>
{
    context.users.Add(nuevoUsuario);
    await context.SaveChangesAsync();

    return nuevoUsuario;
});
app.MapDelete("/users/{id}", async (int id, zozo_context context) =>
{
    var usuario = await context.users.FindAsync(id);

    if (usuario == null)
    {
        return Results.NotFound();
    }

    context.users.Remove(usuario);
    await context.SaveChangesAsync();

    return Results.Ok();
});
//repasar a profundidad esto
app.MapPost("/pets", async (Pet newpet, zozo_context context) =>
{
    context.pets.Add(newpet);
    await context.SaveChangesAsync();

    return newpet;
});
app.MapDelete("/pets/{id}", async (int id, zozo_context context) =>
{
    var pet = await context.pets.FindAsync(id);

    if (pet == null)
    {
        return Results.NotFound();
    }

    context.pets.Remove(pet);
    await context.SaveChangesAsync();

    return Results.Ok();
});


app.MapPost("/request", async (Request_adoption request, zozo_context context) =>
{
    context.request_Adoptions.Add(request);
    await context.SaveChangesAsync();

    return request;
});

app.MapPatch("/users/{id}", async (int id, User datos, zozo_context context) =>
{
    var usuario = await context.users.FindAsync(id);

    if (usuario == null)
    {
        return Results.NotFound();
    }

    if (datos.firstname != null)
    {
        usuario.firstname = datos.firstname;
    }

    if (datos.phone != null)
    {
        usuario.phone = datos.phone;
    }

    if (datos.email != null)
    {
        usuario.email = datos.email;
    }

    await context.SaveChangesAsync();

    return Results.Ok(usuario);
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
