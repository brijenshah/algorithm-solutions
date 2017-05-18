using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class ToDoItemContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoItemContext() : base("name=ToDoContext")
        {
            
        }
    }
}