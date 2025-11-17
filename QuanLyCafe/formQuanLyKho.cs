using System;
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
    public partial class formQuanLyKho : Form
    {
        public formQuanLyKho()
        {
            InitializeComponent();
        }

        private void formQuanLyKho_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
            TaoBang();
            LayThongTinKho();
            GridKho.AllowUserToAddRows = false; // cái này để xóa cái dòng trống ở duói cùng
            GridKho.ReadOnly = true;

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            formChucNang f2 = new formChucNang();
            f2.ShowDialog();
            this.Close();
        }








        private void LayThongTinKho()
        {
            string querry = "SELECT * FROM dbo.TonKho"; // Câu lệnh SQL để lấy thông tin kho
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            using (SqlCommand cmd = new SqlCommand(querry, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        GridKho.Rows.Clear(); // Xóa dữ liệu hiện có trong DataGridView
                        foreach (DataRow row in table.Rows)
                        {
                            GridKho.Rows.Add(row["MANGUYENLIEU"], row["TENNGUYENLIEU"], row["DONVITINH"], row["SOLUONGTON"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TaoBang()
        {
            var clMaNL = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã nguyên liệu",
                Name = "MaNL",
                Width = 250,
            };
            var clTenNL = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Tên nguyên liệu",
                Name = "TenNL",
                Width = 250,
            };
            var clSoLuong = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Số lượng",
                Name = "SoLuong",
                Width = 150,
            };
            var clDonViTinh = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Đơn vị tính",
                Name = "DonViTinh",
                Width = 150,
            };
            GridKho.Columns.Add(clMaNL);
            GridKho.Columns.Add(clTenNL);
            GridKho.Columns.Add(clDonViTinh);
            GridKho.Columns.Add(clSoLuong);
        }
        private void capnhat()
        {
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                conn.Open();
                foreach (DataGridViewRow row in GridKho.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua dòng mới
                    string maNL = row.Cells["MaNL"].Value?.ToString();
                    string soLuong = row.Cells["SoLuong"].Value?.ToString();
                    string query = "UPDATE dbo.TonKho SET SOLUONGTON = @SoLuong WHERE MANGUYENLIEU = @MaNL";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmd.Parameters.AddWithValue("@MaNL", maNL);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cập nhật kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}


