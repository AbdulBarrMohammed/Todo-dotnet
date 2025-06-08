using Microsoft.EntityFrameworkCore;
using Todo.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("TodoContext")));



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.UseDefaultFiles();
app.UseStaticFiles();

var todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", GetAllTodos);


app.Run();


static async Task<IResult> GetAllTodos(TodoContext db)
{
    return TypedResults.Ok(await db.TodoItems.ToArrayAsync());
}
