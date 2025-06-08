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
todoItems.MapDelete("/{id}", DeleteTodo);



app.Run();


static async Task<IResult> GetAllTodos(TodoContext db)
{
    return TypedResults.Ok(await db.TodoItems.ToArrayAsync());
}


static async Task<IResult> DeleteTodo(int id, TodoContext db)
{
    if (await db.TodoItems.FindAsync(id) is TodoItem todo)
    {
        db.TodoItems.Remove(todo);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}
