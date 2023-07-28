using Microsoft.EntityFrameworkCore;
using Shared;

namespace StudentAPI.Data
{
    public class MyStudentDbContext : DbContext
    {
        public MyStudentDbContext(DbContextOptions<MyStudentDbContext> options) : base(options)
        {
            
        }

        // tao cac dbset
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                MaSV = "PH12345",
                Ten = "Nguyen Van A",
                lop = "SD12345"
            }
            );
        }
    }
}
