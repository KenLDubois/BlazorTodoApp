using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public enum Priority
    {
        Low,
        Normal,
        High,
        Urgent
    }

    public class Todo
    {
        public string Text { get; set; }
        public bool Completed { get; set; } = false;
        public Priority Priority { get; set; } = Priority.Normal;
        public Todo Next { get; set; }

        public Todo(){}

        public Todo(string text)
        {
            Text = text;
        }

        public Todo(string text, Priority priority)
        {
            Text = text;
            Priority = priority;
        }
        

    }
}
