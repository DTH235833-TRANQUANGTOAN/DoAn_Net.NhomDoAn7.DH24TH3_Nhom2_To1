namespace QuanLyCafe
{
    partial class formQuanLyHoaDon
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
            this.GridHoaDon = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.gridCTHD = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCTHD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 67);
            this.label1.TabIndex = 16;
            this.label1.Text = "HÓA ĐƠN";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(890, 21);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(243, 50);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // GridHoaDon
            // 
            this.GridHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridHoaDon.Location = new System.Drawing.Point(-3, 100);
            this.GridHoaDon.Name = "GridHoaDon";
            this.GridHoaDon.RowHeadersWidth = 62;
            this.GridHoaDon.RowTemplate.Height = 28;
            this.GridHoaDon.Size = new System.Drawing.Size(1132, 253);
            this.GridHoaDon.TabIndex = 14;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(641, 21);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(243, 50);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa hóa đơn";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // gridCTHD
            // 
            this.gridCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCTHD.Location = new System.Drawing.Point(-3, 413);
            this.gridCTHD.Name = "gridCTHD";
            this.gridCTHD.RowHeadersWidth = 62;
            this.gridCTHD.RowTemplate.Height = 28;
            this.gridCTHD.Size = new System.Drawing.Size(1132, 253);
            this.gridCTHD.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 32);
            this.label2.TabIndex = 19;
            this.label2.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // formQuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 694);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridCTHD);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.GridHoaDon);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "formQuanLyHoaDon";
            this.Text = "formQuanLyHoaDon";
            this.Load += new System.EventHandler(this.formQuanLyHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCTHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView GridHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView gridCTHD;
        private System.Windows.Forms.Label label2;
    }
}