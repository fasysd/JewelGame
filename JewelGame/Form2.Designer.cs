namespace JewelGame
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rd1nguoi = new System.Windows.Forms.RadioButton();
            this.rd2nguoi = new System.Windows.Forms.RadioButton();
            this.cbKichCo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_form2Nguoi = new System.Windows.Forms.Panel();
            this.txtNgChoi1 = new System.Windows.Forms.TextBox();
            this.txtNgChoi2 = new System.Windows.Forms.TextBox();
            this.lbNgChoi1 = new System.Windows.Forms.Label();
            this.lbNgChoi2 = new System.Windows.Forms.Label();
            this.panel_form1Nguoi = new System.Windows.Forms.Panel();
            this.lbTenNgChoi = new System.Windows.Forms.Label();
            this.txtTenNgChoi = new System.Windows.Forms.TextBox();
            this.btnChoiMoi = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.maTranDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kichCo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheDoChoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_LichSu = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_form2Nguoi.SuspendLayout();
            this.panel_form1Nguoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chế độ chơi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kích cỡ";
            // 
            // rd1nguoi
            // 
            this.rd1nguoi.AutoSize = true;
            this.rd1nguoi.Checked = true;
            this.rd1nguoi.Location = new System.Drawing.Point(98, 1);
            this.rd1nguoi.Name = "rd1nguoi";
            this.rd1nguoi.Size = new System.Drawing.Size(102, 20);
            this.rd1nguoi.TabIndex = 2;
            this.rd1nguoi.TabStop = true;
            this.rd1nguoi.Text = "1 người chơi ";
            this.rd1nguoi.UseVisualStyleBackColor = true;
            this.rd1nguoi.CheckedChanged += new System.EventHandler(this.rd1nguoi_CheckedChanged);
            // 
            // rd2nguoi
            // 
            this.rd2nguoi.AutoSize = true;
            this.rd2nguoi.Location = new System.Drawing.Point(98, 28);
            this.rd2nguoi.Name = "rd2nguoi";
            this.rd2nguoi.Size = new System.Drawing.Size(102, 20);
            this.rd2nguoi.TabIndex = 3;
            this.rd2nguoi.Text = "2 người chơi ";
            this.rd2nguoi.UseVisualStyleBackColor = true;
            this.rd2nguoi.CheckedChanged += new System.EventHandler(this.rd2nguoi_CheckedChanged);
            // 
            // cbKichCo
            // 
            this.cbKichCo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKichCo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKichCo.FormattingEnabled = true;
            this.cbKichCo.Items.AddRange(new object[] {
            "8x8",
            "10x10",
            "12x12"});
            this.cbKichCo.Location = new System.Drawing.Point(98, 63);
            this.cbKichCo.Name = "cbKichCo";
            this.cbKichCo.Size = new System.Drawing.Size(145, 24);
            this.cbKichCo.TabIndex = 4;
            this.cbKichCo.SelectedIndexChanged += new System.EventHandler(this.cbKichCo_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbKichCo);
            this.panel1.Controls.Add(this.rd1nguoi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rd2nguoi);
            this.panel1.Location = new System.Drawing.Point(26, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 90);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.panel_form2Nguoi);
            this.panel2.Controls.Add(this.panel_form1Nguoi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(313, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 133);
            this.panel2.TabIndex = 6;
            // 
            // panel_form2Nguoi
            // 
            this.panel_form2Nguoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_form2Nguoi.Controls.Add(this.txtNgChoi1);
            this.panel_form2Nguoi.Controls.Add(this.txtNgChoi2);
            this.panel_form2Nguoi.Controls.Add(this.lbNgChoi1);
            this.panel_form2Nguoi.Controls.Add(this.lbNgChoi2);
            this.panel_form2Nguoi.Location = new System.Drawing.Point(8, 17);
            this.panel_form2Nguoi.Name = "panel_form2Nguoi";
            this.panel_form2Nguoi.Size = new System.Drawing.Size(450, 98);
            this.panel_form2Nguoi.TabIndex = 10;
            this.panel_form2Nguoi.Visible = false;
            // 
            // txtNgChoi1
            // 
            this.txtNgChoi1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgChoi1.Location = new System.Drawing.Point(138, 4);
            this.txtNgChoi1.Name = "txtNgChoi1";
            this.txtNgChoi1.Size = new System.Drawing.Size(235, 22);
            this.txtNgChoi1.TabIndex = 16;
            // 
            // txtNgChoi2
            // 
            this.txtNgChoi2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgChoi2.Location = new System.Drawing.Point(138, 36);
            this.txtNgChoi2.Name = "txtNgChoi2";
            this.txtNgChoi2.Size = new System.Drawing.Size(235, 22);
            this.txtNgChoi2.TabIndex = 15;
            // 
            // lbNgChoi1
            // 
            this.lbNgChoi1.AutoSize = true;
            this.lbNgChoi1.Location = new System.Drawing.Point(30, 10);
            this.lbNgChoi1.Name = "lbNgChoi1";
            this.lbNgChoi1.Size = new System.Drawing.Size(84, 16);
            this.lbNgChoi1.TabIndex = 13;
            this.lbNgChoi1.Text = "Người chơi 1 ";
            // 
            // lbNgChoi2
            // 
            this.lbNgChoi2.AutoSize = true;
            this.lbNgChoi2.Location = new System.Drawing.Point(30, 36);
            this.lbNgChoi2.Name = "lbNgChoi2";
            this.lbNgChoi2.Size = new System.Drawing.Size(84, 16);
            this.lbNgChoi2.TabIndex = 14;
            this.lbNgChoi2.Text = "Người chơi 2 ";
            // 
            // panel_form1Nguoi
            // 
            this.panel_form1Nguoi.Controls.Add(this.lbTenNgChoi);
            this.panel_form1Nguoi.Controls.Add(this.txtTenNgChoi);
            this.panel_form1Nguoi.Location = new System.Drawing.Point(3, 7);
            this.panel_form1Nguoi.Name = "panel_form1Nguoi";
            this.panel_form1Nguoi.Size = new System.Drawing.Size(448, 91);
            this.panel_form1Nguoi.TabIndex = 9;
            // 
            // lbTenNgChoi
            // 
            this.lbTenNgChoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTenNgChoi.AutoSize = true;
            this.lbTenNgChoi.Location = new System.Drawing.Point(19, 36);
            this.lbTenNgChoi.Name = "lbTenNgChoi";
            this.lbTenNgChoi.Size = new System.Drawing.Size(95, 16);
            this.lbTenNgChoi.TabIndex = 7;
            this.lbTenNgChoi.Text = "Tên người chơi";
            // 
            // txtTenNgChoi
            // 
            this.txtTenNgChoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTenNgChoi.Location = new System.Drawing.Point(152, 36);
            this.txtTenNgChoi.Name = "txtTenNgChoi";
            this.txtTenNgChoi.Size = new System.Drawing.Size(235, 22);
            this.txtTenNgChoi.TabIndex = 8;
            // 
            // btnChoiMoi
            // 
            this.btnChoiMoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChoiMoi.AutoSize = true;
            this.btnChoiMoi.Location = new System.Drawing.Point(161, 161);
            this.btnChoiMoi.Name = "btnChoiMoi";
            this.btnChoiMoi.Size = new System.Drawing.Size(122, 39);
            this.btnChoiMoi.TabIndex = 9;
            this.btnChoiMoi.Text = "Chơi mới";
            this.btnChoiMoi.UseVisualStyleBackColor = true;
            this.btnChoiMoi.Click += new System.EventHandler(this.btnChoiMoi_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maTranDau,
            this.kichCo,
            this.thoiGian,
            this.cheDoChoi});
            this.dgv1.Location = new System.Drawing.Point(12, 216);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidth = 51;
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(776, 222);
            this.dgv1.TabIndex = 7;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // maTranDau
            // 
            this.maTranDau.DataPropertyName = "maTranDau";
            this.maTranDau.HeaderText = "Mã trận đấu";
            this.maTranDau.MinimumWidth = 6;
            this.maTranDau.Name = "maTranDau";
            this.maTranDau.ReadOnly = true;
            // 
            // kichCo
            // 
            this.kichCo.DataPropertyName = "kichCo";
            this.kichCo.HeaderText = "Kích cỡ";
            this.kichCo.MinimumWidth = 6;
            this.kichCo.Name = "kichCo";
            this.kichCo.ReadOnly = true;
            // 
            // thoiGian
            // 
            this.thoiGian.DataPropertyName = "thoiGian";
            this.thoiGian.HeaderText = "Thời gian";
            this.thoiGian.MinimumWidth = 6;
            this.thoiGian.Name = "thoiGian";
            this.thoiGian.ReadOnly = true;
            // 
            // cheDoChoi
            // 
            this.cheDoChoi.DataPropertyName = "cheDoChoi";
            this.cheDoChoi.HeaderText = "Chế độ chơi";
            this.cheDoChoi.MinimumWidth = 6;
            this.cheDoChoi.Name = "cheDoChoi";
            this.cheDoChoi.ReadOnly = true;
            // 
            // btn_LichSu
            // 
            this.btn_LichSu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_LichSu.AutoSize = true;
            this.btn_LichSu.Location = new System.Drawing.Point(516, 161);
            this.btn_LichSu.Name = "btn_LichSu";
            this.btn_LichSu.Size = new System.Drawing.Size(122, 39);
            this.btn_LichSu.TabIndex = 8;
            this.btn_LichSu.Text = "Lịch sử ";
            this.btn_LichSu.UseVisualStyleBackColor = true;
            this.btn_LichSu.Click += new System.EventHandler(this.btn1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.10257F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.89743F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 139);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTiepTuc.AutoSize = true;
            this.btnTiepTuc.Location = new System.Drawing.Point(324, 161);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(156, 39);
            this.btnTiepTuc.TabIndex = 10;
            this.btnTiepTuc.Text = "Tiếp tục";
            this.btnTiepTuc.UseVisualStyleBackColor = true;
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnChoiMoi);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_LichSu);
            this.Controls.Add(this.dgv1);
            this.Name = "Form2";
            this.Text = "FormMenu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel_form2Nguoi.ResumeLayout(false);
            this.panel_form2Nguoi.PerformLayout();
            this.panel_form1Nguoi.ResumeLayout(false);
            this.panel_form1Nguoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rd1nguoi;
        private System.Windows.Forms.RadioButton rd2nguoi;
        private System.Windows.Forms.ComboBox cbKichCo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnChoiMoi;
        private System.Windows.Forms.TextBox txtTenNgChoi;
        private System.Windows.Forms.Label lbTenNgChoi;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btn_LichSu;
        private System.Windows.Forms.Panel panel_form1Nguoi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_form2Nguoi;
        private System.Windows.Forms.TextBox txtNgChoi2;
        private System.Windows.Forms.Label lbNgChoi1;
        private System.Windows.Forms.Label lbNgChoi2;
        private System.Windows.Forms.TextBox txtNgChoi1;
        private System.Windows.Forms.Button btnTiepTuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn maTranDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn kichCo;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheDoChoi;
    }
}