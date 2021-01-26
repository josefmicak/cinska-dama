using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Čínská_dáma
{
    public partial class HraForm : Form
    {
        private int pocetHracu;//počet hráčů včetně lidského hráče
        private int prvniTah;
        private int obtiznost;
        private bool simulaceMod;
        private int[] simulaceObtiznost = new int[2];
        private static int konzoleZprava = 2;
        private static int viteziciPocitacovyHrac;
        private bool kontumaceVyhra;
        private static int vypocetTahu;
        private int sekundy = 0, minuty = 0;

        private static bool prehravaniZvuku = true;

        private static Hra hra;

        public HraForm(int pocetHracu, int prvniTah, int obtiznost, bool simulaceMod, int[] simulaceObtiznost)
        {
            this.pocetHracu = pocetHracu;
            this.prvniTah = prvniTah;
            this.obtiznost = obtiznost;
            this.simulaceMod = simulaceMod;
            this.simulaceObtiznost = simulaceObtiznost;
            hra = new Hra(pocetHracu, prvniTah, obtiznost, simulaceMod, simulaceObtiznost);
            InitializeComponent();
            if(simulaceMod)
            {
                pausePB.Visible = false;
                restartPB.Visible = false;
                ukoncitPB.Visible = false;
                konecTahuPB.Visible = false;
                zvukPB.Visible = false;
                casLabel.Visible = false;
                zacitSimulaciButton.Visible = true;
            }
            hra.novaHra(herniPanel.Width, this);
            if(konzoleZprava == 7)
            {
                konzoleZprava = 2;
            }
        }

        private void HraForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 5);
            e.Graphics.DrawRectangle(pen, konzolePanel.Location.X - 4, konzolePanel.Location.Y - 4, konzolePanel.Width + 7, konzolePanel.Height + 7);
            e.Graphics.DrawRectangle(pen, herniPanel.Location.X - 4, herniPanel.Location.Y - 4, herniPanel.Width + 7, herniPanel.Height + 7);
            e.Graphics.DrawRectangle(pen, kontrolniPanel.Location.X - 4, kontrolniPanel.Location.Y - 4, kontrolniPanel.Width + 7, kontrolniPanel.Height + 7);
        }

        private void nakreslitSouradnice(PaintEventArgs e, List<Pole> herniPole)
        {
            int pozX, pozY, xc, yc;
            Font drawFont = new Font("Arial", 8);
            SolidBrush br2 = new SolidBrush(Color.Black);
            for (int i = 0; i < herniPole.Count; i++)
            {
                Pole pole = (Pole)herniPole[i];
                pozX = pole.get_poz_X_He();
                pozY = pole.get_poz_Y_He();
                xc = pozX + (35 / 2);
                yc = pozY + (35 / 2);

                e.Graphics.DrawString(pozX.ToString(), drawFont, br2, (float)pozX + 7, (float)pozY + 5);
                e.Graphics.DrawString(pozY.ToString(), drawFont, br2, (float)pozX + 7, (float)pozY + 15);

            //        e.Graphics.DrawString(xc.ToString(), drawFont, br2, (float)pozX + 7, (float)pozY + 5);
              //      e.Graphics.DrawString(yc.ToString(), drawFont, br2, (float)pozX + 7, (float)pozY + 15);
            }
            drawFont.Dispose();
            br2.Dispose();
        }

        private void herniPanel_Paint(object sender, PaintEventArgs e)
        {
            pocetTahuLabel.Text = "Počet tahů: " + hra.getPocetTahu();

            (List<Pole> herniPole, List<LidskyHrac> poleLidskehoHrace, List<PocitacovyHrac> polePocitacovehoHrace, List<MoznyTahLidskehoHrace> mozneTahyLidskehoHrace, ZvyrazneniPoleLidskehoHrace zvyrazneniPoleLidskehoHrace, List <ZvyrazneniPolePocitacovehoHrace> zvyrazneniPolePocitacovehoHrace, List<VychoziPolePocitacovehoHrace> vychoziPolePocitacovehoHrace) = hra.herniPrvky();

            foreach (Pole p in herniPole)
            {
                p.NakresliPole(e);
            }

            for (int i = 0; i < vychoziPolePocitacovehoHrace.Count; i++)
            {
                VychoziPolePocitacovehoHrace v = vychoziPolePocitacovehoHrace[i];
                int idPocitacovehoHrace = v.get_idPocitacovehoHrace();
                v.NakresliVychoziPolePocitacovehoHrace(e, idPocitacovehoHrace);
            }

            foreach (LidskyHrac h in poleLidskehoHrace)
            {
                h.NakresliLidskehoHrace(e);
            }

            for (int i = 0; i < polePocitacovehoHrace.Count; i++)
            {
                PocitacovyHrac p = polePocitacovehoHrace[i];
                int idPocitacovehoHrace = p.get_idPocitacovehoHrace();
                p.NakresliPocitacovehoHrace(e, idPocitacovehoHrace);
            }

            foreach (MoznyTahLidskehoHrace m in mozneTahyLidskehoHrace)
            {
                m.NakreslimozneTahyLidskehoHrace(e);
            }

            if(zvyrazneniPoleLidskehoHrace != null)
            {
                zvyrazneniPoleLidskehoHrace.NakresliZvyrazeneniPole(e);
            }

            foreach (ZvyrazneniPolePocitacovehoHrace z in zvyrazneniPolePocitacovehoHrace)
            {
                z.NakresliZvyrazeneniPole(e);
            }

        //    nakreslitSouradnice(e, herniPole); - není určeno pro hráče, funkce slouží k vývoji a nebude ve finální verzi zahrnuta
        }

        private void herniPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Casovac.Enabled = true;
            konzolePanel.Refresh();
            hra.panelKliknuti(e.X, e.Y, this);
            konzoleRefresh(vypocetTahu);
            herniPanel.Refresh();
            konzolePanel.Refresh();
        }

        public void konzoleRefresh(int vt)
        {
            vypocetTahu = vt;
            (konzoleZprava, viteziciPocitacovyHrac, kontumaceVyhra) = hra.getKonzoleZprava();
            konzolePanel.Refresh();
        }

        public void konecTahuButton()
        {
            konecTahuPB.Enabled = !konecTahuPB.Enabled;
        }

        private void pausePB_Click(object sender, EventArgs e)
        {
            Casovac.Enabled = !Casovac.Enabled;
            switch (konzoleZprava)
            {
                case 0:
                    pausePB.Image = Čínská_dáma.Properties.Resources.play;
                    herniPanel.MouseClick -= herniPanel_MouseClick;
                    konzoleZprava = 3;
                    break;
                case 3:
                    pausePB.Image = Čínská_dáma.Properties.Resources.pause;
                    herniPanel.MouseClick += herniPanel_MouseClick;
                    konzoleZprava = 0;
                    break;
            }
            konzolePanel.Refresh();
        }

        private void konzolePanel_Paint(object sender, PaintEventArgs e)
        {
            Font drawFont = new Font("Arial", 16);
            SolidBrush brBlack = new SolidBrush(Color.Black);
            
            switch (konzoleZprava)
            {
                case 1:
                    switch (vypocetTahu)
                    {
                        case 2:
                            e.Graphics.DrawString("Probíhá výpočet nejvýhodnějšího tahu pro červeného hráče.", drawFont, brBlack, 5, 15);
                            break;
                        case 3:
                            e.Graphics.DrawString("Probíhá výpočet nejvýhodnějšího tahu pro zeleného hráče.", drawFont, brBlack, 5, 15);
                            break;
                        case 4:
                            e.Graphics.DrawString("Probíhá výpočet nejvýhodnějšího tahu pro žlutého hráče.", drawFont, brBlack, 5, 15);
                            break;
                        case 5:
                            e.Graphics.DrawString("Probíhá výpočet nejvýhodnějšího tahu pro fialového hráče.", drawFont, brBlack, 5, 15);
                            break;
                        case 6:
                            e.Graphics.DrawString("Probíhá výpočet nejvýhodnějšího tahu pro hnědého hráče.", drawFont, brBlack, 5, 15);
                            break;
                    }
                    break;
                case 2:
                    if(simulaceMod)
                    {
                        e.Graphics.DrawString("Hra úspěšně vytvořena. Simulaci spustíte tlačítkem.", drawFont, brBlack, 45, 15);
                    }
                    else
                    {
                        if (prvniTah == 1)
                        {
                            e.Graphics.DrawString("Hra úspěšně vytvořena. První tah má lidský hráč.", drawFont, brBlack, 55, 15);
                        }
                        else
                        {
                            e.Graphics.DrawString("Hra úspěšně vytvořena. První tah mají počítačoví hráči.", drawFont, brBlack, 25, 15);
                        }
                    }
                    break;
                case 3:
                    e.Graphics.DrawString("Hra je pozastavena.", drawFont, brBlack, 200, 15);
                    break;
                case 4:
                    herniPanel.MouseClick -= herniPanel_MouseClick;
                    pausePB.Enabled = false;
                    Casovac.Enabled = false;
                    prehratZvuk(3);
                    if(!kontumaceVyhra)
                    {
                        e.Graphics.DrawString("Gratulujeme, vyhrál jste.", drawFont, brBlack, 180, 15);
                    }
                    else
                    {
                        e.Graphics.DrawString("Gratulujeme, vyhrál jste (kontumačně).", drawFont, brBlack, 120, 15);
                    }
                    break;
                case 5:
                    herniPanel.MouseClick -= herniPanel_MouseClick;
                    pausePB.Enabled = false;
                    Casovac.Enabled = false;
                    prehratZvuk(4);
                    switch (viteziciPocitacovyHrac)
                    {
                        case 2:
                            e.Graphics.DrawString("Bohužel, prohrál jste. Vyhrál nepřítel (hráč červený)", drawFont, brBlack, 55, 15);
                            break;
                        case 3:
                            e.Graphics.DrawString("Bohužel, prohrál jste. Vyhrál nepřítel (hráč zelený)", drawFont, brBlack, 55, 15);
                            break;
                        case 4:
                            e.Graphics.DrawString("Bohužel, prohrál jste. Vyhrál nepřítel (hráč žlutý)", drawFont, brBlack, 55, 15);
                            break;
                        case 5:
                            e.Graphics.DrawString("Bohužel, prohrál jste. Vyhrál nepřítel (hráč fialový)", drawFont, brBlack, 55, 15);
                            break;
                        case 6:
                            e.Graphics.DrawString("Bohužel, prohrál jste. Vyhrál nepřítel (hráč hnědý)", drawFont, brBlack, 55, 15);
                            break;
                    }
                    break;
                case 6:
                    herniPanel.MouseClick -= herniPanel_MouseClick;
                    pausePB.Enabled = false;
                    Casovac.Enabled = false;
                    prehratZvuk(5);
                    e.Graphics.DrawString("Hra skončila remízou.", drawFont, brBlack, 170, 15);
                    break;
                case 7:
                    herniPanel.Refresh();
                    string viteziciPocitacovyHracText = "";
                    switch (viteziciPocitacovyHrac)
                    {
                        case 0:
                            viteziciPocitacovyHracText = "modrý";
                            break;
                        case 2:
                            viteziciPocitacovyHracText = "červený";
                            break;
                        case 3:
                            viteziciPocitacovyHracText = "zelený";
                            break;
                        case 4:
                            viteziciPocitacovyHracText = "žlutý";
                            break;
                        case 5:
                            viteziciPocitacovyHracText = "fialový";
                            break;
                        case 6:
                            viteziciPocitacovyHracText = "hnědý";
                            break;
                        case 7:
                            viteziciPocitacovyHracText = "modrý";
                            break;
                    }
                    string vyslednyText = "Simulace ukončena, vyhrál hráč " + viteziciPocitacovyHracText;
                    if(kontumaceVyhra)
                    {
                        vyslednyText += "\nHráč vyhrál kontumačně.";
                    }
                    e.Graphics.DrawString("Simulace ukončena, vyhrál hráč " + viteziciPocitacovyHracText, drawFont, brBlack, 115, 15);
                    DialogResult result = MessageBox.Show(vyslednyText, "Simulace ukončena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        new MenuForm().Show();
                        Close();
                    }
                    break;
            }
        }

        private void restartPB_Click(object sender, EventArgs e)
        {
            int[] obtiznosti = new int[] { 0, 0 };
            if (konzoleZprava < 4)
            {
                DialogResult vysledek = MessageBox.Show("Restartováním hry bude současná hra ukončena. Chcete pokračovat?", "Restartování hry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (vysledek == DialogResult.Yes)
                {
                    new HraForm(pocetHracu, prvniTah, obtiznost, false, obtiznosti).Show();
                    Close();
                }
            }
            else
            {
                new HraForm(pocetHracu, prvniTah, obtiznost, false, obtiznosti).Show();
                Close();
            }
        }

        private void ukoncitPB_Click(object sender, EventArgs e)
        {
            if (konzoleZprava < 3)
            {
                DialogResult vysledek = MessageBox.Show("Ukončením hry a navrácením do menu bude současná hra ztracena. Chcete pokračovat?", "Ukončení hry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (vysledek == DialogResult.Yes)
                {
                    new MenuForm().Show();
                    Close();
                }
            }
            else
            {
                new MenuForm().Show();
                Close();
            }
        }

        private void konecTahuPB_Click(object sender, EventArgs e)
        {
            hra.konecTahu(this);
            herniPanel.Refresh();
        }

        private void konecTahuPB_EnabledChanged(object sender, EventArgs e)
        {
            if (konecTahuPB.Enabled)
            {
                konecTahuPB.Image = Čínská_dáma.Properties.Resources.konecTahuEnabled;
            }
            else
            {
                konecTahuPB.Image = Čínská_dáma.Properties.Resources.konecTahuDisabled;
            }
        }

        private void zvukPB_Click(object sender, EventArgs e)
        {
            if (prehravaniZvuku)
            {
                prehravaniZvuku = false;
                zvukPB.Image = Čínská_dáma.Properties.Resources.zvukOff;
            }
            else
            {
                prehravaniZvuku = true;
                zvukPB.Image = Čínská_dáma.Properties.Resources.zvukOn;
            }
        }

        public static void prehratZvuk(int idZvuku)
        {
            if(prehravaniZvuku)
            {
                switch (idZvuku)
                {
                    case 1:
                        SoundPlayer click = new SoundPlayer(Čínská_dáma.Properties.Resources.click);
                        click.Play();
                        break;
                    case 2:
                        SoundPlayer hracPohyb = new SoundPlayer(Čínská_dáma.Properties.Resources.hracPohyb);
                        hracPohyb.Play();
                        break;
                    case 3:
                        SoundPlayer vyhra = new SoundPlayer(Čínská_dáma.Properties.Resources.vyhra);
                        vyhra.Play();
                        break;
                    case 4:
                        SoundPlayer prohra = new SoundPlayer(Čínská_dáma.Properties.Resources.prohra);
                        prohra.Play();
                        break;
                    case 5:
                        SoundPlayer remiza = new SoundPlayer(Čínská_dáma.Properties.Resources.remiza);
                        remiza.Play();
                        break;
                }
            }
        }

        private void nováHraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult vysledek = MessageBox.Show("Vytvořením nové hry bude současná hra ztracena. Chcete pokračovat?", "Nová hra", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vysledek == DialogResult.Yes)
            {
                new ParametryHryForm().Show();
                Close();
            }
        }

        private void restartovatHruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartPB_Click(konecTahuPB, null);
        }

        private void návratDoMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ukoncitPB_Click(konecTahuPB, null);
        }

        private void ukončitAplikaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult vysledek = MessageBox.Show("Ukončením aplikace bude současná hra ztracena. Chcete pokračovat?", "Ukončit aplikaci", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vysledek == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void pozastavitpokračovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pausePB_Click(konecTahuPB, null);
        }

        private void konecTahuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (konecTahuPB.Enabled)
            {
                konecTahuPB_Click(konecTahuPB, null);
            }
        }

        private void zapnoutvypnoutZvukyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zvukPB_Click(konecTahuPB, null);
        }

        private void oAplikaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InformaceForm().Show();
        }

        private void zacitSimulaciButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; ; i++)
            {
                hra.pocitacovyHracPohyb(this);
                herniPanel.Refresh();
                if (konzoleZprava == 7)
                {
                    break;
                }
            }
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            sekundy++;
            if (sekundy == 60)
            {
                minuty++;
                sekundy = 0;
            }
            casLabel.Text = minuty.ToString("D2") + ":" + sekundy.ToString("D2");
        }
    }
}
