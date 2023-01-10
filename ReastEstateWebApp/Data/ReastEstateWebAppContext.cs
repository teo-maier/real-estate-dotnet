using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReastEstateWebApp.Models;

namespace ReastEstateWebApp.Data
{
    public class ReastEstateWebAppContext : DbContext
    {
        public ReastEstateWebAppContext (DbContextOptions<ReastEstateWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ReastEstateWebApp.Models.Property> Property { get; set; } = default!;

        public DbSet<ReastEstateWebApp.Models.Agent> Agent { get; set; }
    }
}
