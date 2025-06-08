using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Todo.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoContext>>()))
            {
                // Look for any movies.
                if (context.TodoItems.Any())
                {
                    return;   // DB has been seeded
                }
                context.TodoItems.AddRange(
                    new TodoItem
                    {
                        Name = "Code a new game",
                        Description = "Code a new racing game using c#",
                        IsComplete = false
                    },
                    new TodoItem
                    {
                        Name = "Paint",
                        Description = "Paint a new painting with oil and canvas",
                        IsComplete = false
                    },
                    new TodoItem
                    {
                        Name = "Eat",
                        Description = "Eat a new food item",
                        IsComplete = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
