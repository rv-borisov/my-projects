using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CalculatorApp.Models
{
    public class OperationContext : DbContext
    {
        public DbSet<CalcOperations> CalcOperations { get; set; }
        public OperationContext(DbContextOptions<OperationContext> options)
            : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
