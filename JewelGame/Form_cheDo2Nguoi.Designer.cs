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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_cheDo2Nguoi));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_JewelGrid = new System.Windows.Forms.Panel();
            this.textDamage_player2 = new System.Windows.Forms.Label();
            this.textDamage_player1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Player1Health = new System.Windows.Forms.ProgressBar();
            this.player1Name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.player1SMana = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Cp1 = new System.Windows.Forms.Panel();
            this.label_hpPlayer1 = new System.Windows.Forms.Label();
            this.label_shieldPlayer1 = new System.Windows.Forms.Label();
            this.label_manaPlayer1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Cp2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.player2SMana = new System.Windows.Forms.Panel();
            this.Player2Health = new System.Windows.Forms.ProgressBar();
            this.player2Name = new System.Windows.Forms.Label();
            this.label_hpPlayer2 = new System.Windows.Forms.Label();
            this.label_shieldPlayer2 = new System.Windows.Forms.Label();
            this.label_manaPlayer2 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_JewelGrid.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 653);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_JewelGrid
            // 
            this.panel_JewelGrid.Controls.Add(this.textDamage_player2);
            this.panel_JewelGrid.Controls.Add(this.textDamage_player1);
            this.panel_JewelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_JewelGrid.Location = new System.Drawing.Point(198, 14);
            this.panel_JewelGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_JewelGrid.Name = "panel_JewelGrid";
            this.panel_JewelGrid.Size = new System.Drawing.Size(553, 625);
            this.panel_JewelGrid.TabIndex = 10;
            // 
            // textDamage_player2
            // 
            this.textDamage_player2.AutoSize = true;
            this.textDamage_player2.BackColor = System.Drawing.Color.Transparent;
            this.textDamage_player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDamage_player2.ForeColor = System.Drawing.Color.Red;
            this.textDamage_player2.Location = new System.Drawing.Point(416, 381);
            this.textDamage_player2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textDamage_player2.Name = "textDamage_player2";
            this.textDamage_player2.Size = new System.Drawing.Size(262, 39);
            this.textDamage_player2.TabIndex = 1;
            this.textDamage_player2.Text = "Text Damage 2";
            this.textDamage_player2.Visible = false;
            // 
            // textDamage_player1
            // 
            this.textDamage_player1.AutoSize = true;
            this.textDamage_player1.BackColor = System.Drawing.Color.Transparent;
            this.textDamage_player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDamage_player1.ForeColor = System.Drawing.Color.Red;
            this.textDamage_player1.Location = new System.Drawing.Point(4, 381);
            this.textDamage_player1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textDamage_player1.Name = "textDamage_player1";
            this.textDamage_player1.Size = new System.Drawing.Size(262, 39);
            this.textDamage_player1.TabIndex = 0;
            this.textDamage_player1.Text = "Text Damage 1";
            this.textDamage_player1.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.Player1Health, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.player1Name, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.label_hpPlayer1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label_shieldPlayer1, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label_manaPlayer1, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 8);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 14);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.00008F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.33007F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.83507F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.833154F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.001895F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.833154F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.001895F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.833154F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.33154F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(180, 625);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // Player1Health
            // 
            this.Player1Health.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player1Health.Location = new System.Drawing.Point(4, 266);
            this.Player1Health.Margin = new System.Windows.Forms.Padding(4);
            this.Player1Health.Name = "Player1Health";
            this.Player1Health.Size = new System.Drawing.Size(172, 15);
            this.Player1Health.TabIndex = 0;
            this.Player1Health.Value = 100;
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.player1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Name.Location = new System.Drawing.Point(4, 210);
            this.player1Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(172, 29);
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
            this.panel1.Location = new System.Drawing.Point(4, 314);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 15);
            this.panel1.TabIndex = 5;
            // 
            // player1SMana
            // 
            this.player1SMana.BackColor = System.Drawing.Color.White;
            this.player1SMana.Dock = System.Windows.Forms.DockStyle.Right;
            this.player1SMana.Location = new System.Drawing.Point(119, 0);
            this.player1SMana.Margin = new System.Windows.Forms.Padding(4);
            this.player1SMana.Name = "player1SMana";
            this.player1SMana.Size = new System.Drawing.Size(51, 13);
            this.player1SMana.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Cp1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 362);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 15);
            this.panel2.TabIndex = 7;
            // 
            // Cp1
            // 
            this.Cp1.BackColor = System.Drawing.Color.White;
            this.Cp1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Cp1.Location = new System.Drawing.Point(118, 0);
            this.Cp1.Margin = new System.Windows.Forms.Padding(4);
            this.Cp1.Name = "Cp1";
            this.Cp1.Size = new System.Drawing.Size(52, 13);
            this.Cp1.TabIndex = 0;
            // 
            // label_hpPlayer1
            // 
            this.label_hpPlayer1.AutoSize = true;
            this.label_hpPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hpPlayer1.ForeColor = System.Drawing.Color.Black;
            this.label_hpPlayer1.Location = new System.Drawing.Point(3, 239);
            this.label_hpPlayer1.Name = "label_hpPlayer1";
            this.label_hpPlayer1.Size = new System.Drawing.Size(37, 18);
            this.label_hpPlayer1.TabIndex = 8;
            this.label_hpPlayer1.Text = "HP: ";
            // 
            // label_shieldPlayer1
            // 
            this.label_shieldPlayer1.AutoSize = true;
            this.label_shieldPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_shieldPlayer1.Location = new System.Drawing.Point(3, 285);
            this.label_shieldPlayer1.Name = "label_shieldPlayer1";
            this.label_shieldPlayer1.Size = new System.Drawing.Size(52, 18);
            this.label_shieldPlayer1.TabIndex = 9;
            this.label_shieldPlayer1.Text = "Shield:";
            // 
            // label_manaPlayer1
            // 
            this.label_manaPlayer1.AutoSize = true;
            this.label_manaPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_manaPlayer1.Location = new System.Drawing.Point(3, 333);
            this.label_manaPlayer1.Name = "label_manaPlayer1";
            this.label_manaPlayer1.Size = new System.Drawing.Size(49, 18);
            this.label_manaPlayer1.TabIndex = 10;
            this.label_manaPlayer1.Text = "Mana:";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 384);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(174, 238);
            this.panel3.TabIndex = 12;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel6, 0, 8);
            this.tableLayoutPanel4.Controls.Add(this.panel5, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.Player2Health, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.player2Name, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label_hpPlayer2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label_shieldPlayer2, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label_manaPlayer2, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label_time, 0, 9);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(757, 14);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 10;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.99967F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.4597F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.847793F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.84587F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.847793F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.84587F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.847793F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.84587F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.45974F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.999907F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(182, 625);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 386);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(176, 171);
            this.panel6.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Purple;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.Cp2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 363);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(174, 16);
            this.panel5.TabIndex = 9;
            // 
            // Cp2
            // 
            this.Cp2.BackColor = System.Drawing.Color.White;
            this.Cp2.Dock = System.Windows.Forms.DockStyle.Right;
            this.Cp2.Location = new System.Drawing.Point(123, 0);
            this.Cp2.Margin = new System.Windows.Forms.Padding(4);
            this.Cp2.Name = "Cp2";
            this.Cp2.Size = new System.Drawing.Size(49, 14);
            this.Cp2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Blue;
            this.panel4.Controls.Add(this.player2SMana);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 315);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(174, 16);
            this.panel4.TabIndex = 7;
            // 
            // player2SMana
            // 
            this.player2SMana.BackColor = System.Drawing.Color.White;
            this.player2SMana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2SMana.Dock = System.Windows.Forms.DockStyle.Right;
            this.player2SMana.Location = new System.Drawing.Point(116, 0);
            this.player2SMana.Margin = new System.Windows.Forms.Padding(4);
            this.player2SMana.Name = "player2SMana";
            this.player2SMana.Size = new System.Drawing.Size(58, 16);
            this.player2SMana.TabIndex = 11;
            // 
            // Player2Health
            // 
            this.Player2Health.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player2Health.Location = new System.Drawing.Point(4, 267);
            this.Player2Health.Margin = new System.Windows.Forms.Padding(4);
            this.Player2Health.Name = "Player2Health";
            this.Player2Health.Size = new System.Drawing.Size(174, 16);
            this.Player2Health.TabIndex = 5;
            this.Player2Health.Value = 100;
            // 
            // player2Name
            // 
            this.player2Name.AutoSize = true;
            this.player2Name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.player2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Name.Location = new System.Drawing.Point(4, 210);
            this.player2Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(174, 29);
            this.player2Name.TabIndex = 4;
            this.player2Name.Text = "player2Name";
            this.player2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_hpPlayer2
            // 
            this.label_hpPlayer2.AutoSize = true;
            this.label_hpPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hpPlayer2.ForeColor = System.Drawing.Color.Black;
            this.label_hpPlayer2.Location = new System.Drawing.Point(3, 239);
            this.label_hpPlayer2.Name = "label_hpPlayer2";
            this.label_hpPlayer2.Size = new System.Drawing.Size(33, 18);
            this.label_hpPlayer2.TabIndex = 10;
            this.label_hpPlayer2.Text = "HP:";
            // 
            // label_shieldPlayer2
            // 
            this.label_shieldPlayer2.AutoSize = true;
            this.label_shieldPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_shieldPlayer2.Location = new System.Drawing.Point(3, 287);
            this.label_shieldPlayer2.Name = "label_shieldPlayer2";
            this.label_shieldPlayer2.Size = new System.Drawing.Size(52, 18);
            this.label_shieldPlayer2.TabIndex = 11;
            this.label_shieldPlayer2.Text = "Shield:";
            // 
            // label_manaPlayer2
            // 
            this.label_manaPlayer2.AutoSize = true;
            this.label_manaPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_manaPlayer2.Location = new System.Drawing.Point(3, 335);
            this.label_manaPlayer2.Name = "label_manaPlayer2";
            this.label_manaPlayer2.Size = new System.Drawing.Size(49, 18);
            this.label_manaPlayer2.TabIndex = 12;
            this.label_manaPlayer2.Text = "Mana:";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_time.Location = new System.Drawing.Point(4, 560);
            this.label_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(79, 36);
            this.label_time.TabIndex = 2;
            this.label_time.Text = "Time";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 121);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(4, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(174, 116);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // Form_cheDo2Nguoi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(975, 677);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "Form_cheDo2Nguoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAME BEJEWELED - CHẾ ĐỘ 2 NGƯỜI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_cheDo2Nguoi_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_JewelGrid.ResumeLayout(false);
            this.panel_JewelGrid.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.Label label_hpPlayer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_hpPlayer2;
        private System.Windows.Forms.Label label_shieldPlayer1;
        private System.Windows.Forms.Label label_manaPlayer1;
        private System.Windows.Forms.Label label_shieldPlayer2;
        private System.Windows.Forms.Label label_manaPlayer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label textDamage_player1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label textDamage_player2;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
    }
}

