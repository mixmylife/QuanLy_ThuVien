namespace BTLQuanLyThuVien
{
    partial class XuatDanhSachCuaMotNXB
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
            this.btThoat = new System.Windows.Forms.Button();
            this.btXuatDanhSach = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNXB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btThoat
            // 
            this.btThoat.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btThoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Location = new System.Drawing.Point(444, 415);
            this.btThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(252, 42);
            this.btThoat.TabIndex = 11;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btXuatDanhSach
            // 
            this.btXuatDanhSach.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btXuatDanhSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btXuatDanhSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btXuatDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXuatDanhSach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXuatDanhSach.Location = new System.Drawing.Point(131, 415);
            this.btXuatDanhSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btXuatDanhSach.Name = "btXuatDanhSach";
            this.btXuatDanhSach.Size = new System.Drawing.Size(252, 42);
            this.btXuatDanhSach.TabIndex = 10;
            this.btXuatDanhSach.Text = "Xuất Danh Sách";
            this.btXuatDanhSach.UseVisualStyleBackColor = true;
            this.btXuatDanhSach.Click += new System.EventHandler(this.btXuatDanhSach_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(803, 332);
            this.dataGridView1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tìm Kiếm NXB";
            // 
            // cbNXB
            // 
            this.cbNXB.FormattingEnabled = true;
            this.cbNXB.Location = new System.Drawing.Point(367, 358);
            this.cbNXB.Name = "cbNXB";
            this.cbNXB.Size = new System.Drawing.Size(215, 24);
            this.cbNXB.TabIndex = 13;
            this.cbNXB.SelectedIndexChanged += new System.EventHandler(this.cbNXB_SelectedIndexChanged);
            // 
            // XuatDanhSachCuaMotNXB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(803, 475);
            this.Controls.Add(this.cbNXB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btXuatDanhSach);
            this.Controls.Add(this.dataGridView1);
            this.Name = "XuatDanhSachCuaMotNXB";
            this.Text = "XuatDanhSachCuaMotNXB";
            this.Load += new System.EventHandler(this.XuatDanhSachCuaMotNXB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btXuatDanhSach;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNXB;
    }
}