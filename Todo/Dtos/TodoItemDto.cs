using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Dtos
{
    public class TodoItemDto
    {
        public TodoItemDto() {}
        public TodoItemDto(TodoItem todoItem)
        {
            Name = todoItem.Name;
            Description = todoItem.Description;
            IsComplete = todoItem.IsComplete;
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }
    }
}
