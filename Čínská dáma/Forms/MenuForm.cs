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

        private void NovaHraButton_Click(object sender, EventArgs e)
        {
            new ParametryHryForm().Show();
            Hide();
        }

        private void MenuObrazekPB_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, menuObrazekPB.Width - 1, menuObrazekPB.Height - 1);
        }

        private void OHreButton_Click(object sender, EventArgs e)
        {
            new InformaceForm().Show();
        }

        private void ZavritButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void NováHraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ParametryHryForm().Show();
            Hide();
        }

        private void UkončitAplikaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OHřeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InformaceForm().Show();
        }

        private void SimulatorButton_Click(object sender, EventArgs e)
        {
            new Forms.ParametrySimulatoruForm().Show();
            Hide();
        }

        private void StatistikyButton_Click(object sender, EventArgs e)
        {
            new Forms.StatistikyForm().Show();
            Hide();
        }
    }
}
