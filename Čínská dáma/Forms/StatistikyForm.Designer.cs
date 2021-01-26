namespace Čínská_dáma.Forms
{
    partial class StatistikyForm
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
            this.menuButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.pocetHracu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocetTahu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obtiznosti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vitez = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pocetHracu,
            this.pocetTahu,
            this.obtiznosti,
            this.vitez});
            this.dataGridView1.Location = new System.Drawing.Point(24, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(876, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuButton
            // 
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.Location = new System.Drawing.Point(378, 247);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(172, 61);
            this.menuButton.TabIndex = 6;
            this.menuButton.Text = "Návrat do menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel.Location = new System.Drawing.Point(20, 28);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(39, 20);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "text";
            // 
            // pocetHracu
            // 
            this.pocetHracu.HeaderText = "Počet hráčů";
            this.pocetHracu.Name = "pocetHracu";
            this.pocetHracu.ReadOnly = true;
            // 
            // pocetTahu
            // 
            this.pocetTahu.HeaderText = "Počet tahů";
            this.pocetTahu.Name = "pocetTahu";
            this.pocetTahu.ReadOnly = true;
            // 
            // obtiznosti
            // 
            this.obtiznosti.HeaderText = "Obtížnosti";
            this.obtiznosti.Name = "obtiznosti";
            this.obtiznosti.ReadOnly = true;
            this.obtiznosti.Width = 460;
            // 
            // vitez
            // 
            this.vitez.HeaderText = "Vítěz";
            this.vitez.Name = "vitez";
            this.vitez.ReadOnly = true;
            this.vitez.Width = 150;
            // 
            // StatistikyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 329);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "StatistikyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistiky";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocetHracu;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocetTahu;
        private System.Windows.Forms.DataGridViewTextBoxColumn obtiznosti;
        private System.Windows.Forms.DataGridViewTextBoxColumn vitez;
    }
}