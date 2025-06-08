using Microsoft.EntityFrameworkCore;
using Todo.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("TodoContext")));


        
var app = builder.Build();




app.MapGet("/", () => "Hello World!");

app.Run();
