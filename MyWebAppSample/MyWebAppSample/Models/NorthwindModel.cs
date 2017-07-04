using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAppSample.Models
{
    public class NorthwindModel : DbContext
    {
        public NorthwindModel(DbContextOptions<NorthwindModel> options)
            : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);
        public DbSet<Customer> Customers { get; set; }
    }
}
