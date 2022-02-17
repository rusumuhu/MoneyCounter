using Microsoft.EntityFrameworkCore;
using RubicTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubicTest.Contexts
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Notes { get; set; }
    }
}
