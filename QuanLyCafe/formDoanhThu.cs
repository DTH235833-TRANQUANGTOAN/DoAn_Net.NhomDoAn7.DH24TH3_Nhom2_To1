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

namespace QuanLyCafe
{
    public partial class formDoanhThu : Form
    {
        public formDoanhThu()
        {
            InitializeComponent();
        }

        private void formDoanhThu_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += ComboBox1_ThayDoi;
        }

        private void ComboBox1_ThayDoi(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) //ngày
            {
                txtNgay.Visible = true;
                txtThang.Visible = true;
                txtNam.Visible = true;
            }
            if (comboBox1.SelectedIndex == 1) //tháng
            {
                txtNgay.Visible = false;
                txtThang.Visible = true;
                txtNam.Visible = true;
            }
            if (comboBox1.SelectedIndex == 2) //năm
            {
                txtNgay.Visible = false;
                txtThang.Visible = false;
                txtNam.Visible = true;
            }
        }

        private void btnTinhDoanhThu_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DoanhThuNgay();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DoanhThuThang();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                DoanhThuNam();
            }
        }





        private void DoanhThuNgay()
        {
            string inputNgay = txtNgay.Text.Trim() + "/" + txtThang.Text.Trim() + "/" + txtNam.Text.Trim();
            DateTime ngay;
            if (!DateTime.TryParseExact(inputNgay, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngay))
            {
                MessageBox.Show("Vui lòng nhập ngày hợp lệ theo định dạng dd/MM/yyyy.", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT SUM(TONGTIEN) AS DOANHTHU FROM HOADON WHERE CAST(NGAYLAP AS DATE) = @ngay";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ngay", ngay);
                        object result = cmd.ExecuteScalar();
                        decimal doanhThu = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                        txtDoanhThu.Text = doanhThu.ToString("N0");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tính doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DoanhThuThang()
        {
            string inputThang =  txtThang.Text.Trim() + "/" + txtNam.Text.Trim();
            DateTime thang;
            if (!DateTime.TryParseExact(inputThang, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out thang))
            {
                MessageBox.Show("Vui lòng nhập tháng hợp lệ theo định dạng MM/yyyy.", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT SUM(TONGTIEN) AS DOANHTHU FROM HOADON WHERE MONTH(NGAYLAP) = @thang AND YEAR(NGAYLAP) = @nam";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@thang", thang.Month);
                        cmd.Parameters.AddWithValue("@nam", thang.Year);
                        object result = cmd.ExecuteScalar();
                        decimal doanhThu = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                        txtDoanhThu.Text = doanhThu.ToString("N0");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tính doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DoanhThuNam()
        {
            string inputNam = txtNam.Text.Trim();
            DateTime nam;
            if (!DateTime.TryParseExact(inputNam, "yyyy", null, System.Globalization.DateTimeStyles.None, out nam))
            {
                MessageBox.Show("Vui lòng nhập ngày hợp lệ theo định dạng dd/MM/yyyy.", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT SUM(TONGTIEN) AS DOANHTHU FROM HOADON WHERE YEAR(NGAYLAP) = @nam";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nam", nam.Year);
                        object result = cmd.ExecuteScalar();
                        decimal doanhThu = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                        txtDoanhThu.Text = doanhThu.ToString("N0");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tính doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
