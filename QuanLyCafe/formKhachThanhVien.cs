using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace QuanLyCafe
{
    public partial class formKhachThanhVien : Form
    {
        public formKhachThanhVien()
        {
            InitializeComponent();
        }

        private void formKhachThanhVien_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
            TaoBang();
            LayThongTinKH();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CapNhatThongTinKH();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            LayThongTinKH();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            formChucNang f2 = new formChucNang();
            f2.ShowDialog();
            this.Close();
        }






        private void TaoBang()
        {
            DataGridViewTextBoxColumn clMaKH = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã khách hàng",
                Name = "MaKH",
                Width = 150,
            };
            DataGridViewTextBoxColumn clHoTen = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Tên khách hàng",
                Name = "HoTen",
                Width = 300,
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
            DataGridViewTextBoxColumn clSDT = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Số điện thoại",
                Name = "SDT",
                Width = 200,
            };
            DataGridViewTextBoxColumn clDiemTichLuy = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Điểm tích lũy",
                Name = "DiemTichLuy",
                Width = 150,
            };
            GridKhachHang.Columns.Add(clMaKH);
            GridKhachHang.Columns.Add(clHoTen);
            GridKhachHang.Columns.Add(clNgaySinh);
            GridKhachHang.Columns.Add(clGioiTinh);
            GridKhachHang.Columns.Add(clSDT);
            GridKhachHang.Columns.Add(clDiemTichLuy);

        }
        private void LayThongTinKH()
        {
            string querry = "SELECT * FROM dbo.KhachThanhVien"; // Câu lệnh SQL để lấy thông tin kho
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(querry, conn))
            {
                try
                {
                    GridKhachHang.Rows.Clear(); // Xóa dữ liệu hiện có trong DataGridView
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        GridKhachHang.Rows.Clear(); // Xóa dữ liệu hiện có trong DataGridView
                        foreach (DataRow row in table.Rows)
                        {
                            
                            // Xử lý NGAYSINH: nếu khác DBNull thì convert và format
                            string ngaySinh = "";
                            if (row["NGAYSINH"] != DBNull.Value) // Kiểm tra nếu không phải giá trị null
                                ngaySinh = Convert.ToDateTime(row["NGAYSINH"]).ToString("dd/MM/yyyy"); // Định dạng ngày tháng

                            GridKhachHang.Rows.Add(row["MAKH"], row["HOTEN"], ngaySinh, row["GIOITINH"], row["SDT"], row["DIEMTICHLUY"]); // Thêm dòng vào DataGridView, có cái ngày sinh đã chế lại nên lấy từ biến trong cái foreach
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CapNhatThongTinKH()
        {
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                conn.Open();
                try
                {
                    foreach (DataGridViewRow dong in GridKhachHang.Rows)
                    {
                        if (dong.IsNewRow) continue; // Bỏ qua dòng mới chưa có dữ liệu
                        if (dong.Cells["MaKH"].Value == null || dong.Cells["HoTen"].Value == null)
                            MessageBox.Show("Mã khách hàng và tên không được để trống"); // Bỏ qua nếu mã khách hàng null

                        // cập nhật cho những makh đã có trong database
                        string maKH = dong.Cells["MaKH"].Value?.ToString();
                        string hoTen = dong.Cells["HoTen"].Value?.ToString();
                        DateTime? ngaySinh = null;
                        if (dong.Cells["NgaySinh"].Value != null && DateTime.TryParseExact(dong.Cells["NgaySinh"].Value.ToString().Trim(),"dd/MM/yyyy",CultureInfo.GetCultureInfo("vi-VN"),DateTimeStyles.None, out DateTime ns)) // KHI XÀI TRYPARSEEXACT THÌ PHẢI CÓ MẤY THÔNG TIN NÀY
                        {
                            ngaySinh = ns; // Gán giá trị ngày sinh nếu hợp lệ
                        }
                        string gioiTinh = dong.Cells["GioiTinh"].Value?.ToString();
                        string sdt = dong.Cells["SDT"].Value?.ToString();
                        int diemTichLuy = int.Parse(dong.Cells["DiemTichLuy"].Value?.ToString() ?? "0");


                        // hàm kiểm tra nếu mã khách hàng chưa tồn tại thì chèn mới
                        string checkQuery = "SELECT COUNT(*) FROM dbo.KhachThanhVien WHERE MAKH = @MaKH";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@MaKH", maKH);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count == 0)
                            {
                                // Chèn khách hàng mới (INSERT) trước khi UPDATE
                                string insertQuery = @"
                            INSERT INTO dbo.KhachThanhVien (MAKH, HOTEN, NGAYSINH, GIOITINH, SDT, DIEMTICHLUY)
                            VALUES (@MaKH, @HoTen, @NgaySinh, @GioiTinh, @SDT, @DiemTichLuy)";
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@MaKH", maKH);
                                    insertCmd.Parameters.AddWithValue("@HoTen", hoTen); // Nếu họ tên null thì gán DBNull
                                    insertCmd.Parameters.AddWithValue("@NgaySinh", (object)ngaySinh ?? DBNull.Value);
                                    insertCmd.Parameters.AddWithValue("@GioiTinh", gioiTinh ?? (object)DBNull.Value);
                                    insertCmd.Parameters.AddWithValue("@SDT", sdt ?? (object)DBNull.Value);
                                    insertCmd.Parameters.AddWithValue("@DiemTichLuy", diemTichLuy);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            { 

                                string querycapnhat = "UPDATE dbo.KhachThanhVien SET HOTEN = @HoTen, NGAYSINH = @NgaySinh, GIOITINH = @GioiTinh, SDT = @SDT, DIEMTICHLUY = @DiemTichLuy WHERE MAKH = @MaKH";
                                using (SqlCommand cmd = new SqlCommand(querycapnhat, conn))
                                {
                                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                                    if (ngaySinh.HasValue)
                                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh.Value);
                                    else
                                        cmd.Parameters.AddWithValue("@NgaySinh", DBNull.Value); // Nếu ngày sinh null thì gán DBNull
                                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                                    cmd.Parameters.AddWithValue("@SDT", sdt);
                                    cmd.Parameters.AddWithValue("@DiemTichLuy", diemTichLuy);
                                    cmd.ExecuteNonQuery(); // Thực thi câu lệnh cập nhật
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

       
    }
}
