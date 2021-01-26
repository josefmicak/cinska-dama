using System.Drawing;
using System.Windows.Forms;

namespace Čínská_dáma
{
    class VychoziPolePocitacovehoHrace
    {
        private int poz_X_VNT;
        private int poz_Y_VNT;
        private int sirkaPole;
        private int vyskaPole;
        private int idPocitacovehoHrace;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush brCyan = new SolidBrush(Color.Cyan);
        SolidBrush brSalmon = new SolidBrush(Color.Salmon);
        SolidBrush brPaleGreen = new SolidBrush(Color.PaleGreen);
        SolidBrush brKhaki = new SolidBrush(Color.PapayaWhip);
        SolidBrush brMagenta = new SolidBrush(Color.Magenta);
        SolidBrush brPeru = new SolidBrush(Color.BurlyWood);

        public VychoziPolePocitacovehoHrace(int poz_X_VNT, int poz_Y_VNT, int sirkaPole, int vyskaPole, int idPocitacovehoHrace)
        {
            this.poz_X_VNT = poz_X_VNT;
            this.poz_Y_VNT = poz_Y_VNT;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
            this.idPocitacovehoHrace = idPocitacovehoHrace;
        }

        public int get_idPocitacovehoHrace()
        {
            return idPocitacovehoHrace;
        }

        public void NakresliVychoziPolePocitacovehoHrace(PaintEventArgs e, int idPocitacovehoHrace)
        {
            switch (idPocitacovehoHrace)
            {
                case 0:
                    e.Graphics.FillEllipse(brCyan, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    break;
                case 2:
                    e.Graphics.FillEllipse(brSalmon, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    break;
                case 3:
                    e.Graphics.FillEllipse(brPaleGreen, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    break;
                case 4:
                    e.Graphics.FillEllipse(brKhaki, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    break;
                case 5:
                    e.Graphics.FillEllipse(brMagenta, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    break;
                case 6:
                    e.Graphics.FillEllipse(brPeru, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    e.Graphics.DrawEllipse(pen, this.poz_X_VNT, this.poz_Y_VNT, this.sirkaPole, this.vyskaPole);
                    break;
            }

        }
    }
}