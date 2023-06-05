using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using ToDoList.Models;

namespace ToDoList
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext() { }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<ListItem> ListItems { get; set; }
    }
}
