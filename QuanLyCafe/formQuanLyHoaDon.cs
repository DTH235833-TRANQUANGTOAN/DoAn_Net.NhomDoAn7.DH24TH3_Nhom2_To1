using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class formQuanLyHoaDon : Form
    {
        public formQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void formQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
            XemQuyen(); //quản lý thì dc xóa, nv ko dc
            TaoBang();
            NapDuLieu();
            GridHoaDon.AllowUserToAddRows = false; // cái này để xóa cái dòng trống ở duói cùng
            GridHoaDon.ReadOnly = true;
            GridHoaDon.MultiSelect = false; // Chỉ cho phép chọn một dòng
            GridHoaDon.CellClick += gridHoaDon_CellClick;
           
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaHoaDon(GridHoaDon.CurrentRow.Cells["MaHD"].Value.ToString()); // cái gridview nó có thuộc tính current row để lấy dòng hiện tại đang chọn
        }









        private void TaoBang()
        {
            var clMaHD = new DataGridViewTextBoxColumn() // xài var cho gọn
            {
                HeaderText = "Mã hóa đơn",
                Name = "MaHD",
                Width = 150,
            };
            var clNgayLap = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Ngày lập",
                Name = "NgayLap",
                Width = 332,
            };
            var clMaNV = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã nhân viên",
                Name = "MaNV",
                Width = 150,
            };
            var clMaKH = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã khách hàng",
                Name = "MaKH",
                Width = 150,
            };
            var clTongTien = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Tổng tiền",
                Name = "TongTien",
                Width = 350,
            };
            var CTHDclMaHD = new DataGridViewTextBoxColumn() // xài var cho gọn
            {
                HeaderText = "Mã hóa đơn",
                Name = "CTHDClMaHD",
                Width = 150,
            };
            var clTenSP = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Tên sản phẩm",
                Name = "MaHD",
                Width = 246,
            };
            var clSoLuong = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Số lượng",
                Name = "MaHD",
                Width = 150,
            };
            var clDonGia = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Đơn giá",
                Name = "MaHD",
                Width = 246,
            };
            var clThanhTien = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Thành tiền",
                Name = "MaHD",
                Width = 341,
            };
            GridHoaDon.Columns.Add(clMaHD);
            GridHoaDon.Columns.Add(clNgayLap);
            GridHoaDon.Columns.Add(clMaNV);
            GridHoaDon.Columns.Add(clMaKH);
            GridHoaDon.Columns.Add(clTongTien);
            gridCTHD.Columns.Add(CTHDclMaHD);
            gridCTHD.Columns.Add(clTenSP);
            gridCTHD.Columns.Add(clSoLuong);
            gridCTHD.Columns.Add(clDonGia);
            gridCTHD.Columns.Add(clThanhTien);
        }
        private void XemQuyen()
        {
            string laychucvu = "SELECT CHUCVU FROM dbo.NhanVien WHERE MANV= @manv";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(laychucvu, conn)) // Tạo đối tượng SqlCommand để lấy thông tin nhân viên
                    {
                        cmd.Parameters.AddWithValue("@manv", Form1.MaNV); // Thêm tham số để tránh SQL Injection
                        using (SqlDataReader reader = cmd.ExecuteReader()) // Thực thi câu lệnh và lấy thông tin nhân viên
                        {
                            if (reader.Read())
                            {
                                string chucVu = reader["CHUCVU"].ToString().Trim(); // Lấy giá trị CHUCVU từ kết quả truy vấn
                                if (chucVu != "Quản lý")
                                {
                                    btnXoa.Enabled = false;
                                }
                                else
                                    btnXoa.Enabled = true;
                            }
                        }
                    }
                }
                catch (Exception ex) // Bắt lỗi nếu có lỗi xảy ra trong quá trình kết nối hoặc truy vấn
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void NapDuLieu()
        {
            string querry = "SELECT * FROM dbo.HoaDon";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(querry, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) // Thực thi câu lệnh và lấy dữ liệu
                    {
                        DataTable table = new DataTable(); // Tạo một DataTable để lưu trữ dữ liệu
                        table.Load(reader); // Load dữ liệu từ SqlDataReader vào DataTable
                        GridHoaDon.Rows.Clear(); // Xóa dữ liệu hiện có trong DataGridView
                        foreach (DataRow row in table.Rows)
                        {
                            string ngaylap = Convert .ToDateTime(row["NGAYLAP"]).ToString("dd/MM/yyyy");
                            GridHoaDon.Rows.Add(row["MAHD"], ngaylap, row["MANV"], row["MAKH"], row["TONGTIEN"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void XoaHoaDon(string maHD) // Xóa hóa đơn và chi tiết hóa đơn dựa trên mã hóa đơn
        {
            
            string xoachitiethoadon = "DELETE FROM dbo.ChiTietHoaDon WHERE MAHD = @MaHD";
            string xoahoadon = "DELETE FROM dbo.HoaDon WHERE MAHD = @MaHD";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd1 = new SqlCommand(xoachitiethoadon, conn))
            using (SqlCommand cmd2 = new SqlCommand(xoahoadon, conn))
            {
                cmd1.Parameters.AddWithValue("@MaHD", maHD); // Thêm tham số để tránh SQL Injection
                cmd2.Parameters.AddWithValue("@MaHD", maHD); // Thêm tham số để tránh SQL Injection là mã hóa đơn vì cả 2 câu lệnh đều dùng
                try
                {
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieu(); // Tải lại dữ liệu sau khi xóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void gridHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex ==-1)
                return;
            GridHoaDon.MultiSelect = false; //  đảm bảo chỉ chọn 1 dòng khi click vào ô
            DataGridViewRow row = GridHoaDon.Rows[e.RowIndex];
            GridHoaDon.MultiSelect = true; // Cho phép chọn nhiều dòng trở lại sau khi xử lý
            string maHD = row.Cells["MaHD"].Value.ToString();
            NapDuLieuCTHD(maHD);
        }
        private void NapDuLieuCTHD(string maHD)
        {
            string querry = "SELECT * FROM dbo.ChiTietHoaDon JOIN dbo.SanPham ON dbo.ChiTietHoaDon.MASP =dbo.SanPham.MASP  WHERE MAHD = @MaHD ";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(querry, conn))
            {
                cmd.Parameters.AddWithValue("@MaHD", maHD); // Thêm tham số để tránh SQL Injection
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) // Thực thi câu lệnh và lấy dữ liệu
                    {
                        DataTable table = new DataTable(); // Tạo một DataTable để lưu trữ dữ liệu
                        table.Load(reader); // Load dữ liệu từ SqlDataReader vào DataTable
                       
                        
                        

                   
                        gridCTHD.Rows.Clear(); // Xóa dữ liệu hiện có trong DataGridView
                        foreach (DataRow row in table.Rows)
                        {
                            double ThanhTien = Convert.ToDouble(row["SOLUONG"]) * Convert.ToDouble(row["DONGIA"]);
                            gridCTHD.Rows.Add(row["MAHD"], row["TENSP"], row["SOLUONG"], row["DONGIA"], ThanhTien);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            formChucNang f2 = new formChucNang();
            f2.ShowDialog();
            this.Close();
        }
    }
}
