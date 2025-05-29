namespace JewelGame
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
            this.components = new System.ComponentModel.Container();
            this.panel_JewelGrid = new System.Windows.Forms.Panel();
            this.button_saveGame = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_tranDauHienTai = new System.Windows.Forms.Label();
            this.textBox_ten2 = new System.Windows.Forms.TextBox();
            this.textBox_ten1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip_xemThongTinJewel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip_xemThongTinJewel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_JewelGrid
            // 
            this.panel_JewelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_JewelGrid.Location = new System.Drawing.Point(194, 0);
            this.panel_JewelGrid.Margin = new System.Windows.Forms.Padding(0);
            this.panel_JewelGrid.Name = "panel_JewelGrid";
            this.panel_JewelGrid.Size = new System.Drawing.Size(584, 400);
            this.panel_JewelGrid.TabIndex = 0;
            // 
            // button_saveGame
            // 
            this.button_saveGame.Location = new System.Drawing.Point(766, 41);
            this.button_saveGame.Name = "button_saveGame";
            this.button_saveGame.Size = new System.Drawing.Size(75, 23);
            this.button_saveGame.TabIndex = 1;
            this.button_saveGame.Text = "Save Game";
            this.button_saveGame.UseVisualStyleBackColor = true;
            this.button_saveGame.Click += new System.EventHandler(this.button_saveGame_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(701, 220);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "maTranDau";
            this.Column1.HeaderText = "Mã trận đấu";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tenNguoiChoi1";
            this.Column2.HeaderText = "Người chơi 1";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tenNguoiChoi2";
            this.Column3.HeaderText = "Người chơi 2";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "kichCo";
            this.Column4.HeaderText = "Kích cỡ";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "thoiGian";
            this.Column5.HeaderText = "Thời gian";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel_JewelGrid, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 400);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(873, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click_newGame);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label_tranDauHienTai);
            this.panel1.Controls.Add(this.textBox_ten2);
            this.panel1.Controls.Add(this.textBox_ten1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_saveGame);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 247);
            this.panel1.TabIndex = 6;
            // 
            // label_tranDauHienTai
            // 
            this.label_tranDauHienTai.AutoSize = true;
            this.label_tranDauHienTai.Location = new System.Drawing.Point(741, 76);
            this.label_tranDauHienTai.Name = "label_tranDauHienTai";
            this.label_tranDauHienTai.Size = new System.Drawing.Size(125, 16);
            this.label_tranDauHienTai.TabIndex = 8;
            this.label_tranDauHienTai.Text = "Mã trận dấu hiện tại:";
            // 
            // textBox_ten2
            // 
            this.textBox_ten2.Location = new System.Drawing.Point(741, 194);
            this.textBox_ten2.Name = "textBox_ten2";
            this.textBox_ten2.Size = new System.Drawing.Size(191, 22);
            this.textBox_ten2.TabIndex = 7;
            // 
            // textBox_ten1
            // 
            this.textBox_ten1.Location = new System.Drawing.Point(741, 139);
            this.textBox_ten1.Name = "textBox_ten1";
            this.textBox_ten1.Size = new System.Drawing.Size(191, 22);
            this.textBox_ten1.TabIndex = 6;
            // 
            // contextMenuStrip_xemThongTinJewel
            // 
            this.contextMenuStrip_xemThongTinJewel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_xemThongTinJewel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemThôngTinToolStripMenuItem});
            this.contextMenuStrip_xemThongTinJewel.Name = "contextMenuStrip_xemThongTinJewel";
            this.contextMenuStrip_xemThongTinJewel.Size = new System.Drawing.Size(173, 28);
            // 
            // xemThôngTinToolStripMenuItem
            // 
            this.xemThôngTinToolStripMenuItem.Name = "xemThôngTinToolStripMenuItem";
            this.xemThôngTinToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.xemThôngTinToolStripMenuItem.Text = "Xem thông tin";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(975, 677);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAME BEJEWELED";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip_xemThongTinJewel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_JewelGrid;
        private System.Windows.Forms.Button button_saveGame;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_xemThongTinJewel;
        private System.Windows.Forms.ToolStripMenuItem xemThôngTinToolStripMenuItem;
        private System.Windows.Forms.Label label_tranDauHienTai;
        private System.Windows.Forms.TextBox textBox_ten2;
        private System.Windows.Forms.TextBox textBox_ten1;
    }
}

