namespace QuanLyCafe
{
    partial class formSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.GridSanPham = new System.Windows.Forms.DataGridView();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gr1 = new System.Windows.Forms.GroupBox();
            this.rdoHet = new System.Windows.Forms.RadioButton();
            this.rdoCon = new System.Windows.Forms.RadioButton();
            this.btnCapNhat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridSanPham)).BeginInit();
            this.gr1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.label1.Location = new System.Drawing.Point(50, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 67);
            this.label1.TabIndex = 16;
            this.label1.Text = "SẢN PHẨM";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(919, 167);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(243, 50);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // GridSanPham
            // 
            this.GridSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridSanPham.Location = new System.Drawing.Point(12, 242);
            this.GridSanPham.Name = "GridSanPham";
            this.GridSanPham.RowHeadersWidth = 62;
            this.GridSanPham.RowTemplate.Height = 28;
            this.GridSanPham.Size = new System.Drawing.Size(1150, 253);
            this.GridSanPham.TabIndex = 14;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(259, 90);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(252, 40);
            this.cboDanhMuc.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 32);
            this.label2.TabIndex = 18;
            this.label2.Text = "Danh mục:";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(919, 95);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(243, 50);
            this.btnHuy.TabIndex = 19;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(919, 24);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(243, 50);
            this.btnThem.TabIndex = 20;
            this.btnThem.Text = "Thêm sản phẩm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(259, 136);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(252, 39);
            this.txtTen.TabIndex = 21;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(259, 181);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(252, 39);
            this.txtGiaBan.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 32);
            this.label3.TabIndex = 23;
            this.label3.Text = "Tên sản phẩm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 32);
            this.label4.TabIndex = 24;
            this.label4.Text = "Giá bán:";
            // 
            // gr1
            // 
            this.gr1.Controls.Add(this.rdoHet);
            this.gr1.Controls.Add(this.rdoCon);
            this.gr1.Location = new System.Drawing.Point(574, 90);
            this.gr1.Name = "gr1";
            this.gr1.Size = new System.Drawing.Size(326, 127);
            this.gr1.TabIndex = 25;
            this.gr1.TabStop = false;
            this.gr1.Text = "Trạng thái";
            // 
            // rdoHet
            // 
            this.rdoHet.AutoSize = true;
            this.rdoHet.Location = new System.Drawing.Point(207, 56);
            this.rdoHet.Name = "rdoHet";
            this.rdoHet.Size = new System.Drawing.Size(77, 36);
            this.rdoHet.TabIndex = 1;
            this.rdoHet.TabStop = true;
            this.rdoHet.Text = "Hết";
            this.rdoHet.UseVisualStyleBackColor = true;
            // 
            // rdoCon
            // 
            this.rdoCon.AutoSize = true;
            this.rdoCon.Location = new System.Drawing.Point(23, 56);
            this.rdoCon.Name = "rdoCon";
            this.rdoCon.Size = new System.Drawing.Size(129, 36);
            this.rdoCon.TabIndex = 0;
            this.rdoCon.TabStop = true;
            this.rdoCon.Text = "Còn bán";
            this.rdoCon.UseVisualStyleBackColor = true;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(670, 24);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(243, 50);
            this.btnCapNhat.TabIndex = 26;
            this.btnCapNhat.Text = "Cập nhật sản phẩm";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // formSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1170, 520);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.gr1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDanhMuc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.GridSanPham);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "formSanPham";
            this.Text = "formSanPham";
            this.Load += new System.EventHandler(this.formSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridSanPham)).EndInit();
            this.gr1.ResumeLayout(false);
            this.gr1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView GridSanPham;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gr1;
        private System.Windows.Forms.RadioButton rdoHet;
        private System.Windows.Forms.RadioButton rdoCon;
        private System.Windows.Forms.Button btnCapNhat;
    }
}