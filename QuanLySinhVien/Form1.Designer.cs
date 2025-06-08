namespace QuanLySinhVien
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lNgaySinh = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lHoten = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lGioiTinh = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lNoiSinh = new System.Windows.Forms.Label();
            this.radioNam = new System.Windows.Forms.RadioButton();
            this.radioNu = new System.Windows.Forms.RadioButton();
            this.bAdd = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bCfg = new System.Windows.Forms.Button();
            this.bFilter = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1148, 573);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1142, 353);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lNgaySinh);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.lHoten);
            this.panel1.Controls.Add(this.txtMa);
            this.panel1.Controls.Add(this.lName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 208);
            this.panel1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "d/M/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(125, 112);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(323, 22);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lNgaySinh
            // 
            this.lNgaySinh.AutoSize = true;
            this.lNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNgaySinh.Location = new System.Drawing.Point(12, 112);
            this.lNgaySinh.Name = "lNgaySinh";
            this.lNgaySinh.Size = new System.Drawing.Size(93, 22);
            this.lNgaySinh.TabIndex = 0;
            this.lNgaySinh.Text = "Ngày Sinh";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoTen.Location = new System.Drawing.Point(125, 62);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(323, 22);
            this.txtHoTen.TabIndex = 2;
            // 
            // lHoten
            // 
            this.lHoten.AutoSize = true;
            this.lHoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHoten.Location = new System.Drawing.Point(12, 62);
            this.lHoten.Name = "lHoten";
            this.lHoten.Size = new System.Drawing.Size(70, 22);
            this.lHoten.TabIndex = 0;
            this.lHoten.Text = "Họ Tên";
            // 
            // txtMa
            // 
            this.txtMa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa.Location = new System.Drawing.Point(125, 16);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(323, 22);
            this.txtMa.TabIndex = 1;
            this.txtMa.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(12, 16);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(63, 22);
            this.lName.TabIndex = 0;
            this.lName.Text = "Mã SV";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.bFilter);
            this.panel2.Controls.Add(this.bCfg);
            this.panel2.Controls.Add(this.bDel);
            this.panel2.Controls.Add(this.bAdd);
            this.panel2.Controls.Add(this.radioNu);
            this.panel2.Controls.Add(this.radioNam);
            this.panel2.Controls.Add(this.lGioiTinh);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.lNoiSinh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(577, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 208);
            this.panel2.TabIndex = 4;
            // 
            // lGioiTinh
            // 
            this.lGioiTinh.AutoSize = true;
            this.lGioiTinh.Location = new System.Drawing.Point(53, 62);
            this.lGioiTinh.Name = "lGioiTinh";
            this.lGioiTinh.Size = new System.Drawing.Size(60, 16);
            this.lGioiTinh.TabIndex = 4;
            this.lGioiTinh.Text = "Giới Tinh";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(166, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(323, 22);
            this.textBox2.TabIndex = 4;
            // 
            // lNoiSinh
            // 
            this.lNoiSinh.AutoSize = true;
            this.lNoiSinh.Location = new System.Drawing.Point(53, 16);
            this.lNoiSinh.Name = "lNoiSinh";
            this.lNoiSinh.Size = new System.Drawing.Size(57, 16);
            this.lNoiSinh.TabIndex = 5;
            this.lNoiSinh.Text = "Nơi Sinh";
            // 
            // radioNam
            // 
            this.radioNam.AutoSize = true;
            this.radioNam.Location = new System.Drawing.Point(166, 63);
            this.radioNam.Name = "radioNam";
            this.radioNam.Size = new System.Drawing.Size(57, 20);
            this.radioNam.TabIndex = 9;
            this.radioNam.Text = "Nam";
            this.radioNam.UseVisualStyleBackColor = true;
            // 
            // radioNu
            // 
            this.radioNu.AutoSize = true;
            this.radioNu.Location = new System.Drawing.Point(275, 64);
            this.radioNu.Name = "radioNu";
            this.radioNu.Size = new System.Drawing.Size(45, 20);
            this.radioNu.TabIndex = 5;
            this.radioNu.TabStop = true;
            this.radioNu.Text = "Nữ";
            this.radioNu.UseVisualStyleBackColor = true;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(56, 133);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(100, 40);
            this.bAdd.TabIndex = 6;
            this.bAdd.Text = "Thêm";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(302, 133);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(100, 40);
            this.bDel.TabIndex = 8;
            this.bDel.Text = "Xoá";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bCfg
            // 
            this.bCfg.Location = new System.Drawing.Point(180, 133);
            this.bCfg.Name = "bCfg";
            this.bCfg.Size = new System.Drawing.Size(100, 40);
            this.bCfg.TabIndex = 7;
            this.bCfg.Text = "Sửa";
            this.bCfg.UseVisualStyleBackColor = true;
            this.bCfg.Click += new System.EventHandler(this.bCfg_Click);
            // 
            // bFilter
            // 
            this.bFilter.Location = new System.Drawing.Point(422, 133);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(100, 40);
            this.bFilter.TabIndex = 9;
            this.bFilter.Text = "Lọc";
            this.bFilter.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Quản lý sinh viên (Nguyễn Hoàng Phương - 2251262625)";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lNgaySinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lHoten;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lGioiTinh;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lNoiSinh;
        private System.Windows.Forms.RadioButton radioNu;
        private System.Windows.Forms.RadioButton radioNam;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.Button bCfg;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

