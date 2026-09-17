using Microsoft.EntityFrameworkCore;
using StoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
