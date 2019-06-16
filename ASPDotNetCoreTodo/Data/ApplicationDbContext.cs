using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPDotNetCoreTodo.Models;

namespace ASPDotNetCoreTodo.Data
{
    // Lo que habia antes
    //public class ApplicationDbContext : IdentityDbContext 
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // --> modificación
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TodoItem> Items { get; set; }
        // ...
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // ...
        }
    }
}