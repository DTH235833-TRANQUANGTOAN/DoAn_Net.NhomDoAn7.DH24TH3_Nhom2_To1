using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCafe
{
    public partial class Form1 : Form
    {
        public static String MaNV = "";
        public static String connectionString = "Data Source=PERSONAL-01;Initial Catalog=PY_CAFE;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        
        
        
        
        
        
        
        
        
        
        
        private bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) // Tạo đối tượng kết nối đến cơ sở dữ liệu
            {
                bool ketQua = false;
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM dbo.NhanVien WHERE TAIKHOAN = @tk AND MATKHAU = @mk"; // Câu lệnh SQL để kiểm tra tài khoản và mật khẩu, cụ thể là bảng NhanVien
                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Tạo đối tượng SqlCommand để thực thi câu lệnh SQL
                    {
                        cmd.Parameters.AddWithValue("@tk", taiKhoan); // Thêm tham số để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@mk", matKhau); // Thêm tham số để tránh SQL Injection

                        int count = (int)cmd.ExecuteScalar(); // Thực thi câu lệnh và lấy số lượng bản ghi khớp tức là tài khoản và mật khẩu
                        if (count > 0) // Nếu có bản ghi khớp, tức là đăng nhập thành công
                        {
                            ketQua = true;
                            string queryMANV = "SELECT MANV FROM dbo.NhanVien WHERE TAIKHOAN = @tk AND MATKHAU = @mk"; // Câu lệnh SQL để lấy thông tin nhân viên
                            using (SqlCommand cmdInfo = new SqlCommand(queryMANV, conn)) // Tạo đối tượng SqlCommand để lấy thông tin nhân viên
                            {
                                cmdInfo.Parameters.AddWithValue("@tk", taiKhoan.Trim());
                                cmdInfo.Parameters.AddWithValue("@mk", matKhau.Trim());

                                using (SqlDataReader reader = cmdInfo.ExecuteReader()) // Thực thi câu lệnh và lấy thông tin nhân viên
                                {
                                    if (reader.Read())
                                    {
                                        MaNV = reader["MANV"].ToString(); // Lấy giá trị MANV từ kết quả truy vấn
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex) // Bắt lỗi nếu có lỗi xảy ra trong quá trình kết nối hoặc truy vấn
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return ketQua;
            }
        }





        
        
        
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraDangNhap(taiKhoan, matKhau)) // Kiểm tra đăng nhập, dung thì mở Form2
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                formChucNang f2 = new formChucNang();
                f2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }












        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
        }
    }
}
