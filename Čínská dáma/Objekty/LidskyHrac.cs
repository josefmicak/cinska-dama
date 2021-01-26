using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    class LidskyHrac
    {
        private int poz_X_LHr;
        private int poz_Y_LHr;
        private int sirkaPole;
        private int vyskaPole;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush br = new SolidBrush(Color.DodgerBlue);

        public LidskyHrac(int poz_X_LHr, int poz_Y_LHr, int sirkaPole, int vyskaPole)
        {
            this.poz_X_LHr = poz_X_LHr;
            this.poz_Y_LHr = poz_Y_LHr;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
        }
        
        public int get_poz_X_LHr()
        {
            return poz_X_LHr;
        }

        public int get_poz_Y_LHr()
        {
            return poz_Y_LHr;
        }
        
        public void NakresliLidskehoHrace(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(br, this.poz_X_LHr, this.poz_Y_LHr, this.sirkaPole, this.vyskaPole);
            e.Graphics.DrawEllipse(pen, this.poz_X_LHr, this.poz_Y_LHr, this.sirkaPole, this.vyskaPole);
        }
    }
}
