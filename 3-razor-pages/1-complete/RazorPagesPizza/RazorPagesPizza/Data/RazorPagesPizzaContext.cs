using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesPizza.Models;

namespace RazorPagesPizza.Data
{
    public class RazorPagesPizzaContext : DbContext
    {
        public RazorPagesPizzaContext (DbContextOptions<RazorPagesPizzaContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesPizza.Models.Pizza> Pizza { get; set; } = default!;
    }
}
