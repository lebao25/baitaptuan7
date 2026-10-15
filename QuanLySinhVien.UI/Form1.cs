using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.BLL.Services;
using QuanLySinhVien.DAL.Entities;

namespace QuanLySinhVien.UI
{
    public partial class Form1 : Form
    {
        // Giao tiếp qua tầng BLL theo chuẩn mô hình 3 lớp
        private readonly StudentService _studentService;
        private int _selectedId = 0;

        public Form1()
        {
            InitializeComponent();
            _studentService = new StudentService();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dgvSinhVien.AutoGenerateColumns = false;
            await TaiDanhSach();
        }

        // Tải toàn bộ danh sách sinh viên từ CSDL
        private async Task TaiDanhSach()
        {
            try
            {
                var list = await _studentService.LayDanhSachAsync();
                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = list;

                if (list.Count > 0)
                {
                    // Chọn dòng đầu tiên và điền thông tin lên ô nhập như trên hình mẫu
                    _selectedId = list[0].Id;
                    txtHoTen.Text = list[0].FullName;
                    txtDiem.Text = list[0].Grade.ToString();
                }
                else
                {
                    _selectedId = 0;
                    txtHoTen.Text = string.Empty;
                    txtDiem.Text = string.Empty;
                }

                lblTrangThai.Text = $"Tổng số {list.Count} sinh viên trong cơ sở dữ liệu.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối CSDL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTrangThai.Text = "Không thể kết nối đến cơ sở dữ liệu.";
            }
        }

        // Khi người dùng click chọn dòng trên DataGridView
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSinhVien.Rows.Count) return;

            var dong = dgvSinhVien.Rows[e.RowIndex];
            if (dong.DataBoundItem is Student sv)
            {
                _selectedId = sv.Id;
                txtHoTen.Text = sv.FullName;
                txtDiem.Text = sv.Grade.ToString();
            }
        }

        // Chức năng: Thêm sinh viên
        private async void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            if (!double.TryParse(txtDiem.Text.Trim(), out double diem))
            {
                MessageBox.Show("Điểm phải là một số thực từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }

            try
            {
                await _studentService.ThemSinhVienAsync(hoTen, diem);
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TaiDanhSach();
                lblTrangThai.Text = $"Đã thêm sinh viên \"{hoTen}\" thành công!";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kiểm tra nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng: Sửa thông tin sinh viên
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedId <= 0)
            {
                MessageBox.Show("Vui lòng click chọn một sinh viên trên bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            if (!double.TryParse(txtDiem.Text.Trim(), out double diem))
            {
                MessageBox.Show("Điểm phải là một số thực từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }

            var sv = new Student
            {
                Id = _selectedId,
                FullName = hoTen,
                Grade = diem
            };

            try
            {
                await _studentService.SuaAsync(sv);
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TaiDanhSach();
                lblTrangThai.Text = $"Đã cập nhật sinh viên mã {_selectedId} thành công!";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kiểm tra nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng: Xóa sinh viên
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId <= 0)
            {
                MessageBox.Show("Vui lòng click chọn sinh viên cần xóa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var luaChon = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên \"{txtHoTen.Text}\" (Mã {_selectedId}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (luaChon == DialogResult.Yes)
            {
                try
                {
                    await _studentService.XoaAsync(_selectedId);
                    MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await TaiDanhSach();
                    lblTrangThai.Text = "Đã xóa sinh viên thành công!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Chức năng: Tải lại danh sách
        private async void btnTaiLai_Click(object sender, EventArgs e)
        {
            await TaiDanhSach();
            lblTrangThai.Text = "Đã tải lại toàn bộ danh sách sinh viên.";
        }

        // Chức năng: Lọc SV đạt (Điểm >= 5)
        private async void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                var listDat = await _studentService.LocSinhVienDatAsync(5.0);
                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = listDat;

                // Cập nhật dòng trạng thái màu xanh giống hệt trên hình
                lblTrangThai.Text = $"Tìm thấy {listDat.Count} sinh viên đạt (>= 5).";

                if (listDat.Count > 0)
                {
                    _selectedId = listDat[0].Id;
                    txtHoTen.Text = listDat[0].FullName;
                    txtDiem.Text = listDat[0].Grade.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
