namespace QuanLyCafe
{
    partial class formChucNang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pY_CAFEDataSet = new QuanLyCafe.PY_CAFEDataSet();
            this.pYCAFEDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.btnKiemTraKho = new System.Windows.Forms.Button();
            this.btnKiemTraHoaDon = new System.Windows.Forms.Button();
            this.btnNhapNguyenLieu = new System.Windows.Forms.Button();
            this.btnKhachThanhVien = new System.Windows.Forms.Button();
            this.btnQuanLyNhanVien = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDanhSachSanPham = new System.Windows.Forms.Button();
            this.btnDoanhThu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pY_CAFEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pYCAFEDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pY_CAFEDataSet
            // 
            this.pY_CAFEDataSet.DataSetName = "PY_CAFEDataSet";
            this.pY_CAFEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pYCAFEDataSetBindingSource
            // 
            this.pYCAFEDataSetBindingSource.DataSource = this.pY_CAFEDataSet;
            this.pYCAFEDataSetBindingSource.Position = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label1.Location = new System.Drawing.Point(358, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHỨC NĂNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "chức vụ của bạn là: quản lý";
            // 
            // btnBanHang
            // 
            this.btnBanHang.BackColor = System.Drawing.Color.Linen;
            this.btnBanHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBanHang.Location = new System.Drawing.Point(85, 97);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(167, 74);
            this.btnBanHang.TabIndex = 3;
            this.btnBanHang.Text = "Bán hàng";
            this.btnBanHang.UseVisualStyleBackColor = false;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnKiemTraKho
            // 
            this.btnKiemTraKho.BackColor = System.Drawing.Color.Linen;
            this.btnKiemTraKho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKiemTraKho.Location = new System.Drawing.Point(85, 177);
            this.btnKiemTraKho.Name = "btnKiemTraKho";
            this.btnKiemTraKho.Size = new System.Drawing.Size(167, 74);
            this.btnKiemTraKho.TabIndex = 4;
            this.btnKiemTraKho.Text = "Kiểm tra kho";
            this.btnKiemTraKho.UseVisualStyleBackColor = false;
            this.btnKiemTraKho.Click += new System.EventHandler(this.btnKiemTraKho_Click);
            // 
            // btnKiemTraHoaDon
            // 
            this.btnKiemTraHoaDon.BackColor = System.Drawing.Color.Linen;
            this.btnKiemTraHoaDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKiemTraHoaDon.Location = new System.Drawing.Point(258, 177);
            this.btnKiemTraHoaDon.Name = "btnKiemTraHoaDon";
            this.btnKiemTraHoaDon.Size = new System.Drawing.Size(167, 74);
            this.btnKiemTraHoaDon.TabIndex = 6;
            this.btnKiemTraHoaDon.Text = "Kiểm tra Hóa Đơn";
            this.btnKiemTraHoaDon.UseVisualStyleBackColor = false;
            this.btnKiemTraHoaDon.Click += new System.EventHandler(this.btnKiemTraHoaDon_Click);
            // 
            // btnNhapNguyenLieu
            // 
            this.btnNhapNguyenLieu.BackColor = System.Drawing.Color.Linen;
            this.btnNhapNguyenLieu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNhapNguyenLieu.Location = new System.Drawing.Point(258, 97);
            this.btnNhapNguyenLieu.Name = "btnNhapNguyenLieu";
            this.btnNhapNguyenLieu.Size = new System.Drawing.Size(167, 74);
            this.btnNhapNguyenLieu.TabIndex = 5;
            this.btnNhapNguyenLieu.Text = "Nhập Nguyên liệu";
            this.btnNhapNguyenLieu.UseVisualStyleBackColor = false;
            this.btnNhapNguyenLieu.Click += new System.EventHandler(this.btnNhapNguyenLieu_Click);
            // 
            // btnKhachThanhVien
            // 
            this.btnKhachThanhVien.BackColor = System.Drawing.Color.Linen;
            this.btnKhachThanhVien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKhachThanhVien.Location = new System.Drawing.Point(431, 177);
            this.btnKhachThanhVien.Name = "btnKhachThanhVien";
            this.btnKhachThanhVien.Size = new System.Drawing.Size(167, 74);
            this.btnKhachThanhVien.TabIndex = 8;
            this.btnKhachThanhVien.Text = "Khách Thành Viên";
            this.btnKhachThanhVien.UseVisualStyleBackColor = false;
            this.btnKhachThanhVien.Click += new System.EventHandler(this.btnKhachThanhVien_Click);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.BackColor = System.Drawing.Color.Linen;
            this.btnQuanLyNhanVien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(431, 97);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(167, 74);
            this.btnQuanLyNhanVien.TabIndex = 7;
            this.btnQuanLyNhanVien.Text = "Quản lý";
            this.btnQuanLyNhanVien.UseVisualStyleBackColor = false;
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Linen;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Location = new System.Drawing.Point(347, 279);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(167, 74);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnDanhSachSanPham
            // 
            this.btnDanhSachSanPham.BackColor = System.Drawing.Color.Linen;
            this.btnDanhSachSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDanhSachSanPham.Location = new System.Drawing.Point(604, 97);
            this.btnDanhSachSanPham.Name = "btnDanhSachSanPham";
            this.btnDanhSachSanPham.Size = new System.Drawing.Size(167, 74);
            this.btnDanhSachSanPham.TabIndex = 9;
            this.btnDanhSachSanPham.Text = "Danh Sách sản phẩm";
            this.btnDanhSachSanPham.UseVisualStyleBackColor = false;
            this.btnDanhSachSanPham.Click += new System.EventHandler(this.btnDanhSachSanPham_Click);
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.BackColor = System.Drawing.Color.Linen;
            this.btnDoanhThu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDoanhThu.Location = new System.Drawing.Point(604, 177);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(167, 74);
            this.btnDoanhThu.TabIndex = 11;
            this.btnDoanhThu.Text = "Báo cáo doanh thu";
            this.btnDoanhThu.UseVisualStyleBackColor = false;
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // formChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(955, 502);
            this.Controls.Add(this.btnDoanhThu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDanhSachSanPham);
            this.Controls.Add(this.btnKhachThanhVien);
            this.Controls.Add(this.btnQuanLyNhanVien);
            this.Controls.Add(this.btnKiemTraHoaDon);
            this.Controls.Add(this.btnNhapNguyenLieu);
            this.Controls.Add(this.btnKiemTraKho);
            this.Controls.Add(this.btnBanHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "formChucNang";
            this.Text = "BanHang";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pY_CAFEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pYCAFEDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource pYCAFEDataSetBindingSource;
        private PY_CAFEDataSet pY_CAFEDataSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnKiemTraKho;
        private System.Windows.Forms.Button btnKiemTraHoaDon;
        private System.Windows.Forms.Button btnNhapNguyenLieu;
        private System.Windows.Forms.Button btnKhachThanhVien;
        private System.Windows.Forms.Button btnQuanLyNhanVien;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDanhSachSanPham;
        private System.Windows.Forms.Button btnDoanhThu;
    }
}