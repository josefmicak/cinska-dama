using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Čínská_dáma
{
    class Hra
    {
        private int pocetHracu;//počet hráčů včetně lidského hráče
        private int prvniTah;
        private int obtiznost;
        private bool simulaceMod;
        private int[] simulaceObtiznost = { };
        private static int sirkaPole = 35;
        private static int vyskaPole = 35;
        private int horniOdsazeni = 13;//odsazení prvního herního pole od horní hranice panelu
        private int leveOdsazeni;
        private static int posun = 40;//vzdálenost mezi jednotlivými herními poli
        private int pocetPoli = 121;
        private int pocetTahu = 0;
        private static int konzoleZprava;
        private static int viteziciPocitacovyHrac;
        private bool kliknutMoznyTah = false;
        private bool hracProvedlSkok = false;
        private int kontumaceVyhraHrac = 0;
        private bool kontumaceVyhra;

        private List<Pole> herniPole = new List<Pole>();//všechna herní pole (121)
        private List<LidskyHrac> poleLidskehoHrace = new List<LidskyHrac>();//všechna hráčova pole (10)
        private List<PocitacovyHrac> polePocitacovehoHrace = new List<PocitacovyHrac>();//všechna nepřítelova pole (10 - 50)
        private List<MoznyTahLidskehoHrace> mozneTahyLidskehoHrace = new List<MoznyTahLidskehoHrace>();//všechna pole kam se hráč může z daného místa pohnout
        private List<MoznyTahPocitacovehoHrace> mozneTahyPocitacovehoHrace = new List<MoznyTahPocitacovehoHrace>();//všechna pole kam se nepřítel může z daného místa pohnout
        private List<VychoziPolePocitacovehoHrace> vychoziPolePocitacovehoHrace = new List<VychoziPolePocitacovehoHrace>();//vyznačí pole, ze kterého nepřítel táhl
        private ZvyrazneniPoleLidskehoHrace zvyrazneniPoleLidskehoHrace;
        private List<ZvyrazneniPolePocitacovehoHrace> zvyraznenaPolePocitacovehoHrace = new List<ZvyrazneniPolePocitacovehoHrace>();//zvýrazní pole, na která táhli počítačoví hráči

        public Hra(int pocetHracu, int prvniTah, int obtiznost, bool simulaceMod, int[] simulaceObtiznost)
        {
            this.pocetHracu = pocetHracu;
            this.prvniTah = prvniTah;
            this.obtiznost = obtiznost;
            this.simulaceMod = simulaceMod;
            this.simulaceObtiznost = simulaceObtiznost;
            if (konzoleZprava == 7)
            {
                konzoleZprava = 2;
            }
        }

        public (List<Pole>, List<LidskyHrac>, List<PocitacovyHrac>, List<MoznyTahLidskehoHrace>, ZvyrazneniPoleLidskehoHrace, List<ZvyrazneniPolePocitacovehoHrace>, List<VychoziPolePocitacovehoHrace>) herniPrvky()
        {
            return (herniPole, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, zvyrazneniPoleLidskehoHrace, zvyraznenaPolePocitacovehoHrace, vychoziPolePocitacovehoHrace);
        }

        public void novaHra(int sirkaPanelu, HraForm hraform)//vytvoří herní, hráčova a nepřítelova pole na předem dané pozice
        {
            //reset parametrů předchozí hry
            viteziciPocitacovyHrac = 0;
            kontumaceVyhraHrac = 0;
            kontumaceVyhra = false;

            leveOdsazeni = (sirkaPanelu / 2) - (sirkaPole / 2);

            int poz_X_He = leveOdsazeni;
            int poz_Y_He = horniOdsazeni;

            for (int i = 0; i < pocetPoli; i++)
            {
                Pole pole = new Pole(poz_X_He, poz_Y_He, sirkaPole, vyskaPole, true);
                herniPole.Add(pole);
                switch (i)
                {
                    case 0:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + posun;
                        break;
                    case 2:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 2);
                        break;
                    case 5:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 3);
                        break;
                    case 9:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 8);
                        break;
                    case 22:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 12);
                        break;
                    case 34:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 11);
                        break;
                    case 45:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 10);
                        break;
                    case 55:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 9);
                        break;
                    case 64:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 9);
                        break;
                    case 74:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 10);
                        break;
                    case 85:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 11);
                        break;
                    case 97:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 12);
                        break;
                    case 110:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 8);
                        break;
                    case 114:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 3);
                        break;
                    case 117:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + (posun * 2);
                        break;
                    case 119:
                        poz_Y_He += posun;
                        poz_X_He -= (posun / 2) + posun;
                        break;
                }
                poz_X_He += posun;
            }

            for (int i = 0; i < herniPole.Count; i++)
            {
                Pole pole = herniPole[i];
                poz_X_He = pole.get_poz_X_He();
                poz_Y_He = pole.get_poz_Y_He();

                if(!simulaceMod)
                {
                    if (pocetHracu != 4)
                    {
                        if (poz_Y_He >= posun * 13 + horniOdsazeni && poleLidskehoHrace.Count < 10)
                        {
                            LidskyHrac lidskyHrac = new LidskyHrac(poz_X_He, poz_Y_He, sirkaPole, vyskaPole);
                            poleLidskehoHrace.Add(lidskyHrac);
                        }
                    }
                    else
                    {
                        if ((poz_Y_He == posun * 9 + horniOdsazeni && poz_X_He == leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_He == posun * 10 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 4) || (poz_Y_He == posun * 11 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_He == posun * 12 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 3) && poleLidskehoHrace.Count < 10)
                        {
                            LidskyHrac lidskyHrac = new LidskyHrac(poz_X_He, poz_Y_He, sirkaPole, vyskaPole);
                            poleLidskehoHrace.Add(lidskyHrac);
                        }
                    }
                }

                //zašedění neaktivních polí
                if((pocetHracu == 2 && (jePoleVHornimLevemRohu(poz_X_He, poz_Y_He) || jePoleVHornimPravemRohu(poz_X_He, poz_Y_He) || jePoleVSpodnimLevemRohu(poz_X_He, poz_Y_He) || jePoleVSpodnimPravemRohu(poz_X_He, poz_Y_He))) ||
                    (pocetHracu == 4 && (jePoleVNejnizsimRohu(poz_X_He, poz_Y_He) || jePoleVNejvyssimRohu(poz_X_He, poz_Y_He))))
                {
                    herniPole[i].set_jeAktivni(false);
                }

                for (int n = 0; n <= 6; n++)
                {
                    if ((pocetHracu == 2 && ((n > 2) || ((!simulaceMod && polePocitacovehoHrace.Count == 10) || (simulaceMod && polePocitacovehoHrace.Count == 20)))) || (pocetHracu == 3 && ((n == 2 || n > 4) || (!simulaceMod && polePocitacovehoHrace.Count == 20) || (simulaceMod && polePocitacovehoHrace.Count == 30))) || (pocetHracu == 4 && ((n == 2 || (!simulaceMod && n == 5) || (simulaceMod && n == 0)) || (!simulaceMod && polePocitacovehoHrace.Count == 30) || (simulaceMod && polePocitacovehoHrace.Count == 40))) || (pocetHracu == 6 && (!simulaceMod && polePocitacovehoHrace.Count == 50) || (simulaceMod && polePocitacovehoHrace.Count == 60)))
                    {
                        continue;
                    }
                    if ((n == 0 && poz_Y_He >= posun * 13 + horniOdsazeni && simulaceMod) ||
                        (n == 2 && poz_Y_He <= posun * 3 + horniOdsazeni) ||
                        (n == 3 && ((poz_Y_He == posun * 4 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 3) || (poz_Y_He == posun * 5 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_He == posun * 6 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 4) || (poz_Y_He == posun * 7 + horniOdsazeni && poz_X_He == leveOdsazeni - posun * 4 - posun / 2))) ||
                        (n == 4 && ((poz_Y_He == posun * 4 + horniOdsazeni && poz_X_He >= leveOdsazeni + posun * 3) || (poz_Y_He == posun * 5 + horniOdsazeni && poz_X_He >= leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_He == posun * 6 + horniOdsazeni && poz_X_He >= leveOdsazeni + posun * 4) || (poz_Y_He == posun * 7 + horniOdsazeni && poz_X_He == leveOdsazeni + posun * 4 + posun / 2))) ||
                        (n == 5 && ((poz_Y_He == posun * 9 + horniOdsazeni && poz_X_He == leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_He == posun * 10 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 4) || (poz_Y_He == posun * 11 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_He == posun * 12 + horniOdsazeni && poz_X_He <= leveOdsazeni - posun * 3))) ||
                        (n == 6 && ((poz_Y_He == posun * 9 + horniOdsazeni && poz_X_He == leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_He == posun * 10 + horniOdsazeni && poz_X_He >= leveOdsazeni + posun * 4) || (poz_Y_He == posun * 11 + horniOdsazeni && poz_X_He >= leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_He == posun * 12 + horniOdsazeni && poz_X_He >= leveOdsazeni + posun * 3))))
                    {
                        PocitacovyHrac pocitacovyHrac = new PocitacovyHrac(poz_X_He, poz_Y_He, sirkaPole, vyskaPole, n);
                       polePocitacovehoHrace.Add(pocitacovyHrac);
                    }
                }
            }
            if (prvniTah == 2)
            {
                pocitacovyHracPohyb(hraform);
            }
        }

        public void panelKliknuti(int x, int y, HraForm hraform)
        {
            konzoleZprava = 0;
            int poz_X_LHr, poz_Y_LHr, poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poz_X_He_S, poz_Y_He_S;
            int poz_X_MT, poz_Y_MT;
            int delkaSkokuX = 0, delkaSkokuY = 0;
            VypocetMoznychTahu vypocetMoznychTahu = new VypocetMoznychTahu(sirkaPole, vyskaPole, posun, horniOdsazeni, leveOdsazeni, herniPole);
            bool ukoncitTah = false;

            for (int i = 0; i < herniPole.Count; i++)
            {
                Pole pole = herniPole[i];
                poz_X_He = pole.get_poz_X_He();
                poz_Y_He = pole.get_poz_Y_He();
                poz_X_He_S = poz_X_He + (sirkaPole / 2);
                poz_Y_He_S = poz_Y_He + (vyskaPole / 2);

                bool vPoli = jeVPoli(poz_X_He_S, poz_Y_He_S, sirkaPole / 2, x, y);//ověří, jestli se právě kliknuté souřadnice nacházejí v daném poli
                if(vPoli)
                {
                    for(int j = 0; j < poleLidskehoHrace.Count; j++)
                    {
                        LidskyHrac lidskyHrac = poleLidskehoHrace[j];
                        poz_X_KHr = lidskyHrac.get_poz_X_LHr();
                        poz_Y_KHr = lidskyHrac.get_poz_Y_LHr();
                        if (poz_X_He == poz_X_KHr && poz_Y_He == poz_Y_KHr)//nalezli jsme hráčovo pole, do kterého uživatel kliknul
                        {
                            HraForm.prehratZvuk(1);
                            if (zvyrazneniPoleLidskehoHrace != null && (poz_X_He == zvyrazneniPoleLidskehoHrace.get_poz_X_Zv() && poz_Y_He == zvyrazneniPoleLidskehoHrace.get_poz_Y_Zv()) && hracProvedlSkok)//hráč klikl na pole na které se přesunul - chce tedy ukončit tah
                            {
                                ukoncitTah = true;
                            }
                            mozneTahyLidskehoHrace.Clear();
                            vypocetMoznychTahu.pridaniMoznychTahu(poz_X_KHr, poz_Y_KHr, 1, pocetHracu, false, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);

                            zvyrazneniPoleLidskehoHrace = new ZvyrazneniPoleLidskehoHrace(poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                            break;
                        }
                    }

                    for(int j = 0; j < mozneTahyLidskehoHrace.Count; j++)
                    {
                        MoznyTahLidskehoHrace moznyTah = mozneTahyLidskehoHrace[j];
                        poz_X_MT = moznyTah.get_poz_X_MT();
                        poz_Y_MT = moznyTah.get_poz_Y_MT();
                        if (poz_X_He == poz_X_MT && poz_Y_He == poz_Y_MT)//nalezli jsme možný tah, do kterého hráč kliknul
                        {
                            if (!kliknutMoznyTah)
                            {
                                hraform.konecTahuButton();
                            }
                            kliknutMoznyTah = true;
                            HraForm.prehratZvuk(1);
                            mozneTahyLidskehoHrace.Clear();
                            for (int k = 0; k < poleLidskehoHrace.Count; k++)
                            {
                                LidskyHrac h = poleLidskehoHrace[k];
                                poz_X_LHr = h.get_poz_X_LHr();
                                poz_Y_LHr = h.get_poz_Y_LHr();
                                if (poz_X_LHr == zvyrazneniPoleLidskehoHrace.get_poz_X_Zv() && poz_Y_LHr == zvyrazneniPoleLidskehoHrace.get_poz_Y_Zv())
                                {
                                    poleLidskehoHrace.Remove(h);
                                }
                            }
                            LidskyHrac lidskyHrac = new LidskyHrac(poz_X_He, poz_Y_He, sirkaPole, vyskaPole);
                            poleLidskehoHrace.Add(lidskyHrac);
                            if (Math.Abs(poz_X_MT - zvyrazneniPoleLidskehoHrace.get_poz_X_Zv()) > posun + 1 || Math.Abs(poz_Y_MT - zvyrazneniPoleLidskehoHrace.get_poz_Y_Zv()) > posun + 1)//hráč se posunul skokem - nalezneme možné tahy z pole na které skočil
                            {
                                delkaSkokuX = Math.Abs(poz_X_MT - zvyrazneniPoleLidskehoHrace.get_poz_X_Zv());
                                delkaSkokuY = Math.Abs(poz_Y_MT - zvyrazneniPoleLidskehoHrace.get_poz_Y_Zv());
                                hracProvedlSkok = true;
                                vypocetMoznychTahu.pridaniMoznychTahu(poz_X_He, poz_Y_He, 1, pocetHracu, hracProvedlSkok, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                                zvyrazneniPoleLidskehoHrace = new ZvyrazneniPoleLidskehoHrace(poz_X_MT, poz_Y_MT, sirkaPole, vyskaPole);
                            }
                            else//hráč se přemístil na sousední pole - tah tedy ukončíme
                            {
                                ukoncitTah = true;
                            }
                        }
                    }
                }
            }
            if(ukoncitTah)
            {
                konecTahu(hraform);
            }
        }

        private bool jeVPoli(int poz_X_He_S, int poz_Y_He_S, int prumerPole, int eX, int eY)//ověří, jestli se souřadnice na které hráč klikl nalézají v některém z herních polí
        {
            int pozX = poz_X_He_S - eX;
            int pozY = poz_Y_He_S - eY;
            return pozX * pozX + pozY * pozY <= prumerPole * prumerPole;
        }

        public void konecTahu(HraForm hraform)
        {
            mozneTahyLidskehoHrace.Clear();
            pocetTahu++;
            zvyrazneniPoleLidskehoHrace = null;
            hracProvedlSkok = false;
            hraform.konecTahuButton();
            kliknutMoznyTah = false;
            HraForm.prehratZvuk(2);
            if (prvniTah == 2)
            {
                kontrolaVitezstvi();
            }
            if(konzoleZprava < 4)
            {
                pocitacovyHracPohyb(hraform);
            }
            if (prvniTah == 1)
            {
                kontrolaVitezstvi();
            }
        }

        private void kontrolaVitezstvi()//při dokončení kola (všichni hráči táhli) je zkontrolováno, jestli některý z hráčů nevyhrál (všechna jeho pole se nalézají na protější straně herního pole)
        {
            int poz_X_LHr, poz_Y_LHr, poz_X_PHr, poz_Y_PHr, idPocitacovehoHrace;
            bool lidskyHracVyhral = true;

            for (int i = 0; i < poleLidskehoHrace.Count; i++)
            {
                LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                poz_X_LHr = lidskyHrac.get_poz_X_LHr();
                poz_Y_LHr = lidskyHrac.get_poz_Y_LHr();
                if (pocetHracu != 4)
                {
                    if (poz_Y_LHr > posun * 3 + horniOdsazeni)
                    {
                        lidskyHracVyhral = false;
                    }
                }
                else
                {
                    if ((poz_Y_LHr > posun * 7 + horniOdsazeni) || (poz_Y_LHr < posun * 4 + horniOdsazeni) || (poz_Y_LHr == posun * 4 + horniOdsazeni && poz_X_LHr < leveOdsazeni + posun * 3) || (poz_Y_LHr == posun * 5 + horniOdsazeni && poz_X_LHr < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_LHr == posun * 6 + horniOdsazeni && poz_X_LHr < leveOdsazeni + posun * 4) || (poz_Y_LHr == posun * 7 + horniOdsazeni && poz_X_LHr != leveOdsazeni + posun * 4 + posun / 2))
                    {
                        lidskyHracVyhral = false;
                    }
                }
            }

            int[] pocetPoliPocitacovehoHrace = new int[] { 0, 0, 0, 0, 0, 0 };
            bool[] vyhraPocitacovehoHrace = new bool[] { true, true, true, true, true, true };

            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j < polePocitacovehoHrace.Count; j++)
                {
                    PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[j];
                    poz_X_PHr = pocitacovyHrac.get_poz_X_PHr();
                    poz_Y_PHr = pocitacovyHrac.get_poz_Y_PHr();
                    idPocitacovehoHrace = pocitacovyHrac.get_idPocitacovehoHrace();

                    if (idPocitacovehoHrace != i)
                    {
                        continue;
                    }
                    if(i == 0)
                    {
                        pocetPoliPocitacovehoHrace[5] += 1;
                    }
                    else
                    {
                        pocetPoliPocitacovehoHrace[idPocitacovehoHrace - 2] += 1;
                    }

                    if(idPocitacovehoHrace == 0 && poz_Y_PHr > posun * 3 + horniOdsazeni)
                    {
                        vyhraPocitacovehoHrace[5] = false;
                    }

                    if (idPocitacovehoHrace == 2 && poz_Y_PHr < posun * 13 + horniOdsazeni)
                    {
                        vyhraPocitacovehoHrace[0] = false;
                    }

                    if (idPocitacovehoHrace == 3 && ((poz_Y_PHr < posun * 9 + horniOdsazeni) || (poz_Y_PHr > posun * 12 + horniOdsazeni) || (poz_Y_PHr == posun * 9 + horniOdsazeni && poz_X_PHr != leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_PHr == posun * 10 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 4) || (poz_Y_PHr == posun * 11 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_PHr == posun * 12 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 3)))
                    {
                        vyhraPocitacovehoHrace[1] = false;
                    }

                    if (idPocitacovehoHrace == 4 && ((poz_Y_PHr < posun * 9 + horniOdsazeni) || (poz_Y_PHr > posun * 12 + horniOdsazeni) || (poz_Y_PHr == posun * 9 + horniOdsazeni && poz_X_PHr != leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_PHr == posun * 10 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 4) || (poz_Y_PHr == posun * 11 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_PHr == posun * 12 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 3)))
                    {
                        vyhraPocitacovehoHrace[2] = false;
                    }

                    if (idPocitacovehoHrace == 5 && ((poz_Y_PHr > posun * 7 + horniOdsazeni) || (poz_Y_PHr < posun * 4 + horniOdsazeni) || (poz_Y_PHr == posun * 4 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 3) || (poz_Y_PHr == posun * 5 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_PHr == posun * 6 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 4) || (poz_Y_PHr == posun * 7 + horniOdsazeni && poz_X_PHr != leveOdsazeni + posun * 4 + posun / 2)))
                    {
                        vyhraPocitacovehoHrace[3] = false;
                    }

                    if (idPocitacovehoHrace == 6 && ((poz_Y_PHr > posun * 7 + horniOdsazeni) || (poz_Y_PHr < posun * 4 + horniOdsazeni) || (poz_Y_PHr == posun * 4 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 3) || (poz_Y_PHr == posun * 5 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_PHr == posun * 6 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 4) || (poz_Y_PHr == posun * 7 + horniOdsazeni && poz_X_PHr != leveOdsazeni - posun * 4 - posun / 2)))
                    {
                        vyhraPocitacovehoHrace[4] = false;
                    }
                }
            }

            viteziciPocitacovyHrac = 0;
            for (int i = 0; i < 6; i++)
            {
                if (pocetPoliPocitacovehoHrace[i] > 0 && vyhraPocitacovehoHrace[i] == true)
                {
                    viteziciPocitacovyHrac = i + 2;
                }
            }

            if(kontumaceVyhraHrac != 0)
            {
                kontumaceVyhra = true;
                if(kontumaceVyhraHrac == 1)
                {
                    lidskyHracVyhral = true;
                }
                else
                {
                    viteziciPocitacovyHrac = kontumaceVyhraHrac;
                }
            }

            if(viteziciPocitacovyHrac != 0 && simulaceMod)
            {
                zapisDoStatistik(viteziciPocitacovyHrac);
                konzoleZprava = 7;
            }

            bool remiza = false;
            if (viteziciPocitacovyHrac != 0 && !simulaceMod)
            {
                if (lidskyHracVyhral)
                {
                    remiza = true;
                    konzoleZprava = 6;
                }
                else
                {
                    konzoleZprava = 5;
                }
            }

            if (lidskyHracVyhral && !remiza && !simulaceMod)
            {
                konzoleZprava = 4;
            }
        }

        public void zapisDoStatistik(int viteziciPocitacovyHrac)
        {
            string[] radky = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Statistiky.txt");

            string obtiznostText = "";
            switch(pocetHracu)
            {
                case 2:
                    obtiznostText = simulaceObtiznost[0] + ";" + simulaceObtiznost[5];
                    break;
                case 3:
                    obtiznostText = simulaceObtiznost[1] + ";" + simulaceObtiznost[2] + ";" + simulaceObtiznost[5];
                    break;
                case 4:
                    obtiznostText = simulaceObtiznost[1] + ";" + simulaceObtiznost[2] + ";" + simulaceObtiznost[3] + ";" + simulaceObtiznost[4];
                    break;
                case 6:
                    obtiznostText = simulaceObtiznost[0] + ";" + simulaceObtiznost[1] + ";" + simulaceObtiznost[2] + ";" + simulaceObtiznost[3] + ";" + simulaceObtiznost[4] + ";" + simulaceObtiznost[5];
                    break;
            }

            string vyslednyText = "";
        /*    if(radky[0] != null)
            {
                vyslednyText += "\n";
            }*/
           if(radky.Length != 0)
            {
                vyslednyText += "\n";
            }
            vyslednyText += pocetHracu.ToString() + ";" + pocetTahu + ";" + Convert.ToInt32(kontumaceVyhra) + ";" + obtiznostText + ";" + viteziciPocitacovyHrac;
            File.AppendAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Statistiky.txt", vyslednyText);
        }

        public void pocitacovyHracPohyb(HraForm hraform)
        {
            if (konzoleZprava < 4)
            {
                konzoleZprava = 1;
            }
            hraform.konzoleRefresh(0);
            PohybPocitacovehoHrace pohybPocitacovehoHrace = new PohybPocitacovehoHrace(pocetHracu, prvniTah, pocetTahu, sirkaPole, vyskaPole, posun, horniOdsazeni, leveOdsazeni, herniPole, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace, zvyraznenaPolePocitacovehoHrace, vychoziPolePocitacovehoHrace, kontumaceVyhraHrac, simulaceMod);
            (polePocitacovehoHrace, vychoziPolePocitacovehoHrace, zvyraznenaPolePocitacovehoHrace, kontumaceVyhraHrac) = pohybPocitacovehoHrace.provestPohyb(hraform, obtiznost, simulaceObtiznost);
            if (simulaceMod)
            {
                pocetTahu++;
                kontrolaVitezstvi();
            }
            if (konzoleZprava < 4)
            {
                if (pocetTahu == 0)
                {
                    konzoleZprava = 2;
                }
                else
                {
                    konzoleZprava = 0;
                }
            }
            hraform.konzoleRefresh(0);
        }

        public int getPocetTahu()
        {
            return pocetTahu;
        }

        public (int, int, bool) getKonzoleZprava()
        {
            return (konzoleZprava, viteziciPocitacovyHrac, kontumaceVyhra);
        }

        private bool jePoleVNejvyssimRohu(int poz_X_He, int poz_Y_He)
        {
            if (poz_Y_He > horniOdsazeni + posun * 3)
            {
                return false;
            }
            return true;
        }

        private bool jePoleVNejnizsimRohu(int poz_X_He, int poz_Y_He)
        {
            if (poz_Y_He < horniOdsazeni + posun * 13)
            {
                return false;
            }
            return true;
        }

        private bool jePoleVSpodnimLevemRohu(int poz_X_He, int poz_Y_He)
        {
            if ((poz_Y_He <= horniOdsazeni + posun * 8) || (poz_Y_He >= horniOdsazeni + posun * 13) || (poz_Y_He == posun * 9 + horniOdsazeni && poz_X_He > leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_He == posun * 10 + horniOdsazeni && poz_X_He > leveOdsazeni - posun * 4) || (poz_Y_He == posun * 11 + horniOdsazeni && poz_X_He > leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_He == posun * 12 + horniOdsazeni && poz_X_He > leveOdsazeni - posun * 3))
            {
                return false;
            }
            return true;
        }

        private bool jePoleVHornimPravemRohu(int poz_X_He, int poz_Y_He)
        {
            if ((poz_Y_He >= horniOdsazeni + posun * 8) || (poz_Y_He <= horniOdsazeni + posun * 3) || (poz_Y_He == horniOdsazeni + posun * 7 && poz_X_He < leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_He == horniOdsazeni + posun * 6 && poz_X_He < leveOdsazeni + posun * 4) || (poz_Y_He == horniOdsazeni + posun * 5 && poz_X_He < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_He == horniOdsazeni + posun * 4 && poz_X_He < leveOdsazeni + posun * 3))
            {
                return false;
            }
            return true;
        }

        private bool jePoleVSpodnimPravemRohu(int poz_X_He, int poz_Y_He)
        {
            if ((poz_Y_He <= horniOdsazeni + posun * 8) || (poz_Y_He >= horniOdsazeni + posun * 13) || (poz_Y_He == posun * 9 + horniOdsazeni && poz_X_He < leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_He == posun * 10 + horniOdsazeni && poz_X_He < leveOdsazeni + posun * 4) || (poz_Y_He == posun * 11 + horniOdsazeni && poz_X_He < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_He == posun * 12 + horniOdsazeni && poz_X_He < leveOdsazeni + posun * 3))
            {
                return false;
            }
            return true;
        }

        private bool jePoleVHornimLevemRohu(int poz_X_He, int poz_Y_He)
        {
            if ((poz_Y_He >= horniOdsazeni + posun * 8) || (poz_Y_He <= horniOdsazeni + posun * 3) || (poz_Y_He == horniOdsazeni + posun * 7 && poz_X_He > leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_He == horniOdsazeni + posun * 6 && poz_X_He > leveOdsazeni - posun * 4) || (poz_Y_He == horniOdsazeni + posun * 5 && poz_X_He > leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_He == horniOdsazeni + posun * 4 && poz_X_He > leveOdsazeni - posun * 3))
            {
                return false;
            }
            return true;
        }
    }
}
