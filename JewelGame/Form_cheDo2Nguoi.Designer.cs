namespace JewelGame
{
    partial class Form_cheDo2Nguoi
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_JewelGrid = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Player1Health = new System.Windows.Forms.ProgressBar();
            this.player1Name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.player1SMana = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Cp1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Cp2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.player2SMana = new System.Windows.Forms.Panel();
            this.Player2Health = new System.Windows.Forms.ProgressBar();
            this.player2Name = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 513);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_JewelGrid
            // 
            this.panel_JewelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_JewelGrid.Location = new System.Drawing.Point(225, 13);
            this.panel_JewelGrid.Name = "panel_JewelGrid";
            this.panel_JewelGrid.Size = new System.Drawing.Size(632, 487);
            this.panel_JewelGrid.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.Player1Health, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.player1Name, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(206, 487);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // Player1Health
            // 
            this.Player1Health.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player1Health.Location = new System.Drawing.Point(4, 215);
            this.Player1Health.Margin = new System.Windows.Forms.Padding(4);
            this.Player1Health.Name = "Player1Health";
            this.Player1Health.Size = new System.Drawing.Size(198, 13);
            this.Player1Health.TabIndex = 0;
            this.Player1Health.Value = 100;
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.player1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Name.Location = new System.Drawing.Point(4, 182);
            this.player1Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(198, 29);
            this.player1Name.TabIndex = 2;
            this.player1Name.Text = "player1Name";
            this.player1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.player1SMana);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 236);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 13);
            this.panel1.TabIndex = 5;
            // 
            // player1SMana
            // 
            this.player1SMana.BackColor = System.Drawing.Color.White;
            this.player1SMana.Dock = System.Windows.Forms.DockStyle.Right;
            this.player1SMana.Location = new System.Drawing.Point(145, 0);
            this.player1SMana.Margin = new System.Windows.Forms.Padding(4);
            this.player1SMana.Name = "player1SMana";
            this.player1SMana.Size = new System.Drawing.Size(51, 11);
            this.player1SMana.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.Controls.Add(this.Cp1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 257);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 13);
            this.panel2.TabIndex = 7;
            // 
            // Cp1
            // 
            this.Cp1.BackColor = System.Drawing.Color.White;
            this.Cp1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Cp1.Location = new System.Drawing.Point(146, 0);
            this.Cp1.Margin = new System.Windows.Forms.Padding(4);
            this.Cp1.Name = "Cp1";
            this.Cp1.Size = new System.Drawing.Size(52, 13);
            this.Cp1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel5, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.Player2Health, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.player2Name, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(863, 13);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(208, 487);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Purple;
            this.panel5.Controls.Add(this.Cp2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 257);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 13);
            this.panel5.TabIndex = 9;
            // 
            // Cp2
            // 
            this.Cp2.BackColor = System.Drawing.Color.White;
            this.Cp2.Dock = System.Windows.Forms.DockStyle.Right;
            this.Cp2.Location = new System.Drawing.Point(150, 0);
            this.Cp2.Margin = new System.Windows.Forms.Padding(4);
            this.Cp2.Name = "Cp2";
            this.Cp2.Size = new System.Drawing.Size(50, 13);
            this.Cp2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Blue;
            this.panel4.Controls.Add(this.player2SMana);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 236);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 13);
            this.panel4.TabIndex = 7;
            // 
            // player2SMana
            // 
            this.player2SMana.BackColor = System.Drawing.Color.White;
            this.player2SMana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2SMana.Dock = System.Windows.Forms.DockStyle.Right;
            this.player2SMana.Location = new System.Drawing.Point(142, 0);
            this.player2SMana.Margin = new System.Windows.Forms.Padding(4);
            this.player2SMana.Name = "player2SMana";
            this.player2SMana.Size = new System.Drawing.Size(58, 13);
            this.player2SMana.TabIndex = 11;
            // 
            // Player2Health
            // 
            this.Player2Health.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player2Health.Location = new System.Drawing.Point(4, 215);
            this.Player2Health.Margin = new System.Windows.Forms.Padding(4);
            this.Player2Health.Name = "Player2Health";
            this.Player2Health.Size = new System.Drawing.Size(200, 13);
            this.Player2Health.TabIndex = 5;
            this.Player2Health.Value = 100;
            // 
            // player2Name
            // 
            this.player2Name.AutoSize = true;
            this.player2Name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.player2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Name.Location = new System.Drawing.Point(4, 182);
            this.player2Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(200, 29);
            this.player2Name.TabIndex = 4;
            this.player2Name.Text = "player2Name";
            this.player2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_cheDo2Nguoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 537);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_cheDo2Nguoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_JewelGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ProgressBar Player1Health;
        private System.Windows.Forms.Label player1Name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel player1SMana;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Cp1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel Cp2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel player2SMana;
        private System.Windows.Forms.ProgressBar Player2Health;
        private System.Windows.Forms.Label player2Name;
    }
}

