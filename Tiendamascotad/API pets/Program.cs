using API_pets.Models;
using Azure.Core;
using Microsoft.AspNetCore.Identity.Data;
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
app.MapGet("/request/user/{id}", async (int id, zozo_context context) =>
{
    var solicitudes = await context.adoption_request
        .Where(r => r.id_user == id)
        .ToListAsync();

    return Results.Ok(solicitudes);
});
app.MapGet("/users/{id}", async (int id ,zozo_context context) =>
{
    var user = await context.users.FindAsync(id);
    if (user == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(user);
});

app.MapGet("/pets", async (zozo_context context) =>
{
    return await context.pets.ToListAsync();
});

app.MapGet("/request", async (zozo_context context) =>
{
    return await context.adoption_request.ToListAsync();
});



app.MapGet("/pets/{id}", async (int id, zozo_context context) =>
{
    var mascota = await context.pets.FindAsync(id);

    if (mascota == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(mascota);
});
app.MapPut("/request/{id}", async (int id, Request_adoption datos, zozo_context context) =>
{
    var solicitud = await context.adoption_request.FindAsync(id);

    if (solicitud == null)
    {
        return Results.NotFound();
    }

    solicitud.adoption_state = datos.adoption_state;

    await context.SaveChangesAsync();

    return Results.Ok(solicitud);
});
//repasar a profundidad esto
app.MapPost("/users/registrar", async (User nuevoUsuario, zozo_context context) =>
{
    Console.WriteLine("LLEGÓ EL REGISTRO");

    var existe = await context.users
        .AnyAsync(u => u.id_user == nuevoUsuario.id_user);

    if (existe)
    {
        return Results.BadRequest("El usuario ya existe");
    }

    context.users.Add(nuevoUsuario);
    await context.SaveChangesAsync();

    return Results.Ok(nuevoUsuario);

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
app.MapPost("/login", async (Ayudalogin login, zozo_context context) =>
{
    var usuario = await context.users
        .FirstOrDefaultAsync(u => u.email == login.email);

    if (usuario == null || usuario.password != login.password)
        return Results.BadRequest("Email o contraseña incorrectos");

    return Results.Ok(usuario);
});

//app.MapPost("/login", async (string email, string password, zozo_context context) =>
//{
//    var usuario = await context.users
//        .FirstOrDefaultAsync(u => u.email == email);

//    if (usuario == null)
//    {
//        return Results.NotFound("you are not registered");
//    }

//    if (usuario.password != password)
//    {
//        return Results.BadRequest("wrong password");
//    }

//    return Results.Ok("succefull login");
//});


app.MapPost("/request", async (Request_adoption request, zozo_context context) =>
{
    context.adoption_request.Add(request);
    await context.SaveChangesAsync();

    return request;
});
//estudiar la diferencia de patch y put


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
