using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspDotnetDemo.Models;

namespace AspDotnetDemo.Data
{
    public class AspDotnetDemoContext : DbContext
    {
        public AspDotnetDemoContext (DbContextOptions<AspDotnetDemoContext> options)
            : base(options)
        {
        }

        public DbSet<AspDotnetDemo.Models.Movie> Movie { get; set; }
    }
}
