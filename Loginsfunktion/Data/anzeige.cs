using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loginsfunktion.Models;
using Microsoft.EntityFrameworkCore;

namespace Loginsfunktion.Data
{
    internal class anzeige : DbContext
    {
        public DbSet<Login> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MININT-SMH5KTQ\SQLEXPRESS03;Database=MyDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
          
        }
    }
}
  