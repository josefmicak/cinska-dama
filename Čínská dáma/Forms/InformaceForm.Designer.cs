namespace Čínská_dáma
{
    partial class InformaceForm
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
            this.ZavritButton = new System.Windows.Forms.Button();
            this.pravidlaGB = new System.Windows.Forms.GroupBox();
            this.PravidlaTB = new System.Windows.Forms.TextBox();
            this.oAplikaciGB = new System.Windows.Forms.GroupBox();
            this.OAplikaciTB = new System.Windows.Forms.TextBox();
            this.ovladaniGB = new System.Windows.Forms.GroupBox();
            this.OvladaniTB = new System.Windows.Forms.TextBox();
            this.pravidlaGB.SuspendLayout();
            this.oAplikaciGB.SuspendLayout();
            this.ovladaniGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // ZavritButton
            // 
            this.ZavritButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZavritButton.Location = new System.Drawing.Point(313, 532);
            this.ZavritButton.Name = "ZavritButton";
            this.ZavritButton.Size = new System.Drawing.Size(115, 38);
            this.ZavritButton.TabIndex = 3;
            this.ZavritButton.Text = "Zavřít";
            this.ZavritButton.UseVisualStyleBackColor = true;
            this.ZavritButton.Click += new System.EventHandler(this.PokracovatDoMenuButton_Click);
            // 
            // pravidlaGB
            // 
            this.pravidlaGB.Controls.Add(this.PravidlaTB);
            this.pravidlaGB.Location = new System.Drawing.Point(12, 13);
            this.pravidlaGB.Name = "pravidlaGB";
            this.pravidlaGB.Size = new System.Drawing.Size(723, 190);
            this.pravidlaGB.TabIndex = 4;
            this.pravidlaGB.TabStop = false;
            this.pravidlaGB.Text = "Pravidla";
            // 
            // PravidlaTB
            // 
            this.PravidlaTB.BackColor = System.Drawing.Color.White;
            this.PravidlaTB.Location = new System.Drawing.Point(17, 29);
            this.PravidlaTB.Multiline = true;
            this.PravidlaTB.Name = "PravidlaTB";
            this.PravidlaTB.ReadOnly = true;
            this.PravidlaTB.Size = new System.Drawing.Size(688, 140);
            this.PravidlaTB.TabIndex = 0;
            // 
            // oAplikaciGB
            // 
            this.oAplikaciGB.Controls.Add(this.OAplikaciTB);
            this.oAplikaciGB.Location = new System.Drawing.Point(12, 369);
            this.oAplikaciGB.Name = "oAplikaciGB";
            this.oAplikaciGB.Size = new System.Drawing.Size(723, 141);
            this.oAplikaciGB.TabIndex = 5;
            this.oAplikaciGB.TabStop = false;
            this.oAplikaciGB.Text = "O aplikaci";
            // 
            // OAplikaciTB
            // 
            this.OAplikaciTB.BackColor = System.Drawing.Color.White;
            this.OAplikaciTB.Location = new System.Drawing.Point(17, 29);
            this.OAplikaciTB.Multiline = true;
            this.OAplikaciTB.Name = "OAplikaciTB";
            this.OAplikaciTB.ReadOnly = true;
            this.OAplikaciTB.Size = new System.Drawing.Size(688, 102);
            this.OAplikaciTB.TabIndex = 0;
            // 
            // ovladaniGB
            // 
            this.ovladaniGB.Controls.Add(this.OvladaniTB);
            this.ovladaniGB.Location = new System.Drawing.Point(12, 218);
            this.ovladaniGB.Name = "ovladaniGB";
            this.ovladaniGB.Size = new System.Drawing.Size(723, 145);
            this.ovladaniGB.TabIndex = 5;
            this.ovladaniGB.TabStop = false;
            this.ovladaniGB.Text = "Ovládání";
            // 
            // OvladaniTB
            // 
            this.OvladaniTB.BackColor = System.Drawing.Color.White;
            this.OvladaniTB.Location = new System.Drawing.Point(17, 29);
            this.OvladaniTB.Multiline = true;
            this.OvladaniTB.Name = "OvladaniTB";
            this.OvladaniTB.ReadOnly = true;
            this.OvladaniTB.Size = new System.Drawing.Size(688, 102);
            this.OvladaniTB.TabIndex = 0;
            // 
            // InformaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 582);
            this.Controls.Add(this.ovladaniGB);
            this.Controls.Add(this.oAplikaciGB);
            this.Controls.Add(this.pravidlaGB);
            this.Controls.Add(this.ZavritButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InformaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Čínská dáma - O hře Čínská dáma";
            this.pravidlaGB.ResumeLayout(false);
            this.pravidlaGB.PerformLayout();
            this.oAplikaciGB.ResumeLayout(false);
            this.oAplikaciGB.PerformLayout();
            this.ovladaniGB.ResumeLayout(false);
            this.ovladaniGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ZavritButton;
        private System.Windows.Forms.GroupBox pravidlaGB;
        private System.Windows.Forms.TextBox PravidlaTB;
        private System.Windows.Forms.GroupBox oAplikaciGB;
        private System.Windows.Forms.TextBox OAplikaciTB;
        private System.Windows.Forms.GroupBox ovladaniGB;
        private System.Windows.Forms.TextBox OvladaniTB;
    }
}