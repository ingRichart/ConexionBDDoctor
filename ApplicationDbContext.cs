using CRUD_Students2.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Students2
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}