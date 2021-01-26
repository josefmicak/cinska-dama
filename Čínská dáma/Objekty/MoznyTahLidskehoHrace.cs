using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    class MoznyTahLidskehoHrace
    {
        private int poz_X_MT;
        private int poz_Y_MT;
        private int poz_X_KLHr;
        private int poz_Y_KLHr;
        private int sirkaPole;
        private int vyskaPole;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush br = new SolidBrush(Color.Cyan);

        public MoznyTahLidskehoHrace(int poz_X_MT, int poz_Y_MT, int poz_X_KLHr, int poz_Y_KLHr, int sirkaPole, int vyskaPole)
        {
            this.poz_X_MT = poz_X_MT;
            this.poz_Y_MT = poz_Y_MT;
            this.poz_X_KLHr = poz_X_KLHr;
            this.poz_Y_KLHr = poz_Y_KLHr;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
        }

        public int get_poz_X_MT()
        {
            return poz_X_MT;
        }

        public int get_poz_Y_MT()
        {
            return poz_Y_MT;
        }

        public int get_poz_X_KLHr()
        {
            return poz_X_KLHr;
        }

        public int get_poz_Y_KLHr()
        {
            return poz_Y_KLHr;
        }

        public void NakreslimozneTahyLidskehoHrace(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(br, this.poz_X_MT, this.poz_Y_MT, this.sirkaPole, this.vyskaPole);
            e.Graphics.DrawEllipse(pen, this.poz_X_MT, this.poz_Y_MT, this.sirkaPole, this.vyskaPole);
        }
    }
}
