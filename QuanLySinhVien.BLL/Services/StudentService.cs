using QuanLySinhVien.DAL.Entities;
using QuanLySinhVien.DAL.Repositories;

namespace QuanLySinhVien.BLL.Services
{
    public class StudentService
    {
        private readonly StudentRepository _repository;

        public StudentService()
        {
            _repository = new StudentRepository();
        }

        public StudentService(StudentRepository repository)
        {
            _repository = repository;
        }

        // Lấy danh sách toàn bộ sinh viên từ CSDL
        public async Task<List<Student>> LayDanhSachAsync()
        {
            return await _repository.LayDanhSachAsync();
        }

        // Tìm sinh viên theo mã Id
        public async Task<Student?> TimTheoIdAsync(int id)
        {
            return await _repository.TimTheoIdAsync(id);
        }

        // Thêm sinh viên từ đối tượng
        public async Task ThemAsync(Student sv)
        {
            if (sv == null)
                throw new ArgumentException("Dữ liệu sinh viên không hợp lệ!");

            KiemTraNghiepVu(sv.FullName, sv.Grade);
            sv.FullName = sv.FullName.Trim();
            await _repository.ThemAsync(sv);
        }

        // Thêm sinh viên từ tham số họ tên và điểm
        public async Task ThemSinhVienAsync(string hoTen, double diem)
        {
            KiemTraNghiepVu(hoTen, diem);
            var sv = new Student { FullName = hoTen.Trim(), Grade = diem };
            await _repository.ThemAsync(sv);
        }

        // Cập nhật thông tin sinh viên
        public async Task SuaAsync(Student sv)
        {
            if (sv == null || sv.Id <= 0)
                throw new ArgumentException("Vui lòng chọn một sinh viên để sửa!");

            KiemTraNghiepVu(sv.FullName, sv.Grade);
            sv.FullName = sv.FullName.Trim();
            await _repository.SuaAsync(sv);
        }

        // Xóa sinh viên
        public async Task XoaAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Vui lòng chọn một sinh viên để xóa!");

            await _repository.XoaAsync(id);
        }

        // Lọc sinh viên đạt (Điểm >= 5.0)
        public async Task<List<Student>> LocSinhVienDatAsync(double diemChuan = 5.0)
        {
            return await _repository.LocSinhVienDatAsync(diemChuan);
        }

        // Kiểm tra hợp lệ dữ liệu sinh viên
        private void KiemTraNghiepVu(string hoTen, double diem)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new ArgumentException("Họ tên sinh viên không được để trống!");

            if (diem < 0 || diem > 10)
                throw new ArgumentException("Điểm số phải từ 0 đến 10!");
        }
    }
}
