using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Service;

namespace CarService.Service
{
    public class CarServiceContext : IdentityDbContext<User>
    {
        public CarServiceContext(DbContextOptions<CarServiceContext> options) : base(options)
        {

        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationType> ReservationTypes { get; set; }
        public DbSet<Worksheet> Worksheets { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<WorksheetMaterial> WorksheetMaterials { get; set; }
        public DbSet<User> User { get; set; }
    }
}
