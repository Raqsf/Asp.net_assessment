using HPEL_Assessment.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HPEL_Assessment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Claims> Claims { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Owners> Owners { get; set; }
    }
}
