using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    class Pole
    {
        private int poz_X_He;
        private int poz_Y_He;
        private int sirkaPole;
        private int vyskaPole;
        private bool jeAktivni;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush brWhite = new SolidBrush(Color.White);
        SolidBrush brGray = new SolidBrush(Color.Gray);

        public Pole(int poz_X_He, int poz_Y_He, int sirkaPole, int vyskaPole, bool jeAktivni)
        {
            this.poz_X_He = poz_X_He;
            this.poz_Y_He = poz_Y_He;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
            this.jeAktivni = jeAktivni;
        }
        
        public int Get_poz_X_He()
        {
            return poz_X_He;
        }

        public int Get_poz_Y_He()
        {
            return poz_Y_He;
        }

        public void Set_jeAktivni(bool jeAktivni)
        {
            this.jeAktivni = jeAktivni;
        }
        
        public void NakresliPole(PaintEventArgs e)
        {
            if(jeAktivni)
            {
                e.Graphics.FillEllipse(brWhite, this.poz_X_He, this.poz_Y_He, this.sirkaPole, this.vyskaPole);
            }
            else
            {
                e.Graphics.FillEllipse(brGray, this.poz_X_He, this.poz_Y_He, this.sirkaPole, this.vyskaPole);
            }
            e.Graphics.DrawEllipse(pen, this.poz_X_He, this.poz_Y_He, this.sirkaPole, this.vyskaPole);
        }
    }
}
