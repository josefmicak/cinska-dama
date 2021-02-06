namespace Čínská_dáma
{
    partial class HraForm
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
            this.kontrolniPanel = new System.Windows.Forms.Panel();
            this.zacitSimulaciButton = new System.Windows.Forms.Button();
            this.konecTahuPB = new System.Windows.Forms.PictureBox();
            this.pausePB = new System.Windows.Forms.PictureBox();
            this.zvukPB = new System.Windows.Forms.PictureBox();
            this.UkoncitPB = new System.Windows.Forms.PictureBox();
            this.restartPB = new System.Windows.Forms.PictureBox();
            this.konzolePanel = new System.Windows.Forms.Panel();
            this.Casovac = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nováHraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartovatHruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.návratDoMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ukončitAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pozastavitpokračovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecTahuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapnoutvypnoutZvukyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nápovědaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herniPanel = new Čínská_dáma.DoubleBufferedPanel();
            this.casLabel = new System.Windows.Forms.Label();
            this.pocetTahuLabel = new System.Windows.Forms.Label();
            this.kontrolniPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.konecTahuPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zvukPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UkoncitPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartPB)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.herniPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kontrolniPanel
            // 
            this.kontrolniPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.kontrolniPanel.Controls.Add(this.zacitSimulaciButton);
            this.kontrolniPanel.Controls.Add(this.konecTahuPB);
            this.kontrolniPanel.Controls.Add(this.pausePB);
            this.kontrolniPanel.Controls.Add(this.zvukPB);
            this.kontrolniPanel.Controls.Add(this.UkoncitPB);
            this.kontrolniPanel.Controls.Add(this.restartPB);
            this.kontrolniPanel.Location = new System.Drawing.Point(225, 839);
            this.kontrolniPanel.Name = "kontrolniPanel";
            this.kontrolniPanel.Size = new System.Drawing.Size(443, 86);
            this.kontrolniPanel.TabIndex = 5;
            // 
            // zacitSimulaciButton
            // 
            this.zacitSimulaciButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zacitSimulaciButton.Location = new System.Drawing.Point(128, 20);
            this.zacitSimulaciButton.Name = "zacitSimulaciButton";
            this.zacitSimulaciButton.Size = new System.Drawing.Size(194, 44);
            this.zacitSimulaciButton.TabIndex = 10;
            this.zacitSimulaciButton.Text = "Začít simulaci";
            this.zacitSimulaciButton.UseVisualStyleBackColor = true;
            this.zacitSimulaciButton.Visible = false;
            this.zacitSimulaciButton.Click += new System.EventHandler(this.ZacitSimulaciButton_Click);
            // 
            // konecTahuPB
            // 
            this.konecTahuPB.Enabled = false;
            this.konecTahuPB.Image = global::Čínská_dáma.Properties.Resources.konecTahuDisabled;
            this.konecTahuPB.Location = new System.Drawing.Point(267, 7);
            this.konecTahuPB.Name = "konecTahuPB";
            this.konecTahuPB.Size = new System.Drawing.Size(82, 72);
            this.konecTahuPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.konecTahuPB.TabIndex = 6;
            this.konecTahuPB.TabStop = false;
            this.konecTahuPB.EnabledChanged += new System.EventHandler(this.KonecTahuPB_EnabledChanged);
            this.konecTahuPB.Click += new System.EventHandler(this.KonecTahuPB_Click);
            // 
            // pausePB
            // 
            this.pausePB.Image = global::Čínská_dáma.Properties.Resources.pause;
            this.pausePB.Location = new System.Drawing.Point(3, 7);
            this.pausePB.Name = "pausePB";
            this.pausePB.Size = new System.Drawing.Size(82, 72);
            this.pausePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pausePB.TabIndex = 5;
            this.pausePB.TabStop = false;
            this.pausePB.Click += new System.EventHandler(this.PausePB_Click);
            // 
            // zvukPB
            // 
            this.zvukPB.Image = global::Čínská_dáma.Properties.Resources.zvukOn;
            this.zvukPB.Location = new System.Drawing.Point(355, 7);
            this.zvukPB.Name = "zvukPB";
            this.zvukPB.Size = new System.Drawing.Size(82, 72);
            this.zvukPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.zvukPB.TabIndex = 2;
            this.zvukPB.TabStop = false;
            this.zvukPB.Click += new System.EventHandler(this.ZvukPB_Click);
            // 
            // UkoncitPB
            // 
            this.UkoncitPB.Image = global::Čínská_dáma.Properties.Resources.ukoncit;
            this.UkoncitPB.Location = new System.Drawing.Point(179, 7);
            this.UkoncitPB.Name = "UkoncitPB";
            this.UkoncitPB.Size = new System.Drawing.Size(82, 72);
            this.UkoncitPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UkoncitPB.TabIndex = 4;
            this.UkoncitPB.TabStop = false;
            this.UkoncitPB.Click += new System.EventHandler(this.UkoncitPB_Click);
            // 
            // restartPB
            // 
            this.restartPB.Image = global::Čínská_dáma.Properties.Resources.restart;
            this.restartPB.Location = new System.Drawing.Point(91, 7);
            this.restartPB.Name = "restartPB";
            this.restartPB.Size = new System.Drawing.Size(82, 72);
            this.restartPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.restartPB.TabIndex = 3;
            this.restartPB.TabStop = false;
            this.restartPB.Click += new System.EventHandler(this.RestartPB_Click);
            // 
            // konzolePanel
            // 
            this.konzolePanel.BackColor = System.Drawing.Color.White;
            this.konzolePanel.Location = new System.Drawing.Point(143, 39);
            this.konzolePanel.Name = "konzolePanel";
            this.konzolePanel.Size = new System.Drawing.Size(600, 55);
            this.konzolePanel.TabIndex = 7;
            this.konzolePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.KonzolePanel_Paint);
            // 
            // Casovac
            // 
            this.Casovac.Interval = 1000;
            this.Casovac.Tick += new System.EventHandler(this.Casovac_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.hraToolStripMenuItem,
            this.nápovědaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nováHraToolStripMenuItem,
            this.restartovatHruToolStripMenuItem,
            this.návratDoMenuToolStripMenuItem,
            this.toolStripSeparator1,
            this.ukončitAplikaciToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // nováHraToolStripMenuItem
            // 
            this.nováHraToolStripMenuItem.Name = "nováHraToolStripMenuItem";
            this.nováHraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nováHraToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.nováHraToolStripMenuItem.Text = "Nová hra";
            this.nováHraToolStripMenuItem.Click += new System.EventHandler(this.NováHraToolStripMenuItem_Click);
            // 
            // restartovatHruToolStripMenuItem
            // 
            this.restartovatHruToolStripMenuItem.Name = "restartovatHruToolStripMenuItem";
            this.restartovatHruToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.restartovatHruToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.restartovatHruToolStripMenuItem.Text = "Restartovat hru";
            this.restartovatHruToolStripMenuItem.Click += new System.EventHandler(this.RestartovatHruToolStripMenuItem_Click);
            // 
            // návratDoMenuToolStripMenuItem
            // 
            this.návratDoMenuToolStripMenuItem.Name = "návratDoMenuToolStripMenuItem";
            this.návratDoMenuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.návratDoMenuToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.návratDoMenuToolStripMenuItem.Text = "Návrat do menu";
            this.návratDoMenuToolStripMenuItem.Click += new System.EventHandler(this.NávratDoMenuToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // ukončitAplikaciToolStripMenuItem
            // 
            this.ukončitAplikaciToolStripMenuItem.Name = "ukončitAplikaciToolStripMenuItem";
            this.ukončitAplikaciToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ukončitAplikaciToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.ukončitAplikaciToolStripMenuItem.Text = "Ukončit aplikaci";
            this.ukončitAplikaciToolStripMenuItem.Click += new System.EventHandler(this.UkončitAplikaciToolStripMenuItem_Click);
            // 
            // hraToolStripMenuItem
            // 
            this.hraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pozastavitpokračovatToolStripMenuItem,
            this.konecTahuToolStripMenuItem,
            this.zapnoutvypnoutZvukyToolStripMenuItem});
            this.hraToolStripMenuItem.Name = "hraToolStripMenuItem";
            this.hraToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.hraToolStripMenuItem.Text = "Hra";
            // 
            // pozastavitpokračovatToolStripMenuItem
            // 
            this.pozastavitpokračovatToolStripMenuItem.Name = "pozastavitpokračovatToolStripMenuItem";
            this.pozastavitpokračovatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pozastavitpokračovatToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.pozastavitpokračovatToolStripMenuItem.Text = "Pozastavit/pokračovat";
            this.pozastavitpokračovatToolStripMenuItem.Click += new System.EventHandler(this.PozastavitpokračovatToolStripMenuItem_Click);
            // 
            // konecTahuToolStripMenuItem
            // 
            this.konecTahuToolStripMenuItem.Name = "konecTahuToolStripMenuItem";
            this.konecTahuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.konecTahuToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.konecTahuToolStripMenuItem.Text = "Konec tahu";
            this.konecTahuToolStripMenuItem.Click += new System.EventHandler(this.KonecTahuToolStripMenuItem_Click);
            // 
            // zapnoutvypnoutZvukyToolStripMenuItem
            // 
            this.zapnoutvypnoutZvukyToolStripMenuItem.Name = "zapnoutvypnoutZvukyToolStripMenuItem";
            this.zapnoutvypnoutZvukyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.zapnoutvypnoutZvukyToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.zapnoutvypnoutZvukyToolStripMenuItem.Text = "Zapnout/vypnout zvuky";
            this.zapnoutvypnoutZvukyToolStripMenuItem.Click += new System.EventHandler(this.ZapnoutvypnoutZvukyToolStripMenuItem_Click);
            // 
            // nápovědaToolStripMenuItem
            // 
            this.nápovědaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oAplikaciToolStripMenuItem});
            this.nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            this.nápovědaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.nápovědaToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.nápovědaToolStripMenuItem.Text = "Nápověda";
            // 
            // oAplikaciToolStripMenuItem
            // 
            this.oAplikaciToolStripMenuItem.Name = "oAplikaciToolStripMenuItem";
            this.oAplikaciToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.oAplikaciToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.oAplikaciToolStripMenuItem.Text = "O aplikaci";
            this.oAplikaciToolStripMenuItem.Click += new System.EventHandler(this.OAplikaciToolStripMenuItem_Click);
            // 
            // herniPanel
            // 
            this.herniPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.herniPanel.Controls.Add(this.casLabel);
            this.herniPanel.Controls.Add(this.pocetTahuLabel);
            this.herniPanel.Location = new System.Drawing.Point(143, 115);
            this.herniPanel.Name = "herniPanel";
            this.herniPanel.Size = new System.Drawing.Size(600, 702);
            this.herniPanel.TabIndex = 4;
            this.herniPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HerniPanel_Paint);
            this.herniPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HerniPanel_MouseClick);
            // 
            // casLabel
            // 
            this.casLabel.AutoSize = true;
            this.casLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casLabel.Location = new System.Drawing.Point(517, 16);
            this.casLabel.Name = "casLabel";
            this.casLabel.Size = new System.Drawing.Size(71, 25);
            this.casLabel.TabIndex = 6;
            this.casLabel.Text = "00:00";
            // 
            // pocetTahuLabel
            // 
            this.pocetTahuLabel.AutoSize = true;
            this.pocetTahuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pocetTahuLabel.Location = new System.Drawing.Point(12, 16);
            this.pocetTahuLabel.Name = "pocetTahuLabel";
            this.pocetTahuLabel.Size = new System.Drawing.Size(152, 25);
            this.pocetTahuLabel.TabIndex = 2;
            this.pocetTahuLabel.Text = "Počet tahů: 0";
            // 
            // HraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(884, 960);
            this.Controls.Add(this.konzolePanel);
            this.Controls.Add(this.kontrolniPanel);
            this.Controls.Add(this.herniPanel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "HraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Čínská dáma - Hra";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HraForm_Paint);
            this.kontrolniPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.konecTahuPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zvukPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UkoncitPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartPB)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.herniPanel.ResumeLayout(false);
            this.herniPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DoubleBufferedPanel herniPanel;
        private System.Windows.Forms.Label casLabel;
        private System.Windows.Forms.Label pocetTahuLabel;
        private System.Windows.Forms.Panel kontrolniPanel;
        private System.Windows.Forms.PictureBox pausePB;
        private System.Windows.Forms.PictureBox zvukPB;
        private System.Windows.Forms.PictureBox UkoncitPB;
        private System.Windows.Forms.PictureBox restartPB;
        private System.Windows.Forms.Timer Casovac;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nováHraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartovatHruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem návratDoMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ukončitAplikaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pozastavitpokračovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecTahuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapnoutvypnoutZvukyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nápovědaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oAplikaciToolStripMenuItem;
        private System.Windows.Forms.PictureBox konecTahuPB;
        private System.Windows.Forms.Panel konzolePanel;
        private System.Windows.Forms.Button zacitSimulaciButton;
    }
}