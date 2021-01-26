using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    class MoznyTahPocitacovehoHrace
    {
        private int poz_X_MT;
        private int poz_Y_MT;
        private int poz_X_KPHr;
        private int poz_Y_KPHr;
        private int sirkaPole;
        private int vyskaPole;
        private int idPocitacovehoHrace;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush br = new SolidBrush(Color.Cyan);

        public MoznyTahPocitacovehoHrace(int poz_X_MT, int poz_Y_MT, int poz_X_KPHr, int poz_Y_KPHr, int sirkaPole, int vyskaPole, int idPocitacovehoHrace)
        {
            this.poz_X_MT = poz_X_MT;
            this.poz_Y_MT = poz_Y_MT;
            this.poz_X_KPHr = poz_X_KPHr;
            this.poz_Y_KPHr = poz_Y_KPHr;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
            this.idPocitacovehoHrace = idPocitacovehoHrace;
        }

        public int get_poz_X_MT()
        {
            return poz_X_MT;
        }

        public int get_poz_Y_MT()
        {
            return poz_Y_MT;
        }

        public int get_poz_X_KPHr()
        {
            return poz_X_KPHr;
        }

        public int get_poz_Y_KPHr()
        {
            return poz_Y_KPHr;
        }

        public int get_idPocitacovehoHrace()
        {
            return idPocitacovehoHrace;
        }

        public void NakreslimozneTahyLidskehoHrace(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(br, this.poz_X_MT, this.poz_Y_MT, this.sirkaPole, this.vyskaPole);
            e.Graphics.DrawEllipse(pen, this.poz_X_MT, this.poz_Y_MT, this.sirkaPole, this.vyskaPole);
        }
    }
}
