namespace QuanLySinhVien.UI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblDiem = new Label();
            txtDiem = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnTaiLai = new Button();
            btnLoc = new Button();
            dgvSinhVien = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            lblTrangThai = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(620, 35);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ SINH VIÊN - EF CORE (CRUD ĐẦY ĐỦ)";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.Location = new Point(35, 68);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 19);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(95, 65);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(270, 25);
            txtHoTen.TabIndex = 2;
            // 
            // lblDiem
            // 
            lblDiem.AutoSize = true;
            lblDiem.Font = new Font("Segoe UI", 10F);
            lblDiem.Location = new Point(385, 68);
            lblDiem.Name = "lblDiem";
            lblDiem.Size = new Size(44, 19);
            lblDiem.TabIndex = 3;
            lblDiem.Text = "Điểm:";
            // 
            // txtDiem
            // 
            txtDiem.Font = new Font("Segoe UI", 10F);
            txtDiem.Location = new Point(435, 65);
            txtDiem.Name = "txtDiem";
            txtDiem.Size = new Size(185, 25);
            txtDiem.TabIndex = 4;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.WhiteSmoke;
            btnThem.Font = new Font("Segoe UI", 9.5F);
            btnThem.Location = new Point(35, 110);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 34);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.WhiteSmoke;
            btnSua.Font = new Font("Segoe UI", 9.5F);
            btnSua.Location = new Point(132, 110);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(88, 34);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.WhiteSmoke;
            btnXoa.Font = new Font("Segoe UI", 9.5F);
            btnXoa.Location = new Point(229, 110);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(88, 34);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.BackColor = Color.WhiteSmoke;
            btnTaiLai.Font = new Font("Segoe UI", 9.5F);
            btnTaiLai.Location = new Point(326, 110);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(140, 34);
            btnTaiLai.TabIndex = 8;
            btnTaiLai.Text = "Tải lại danh sách";
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.WhiteSmoke;
            btnLoc.Font = new Font("Segoe UI", 9.5F);
            btnLoc.Location = new Point(475, 110);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(145, 34);
            btnLoc.TabIndex = 9;
            btnLoc.Text = "Lọc SV đạt";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = SystemColors.Window;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colId, colFullName, colGrade });
            dgvSinhVien.Location = new Point(35, 158);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersWidth = 35;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(585, 230);
            dgvSinhVien.TabIndex = 10;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.FillWeight = 50F;
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 160F;
            colFullName.HeaderText = "FullName";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colGrade
            // 
            colGrade.DataPropertyName = "Grade";
            colGrade.FillWeight = 70F;
            colGrade.HeaderText = "Grade";
            colGrade.Name = "colGrade";
            colGrade.ReadOnly = true;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 10F);
            lblTrangThai.ForeColor = Color.Green;
            lblTrangThai.Location = new Point(35, 400);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(204, 19);
            lblTrangThai.TabIndex = 11;
            lblTrangThai.Text = "Tìm thấy 3 sinh viên đạt (>= 5).";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 440);
            Controls.Add(lblTrangThai);
            Controls.Add(dgvSinhVien);
            Controls.Add(btnLoc);
            Controls.Add(btnTaiLai);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtDiem);
            Controls.Add(lblDiem);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sinh viên - EF Core CRUD";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblDiem;
        private TextBox txtDiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnTaiLai;
        private Button btnLoc;
        private DataGridView dgvSinhVien;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colGrade;
        private Label lblTrangThai;
    }
}
