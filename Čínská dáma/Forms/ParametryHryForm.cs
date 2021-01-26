using System;
using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    public partial class ParametryHryForm : Form
    {
        private int prvniTah = 0;
        private int pocetHracu = 0;
        private Pen pen = new Pen(Color.Black, 5);

        public ParametryHryForm()
        {
            InitializeComponent();
        }

        private void prvniHracPanel_Click(object sender, EventArgs e)
        {
            prvniTah = 1;
            prvniHracPanel.BackColor = Color.Cyan;
            prvniPocitacPanel.BackColor = Color.White;
            nahodnePanel.BackColor = Color.White;
        }

        private void prvniPocitacPanel_Click(object sender, EventArgs e)
        {
            prvniTah = 2;
            prvniHracPanel.BackColor = Color.White;
            prvniPocitacPanel.BackColor = Color.Cyan;
            nahodnePanel.BackColor = Color.White;
        }

        private void nahodnePanel_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            prvniTah = random.Next(1, 3);
            prvniHracPanel.BackColor = Color.White;
            prvniPocitacPanel.BackColor = Color.White;
            nahodnePanel.BackColor = Color.Cyan;
        }

        private void prvniHracLabel_Click(object sender, EventArgs e)
        {
            prvniHracPanel_Click(prvniHracPanel, EventArgs.Empty);
        }

        private void prvniPocitacLabel_Click(object sender, EventArgs e)
        {
            prvniPocitacPanel_Click(prvniPocitacPanel, EventArgs.Empty);
        }

        private void nahodneLabel_Click(object sender, EventArgs e)
        {
            nahodnePanel_Click(nahodnePanel, EventArgs.Empty);
        }

        private void ParametryHry_FormClosing(object sender, FormClosingEventArgs e)
        {
            pen.Dispose();
        }

        private void dvaHraciPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, dvaHraciPanel.Width - 1, dvaHraciPanel.Height - 1);
        }

        private void triHraciPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, triHraciPanel.Width - 1, triHraciPanel.Height - 1);
        }

        private void ctyriHraciPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, ctyriHraciPanel.Width - 1, ctyriHraciPanel.Height - 1);
        }

        private void sestHracuPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, sestHracuPanel.Width - 1, sestHracuPanel.Height - 1);
        }

        private void dvaHraciPanel_Click(object sender, EventArgs e)
        {
            pocetHracu = 2;
            dvaHraciPanel.BackColor = Color.Cyan;
            triHraciPanel.BackColor = Color.White;
            ctyriHraciPanel.BackColor = Color.White;
            sestHracuPanel.BackColor = Color.White;
        }

        private void dvaHraciPB_Click(object sender, EventArgs e)
        {
            dvaHraciPanel_Click(dvaHraciPanel, EventArgs.Empty);
        }

        private void dvaHraciLabel_Click(object sender, EventArgs e)
        {
            dvaHraciPanel_Click(dvaHraciPanel, EventArgs.Empty);
        }

        private void triHraciPanel_Click(object sender, EventArgs e)
        {
            pocetHracu = 3;
            dvaHraciPanel.BackColor = Color.White;
            triHraciPanel.BackColor = Color.Cyan;
            ctyriHraciPanel.BackColor = Color.White;
            sestHracuPanel.BackColor = Color.White;
        }

        private void triHraciPB_Click(object sender, EventArgs e)
        {
            triHraciPanel_Click(triHraciPanel, EventArgs.Empty);
        }

        private void triHraciLabel_Click(object sender, EventArgs e)
        {
            triHraciPanel_Click(triHraciPanel, EventArgs.Empty);
        }

        private void ctyriHraciPanel_Click(object sender, EventArgs e)
        {
            pocetHracu = 4;
            dvaHraciPanel.BackColor = Color.White;
            triHraciPanel.BackColor = Color.White;
            ctyriHraciPanel.BackColor = Color.Cyan;
            sestHracuPanel.BackColor = Color.White;
        }

        private void ctyriHraciPB_Click(object sender, EventArgs e)
        {
            ctyriHraciPanel_Click(ctyriHraciPanel, EventArgs.Empty);
        }

        private void ctyriHraciLabel_Click(object sender, EventArgs e)
        {
            ctyriHraciPanel_Click(ctyriHraciPanel, EventArgs.Empty);
        }

        private void sestHracuPanel_Click(object sender, EventArgs e)
        {
            pocetHracu = 6;
            dvaHraciPanel.BackColor = Color.White;
            triHraciPanel.BackColor = Color.White;
            ctyriHraciPanel.BackColor = Color.White;
            sestHracuPanel.BackColor = Color.Cyan;
        }

        private void sestHracuPB_Click(object sender, EventArgs e)
        {
            sestHracuPanel_Click(sestHracuPanel, EventArgs.Empty);
        }

        private void sestHracu_Click(object sender, EventArgs e)
        {
            sestHracuPanel_Click(sestHracuPanel, EventArgs.Empty);
        }

        private void zacitHruButton_Click(object sender, EventArgs e)
        {
            if(pocetHracu == 0 || prvniTah == 0)
            {
                MessageBox.Show("Nevybral jste počet hráčů nebo hráče s prvním tahem.\nProsím zvolte parametry hry.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int[] obtiznosti = new int[] { 0, 0};
                new HraForm(pocetHracu, prvniTah, obtiznostTB.Value, false, obtiznosti).Show();
                Close();
            }
        }

        private void prvniHracPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, prvniHracPanel.Width - 1, prvniHracPanel.Height - 1);
        }

        private void prvniPocitacPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, prvniPocitacPanel.Width - 1, prvniPocitacPanel.Height - 1);
        }

        private void nahodnePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, nahodnePanel.Width - 1, nahodnePanel.Height - 1);
        }
    }
}
