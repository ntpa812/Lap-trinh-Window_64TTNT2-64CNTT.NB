namespace QLNhanSu
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.hoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hocHam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTim = new System.Windows.Forms.Button();
            this.cbbHocHam = new System.Windows.Forms.ComboBox();
            this.cbbDonVi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbQue = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hoTen,
            this.gioiTinh,
            this.queQuan,
            this.donVi,
            this.hocHam});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 118);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(592, 226);
            this.dataGridView1.TabIndex = 1;
            // 
            // hoTen
            // 
            this.hoTen.DataPropertyName = "hoTen";
            this.hoTen.HeaderText = "Họ tên";
            this.hoTen.MinimumWidth = 6;
            this.hoTen.Name = "hoTen";
            // 
            // gioiTinh
            // 
            this.gioiTinh.DataPropertyName = "gioiTinh";
            this.gioiTinh.HeaderText = "Giới tính";
            this.gioiTinh.MinimumWidth = 6;
            this.gioiTinh.Name = "gioiTinh";
            // 
            // queQuan
            // 
            this.queQuan.DataPropertyName = "queQuan";
            this.queQuan.HeaderText = "Quê quán";
            this.queQuan.MinimumWidth = 6;
            this.queQuan.Name = "queQuan";
            // 
            // donVi
            // 
            this.donVi.DataPropertyName = "donVi";
            this.donVi.HeaderText = "Đơn vị";
            this.donVi.MinimumWidth = 6;
            this.donVi.Name = "donVi";
            // 
            // hocHam
            // 
            this.hocHam.DataPropertyName = "hocHam";
            this.hocHam.HeaderText = "Học hàm/Học vị";
            this.hocHam.MinimumWidth = 6;
            this.hocHam.Name = "hocHam";
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.SystemColors.Control;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(437, 37);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(114, 41);
            this.btnTim.TabIndex = 21;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // cbbHocHam
            // 
            this.cbbHocHam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbHocHam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHocHam.FormattingEnabled = true;
            this.cbbHocHam.Items.AddRange(new object[] {
            "Giáo sư",
            "Tiến sĩ",
            "Thạc sĩ"});
            this.cbbHocHam.Location = new System.Drawing.Point(147, 46);
            this.cbbHocHam.Margin = new System.Windows.Forms.Padding(2);
            this.cbbHocHam.Name = "cbbHocHam";
            this.cbbHocHam.Size = new System.Drawing.Size(232, 25);
            this.cbbHocHam.TabIndex = 17;
            // 
            // cbbDonVi
            // 
            this.cbbDonVi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDonVi.FormattingEnabled = true;
            this.cbbDonVi.Items.AddRange(new object[] {
            "Khoa Công nghệ thông tin",
            "Khoa Cơ Khí",
            "Khoa Điện - Điện tử"});
            this.cbbDonVi.Location = new System.Drawing.Point(147, 78);
            this.cbbDonVi.Margin = new System.Windows.Forms.Padding(2);
            this.cbbDonVi.Name = "cbbDonVi";
            this.cbbDonVi.Size = new System.Drawing.Size(232, 25);
            this.cbbDonVi.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 49);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Học hàm/học vị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Đơn vị";
            // 
            // cbbQue
            // 
            this.cbbQue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbQue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbQue.FormattingEnabled = true;
            this.cbbQue.Items.AddRange(new object[] {
            "Hà Nội",
            "TP Hồ Chí Minh",
            "Huế"});
            this.cbbQue.Location = new System.Drawing.Point(147, 11);
            this.cbbQue.Margin = new System.Windows.Forms.Padding(2);
            this.cbbQue.Name = "cbbQue";
            this.cbbQue.Size = new System.Drawing.Size(232, 25);
            this.cbbQue.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Quê quán";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(592, 344);
            this.Controls.Add(this.cbbQue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.cbbHocHam);
            this.Controls.Add(this.cbbDonVi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn queQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn donVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn hocHam;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cbbHocHam;
        private System.Windows.Forms.ComboBox cbbDonVi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbQue;
        private System.Windows.Forms.Label label3;
    }
}