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
    public partial class formNhapNguyenLieu : Form
    {
        public formNhapNguyenLieu()
        {
            InitializeComponent();
        }

        private void formNhapNguyenLieu_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"D:\ky 1 nam 3\net\DoAn\DoAn_Net.NhomDoAn7.DH24TH3_Nhom2_To1\QuanLyCafe\HinhAnh\cafe_icon.ico");
            TaoBang();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            GridNhap.Rows.Clear();
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
                Width = 482,
            };
            var clSoLuong = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Số lượng",
                Name = "SoLuong",
                Width = 200,
            };
            var clDonViTinh = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Đơn vị tính",
                Name = "DonViTinh",
                Width = 200,
            };
            GridNhap.Columns.Add(clMaNL);
            GridNhap.Columns.Add(clTenNL);
            GridNhap.Columns.Add(clDonViTinh);
            GridNhap.Columns.Add(clSoLuong);
        }
        private void CapNhatCSDL()
        {
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    foreach (DataGridViewRow dong in GridNhap.Rows)
                    {
                        if (dong.IsNewRow) continue;

                        string maNL = dong.Cells["MaNL"].Value?.ToString();
                        string tenNL = dong.Cells["TenNL"].Value?.ToString();
                        string donViTinh = dong.Cells["DonViTinh"].Value?.ToString();
                        int SoLuong = int.Parse(dong.Cells["SoLuong"].Value?.ToString());

                        if (string.IsNullOrEmpty(maNL) || string.IsNullOrEmpty(tenNL) || string.IsNullOrEmpty(donViTinh) || SoLuong <= 0)
                        {
                            throw new Exception("Dữ liệu không hợp lệ: Mã, Tên, Đơn vị tính và số lượng không được để trống hoặc ≤ 0.");
                        }

                        string checkQuery = "SELECT TENNGUYENLIEU, SOLUONGTON FROM dbo.TonKho WHERE MANGUYENLIEU = @MaNL OR TENNGUYENLIEU = @TenNL";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@MaNL", maNL);
                            checkCmd.Parameters.AddWithValue("@TenNL", tenNL);

                            List<(string TenNL_DB, int SoLuong_DB)> matched = new List<(string, int)>();

                            using (SqlDataReader reader = checkCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    matched.Add((reader.GetString(0), reader.GetInt32(1)));
                                }
                            } // <-- reader đóng tại đây

                            if (matched.Count > 0)
                            {
                                bool maTenTrung = matched.Any(m => m.TenNL_DB == tenNL); // Cả mã và tên trùng
                                bool chiMaTrung = matched.Any(m => m.TenNL_DB != tenNL); // Chỉ trùng một trong hai

                                if (maTenTrung)
                                {
                                    // Cộng số lượng
                                    string updateQuery = "UPDATE dbo.TonKho SET SOLUONGTON = SOLUONGTON + @SoLuong WHERE MANGUYENLIEU = @MaNL AND TENNGUYENLIEU = @TenNL";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction))
                                    {
                                        updateCmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                                        updateCmd.Parameters.AddWithValue("@MaNL", maNL);
                                        updateCmd.Parameters.AddWithValue("@TenNL", tenNL);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    throw new Exception($"Dữ liệu bị trùng không hợp lệ: Mã hoặc Tên nguyên liệu '{maNL}/{tenNL}' đã tồn tại nhưng không khớp cả hai.");
                                }
                            }
                            else
                            {
                                // Chèn mới
                                string insertQuery = "INSERT INTO dbo.TonKho (MANGUYENLIEU, TENNGUYENLIEU, DONVITINH, SOLUONGTON) VALUES (@MaNL, @TenNL, @DonViTinh, @SoLuong)";
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@MaNL", maNL);
                                    insertCmd.Parameters.AddWithValue("@TenNL", tenNL);
                                    insertCmd.Parameters.AddWithValue("@DonViTinh", donViTinh);
                                    insertCmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                
                        transaction.Commit();
                    MessageBox.Show("Cập nhật cơ sở dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi cập nhật cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            CapNhatCSDL();
        }

        
    }
    }
