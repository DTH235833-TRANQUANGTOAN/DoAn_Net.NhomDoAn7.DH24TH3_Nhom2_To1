using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class formSanPham : Form
    {
        public formSanPham()
        {
            InitializeComponent();
        }

        private void formSanPham_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
            btnCapNhat.Enabled = false;
            btnThem.Enabled = true;
            GridSanPham.ReadOnly = true;
            GridSanPham.AllowUserToAddRows = false;
            SetDanhMuc();
            TaoBang();
            NapDuLieu();
            cboDanhMuc.SelectedIndexChanged += CboDanhMuc_ThayDoiLuaChon;
            GridSanPham.MultiSelect = true; // Cho phép chọn nhiều dòng
            GridSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả dòng khi nhấp vào một ô
            GridSanPham.MouseDown += GridSanPham_BoChon;

            GridSanPham.CellClick += GridSanPham_CellClick;

           }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSanPham();
            txtGiaBan.Clear();
            txtTen.Clear();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CapNhatSanPham();
            txtGiaBan.Clear();
            txtTen.Clear();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtGiaBan.Clear();
            txtTen.Clear();
            GridSanPham.ClearSelection();
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
            DataGridViewTextBoxColumn clMaSP = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã SP",
                Name = "MASP",
                Width = 150,
            };
            DataGridViewTextBoxColumn clTenSP = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Tên SP",
                Name = "TENSP",
                Width = 300,
            };
            DataGridViewTextBoxColumn clGiaBan = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Giá Bán",
                Name = "GIABAN",
                Width = 350,
            };
            DataGridViewTextBoxColumn clMaDM = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã danh mục",
                Name = "MADM",
                Width = 150,
            };
            DataGridViewTextBoxColumn clTrangThai = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Trạng Thái",
                Name = "TRANG THAI",
                Width = 200,
            };
            GridSanPham.Columns.AddRange(new DataGridViewColumn[] { clMaSP, clTenSP, clGiaBan, clMaDM, clTrangThai });

        }
        private void SetDanhMuc()
        {
            string danhmucquerry = "select * from DANHMUC";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(danhmucquerry, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboDanhMuc.DataSource = dt;
                cboDanhMuc.DisplayMember = "TENDANHMUC";
                cboDanhMuc.ValueMember = "MADM";
            }
        }
        private void NapDuLieu()
        {
            string madm = cboDanhMuc.SelectedValue.ToString();
            string sanphamquerry = "select * from SANPHAM where MADM=@madm";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(sanphamquerry, conn))
            {
                cmd.Parameters.AddWithValue("@madm", madm);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) // Thực thi câu lệnh và lấy dữ liệu
                    {
                        DataTable table = new DataTable(); // Tạo một DataTable để lưu trữ dữ liệu
                        table.Load(reader); // Load dữ liệu từ SqlDataReader vào DataTable
                        GridSanPham.Rows.Clear(); // Xóa dữ liệu hiện có trong DataGridView
                        foreach (DataRow row in table.Rows)
                        {
                            GridSanPham.Rows.Add(row["MASP"], row["TENSP"], row["GIABAN"], row["MADM"], row["TRANGTHAI"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void CboDanhMuc_ThayDoiLuaChon(object sender, EventArgs e) // Khi thay đổi lựa chọn trong ComboBox
        {
            NapDuLieu();
        }
       
        private void GridSanPham_BoChon(object sender, MouseEventArgs e)
        {
            var hit = GridSanPham.HitTest(e.X, e.Y);

            // Click vào vùng trống → bỏ chọn
            if (hit.Type == DataGridViewHitTestType.None)
            {
                GridSanPham.ClearSelection();

                txtTen.Clear();
                txtGiaBan.Clear();
                rdoCon.Checked = false;
                rdoHet.Checked = false;

                btnThem.Enabled = true;
                btnCapNhat.Enabled = false;
            }
        }
        private void GridSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào header thì bỏ qua
            if (e.RowIndex < 0) return;

            GridSanPham.MultiSelect = false; // vẫn đảm bảo chỉ chọn 1 dòng khi click vào ô
            DataGridViewRow row = GridSanPham.Rows[e.RowIndex];

            // Hiển thị dữ liệu
            txtTen.Text = row.Cells["TENSP"].Value.ToString();
            txtGiaBan.Text = row.Cells["GIABAN"].Value.ToString();

            if (row.Cells["TRANG THAI"].Value.ToString() == "Còn bán")
            {
                rdoCon.Checked = true;
                rdoHet.Checked = false;
            }
            else
            {
                rdoHet.Checked = true;
                rdoCon.Checked = false;
            }

            btnThem.Enabled = false;
            btnCapNhat.Enabled = true;
        }
        private void ThemSanPham()
        {
            string masp = TaoMASP();
            string tensp = txtTen.Text;
            decimal giaban;
            if (!decimal.TryParse(txtGiaBan.Text, out giaban))
            {
                MessageBox.Show("Giá bán không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string madm = cboDanhMuc.SelectedValue.ToString();
            string trangthai = rdoCon.Checked ? "Còn bán" : "Ngừng bán";
            string insertQuery = "INSERT INTO SANPHAM (MASP, TENSP, GIABAN, MADM, TRANGTHAI) " +
                                 "VALUES (@masp, @tensp, @giaban, @madm, @trangthai)";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@masp", masp);
                cmd.Parameters.AddWithValue("@tensp", tensp);
                cmd.Parameters.AddWithValue("@giaban", giaban);
                cmd.Parameters.AddWithValue("@madm", madm);
                cmd.Parameters.AddWithValue("@trangthai", trangthai);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieu(); // Tải lại dữ liệu sau khi thêm
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private string TaoMASP()
        {
            string masp = "";
            string query = "SELECT TOP 1 MASP FROM SANPHAM ORDER BY MASP DESC";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string MaSPGanNhat = result.ToString();
                    int so = int.Parse(MaSPGanNhat.Substring(2)) + 1; // lay 3 so cua san pham
                    masp = "SP" + so.ToString("D3"); // tao ma moi
                }
                else
                {
                    masp = "SP001"; // neu chua co san pham nao thi tao ma SP001
                }
                return masp;
            }
        }
        private void CapNhatSanPham()
        {
            string masp = GridSanPham.SelectedRows[0].Cells["MASP"].Value.ToString();
            string tensp = txtTen.Text;
            decimal giaban;
            if (!decimal.TryParse(txtGiaBan.Text, out giaban))
            {
                MessageBox.Show("Giá bán không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string madm = cboDanhMuc.SelectedValue.ToString();
            string trangthai = rdoCon.Checked ? "Còn bán" : "Ngừng bán";
            string updateQuery = "UPDATE SANPHAM SET TENSP=@tensp, GIABAN=@giaban, MADM=@madm, TRANGTHAI=@trangthai WHERE MASP=@masp";
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@masp", masp);
                cmd.Parameters.AddWithValue("@tensp", tensp);
                cmd.Parameters.AddWithValue("@giaban", giaban);
                cmd.Parameters.AddWithValue("@madm", madm);
                cmd.Parameters.AddWithValue("@trangthai", trangthai);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NapDuLieu(); // Tải lại dữ liệu sau khi cập nhật
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      
    }
}
