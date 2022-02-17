using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RubicTest.Models;

namespace RubicTest.Contexts
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) 
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
