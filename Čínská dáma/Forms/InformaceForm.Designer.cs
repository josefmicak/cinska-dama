﻿namespace Čínská_dáma
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
            this.zavritButton = new System.Windows.Forms.Button();
            this.pravidlaGB = new System.Windows.Forms.GroupBox();
            this.pravidlaTB = new System.Windows.Forms.TextBox();
            this.oAplikaciGB = new System.Windows.Forms.GroupBox();
            this.oAplikaciTB = new System.Windows.Forms.TextBox();
            this.ovladaniGB = new System.Windows.Forms.GroupBox();
            this.ovladaniTB = new System.Windows.Forms.TextBox();
            this.pravidlaGB.SuspendLayout();
            this.oAplikaciGB.SuspendLayout();
            this.ovladaniGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // zavritButton
            // 
            this.zavritButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zavritButton.Location = new System.Drawing.Point(313, 532);
            this.zavritButton.Name = "zavritButton";
            this.zavritButton.Size = new System.Drawing.Size(115, 38);
            this.zavritButton.TabIndex = 3;
            this.zavritButton.Text = "Zavřít";
            this.zavritButton.UseVisualStyleBackColor = true;
            this.zavritButton.Click += new System.EventHandler(this.pokracovatDoMenuButton_Click);
            // 
            // pravidlaGB
            // 
            this.pravidlaGB.Controls.Add(this.pravidlaTB);
            this.pravidlaGB.Location = new System.Drawing.Point(12, 13);
            this.pravidlaGB.Name = "pravidlaGB";
            this.pravidlaGB.Size = new System.Drawing.Size(723, 190);
            this.pravidlaGB.TabIndex = 4;
            this.pravidlaGB.TabStop = false;
            this.pravidlaGB.Text = "Pravidla";
            // 
            // pravidlaTB
            // 
            this.pravidlaTB.BackColor = System.Drawing.Color.White;
            this.pravidlaTB.Location = new System.Drawing.Point(17, 29);
            this.pravidlaTB.Multiline = true;
            this.pravidlaTB.Name = "pravidlaTB";
            this.pravidlaTB.ReadOnly = true;
            this.pravidlaTB.Size = new System.Drawing.Size(688, 140);
            this.pravidlaTB.TabIndex = 0;
            // 
            // oAplikaciGB
            // 
            this.oAplikaciGB.Controls.Add(this.oAplikaciTB);
            this.oAplikaciGB.Location = new System.Drawing.Point(12, 369);
            this.oAplikaciGB.Name = "oAplikaciGB";
            this.oAplikaciGB.Size = new System.Drawing.Size(723, 141);
            this.oAplikaciGB.TabIndex = 5;
            this.oAplikaciGB.TabStop = false;
            this.oAplikaciGB.Text = "O aplikaci";
            // 
            // oAplikaciTB
            // 
            this.oAplikaciTB.BackColor = System.Drawing.Color.White;
            this.oAplikaciTB.Location = new System.Drawing.Point(17, 29);
            this.oAplikaciTB.Multiline = true;
            this.oAplikaciTB.Name = "oAplikaciTB";
            this.oAplikaciTB.ReadOnly = true;
            this.oAplikaciTB.Size = new System.Drawing.Size(688, 102);
            this.oAplikaciTB.TabIndex = 0;
            // 
            // ovladaniGB
            // 
            this.ovladaniGB.Controls.Add(this.ovladaniTB);
            this.ovladaniGB.Location = new System.Drawing.Point(12, 218);
            this.ovladaniGB.Name = "ovladaniGB";
            this.ovladaniGB.Size = new System.Drawing.Size(723, 145);
            this.ovladaniGB.TabIndex = 5;
            this.ovladaniGB.TabStop = false;
            this.ovladaniGB.Text = "Ovládání";
            // 
            // ovladaniTB
            // 
            this.ovladaniTB.BackColor = System.Drawing.Color.White;
            this.ovladaniTB.Location = new System.Drawing.Point(17, 29);
            this.ovladaniTB.Multiline = true;
            this.ovladaniTB.Name = "ovladaniTB";
            this.ovladaniTB.ReadOnly = true;
            this.ovladaniTB.Size = new System.Drawing.Size(688, 102);
            this.ovladaniTB.TabIndex = 0;
            // 
            // InformaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 582);
            this.Controls.Add(this.ovladaniGB);
            this.Controls.Add(this.oAplikaciGB);
            this.Controls.Add(this.pravidlaGB);
            this.Controls.Add(this.zavritButton);
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

        private System.Windows.Forms.Button zavritButton;
        private System.Windows.Forms.GroupBox pravidlaGB;
        private System.Windows.Forms.TextBox pravidlaTB;
        private System.Windows.Forms.GroupBox oAplikaciGB;
        private System.Windows.Forms.TextBox oAplikaciTB;
        private System.Windows.Forms.GroupBox ovladaniGB;
        private System.Windows.Forms.TextBox ovladaniTB;
    }
}