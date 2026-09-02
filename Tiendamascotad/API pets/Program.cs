using API_pets.Models;
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
    return await context.request_Adoptions.ToListAsync();
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

//repasar a profundidad esto
app.MapPost("/users/registrar", async (User nuevoUsuario, zozo_context context) =>
{
    context.users.Add(nuevoUsuario);
    await context.SaveChangesAsync();

    
    return Results.Ok("User registered successfully");
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


//repasar a profundidad esto
app.MapPost("/pets/registrar", async (Pet newpet, zozo_context context) =>
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

app.MapPut("pets/actualizar", async (int id, Pet datos, zozo_context context) =>
{
    context.pets.Update(datos);
    await context.SaveChangesAsync();

    return context;
});
app.MapPost("/request", async (Request_adoption request, zozo_context context) =>
{
    context.request_Adoptions.Add(request);
    await context.SaveChangesAsync();

    return request;
});
//estudiar la diferencia de patch y put
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
