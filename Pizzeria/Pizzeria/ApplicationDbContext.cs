﻿using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
    }
}