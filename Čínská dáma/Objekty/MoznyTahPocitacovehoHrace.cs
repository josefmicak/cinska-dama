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
        private int idPocitacovehoHrace;

        public MoznyTahPocitacovehoHrace(int poz_X_MT, int poz_Y_MT, int poz_X_KPHr, int poz_Y_KPHr, int idPocitacovehoHrace)
        {
            this.poz_X_MT = poz_X_MT;
            this.poz_Y_MT = poz_Y_MT;
            this.poz_X_KPHr = poz_X_KPHr;
            this.poz_Y_KPHr = poz_Y_KPHr;
            this.idPocitacovehoHrace = idPocitacovehoHrace;
        }

        public int Get_poz_X_MT()
        {
            return poz_X_MT;
        }

        public int Get_poz_Y_MT()
        {
            return poz_Y_MT;
        }

        public int Get_poz_X_KPHr()
        {
            return poz_X_KPHr;
        }

        public int Get_poz_Y_KPHr()
        {
            return poz_Y_KPHr;
        }

        public int Get_idPocitacovehoHrace()
        {
            return idPocitacovehoHrace;
        }
    }
}
