using System;
using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    public partial class MenuForm : Form
    {
        private Pen pen = new Pen(Color.Black, 5);
        public MenuForm()
        {
            InitializeComponent();
        }

        private void novaHraButton_Click(object sender, EventArgs e)
        {
            new ParametryHryForm().Show();
            Hide();
        }

        private void menuObrazekPB_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, menuObrazekPB.Width - 1, menuObrazekPB.Height - 1);
        }

        private void oHreButton_Click(object sender, EventArgs e)
        {
            new InformaceForm().Show();
        }

        private void zavritButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void nováHraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ParametryHryForm().Show();
            Hide();
        }

        private void ukončitAplikaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void oHřeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InformaceForm().Show();
        }

        private void simulatorButton_Click(object sender, EventArgs e)
        {
            new Forms.ParametrySimulatoruForm().Show();
            Hide();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void statistikyButton_Click(object sender, EventArgs e)
        {
            new Forms.StatistikyForm().Show();
            Hide();
        }
    }
}
