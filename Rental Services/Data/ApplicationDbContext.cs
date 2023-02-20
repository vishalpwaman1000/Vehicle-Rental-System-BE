using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<AuthDetails> AuthDetails { get; set; } // 

        public DbSet<VehicleDetails> VehicleDetails { get; set; }

        public DbSet<BookingDetails> BookingDetails { get; set; }

    }
}
