using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    class ZvyrazneniPoleLidskehoHrace
    {
        private int poz_X_Zv;
        private int poz_Y_Zv;
        private int sirkaPole;
        private int vyskaPole;
        Pen pen = new Pen(Color.Black, 5);

        public ZvyrazneniPoleLidskehoHrace(int poz_X_Zv, int poz_Y_Zv, int sirkaPole, int vyskaPole)
        {
            this.poz_X_Zv = poz_X_Zv;
            this.poz_Y_Zv = poz_Y_Zv;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
        }

        public int Get_poz_X_Zv()
        {
            return poz_X_Zv;
        }

        public int Get_poz_Y_Zv()
        {
            return poz_Y_Zv;
        }

        public void NakresliZvyrazeneniPole(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(pen, this.poz_X_Zv, this.poz_Y_Zv, this.sirkaPole, this.vyskaPole);
        }
    }
}
