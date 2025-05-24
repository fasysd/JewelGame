namespace Project_JewelGame
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
            this.panel_JewelGrid = new System.Windows.Forms.Panel();
            this.button_saveGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_JewelGrid
            // 
            this.panel_JewelGrid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_JewelGrid.Location = new System.Drawing.Point(171, 12);
            this.panel_JewelGrid.Margin = new System.Windows.Forms.Padding(0);
            this.panel_JewelGrid.Name = "panel_JewelGrid";
            this.panel_JewelGrid.Size = new System.Drawing.Size(500, 500);
            this.panel_JewelGrid.TabIndex = 0;
            // 
            // button_saveGame
            // 
            this.button_saveGame.Location = new System.Drawing.Point(749, 125);
            this.button_saveGame.Name = "button_saveGame";
            this.button_saveGame.Size = new System.Drawing.Size(75, 23);
            this.button_saveGame.TabIndex = 1;
            this.button_saveGame.Text = "Save Game";
            this.button_saveGame.UseVisualStyleBackColor = true;
            this.button_saveGame.Click += new System.EventHandler(this.button_saveGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(880, 541);
            this.Controls.Add(this.button_saveGame);
            this.Controls.Add(this.panel_JewelGrid);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAME BEJEWELED";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_JewelGrid;
        private System.Windows.Forms.Button button_saveGame;
    }
}

