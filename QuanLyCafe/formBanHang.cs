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
    public partial class Form3 : Form
    {
        private DataTable _dtSanPham; // tạo ở ngoài vì cần xài nhiều lần
        private DataTable _dtKhachHang;

        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            txtChucVu.Enabled = false;//3 cái textbox này ko cho sửa
            LayThongTinNV(); // load thông tin nhân viên
            LoadSanPhamvaKH(); // load sản phẩm và khách hàng
            TaoBang(); // làm mấy cái khung
            Grid1.CellValueChanged += Grid1_ThayDoi; // sự kiện khi giá trị ô thay đổi
            Grid1.CurrentCellDirtyStateChanged += Grid1_CurrentCellDirtyStateChanged; // sự kiện khi ô hiện tại bị thay đổi trạng thái
            Grid1.EditingControlShowing += Grid1_ChongChonTrung;
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            TaoHoaDon();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            formChucNang f2 = new formChucNang();
            f2.ShowDialog();
            this.Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            LayThongTinNV();
        }
        private void LayThongTinNV()
        {
            string query = "SELECT MANV, HOTEN, CHUCVU FROM dbo.NhanVien WHERE MANV = @manv";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@manv", Form1.MaNV);
                try
                {
                    txtChucVu.Clear();
                    txtMaNV.Clear();
                    txtTenNV.Clear();
                    Grid1.Rows.Clear();
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtMaNV.Text = reader["MANV"].ToString();
                            txtTenNV.Text = reader["HOTEN"].ToString();
                            txtChucVu.Text = reader["CHUCVU"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void LoadSanPhamvaKH()
        {
            const string sql = "SELECT MASP, TENSP, GIABAN FROM dbo.SanPham ORDER BY TENSP";
            _dtSanPham = new DataTable();
            using (var conn = new SqlConnection(Form1.connectionString))// Tạo đối tượng SqlConnection để kết nối cơ sở dữ liệu
            using (var da = new SqlDataAdapter(sql, conn))// Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
            {
                try
                {
                    da.Fill(_dtSanPham); // Điền dữ liệu vào DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            using (var conn = new SqlConnection(Form1.connectionString))// Tạo đối tượng SqlConnection để kết nối cơ sở dữ liệu
            using (var da = new SqlDataAdapter("SELECT MAKH, HOTEN FROM dbo.KhachThanhVien ORDER BY HOTEN", conn))// Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
            {
                _dtKhachHang = new DataTable();
                try
                {
                    da.Fill(_dtKhachHang); // Điền dữ liệu vào DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            DataRow row = _dtKhachHang.NewRow(); // tạo dòng mới
            row["MAKH"] = DBNull.Value;       // giá trị null thật trong SQL
            row["HOTEN"] = "-- Khách lẻ --"; // hiển thị cho người dùng
            _dtKhachHang.Rows.InsertAt(row, 0); // chèn vào đầu bảng
            cboMaKH.DataSource = _dtKhachHang;
            cboMaKH.DisplayMember = "HOTEN"; // khong co 2 cai nay thi bi loi
            cboMaKH.ValueMember = "MAKH";
        }

        private void TaoBang()
        {
            Grid1.Columns.Clear();
            Grid1.AutoGenerateColumns = false;

            // Cột ComboBox Tên Sản Phẩm (hiển thị TENSP, giá trị là MASP)
            var clTenSP = new DataGridViewComboBoxColumn
            {
                HeaderText = "Tên Sản Phẩm",
                Name = "TenSP",                 // tên cột trên grid
                DataSource = _dtSanPham,        // nguồn dữ liệu
                DisplayMember = "TENSP",        // hiển thị tên
                ValueMember = "MASP",           // giá trị thực tế lưu
                AutoComplete = true,
                Width = 400
            };
            var clSoLuong = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Lượng",
                Name = "SoLuong",
                Width = 100
            };
            var clDonGia = new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn Giá",
                Name = "DonGia",
                Width = 300,
                ReadOnly = true,

            };
            var clThanhTien = new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành Tiền",
                Name = "ThanhTien",
                Width = 400,
                ReadOnly = true,
            };
     
            Grid1.Columns.Add(clTenSP);
            Grid1.Columns.Add(clSoLuong);
            Grid1.Columns.Add(clDonGia);
            Grid1.Columns.Add(clThanhTien);


        }
        private void Grid1_ThayDoi(object sender, DataGridViewCellEventArgs e) // sự kiện khi giá trị ô thay đổi
        {
           
   
            // Kiểm tra nếu đang thay đổi ở cột "TenSP" và dòng hợp lệ
            if (e.RowIndex >= 0 && Grid1.Columns[e.ColumnIndex].Name == "TenSP") // cột Tên Sản Phẩm
            {
                var cell = Grid1.Rows[e.RowIndex].Cells["TenSP"]; // Lấy ô hiện tại
                if (cell.Value != null)// đảm bảo có giá trị
                {
                    string maSP = cell.Value.ToString();// Lấy mã sản phẩm từ ô

                    // Tìm trong DataTable _dtSanPham để lấy giá bán
                    DataRow[] rows = _dtSanPham.Select($"MASP = '{maSP}'"); // Lọc dòng theo MASP, maSP từ  ô
                    if (rows.Length > 0)
                    {
                        decimal gia = Convert.ToDecimal(rows[0]["GIABAN"]);
                        Grid1.Rows[e.RowIndex].Cells["DonGia"].Value = gia.ToString("N0"); // định dạng 1,000
                    }
                }
            }
            if (e.RowIndex >= 0 && (Grid1.Columns[e.ColumnIndex].Name == "SoLuong" || Grid1.Columns[e.ColumnIndex].Name == "DonGia")) // chỗ này là dành cho thành tiền
            {
                var cellSoLuong = Grid1.Rows[e.RowIndex].Cells["SoLuong"];
                var cellDonGia = Grid1.Rows[e.RowIndex].Cells["DonGia"];
                if (cellSoLuong.Value != null && cellDonGia.Value != null)
                {
                    if (int.TryParse(cellSoLuong.Value.ToString(), out int soLuong) && decimal.TryParse(cellDonGia.Value.ToString(), out decimal donGia))
                    {
                        decimal thanhTien = soLuong * donGia;
                        Grid1.Rows[e.RowIndex].Cells["ThanhTien"].Value = thanhTien.ToString("N0");
                    }
                }
                txtThanhTien.Text = Grid1.Rows.Cast<DataGridViewRow>() // Lấy tất cả các dòng trong Grid1
                    .Where(r => r.Cells["ThanhTien"].Value != null) // Lọc các dòng có giá trị Thành Tiền
                    .Sum(r => decimal.Parse(r.Cells["ThanhTien"].Value.ToString())) // Tính tổng thành tiền
                    .ToString("N0"); // Cập nhật tổng thành tiền
            }
        }
        private void Grid1_CurrentCellDirtyStateChanged(object sender, EventArgs e) // sự kiện khi ô hiện tại bị thay đổi trạng thái
        {
            if (Grid1.IsCurrentCellDirty) // nếu ô hiện tại bị thay đổi
            {
                Grid1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void TaoHoaDon()
        {
            foreach(DataGridViewRow row in Grid1.Rows)
            {
                if (row.IsNewRow) continue; // bỏ qua dòng mới
                if (row.Cells["TenSP"].Value == null || string.IsNullOrEmpty(row.Cells["TenSP"].Value.ToString()) ||
                    row.Cells["SoLuong"].Value == null || string.IsNullOrEmpty(row.Cells["SoLuong"].Value.ToString()))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm và số lượng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // dừng việc tạo hóa đơn nếu có thông tin thiếu
                }
            }
            string maHD = TaoMaHD();
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                try
                {
                    int diemThuong = TinhDiem();
                    conn.Open();
                    SqlTransaction ThaoTacThem = conn.BeginTransaction();
                    // Thêm hóa đơn
                    string insertDiemTichLuyQuery = "UPDATE dbo.KhachThanhVien SET DIEMTICHLUY = DIEMTICHLUY + @diemtichluy WHERE MAKH = @makh";
                    string insertHoaDonQuery = "INSERT INTO dbo.HoaDon (MAHD, MANV, MAKH, NGAYLAP, TONGTIEN) VALUES (@mahd, @manv, @makh, @ngaylap, @tongtien)";
                    string insertChiTietQuery = "INSERT INTO dbo.ChiTietHoaDon (MAHD, MASP, SOLUONG, DONGIA, THANHTIEN) VALUES (@mahd, @masp, @soluong, @dongia, @thanhtien)";
                    using (SqlCommand cmdHoaDon = new SqlCommand(insertHoaDonQuery, conn, ThaoTacThem)) // làm cái hóa đơn trc khi làm cái chi tiết
                    {
                        cmdHoaDon.Parameters.AddWithValue("@manv", txtMaNV.Text);
                        cmdHoaDon.Parameters.AddWithValue("@makh", cboMaKH.SelectedValue);
                        cmdHoaDon.Parameters.AddWithValue("@ngaylap", DateTime.Now);
                        cmdHoaDon.Parameters.AddWithValue("@tongtien", decimal.Parse(txtThanhTien.Text, System.Globalization.NumberStyles.AllowThousands));
                        cmdHoaDon.Parameters.AddWithValue("@mahd", maHD);
                        cmdHoaDon.ExecuteNonQuery(); // Thực thi lệnh thêm hóa đơn

                        // Thêm chi tiết hóa đơn
                        using (SqlCommand cmdChiTiet = new SqlCommand(insertChiTietQuery, conn, ThaoTacThem))
                        {
                            cmdChiTiet.Parameters.Add("@mahd", SqlDbType.NChar);
                            cmdChiTiet.Parameters.Add("@masp", SqlDbType.VarChar);
                            cmdChiTiet.Parameters.Add("@soluong", SqlDbType.Int);
                            cmdChiTiet.Parameters.Add("@dongia", SqlDbType.Decimal);
                            cmdChiTiet.Parameters.Add("@thanhtien", SqlDbType.Decimal);
                            foreach (DataGridViewRow row in Grid1.Rows)
                            {
                                if (row.IsNewRow) continue; // bỏ qua dòng mới
                                cmdChiTiet.Parameters["@mahd"].Value = maHD;
                                cmdChiTiet.Parameters["@masp"].Value = row.Cells["TenSP"].Value;
                                cmdChiTiet.Parameters["@soluong"].Value = int.Parse(row.Cells["SoLuong"].Value.ToString());
                                cmdChiTiet.Parameters["@dongia"].Value = decimal.Parse(row.Cells["DonGia"].Value.ToString(), System.Globalization.NumberStyles.AllowThousands);
                                cmdChiTiet.Parameters["@thanhtien"].Value = decimal.Parse(row.Cells["ThanhTien"].Value.ToString(), System.Globalization.NumberStyles.AllowThousands);
                                cmdChiTiet.ExecuteNonQuery();
                            }
                        }
                        // Cập nhật điểm thưởng nếu có khách hàng
                        if (cboMaKH.SelectedValue != DBNull.Value)
                        {
                            using (SqlCommand cmdDiemTichLuy = new SqlCommand(insertDiemTichLuyQuery, conn, ThaoTacThem))
                            {
                                cmdDiemTichLuy.Parameters.AddWithValue("@diemtichluy", diemThuong);
                                cmdDiemTichLuy.Parameters.AddWithValue("@makh", cboMaKH.SelectedValue);
                                cmdDiemTichLuy.ExecuteNonQuery();
                            }
                        }
                    }
                    ThaoTacThem.Commit(); // Xác nhận tạo hd thành công
                    MessageBox.Show("Tạo hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset lại form sau khi tạo hóa đơn
                    Grid1.Rows.Clear();
                    txtThanhTien.Text = "0";


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private string TaoMaHD()
        {
            string maHD = "";
            string query = "SELECT TOP 1 MAHD FROM dbo.HoaDon ORDER BY MAHD DESC";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string MaHDGanNhat = result.ToString();
                    int so = int.Parse(MaHDGanNhat.Substring(2)) + 1; // lay 3 so cua hoa don
                    maHD = "HD" + so.ToString("D3"); // tao ma moi
                }
                else
                {
                    maHD = "HD001"; // neu chua co hoa don nao thi tao HD001
                }
            }
            return maHD;
        }
        private void Grid1_ChongChonTrung(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (Grid1.CurrentCell.OwningColumn.Name == "TenSP" && e.Control is ComboBox cb) // nếu cột hiện tại là Tên Sản Phẩm và control là ComboBox
            {
                cb.SelectedIndexChanged += ComboBox_SelectedIndexChanged; //  sự kiện chọn trùng
            }
            if (Grid1.CurrentCell.OwningColumn.Name == "SoLuong" && e.Control is TextBox tb)
            {
                tb.KeyPress -= TextBox_SoLuong_KeyPress;
                tb.KeyPress += TextBox_SoLuong_KeyPress;
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string selectedValue = cb.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedValue)) return;

            // Duyệt các dòng để kiểm tra trùng MASP (ValueMember)
            foreach (DataGridViewRow row in Grid1.Rows)
            {
                if (row.Index != Grid1.CurrentCell.RowIndex && row.Cells["TenSP"].Value != null)
                {
                    if (row.Cells["TenSP"].Value.ToString() == selectedValue)
                    {
                        MessageBox.Show("Sản phẩm này đã có trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cb.SelectedIndex = -1; // hủy chọn
                        return;
                    }
                }
            }
        }
        private void TextBox_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chặn ký tự không phải số và không phải phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // nếu ko phải ký tự điều khiển và ko phải số
            {
                e.Handled = true; // không cho nhập
                MessageBox.Show("Chỉ được nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu chưa chọn tên sản phẩm
            if (Grid1.CurrentRow != null) // đảm bảo có dòng hiện tại
            {
                var cellTenSP = Grid1.CurrentRow.Cells["TenSP"]; // lấy ô tên sản phẩm của dòng hiện tại
                if (cellTenSP.Value == null || string.IsNullOrEmpty(cellTenSP.Value.ToString())) // nếu chưa chọn tên sản phẩm
                {
                    e.Handled = true; // không cho nhập
                    MessageBox.Show("Vui lòng chọn tên sản phẩm trước khi nhập số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private int TinhDiem()
        {
            decimal tongTien = decimal.Parse(txtThanhTien.Text, System.Globalization.NumberStyles.AllowThousands);
            int diemThuong = (int)(tongTien / 10000); // 1 điểm cho mỗi 10,000 đồng
            return diemThuong;
        }        
    }
}


