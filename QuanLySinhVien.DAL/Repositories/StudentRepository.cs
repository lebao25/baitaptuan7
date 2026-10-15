using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Entities;

namespace QuanLySinhVien.DAL.Repositories
{
    public class StudentRepository
    {
        public async Task<List<Student>> LayDanhSachAsync()
        {
            using (var context = new AppDbContext())
            {
                return await context.Students.AsNoTracking().ToListAsync();
            }
        }

        public async Task<Student?> TimTheoIdAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                return await context.Students.FindAsync(id);
            }
        }

        public async Task ThemAsync(Student sv)
        {
            using (var context = new AppDbContext())
            {
                context.Students.Add(sv);
                await context.SaveChangesAsync();
            }
        }

        public async Task SuaAsync(Student sv)
        {
            using (var context = new AppDbContext())
            {
                var existing = await context.Students.FindAsync(sv.Id);
                if (existing != null)
                {
                    existing.FullName = sv.FullName;
                    existing.Grade = sv.Grade;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task XoaAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                var sv = await context.Students.FindAsync(id);
                if (sv != null)
                {
                    context.Students.Remove(sv);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Student>> LocSinhVienDatAsync(double diemChuan = 5.0)
        {
            using (var context = new AppDbContext())
            {
                return await context.Students
                    .AsNoTracking()
                    .Where(s => s.Grade >= diemChuan)
                    .ToListAsync();
            }
        }
    }
}
