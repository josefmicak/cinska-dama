using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    class PocitacovyHrac
    {
        private int poz_X_PHr;
        private int poz_Y_PHr;
        private int sirkaPole;
        private int vyskaPole;
        private int idPocitacovehoHrace;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush brBlue = new SolidBrush(Color.DodgerBlue);
        SolidBrush brRed = new SolidBrush(Color.Red);
        SolidBrush brGreen = new SolidBrush(Color.LimeGreen);
        SolidBrush brYellow = new SolidBrush(Color.Yellow);
        SolidBrush brPurple = new SolidBrush(Color.Purple);
        SolidBrush brChocolate = new SolidBrush(Color.Chocolate);

        public PocitacovyHrac(int poz_X_PHr, int poz_Y_PHr, int sirkaPole, int vyskaPole, int idPocitacovehoHrace)
        {
            this.poz_X_PHr = poz_X_PHr;
            this.poz_Y_PHr = poz_Y_PHr;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
            this.idPocitacovehoHrace = idPocitacovehoHrace;
        }

        public int Get_poz_X_PHr()
        {
            return poz_X_PHr;
        }

        public int Get_poz_Y_PHr()
        {
            return poz_Y_PHr;
        }

        public int Get_idPocitacovehoHrace()
        {
            return idPocitacovehoHrace;
        }

        public void NakresliPocitacovehoHrace(PaintEventArgs e, int idPocitacovehoHrace)
        {
            switch(idPocitacovehoHrace)
            {
                case 0:
                    e.Graphics.FillEllipse(brBlue, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    break;
                case 2:
                    e.Graphics.FillEllipse(brRed, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    break;
                case 3:
                    e.Graphics.FillEllipse(brGreen, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    break;
                case 4:
                    e.Graphics.FillEllipse(brYellow, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    break;
                case 5:
                    e.Graphics.FillEllipse(brPurple, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    break;
                case 6:
                    e.Graphics.FillEllipse(brChocolate, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_PHr, this.poz_Y_PHr, this.sirkaPole, this.vyskaPole);
                    break;
            }
        }
    }
}
