namespace Čínská_dáma
{
    partial class MenuForm
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
            this.novaHraButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nováHraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ukončitAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nápovědaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oHřeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObrazekPB = new System.Windows.Forms.PictureBox();
            this.oHreButton = new System.Windows.Forms.Button();
            this.zavritButton = new System.Windows.Forms.Button();
            this.simulatorButton = new System.Windows.Forms.Button();
            this.statistikyButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuObrazekPB)).BeginInit();
            this.SuspendLayout();
            // 
            // novaHraButton
            // 
            this.novaHraButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novaHraButton.Location = new System.Drawing.Point(340, 375);
            this.novaHraButton.Name = "novaHraButton";
            this.novaHraButton.Size = new System.Drawing.Size(108, 38);
            this.novaHraButton.TabIndex = 0;
            this.novaHraButton.Text = "Nová hra";
            this.novaHraButton.UseVisualStyleBackColor = true;
            this.novaHraButton.Click += new System.EventHandler(this.NovaHraButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.nápovědaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nováHraToolStripMenuItem,
            this.ukončitAplikaciToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // nováHraToolStripMenuItem
            // 
            this.nováHraToolStripMenuItem.Name = "nováHraToolStripMenuItem";
            this.nováHraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nováHraToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.nováHraToolStripMenuItem.Text = "Nová hra";
            this.nováHraToolStripMenuItem.Click += new System.EventHandler(this.NováHraToolStripMenuItem_Click);
            // 
            // ukončitAplikaciToolStripMenuItem
            // 
            this.ukončitAplikaciToolStripMenuItem.Name = "ukončitAplikaciToolStripMenuItem";
            this.ukončitAplikaciToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ukončitAplikaciToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.ukončitAplikaciToolStripMenuItem.Text = "Ukončit aplikaci";
            this.ukončitAplikaciToolStripMenuItem.Click += new System.EventHandler(this.UkončitAplikaciToolStripMenuItem_Click);
            // 
            // nápovědaToolStripMenuItem
            // 
            this.nápovědaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oHřeToolStripMenuItem});
            this.nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            this.nápovědaToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.nápovědaToolStripMenuItem.Text = "Nápověda";
            // 
            // oHřeToolStripMenuItem
            // 
            this.oHřeToolStripMenuItem.Name = "oHřeToolStripMenuItem";
            this.oHřeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.oHřeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.oHřeToolStripMenuItem.Text = "O hře";
            this.oHřeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.oHřeToolStripMenuItem.Click += new System.EventHandler(this.OHřeToolStripMenuItem_Click);
            // 
            // menuObrazekPB
            // 
            this.menuObrazekPB.Image = global::Čínská_dáma.Properties.Resources.MenuObrazek;
            this.menuObrazekPB.Location = new System.Drawing.Point(227, 37);
            this.menuObrazekPB.Name = "menuObrazekPB";
            this.menuObrazekPB.Size = new System.Drawing.Size(344, 316);
            this.menuObrazekPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuObrazekPB.TabIndex = 2;
            this.menuObrazekPB.TabStop = false;
            this.menuObrazekPB.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuObrazekPB_Paint);
            // 
            // oHreButton
            // 
            this.oHreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oHreButton.Location = new System.Drawing.Point(340, 525);
            this.oHreButton.Name = "oHreButton";
            this.oHreButton.Size = new System.Drawing.Size(108, 38);
            this.oHreButton.TabIndex = 3;
            this.oHreButton.Text = "O hře";
            this.oHreButton.UseVisualStyleBackColor = true;
            this.oHreButton.Click += new System.EventHandler(this.OHreButton_Click);
            // 
            // zavritButton
            // 
            this.zavritButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zavritButton.Location = new System.Drawing.Point(340, 575);
            this.zavritButton.Name = "zavritButton";
            this.zavritButton.Size = new System.Drawing.Size(108, 38);
            this.zavritButton.TabIndex = 4;
            this.zavritButton.Text = "Zavřít";
            this.zavritButton.UseVisualStyleBackColor = true;
            this.zavritButton.Click += new System.EventHandler(this.ZavritButton_Click);
            // 
            // simulatorButton
            // 
            this.simulatorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulatorButton.Location = new System.Drawing.Point(340, 425);
            this.simulatorButton.Name = "simulatorButton";
            this.simulatorButton.Size = new System.Drawing.Size(108, 38);
            this.simulatorButton.TabIndex = 5;
            this.simulatorButton.Text = "Simulátor";
            this.simulatorButton.UseVisualStyleBackColor = true;
            this.simulatorButton.Click += new System.EventHandler(this.SimulatorButton_Click);
            // 
            // statistikyButton
            // 
            this.statistikyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statistikyButton.Location = new System.Drawing.Point(340, 475);
            this.statistikyButton.Name = "statistikyButton";
            this.statistikyButton.Size = new System.Drawing.Size(108, 38);
            this.statistikyButton.TabIndex = 6;
            this.statistikyButton.Text = "Statistiky";
            this.statistikyButton.UseVisualStyleBackColor = true;
            this.statistikyButton.Click += new System.EventHandler(this.StatistikyButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.statistikyButton);
            this.Controls.Add(this.simulatorButton);
            this.Controls.Add(this.zavritButton);
            this.Controls.Add(this.oHreButton);
            this.Controls.Add(this.menuObrazekPB);
            this.Controls.Add(this.novaHraButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Čínská dáma - Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuObrazekPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button novaHraButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.PictureBox menuObrazekPB;
        private System.Windows.Forms.Button oHreButton;
        private System.Windows.Forms.Button zavritButton;
        private System.Windows.Forms.ToolStripMenuItem nováHraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ukončitAplikaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nápovědaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oHřeToolStripMenuItem;
        private System.Windows.Forms.Button simulatorButton;
        private System.Windows.Forms.Button statistikyButton;
    }
}

