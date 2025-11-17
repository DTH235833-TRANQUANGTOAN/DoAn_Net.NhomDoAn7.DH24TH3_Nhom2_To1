using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class formQuanLyNhanVien : Form
    {
        public formQuanLyNhanVien()
        {
            InitializeComponent();
        }
        private void formQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
            TaoBang();
            NapDuLieu();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn cập nhật dữ liệu nhân viên không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == DialogResult.Yes)
                CapNhatDuLieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            formChucNang f2 = new formChucNang();
            f2.ShowDialog();
            this.Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            NapDuLieu();
        }





        private void TaoBang()
        {
            DataGridViewTextBoxColumn clMaNV = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã nhân viên",
                Name = "MaNV",
                Width = 150,
            };
            DataGridViewTextBoxColumn clHoTen = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Họ tên",
                Name = "HoTen",
                Width = 250,
            };
            DataGridViewTextBoxColumn clNgaySinh = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Ngày sinh",
                Name = "NgaySinh",
                Width = 200,
            };
            DataGridViewTextBoxColumn clGioiTinh = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Giới tính",
                Name = "GioiTinh",
                Width = 100,
            };
            DataGridViewTextBoxColumn clDiaChi = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Địa chỉ",
                Name = "DiaChi",
                Width = 300,
            };
            DataGridViewTextBoxColumn clSDT = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Số điện thoại",
                Name = "SDT",
                Width = 200,
            };
            DataGridViewTextBoxColumn clChucVu = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Chức vụ",
                Name = "ChucVu",
                Width = 150,
            };
            DataGridViewTextBoxColumn TaiKhoan = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Tài khoản",
                Name = "TaiKhoan",
                Width = 150,
            };
            DataGridViewTextBoxColumn MatKhau = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mật khẩu",
                Name = "MatKhau",
                Width = 150,
            };
            DataGridViewTextBoxColumn clTrangThai = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Trạng thái",
                Name = "TrangThai",
                Width = 150,
            };
            GridNhanVien.Columns.Add(clMaNV);
            GridNhanVien.Columns.Add(clHoTen);
            GridNhanVien.Columns.Add(clNgaySinh);
            GridNhanVien.Columns.Add(clGioiTinh);
            GridNhanVien.Columns.Add(clDiaChi);
            GridNhanVien.Columns.Add(clSDT);
            GridNhanVien.Columns.Add(clChucVu);
            GridNhanVien.Columns.Add(TaiKhoan);
            GridNhanVien.Columns.Add(MatKhau);
            GridNhanVien.Columns.Add(clTrangThai);
        }
        private void NapDuLieu()
        {
            string query = "SELECT * FROM dbo.NhanVien";
            using(SqlConnection conn = new SqlConnection(Form1.connectionString))
            using(SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    GridNhanVien.Rows.Clear();
                    conn.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        GridNhanVien.Rows.Clear();
                        foreach(DataRow row in table.Rows)
                        {
                            String NgaySinhStr = Convert.ToDateTime(row["NGAYSINH"]).ToString("dd/MM/yyyy");
                            GridNhanVien.Rows.Add(row["MANV"], row["HOTEN"], NgaySinhStr, row["GIOITINH"], row["DIACHI"], row["SDT"], row["CHUCVU"], row["TAIKHOAN"], row["MATKHAU"], row["TRANGTHAI"]);
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CapNhatDuLieu()
        {
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                conn.Open();
                try
                {
                    foreach(DataGridViewRow dong in GridNhanVien.Rows)
                    {
                        int dem = 0;
                        if (dong.IsNewRow) continue;
                        foreach (DataGridViewCell cell in dong.Cells)
                        {
                            if (cell.Value == null)
                                dem++;
                        }
                        if (dem ==10) // Nếu tất cả các ô trong dòng đều trống, bỏ qua dòng này
                            continue;
                        if (dem >0)
                        {
                            MessageBox.Show("Dữ liệu nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string manv = dong.Cells["MaNV"].Value.ToString();
                        string hoten = dong.Cells["HoTen"].Value.ToString();
                        DateTime.TryParseExact(dong.Cells["NgaySinh"].Value.ToString().Trim(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"), DateTimeStyles.None, out DateTime NgaySinh);                  string gioitinh = dong.Cells["GioiTinh"].Value.ToString();
                        string diachi = dong.Cells["DiaChi"].Value.ToString();
                        string sdt = dong.Cells["SDT"].Value.ToString();
                        string chucvu = dong.Cells["ChucVu"].Value.ToString();
                        string taikhoan = dong.Cells["TaiKhoan"].Value.ToString();
                        string matkhau = dong.Cells["MatKhau"].Value.ToString();
                        string trangthai = dong.Cells["TrangThai"].Value.ToString();

                        string checkQuery = "SELECT COUNT(*) FROM dbo.NhanVien WHERE MANV = @MANV";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@MANV", manv);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count == 0) // Nếu mã nhân viên chưa tồn tại
                            {
                                // Chèn nhân viên mới (INSERT) trước khi UPDATE
                                string insertQuery = @"INSERT INTO dbo.NhanVien (MANV, HOTEN, NGAYSINH, GIOITINH, DIACHI, SDT, CHUCVU, TAIKHOAN, MATKHAU, TRANGTHAI)
                                                     VALUES (@MANV, @HOTEN, @NGAYSINH, @GIOITINH, @DIACHI, @SDT, @CHUCVU, @TAIKHOAN, @MATKHAU, @TRANGTHAI)";
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn)) // Sử dụng insertCmd để chèn nhân viên mới DUA @MANNV VAO MANV TRONG DATABASE
                                {
                                    insertCmd.Parameters.AddWithValue("@MANV", manv); // DUA CAC THONG TIN TU manv vao @MANV
                                    insertCmd.Parameters.AddWithValue("@HOTEN", hoten);
                                    insertCmd.Parameters.AddWithValue("@NGAYSINH", NgaySinh);
                                    insertCmd.Parameters.AddWithValue("@GIOITINH", gioitinh);
                                    insertCmd.Parameters.AddWithValue("@DIACHI", diachi);
                                    insertCmd.Parameters.AddWithValue("@SDT", sdt);
                                    insertCmd.Parameters.AddWithValue("@CHUCVU", chucvu);
                                    insertCmd.Parameters.AddWithValue("@TAIKHOAN", taikhoan);
                                    insertCmd.Parameters.AddWithValue("@MATKHAU", matkhau);
                                    insertCmd.Parameters.AddWithValue("@TRANGTHAI", trangthai);
                                    insertCmd.ExecuteNonQuery(); // thuc thi toan lenh insert cmd, mấy cái ở trên là tham số đã thiết lập
                                }
                            }
                            else
                            { 
                                string updateQuery = @"UPDATE dbo.NhanVien
                                                       SET HOTEN = @HOTEN,
                                                           NGAYSINH = @NGAYSINH,
                                                           GIOITINH = @GIOITINH,
                                                           DIACHI = @DIACHI,
                                                           SDT = @SDT,
                                                           CHUCVU = @CHUCVU,
                                                           TAIKHOAN = @TAIKHOAN,
                                                           MATKHAU = @MATKHAU,
                                                           TRANGTHAI = @TRANGTHAI
                                                       WHERE MANV = @MANV";
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn)) // Sử dụng updateCmd để cập nhật nhân viên
                                {
                                    updateCmd.Parameters.AddWithValue("@MANV", manv);
                                    updateCmd.Parameters.AddWithValue("@HOTEN", hoten);
                                    updateCmd.Parameters.AddWithValue("@NGAYSINH", NgaySinh);
                                    updateCmd.Parameters.AddWithValue("@GIOITINH", gioitinh);
                                    updateCmd.Parameters.AddWithValue("@DIACHI", diachi);
                                    updateCmd.Parameters.AddWithValue("@SDT", sdt);
                                    updateCmd.Parameters.AddWithValue("@CHUCVU", chucvu);
                                    updateCmd.Parameters.AddWithValue("@TAIKHOAN", taikhoan);
                                    updateCmd.Parameters.AddWithValue("@MATKHAU", matkhau);
                                    updateCmd.Parameters.AddWithValue("@TRANGTHAI", trangthai);
                                    updateCmd.ExecuteNonQuery(); // Thực thi lệnh cập nhật
                                }
                            }
                        }
                    }
                    MessageBox.Show("Cập nhật dữ liệu nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
   
}
