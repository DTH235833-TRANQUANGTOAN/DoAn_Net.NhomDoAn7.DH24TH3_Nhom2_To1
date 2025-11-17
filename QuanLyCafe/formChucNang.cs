using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Thêm thư viện để làm việc với SQL Server

namespace QuanLyCafe
{
    public partial class formChucNang : Form
    {
        
        public formChucNang()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
            string chucVu ="";
            string queryCHUCVU = "SELECT CHUCVU FROM dbo.NhanVien WHERE MANV= @manv"; // Câu lệnh SQL để lấy thông tin nhân viên
            using (SqlConnection conn = new SqlConnection(Form1.connectionString)) // Tạo đối tượng SqlConnection để kết nối cơ sở dữ liệu
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryCHUCVU, conn)) // Tạo đối tượng SqlCommand để lấy thông tin nhân viên
                    {
                        cmd.Parameters.AddWithValue("@manv", Form1.MaNV); // Thêm tham số để tránh SQL Injection
                        using (SqlDataReader reader = cmd.ExecuteReader()) // Thực thi câu lệnh và lấy thông tin nhân viên
                        {
                            if (reader.Read())
                            {
                                chucVu = reader["CHUCVU"].ToString().Trim(); // Lấy giá trị CHUCVU từ kết quả truy vấn
                                label2.Text = "chức vụ của bạn: " + chucVu; // Hiển thị chức vụ lên label
                            }
                        }
                    }
                }
                catch (Exception ex) // Bắt lỗi nếu có lỗi xảy ra trong quá trình kết nối hoặc truy vấn
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (chucVu=="Quản lý")
            {
                btnBanHang.Enabled = true;
                btnKiemTraKho.Enabled = true;
                btnKiemTraHoaDon.Enabled = true;
                btnNhapNguyenLieu.Enabled = true;
                btnKhachThanhVien.Enabled = true;
                btnQuanLyNhanVien.Enabled = true;
            }
            else // may chuc vụ khác thì làm gì cũng dc ngoại trừ vụ nhân viên
            {
                btnBanHang.Enabled = true;
                btnKiemTraKho.Enabled = true;
                btnKiemTraHoaDon.Enabled = true;
                btnNhapNguyenLieu.Enabled = true;
                btnKhachThanhVien.Enabled = true;
                btnQuanLyNhanVien.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
            this.Close();
        }

        private void btnKiemTraKho_Click(object sender, EventArgs e)
        {
            this.Hide();
            formQuanLyKho f4 = new formQuanLyKho();
            f4.ShowDialog();
            this.Close();
        }

        private void btnNhapNguyenLieu_Click(object sender, EventArgs e)
        {
            this.Hide();
            formNhapNguyenLieu f5 = new formNhapNguyenLieu();
            f5.ShowDialog();
            this.Close();
        }

        private void btnKiemTraHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            formQuanLyHoaDon f6 = new formQuanLyHoaDon();
            f6.ShowDialog();
            this.Close();
        }

        private void btnKhachThanhVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            formKhachThanhVien f7 = new formKhachThanhVien();
            f7.ShowDialog();
            this.Close();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            formQuanLyNhanVien f8 = new formQuanLyNhanVien();
            f8.ShowDialog();
            this.Close();
        }

        private void btnDanhSachSanPham_Click(object sender, EventArgs e)
        {
            this.Hide();
            formSanPham f9 = new formSanPham();
            f9.ShowDialog();
            this.Close();
        }
    }
}
