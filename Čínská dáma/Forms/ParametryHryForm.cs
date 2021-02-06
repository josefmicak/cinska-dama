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

        private void PrvniHracPanel_Click(object sender, EventArgs e)
        {
            prvniTah = 1;
            prvniHracPanel.BackColor = Color.Cyan;
            prvniPocitacPanel.BackColor = Color.White;
            nahodnePanel.BackColor = Color.White;
        }

        private void PrvniPocitacPanel_Click(object sender, EventArgs e)
        {
            prvniTah = 2;
            prvniHracPanel.BackColor = Color.White;
            prvniPocitacPanel.BackColor = Color.Cyan;
            nahodnePanel.BackColor = Color.White;
        }

        private void NahodnePanel_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            prvniTah = random.Next(1, 3);
            prvniHracPanel.BackColor = Color.White;
            prvniPocitacPanel.BackColor = Color.White;
            nahodnePanel.BackColor = Color.Cyan;
        }

        private void PrvniHracLabel_Click(object sender, EventArgs e)
        {
            PrvniHracPanel_Click(prvniHracPanel, EventArgs.Empty);
        }

        private void PrvniPocitacLabel_Click(object sender, EventArgs e)
        {
            PrvniPocitacPanel_Click(prvniPocitacPanel, EventArgs.Empty);
        }

        private void NahodneLabel_Click(object sender, EventArgs e)
        {
            NahodnePanel_Click(nahodnePanel, EventArgs.Empty);
        }

        private void DvaHraciPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, dvaHraciPanel.Width - 1, dvaHraciPanel.Height - 1);
        }

        private void TriHraciPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, triHraciPanel.Width - 1, triHraciPanel.Height - 1);
        }

        private void CtyriHraciPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, ctyriHraciPanel.Width - 1, ctyriHraciPanel.Height - 1);
        }

        private void SestHracuPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, sestHracuPanel.Width - 1, sestHracuPanel.Height - 1);
        }

        private void DvaHraciPanel_Click(object sender, EventArgs e)
        {
            pocetHracu = 2;
            dvaHraciPanel.BackColor = Color.Cyan;
            triHraciPanel.BackColor = Color.White;
            ctyriHraciPanel.BackColor = Color.White;
            sestHracuPanel.BackColor = Color.White;
        }

        private void DvaHraciPB_Click(object sender, EventArgs e)
        {
            DvaHraciPanel_Click(dvaHraciPanel, EventArgs.Empty);
        }

        private void DvaHraciLabel_Click(object sender, EventArgs e)
        {
            DvaHraciPanel_Click(dvaHraciPanel, EventArgs.Empty);
        }

        private void TriHraciPanel_Click(object sender, EventArgs e)
        {
            pocetHracu = 3;
            dvaHraciPanel.BackColor = Color.White;
            triHraciPanel.BackColor = Color.Cyan;
            ctyriHraciPanel.BackColor = Color.White;
            sestHracuPanel.BackColor = Color.White;
        }

        private void TriHraciPB_Click(object sender, EventArgs e)
        {
            TriHraciPanel_Click(triHraciPanel, EventArgs.Empty);
        }

        private void TriHraciLabel_Click(object sender, EventArgs e)
        {
            TriHraciPanel_Click(triHraciPanel, EventArgs.Empty);
        }

        private void CtyriHraciPanel_Click(object sender, EventArgs e)
        {
            pocetHracu = 4;
            dvaHraciPanel.BackColor = Color.White;
            triHraciPanel.BackColor = Color.White;
            ctyriHraciPanel.BackColor = Color.Cyan;
            sestHracuPanel.BackColor = Color.White;
        }

        private void CtyriHraciPB_Click(object sender, EventArgs e)
        {
            CtyriHraciPanel_Click(ctyriHraciPanel, EventArgs.Empty);
        }

        private void CtyriHraciLabel_Click(object sender, EventArgs e)
        {
            CtyriHraciPanel_Click(ctyriHraciPanel, EventArgs.Empty);
        }

        private void SestHracuPanel_Click(object sender, EventArgs e)
        {
            pocetHracu = 6;
            dvaHraciPanel.BackColor = Color.White;
            triHraciPanel.BackColor = Color.White;
            ctyriHraciPanel.BackColor = Color.White;
            sestHracuPanel.BackColor = Color.Cyan;
        }

        private void SestHracuPB_Click(object sender, EventArgs e)
        {
            SestHracuPanel_Click(sestHracuPanel, EventArgs.Empty);
        }

        private void SestHracu_Click(object sender, EventArgs e)
        {
            SestHracuPanel_Click(sestHracuPanel, EventArgs.Empty);
        }

        private void ZacitHruButton_Click(object sender, EventArgs e)
        {
            if(pocetHracu == 0 || prvniTah == 0)
            {
                MessageBox.Show("Nevybral jste počet hráčů nebo hráče s prvním tahem.\nProsím zvolte parametry hry.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int[] obtiznosti = new int[] { 0, 0};
                new HraForm(pocetHracu, prvniTah, obtiznostTB.Value, false, obtiznosti, false, 0).Show();
                Close();
            }
        }

        private void PrvniHracPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, prvniHracPanel.Width - 1, prvniHracPanel.Height - 1);
        }

        private void PrvniPocitacPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, prvniPocitacPanel.Width - 1, prvniPocitacPanel.Height - 1);
        }

        private void NahodnePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, nahodnePanel.Width - 1, nahodnePanel.Height - 1);
        }
    }
}
