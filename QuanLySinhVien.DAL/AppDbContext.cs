using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Entities;

namespace QuanLySinhVien.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Sử dụng CSDL QuanLySinhVien có sẵn trên máy
                // (Mặc định dùng LocalDB của Visual Studio hoặc bạn có thể đổi sang BAONGUYEN\BAONGUYEN1 nếu dùng SQL Server riêng)
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuanLySinhVien;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
