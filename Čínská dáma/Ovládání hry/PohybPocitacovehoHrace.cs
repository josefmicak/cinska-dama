using System;
using System.Collections.Generic;

namespace Čínská_dáma
{
    class PohybPocitacovehoHrace
    {
        private int pocetHracu;
        private int prvniTah;
        private int sirkaPole;
        private int vyskaPole;
        private int posun;
        private int horniOdsazeni;
        private int leveOdsazeni;
        private int pocetTahu;
        private bool simulaceMod;

        private bool overovatVyhodnostTahu;

        private List<Pole> herniPole = new List<Pole>();
        private List<LidskyHrac> poleLidskehoHrace = new List<LidskyHrac>();
        private List<PocitacovyHrac> polePocitacovehoHrace = new List<PocitacovyHrac>();
        private List<MoznyTahLidskehoHrace> mozneTahyLidskehoHrace = new List<MoznyTahLidskehoHrace>();
        private List<MoznyTahPocitacovehoHrace> mozneTahyPocitacovehoHrace = new List<MoznyTahPocitacovehoHrace>();
        private List<VychoziPolePocitacovehoHrace> vychoziPolePocitacovehoHrace = new List<VychoziPolePocitacovehoHrace>();
        private List<ZvyrazneniPolePocitacovehoHrace> zvyraznenaPolePocitacovehoHrace = new List<ZvyrazneniPolePocitacovehoHrace>();

        private VypocetMoznychTahu vypocetMoznychTahu;
        Random random = new Random();

        public PohybPocitacovehoHrace(int pocetHracu, int prvniTah, int pocetTahu, int sirkaPole, int vyskaPole, int posun, int horniOdsazeni, int leveOdsazeni, List<Pole> herniPole, List<LidskyHrac> poleLidskehoHrace, List<PocitacovyHrac> polePocitacovehoHrace, List<MoznyTahLidskehoHrace> mozneTahyLidskehoHrace, List<MoznyTahPocitacovehoHrace> mozneTahyPocitacovehoHrace, List<ZvyrazneniPolePocitacovehoHrace> zvyraznenaPolePocitacovehoHrace, List<VychoziPolePocitacovehoHrace> vychoziPolePocitacovehoHrace, bool simulaceMod)
        {
            this.pocetHracu = pocetHracu;
            this.prvniTah = prvniTah;
            this.pocetTahu = pocetTahu;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
            this.posun = posun;
            this.horniOdsazeni = horniOdsazeni;
            this.leveOdsazeni = leveOdsazeni;
            this.herniPole = herniPole;
            this.polePocitacovehoHrace = polePocitacovehoHrace;
            this.poleLidskehoHrace = poleLidskehoHrace;
            this.mozneTahyLidskehoHrace = mozneTahyLidskehoHrace;
            this.mozneTahyPocitacovehoHrace = mozneTahyPocitacovehoHrace;
            this.zvyraznenaPolePocitacovehoHrace = zvyraznenaPolePocitacovehoHrace;
            this.vychoziPolePocitacovehoHrace = vychoziPolePocitacovehoHrace;
            this.simulaceMod = simulaceMod;
        }

        public (List<PocitacovyHrac>, List<VychoziPolePocitacovehoHrace>, List<ZvyrazneniPolePocitacovehoHrace>) ProvestPohyb(HraForm hraform, int obtiznost, int[] simulaceObtiznost)
        {
            int poz_X_PHr, poz_Y_PHr, poz_X_MT, poz_Y_MT, idOdebiranehoPole = 0, novePoleX, novePoleY, poleKeKontroleX, poleKeKontroleY, delkaSkokuX = 0, delkaSkokuY = 0;
            int maxRozdilY, rozdilX = 0, idPocitacovehoHrace, maxRozdil, pocetPosledniRadek, pocetPredposledniRadek, pozXPosledniRadek = 0, pozXPredposledniRadek = 0;

            bool hracSePohlSkokem, provestTah = true;

            List<int> nevyhodnaPoleX = new List<int>();//seznam polí na která je v daném tahu pro nepřítele nevýhodné táhnout (x-ová souřadnice)
            List<int> nevyhodnaPoleY = new List<int>();//seznam polí na která je v daném tahu pro nepřítele nevýhodné táhnout (y-ová souřadnice)

            vypocetMoznychTahu = new VypocetMoznychTahu(sirkaPole, vyskaPole, posun, horniOdsazeni, leveOdsazeni, herniPole);

            vychoziPolePocitacovehoHrace.Clear();
            zvyraznenaPolePocitacovehoHrace.Clear();

            VytvoreniTahuLidskehoHrace();
            int nejvyhodnejsiHracuvTah = VypocetNejvyhodnejsihoTahuLidskehoHrace(pocetHracu);

            for (int n = 0; n <= 6; n++)
            {
                if (!SplnenyPodminkyProPohyb(n, simulaceMod))
                {
                    continue;
                }
                if(simulaceMod)
                {
                    obtiznost = NastaveniObtiznosti(n, simulaceObtiznost);
                }
                if (obtiznost <= 2)
                {
                    mozneTahyPocitacovehoHrace.Clear();
                    for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        hracSePohlSkokem = false;

                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        idPocitacovehoHrace = pocitacovyHrac.Get_idPocitacovehoHrace();
                        if (idPocitacovehoHrace != n)
                        {
                            continue;
                        }
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                    }

                    List<int> proveditelnePohyby = new List<int>();
                    for (int i = 0; i < mozneTahyPocitacovehoHrace.Count; i++)
                    {
                        if(n != mozneTahyPocitacovehoHrace[i].Get_idPocitacovehoHrace())
                        {
                            continue;
                        }
                        if(PridatTahHrace(obtiznost, n, mozneTahyPocitacovehoHrace[i].Get_poz_X_MT(), mozneTahyPocitacovehoHrace[i].Get_poz_Y_MT(), mozneTahyPocitacovehoHrace[i].Get_poz_X_KPHr(), mozneTahyPocitacovehoHrace[i].Get_poz_Y_KPHr(), 0))
                        {
                            proveditelnePohyby.Add(i);
                        }
                    }
                    int cislo = random.Next(0, proveditelnePohyby.Count);
                    int idPohybu;
                    if (proveditelnePohyby.Count == 0)//pokud není k dispozici žádný pohyb, provedeme náhodně vybraný tah
                    {
                        idPohybu = random.Next(0, mozneTahyPocitacovehoHrace.Count);
                    }
                    else
                    {
                        idPohybu = proveditelnePohyby[cislo];
                    }
                    if (mozneTahyPocitacovehoHrace.Count > 0)//u her více hráčů se může ve velmi vzácných případech stát, že není k dispozici žádný možný tah
                    {
                        for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                        {
                            PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                            if (pocitacovyHrac.Get_poz_X_PHr() == mozneTahyPocitacovehoHrace[idPohybu].Get_poz_X_KPHr() && pocitacovyHrac.Get_poz_Y_PHr() == mozneTahyPocitacovehoHrace[idPohybu].Get_poz_Y_KPHr())
                            {
                                idOdebiranehoPole = i;
                                break;
                            }
                        }
                        PridaniPolePocitacovehoHrace(idOdebiranehoPole, mozneTahyPocitacovehoHrace[idPohybu].Get_poz_X_MT(), mozneTahyPocitacovehoHrace[idPohybu].Get_poz_Y_MT(), n);
                    }
                }
                else
                {
                    hraform.KonzoleRefresh(n);
                    maxRozdil = 0;
                    maxRozdilY = 0;
                    pocetPosledniRadek = 0;
                    pocetPredposledniRadek = 0;
                    novePoleX = 0;
                    novePoleY = 0;
                    poleKeKontroleX = 0;
                    poleKeKontroleY = 0;

                    if (n == 3 || n == 5)
                    {
                        pozXPosledniRadek = 1000;
                        pozXPredposledniRadek = 1000;
                    }
                    else if (n == 4 || n == 6)
                    {
                        pozXPosledniRadek = 0;
                        pozXPredposledniRadek = 0;
                    }

                    for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        mozneTahyPocitacovehoHrace.Clear();
                        hracSePohlSkokem = false;

                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        idPocitacovehoHrace = pocitacovyHrac.Get_idPocitacovehoHrace();
                        if (idPocitacovehoHrace != n)
                        {
                            continue;
                        }

                        (pocetPosledniRadek, pocetPredposledniRadek, pozXPosledniRadek, pozXPredposledniRadek) = PripravaKoncovychTahu(n, pocetPosledniRadek, pocetPredposledniRadek, pozXPosledniRadek, pozXPredposledniRadek, poz_X_PHr, poz_Y_PHr);
                        
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            bool pridatMoznyTah = true;
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (Math.Abs(poz_Y_MT - poz_Y_PHr) > posun || Math.Abs(poz_X_MT - poz_X_PHr) > posun)//na ověřovaný možný tah se budeme muset dostat skokem
                            {
                                hracSePohlSkokem = true;
                            }
                            else
                            {
                                hracSePohlSkokem = false;
                            }

                            if (hracSePohlSkokem)//na ověřované pole jsme se dostali skokem - zkontrolujeme možné tahy z tohoto pole
                            {
                                delkaSkokuX = Math.Abs(moznyTah.Get_poz_X_MT() - moznyTah.Get_poz_X_KPHr());
                                delkaSkokuY = Math.Abs(moznyTah.Get_poz_Y_MT() - moznyTah.Get_poz_Y_KPHr());
                                vypocetMoznychTahu.PridaniMoznychTahu(poz_X_MT, poz_Y_MT, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                            }
                            if (n == 0)
                            {
                                if (poz_Y_PHr - poz_Y_MT > maxRozdilY)//skok který počítačového hráče posune nejdále na y-ové ose
                                {
                                    for (int k = 0; k < nevyhodnaPoleX.Count; k++)
                                    {
                                        if (poz_X_MT == nevyhodnaPoleX[k] && poz_Y_MT == nevyhodnaPoleY[k])
                                        {
                                            pridatMoznyTah = false;
                                        }
                                    }
                                    if (pridatMoznyTah)
                                    {
                                        maxRozdilY = poz_Y_PHr - poz_Y_MT;
                                        rozdilX = Math.Abs(leveOdsazeni - poz_X_MT);
                                        idOdebiranehoPole = i;
                                        novePoleX = poz_X_MT;
                                        novePoleY = poz_Y_MT;
                                        poleKeKontroleX = poz_X_PHr;
                                        poleKeKontroleY = poz_Y_PHr;
                                    }
                                }
                                else if (poz_Y_PHr - poz_Y_MT == maxRozdilY)
                                {
                                    if (Math.Abs(leveOdsazeni - poz_X_MT) < rozdilX)//skok který počítačového hráče posune stejně daleko na y-ové ose, ale blíže ke středu pole na x-ové ose
                                    {
                                        for (int k = 0; k < nevyhodnaPoleX.Count; k++)
                                        {
                                            if (poz_X_MT == nevyhodnaPoleX[k] && poz_Y_MT == nevyhodnaPoleY[k])
                                            {
                                                pridatMoznyTah = false;
                                            }
                                        }
                                        if (pridatMoznyTah)
                                        {
                                            rozdilX = Math.Abs(leveOdsazeni - poz_X_MT);
                                            idOdebiranehoPole = i;
                                            novePoleX = poz_X_MT;
                                            novePoleY = poz_Y_MT;
                                            poleKeKontroleX = poz_X_PHr;
                                            poleKeKontroleY = poz_Y_PHr;
                                        }
                                    }
                                }
                            }
                            else if (n == 2)
                            {
                                if (poz_Y_MT - poz_Y_PHr > maxRozdilY)//skok který počítačového hráče posune nejdále na y-ové ose
                                {
                                    for (int k = 0; k < nevyhodnaPoleX.Count; k++)
                                    {
                                        if (poz_X_MT == nevyhodnaPoleX[k] && poz_Y_MT == nevyhodnaPoleY[k])
                                        {
                                            pridatMoznyTah = false;
                                        }
                                    }
                                    if (pridatMoznyTah)
                                    {
                                        maxRozdilY = poz_Y_MT - poz_Y_PHr;
                                        rozdilX = Math.Abs(leveOdsazeni - poz_X_MT);
                                        idOdebiranehoPole = i;
                                        novePoleX = poz_X_MT;
                                        novePoleY = poz_Y_MT;
                                        poleKeKontroleX = poz_X_PHr;
                                        poleKeKontroleY = poz_Y_PHr;
                                    }
                                }
                                else if (poz_Y_MT - poz_Y_PHr == maxRozdilY)//skok který počítačového hráče posune stejně daleko na y-ové ose, ale blíže ke středu pole na x-ové ose
                                {
                                    if (Math.Abs(leveOdsazeni - poz_X_MT) < rozdilX)
                                    {
                                        for (int k = 0; k < nevyhodnaPoleX.Count; k++)
                                        {
                                            if (poz_X_MT == nevyhodnaPoleX[k] && poz_Y_MT == nevyhodnaPoleY[k])
                                            {
                                                pridatMoznyTah = false;
                                            }
                                        }
                                        if (pridatMoznyTah)
                                        {
                                            rozdilX = Math.Abs(leveOdsazeni - poz_X_MT);
                                            idOdebiranehoPole = i;
                                            novePoleX = poz_X_MT;
                                            novePoleY = poz_Y_MT;
                                            poleKeKontroleX = poz_X_PHr;
                                            poleKeKontroleY = poz_Y_PHr;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if(PridatTahHrace(obtiznost, n, poz_X_MT, poz_Y_MT, poz_X_PHr, poz_Y_PHr, maxRozdil))
                                {
                                    for (int k = 0; k < nevyhodnaPoleX.Count; k++)
                                    {
                                        if (poz_X_MT == nevyhodnaPoleX[k] && poz_Y_MT == nevyhodnaPoleY[k])
                                        {
                                            pridatMoznyTah = false;
                                        }
                                    }
                                    if (pridatMoznyTah)
                                    {
                                        switch(n)
                                        {
                                            case 3:
                                                maxRozdil = (poz_X_MT - poz_X_PHr) + (poz_Y_MT - poz_Y_PHr);
                                                break;
                                            case 4:
                                                maxRozdil = (poz_X_PHr - poz_X_MT) + (poz_Y_MT - poz_Y_PHr);
                                                break;
                                            case 5:
                                                maxRozdil = (poz_X_MT - poz_X_PHr) + (poz_Y_PHr - poz_Y_MT);
                                                break;
                                            case 6:
                                                maxRozdil = (poz_X_PHr - poz_X_MT) + (poz_Y_PHr - poz_Y_MT);
                                                break;
                                        }
                                        
                                        idOdebiranehoPole = i;
                                        novePoleX = poz_X_MT;
                                        novePoleY = poz_Y_MT;
                                        poleKeKontroleX = poz_X_PHr;
                                        poleKeKontroleY = poz_Y_PHr;
                                    }
                                }
                            }
                        }
                    }
                    //započítání kamenů hráče, pro kterého byl trojúhelník výchozím (pokud bychom tyto kameny nezapočítali, mohlo by se stát, že by blokovaný hráč nemohl dokončit hru)
                    for(int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        idPocitacovehoHrace = pocitacovyHrac.Get_idPocitacovehoHrace();
                        if((n == 3 && idPocitacovehoHrace != 6) || (n == 4 && idPocitacovehoHrace != 5) || (n == 5 && idPocitacovehoHrace != 4) || (n == 6 && idPocitacovehoHrace != 3))
                        {
                            continue;
                        }
                        (pocetPosledniRadek, pocetPredposledniRadek) = ZapocitaniKamenuVychozihoHrace(n, pocetPosledniRadek, pocetPredposledniRadek, poz_X_PHr, poz_Y_PHr);
                    }

                    if (n == 0)
                    {
                        (idOdebiranehoPole, novePoleX, novePoleY, poleKeKontroleX, poleKeKontroleY) = ProvedeniPocatecnichTahu(n, pocetTahu, idOdebiranehoPole, novePoleX, novePoleY, poleKeKontroleX, poleKeKontroleY, prvniTah, simulaceMod);
                        if (novePoleX == 0 && novePoleY == 0)//ošetření pohybu na úplném konci hry, kdy se nepřítel nemůže posunout směrem vzad na y-ové ose
                        {
                            int posunX = 1000;
                            overovatVyhodnostTahu = false;
                            bool chybejiciPole = false;
                            for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                            {
                                PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                                poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                                poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                                int _idPocitacovehoHrace = pocitacovyHrac.Get_idPocitacovehoHrace();
                                if (_idPocitacovehoHrace != 0)
                                {
                                    continue;
                                }
                                if (poz_X_PHr == leveOdsazeni - posun - posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 3)
                                {
                                    chybejiciPole = true;
                                }
                                if (poz_Y_PHr <= horniOdsazeni + posun * 3)
                                {
                                    continue;
                                }
                                mozneTahyPocitacovehoHrace.Clear();
                                hracSePohlSkokem = false;
                                vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);

                                for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                                {
                                    MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                                    poz_X_MT = moznyTah.Get_poz_X_MT();
                                    poz_Y_MT = moznyTah.Get_poz_Y_MT();
                                    if (poz_X_PHr == leveOdsazeni && poz_Y_PHr == horniOdsazeni + posun * 4)
                                    {
                                        idOdebiranehoPole = i;
                                        poleKeKontroleX = 0;
                                        poleKeKontroleY = 0;
                                        novePoleY = horniOdsazeni + posun * 4;
                                        if (chybejiciPole)
                                        {
                                            novePoleX = leveOdsazeni + posun;
                                        }
                                        else
                                        {
                                            novePoleX = leveOdsazeni - posun;
                                        }
                                    }
                                    else
                                    {
                                        if (Math.Abs(leveOdsazeni - poz_X_MT) < posunX)
                                        {
                                            idOdebiranehoPole = i;
                                            posunX = Math.Abs(leveOdsazeni - poz_X_MT);
                                            novePoleX = poz_X_MT;
                                            novePoleY = poz_Y_MT;
                                            poleKeKontroleX = 0;
                                            poleKeKontroleY = 0;
                                            provestTah = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (n == 2)
                    {
                        if (!JeTahVyhodny(poleKeKontroleX, poleKeKontroleY, novePoleX, novePoleY, n, nejvyhodnejsiHracuvTah, pocetHracu))
                        {
                            provestTah = false;
                            nevyhodnaPoleX.Add(novePoleX);
                            nevyhodnaPoleY.Add(novePoleY);
                        }
                        if (pocetHracu == 2)
                        {
                            (idOdebiranehoPole, novePoleX, novePoleY, poleKeKontroleX, poleKeKontroleY) = ProvedeniPocatecnichTahu(n, pocetTahu, idOdebiranehoPole, novePoleX, novePoleY, poleKeKontroleX, poleKeKontroleY, prvniTah, simulaceMod);
                        }
                        if (novePoleX == 0 && novePoleY == 0)//ošetření pohybu na úplném konci hry, kdy se nepřítel nemůže posunout směrem vpřed na y-ové ose
                        {
                            int posunX = 1000;
                            overovatVyhodnostTahu = false;
                            bool chybejiciPole = false;
                            for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                            {
                                PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                                poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                                poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                                int _idPocitacovehoHrace = pocitacovyHrac.Get_idPocitacovehoHrace();
                                if (_idPocitacovehoHrace != 2)
                                {
                                    continue;
                                }
                                if (poz_X_PHr == leveOdsazeni - posun - posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 13)
                                {
                                    chybejiciPole = true;
                                }
                                if (poz_Y_PHr >= horniOdsazeni + posun * 13)
                                {
                                    continue;
                                }
                                mozneTahyPocitacovehoHrace.Clear();
                                hracSePohlSkokem = false;
                                vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);

                                for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                                {
                                    MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                                    poz_X_MT = moznyTah.Get_poz_X_MT();
                                    poz_Y_MT = moznyTah.Get_poz_Y_MT();
                                    if (poz_X_PHr == leveOdsazeni && poz_Y_PHr == horniOdsazeni + posun * 12)
                                    {
                                        idOdebiranehoPole = i;
                                        poleKeKontroleX = 0;
                                        poleKeKontroleY = 0;
                                        novePoleY = horniOdsazeni + posun * 12;
                                        if (chybejiciPole)
                                        {
                                            novePoleX = leveOdsazeni + posun;
                                        }
                                        else
                                        {
                                            novePoleX = leveOdsazeni - posun;
                                        }
                                    }
                                    else
                                    {
                                        if (Math.Abs(leveOdsazeni - poz_X_MT) < posunX)
                                        {
                                            idOdebiranehoPole = i;
                                            posunX = Math.Abs(leveOdsazeni - poz_X_MT);
                                            novePoleX = poz_X_MT;
                                            novePoleY = poz_Y_MT;
                                            poleKeKontroleX = 0;
                                            poleKeKontroleY = 0;
                                            provestTah = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        (novePoleX, novePoleY, idOdebiranehoPole, poleKeKontroleX, poleKeKontroleY) = OsetreniKoncovychTahu(n, pocetPosledniRadek, pocetPredposledniRadek, pozXPosledniRadek, pozXPredposledniRadek, novePoleX, novePoleY, idOdebiranehoPole, delkaSkokuX, delkaSkokuY, poleKeKontroleX, poleKeKontroleY);
                        
                        //ošetření případů, kdy nebyl nalezen žádný vhodný tah
                        if (novePoleX == 0 && novePoleY == 0)
                        {
                            if (overovatVyhodnostTahu)//zkusíme znovu nalézt vhodný tah, tentokrát nebudeme zvažovat pozice polí lidského hráče
                            {
                                overovatVyhodnostTahu = false;
                                provestTah = false;
                                nevyhodnaPoleX.Clear();
                                nevyhodnaPoleY.Clear();
                            }
                            else//nenalezli jsme vhodný tah ani bez zvažování pozic polí lidského hráče, provedeme tedy náhodně vybraný tah, který ale nepřítele neposune směrem dál od cíle
                            {
                                hracSePohlSkokem = false;
                                for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                                {
                                    PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                                    poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                                    poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                                    int _idPocitacovehoHrace = pocitacovyHrac.Get_idPocitacovehoHrace();
                                    mozneTahyPocitacovehoHrace.Clear();
                                    vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                                    for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                                    {
                                        MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                                        poz_X_MT = moznyTah.Get_poz_X_MT();
                                        poz_Y_MT = moznyTah.Get_poz_Y_MT();
                                        if (n == 3 && poz_X_MT >= poz_X_PHr && poz_Y_MT >= poz_Y_PHr && n == _idPocitacovehoHrace)
                                        {
                                            novePoleX = poz_X_MT;
                                            novePoleY = poz_Y_MT;
                                            idOdebiranehoPole = i;
                                            break;
                                        }

                                        if (n == 4 && poz_X_MT <= poz_X_PHr && poz_Y_MT >= poz_Y_PHr && n == _idPocitacovehoHrace)
                                        {
                                            novePoleX = poz_X_MT;
                                            novePoleY = poz_Y_MT;
                                            idOdebiranehoPole = i;
                                            break;
                                        }

                                        if (n == 5 && poz_X_MT >= poz_X_PHr && poz_Y_MT >= poz_Y_PHr && n == _idPocitacovehoHrace)
                                        {
                                            novePoleX = poz_X_MT;
                                            novePoleY = poz_Y_MT;
                                            idOdebiranehoPole = i;
                                            break;
                                        }

                                        if (n == 6 && poz_X_MT <= poz_X_PHr && poz_Y_MT >= poz_Y_PHr && n == _idPocitacovehoHrace)
                                        {
                                            novePoleX = poz_X_MT;
                                            novePoleY = poz_Y_MT;
                                            idOdebiranehoPole = i;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (overovatVyhodnostTahu)
                        {
                            if (!JeTahVyhodny(poleKeKontroleX, poleKeKontroleY, novePoleX, novePoleY, n, nejvyhodnejsiHracuvTah, pocetHracu))
                            {
                                provestTah = false;
                                nevyhodnaPoleX.Add(novePoleX);
                                nevyhodnaPoleY.Add(novePoleY);
                            }
                        }
                    }
                    if (provestTah)
                    {
                        for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                        {
                            PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                            if (pocitacovyHrac.Get_poz_X_PHr() == poleKeKontroleX && pocitacovyHrac.Get_poz_Y_PHr() == poleKeKontroleY)
                            {
                                idOdebiranehoPole = i;
                            }
                        }
                        PridaniPolePocitacovehoHrace(idOdebiranehoPole, novePoleX, novePoleY, n);
                    }
                    else
                    {
                        n--;
                        provestTah = true;
                    }
                }
            }
            mozneTahyLidskehoHrace.Clear();
            mozneTahyPocitacovehoHrace.Clear();
            nevyhodnaPoleX.Clear();
            nevyhodnaPoleY.Clear();
            return (polePocitacovehoHrace, vychoziPolePocitacovehoHrace, zvyraznenaPolePocitacovehoHrace);
        }

        private int NastaveniObtiznosti(int n, int[] simulaceObtiznost)
        {
            if (n == 0)
            {
                return simulaceObtiznost[5];
            }
            if (n == 2)
            {
                return simulaceObtiznost[0];
            }
            if (n == 3)
            {
                return simulaceObtiznost[1];
            }
            if (n == 4)
            {
                return simulaceObtiznost[2];
            }
            if (n == 5)
            {
                return simulaceObtiznost[3];
            }
            if (n == 6)
            {
                return simulaceObtiznost[4];
            }
            return 0;
        }

        private bool PridatTahHrace(int obtiznost, int n, int poz_X_MT, int poz_Y_MT, int poz_X_PHr, int poz_Y_PHr, int maxRozdil)
        {
            if(obtiznost == 1)
            {
                if((n == 0 && poz_Y_MT <= poz_Y_PHr) ||
                    (n == 2 && poz_Y_MT >= poz_Y_PHr) ||
                    (n == 3 && poz_X_MT > poz_X_PHr && poz_Y_MT > poz_Y_PHr) ||
                    (n == 4 && poz_X_MT < poz_X_PHr && poz_Y_MT > poz_Y_PHr) ||
                    (n == 5 && poz_X_MT > poz_X_PHr && poz_Y_MT < poz_Y_PHr) ||
                    (n == 6 && poz_X_MT < poz_X_PHr && poz_Y_MT < poz_Y_PHr))
                {
                    return true;
                }
            }
            else if(obtiznost == 2)
            {
                if ((n == 0 && poz_Y_MT < poz_Y_PHr) ||
                    (n == 2 && poz_Y_MT > poz_Y_PHr) ||
                    (n == 3 && poz_X_MT >= poz_X_PHr && poz_Y_MT >= poz_Y_PHr) ||
                    (n == 4 && poz_X_MT <= poz_X_PHr && poz_Y_MT >= poz_Y_PHr) ||
                    (n == 5 && poz_X_MT >= poz_X_PHr && poz_Y_MT <= poz_Y_PHr) ||
                    (n == 6 && poz_X_MT <= poz_X_PHr && poz_Y_MT <= poz_Y_PHr))
                {
                    return true;
                }
            }
            else if(obtiznost == 3)
            {
                if((n == 3 && (poz_X_MT - poz_X_PHr) + (poz_Y_MT - poz_Y_PHr) > maxRozdil) ||
                    (n == 4 && (poz_X_PHr - poz_X_MT) + (poz_Y_MT - poz_Y_PHr) > maxRozdil) ||
                    (n == 5 && (poz_X_MT - poz_X_PHr) + (poz_Y_PHr - poz_Y_MT) > maxRozdil ||
                    (n == 6 && (poz_X_PHr - poz_X_MT) + (poz_Y_PHr - poz_Y_MT) > maxRozdil)))
                return true;
            }
            return false;
        }

        private(int, int, int, int, int) ProvedeniPocatecnichTahu(int n, int pocetTahu, int idOdebiranehoPole, int novePoleX, int novePoleY, int poleKeKontroleX, int poleKeKontroleY, int prvniTah, bool simulaceMod)
        {
            if(n == 0)
            {
                if (pocetTahu == 0)
                {
                    idOdebiranehoPole = 10;
                    novePoleX = leveOdsazeni - posun;
                    novePoleY = horniOdsazeni + posun * 12;
                    poleKeKontroleX = 0;
                    poleKeKontroleY = 0;
                }
                if (pocetTahu == 1)
                {
                    idOdebiranehoPole = 11;
                    novePoleX = leveOdsazeni + posun;
                    novePoleY = horniOdsazeni + posun * 12;
                    poleKeKontroleX = 0;
                    poleKeKontroleY = 0;
                }
                if (pocetTahu == 4)
                {
                    idOdebiranehoPole = 11;
                    novePoleX = leveOdsazeni + posun * 2;
                    novePoleY = horniOdsazeni + posun * 12;
                    poleKeKontroleX = 0;
                    poleKeKontroleY = 0;
                }
            }
            else if(n == 2)
            {
                if ((prvniTah == 1 && pocetTahu == 1 && !simulaceMod) || (prvniTah == 2 && pocetTahu == 0 && !simulaceMod) || (simulaceMod && pocetTahu == 0))//první tah - předem daný
                {
                    idOdebiranehoPole = 6;
                    novePoleX = leveOdsazeni - posun;
                    novePoleY = horniOdsazeni + posun * 4;
                    poleKeKontroleX = 0;
                    poleKeKontroleY = 0;
                }
                if ((prvniTah == 1 && pocetTahu == 2 && !simulaceMod) || (prvniTah == 2 && pocetTahu == 1 && !simulaceMod) || (simulaceMod && pocetTahu == 1))//druhý tah - předem daný
                {
                    idOdebiranehoPole = 8;
                    novePoleX = leveOdsazeni + posun;
                    novePoleY = horniOdsazeni + posun * 4;
                    poleKeKontroleX = 0;
                    poleKeKontroleY = 0;
                }
                if ((prvniTah == 1 && pocetTahu == 5 && !simulaceMod) || (prvniTah == 2 && pocetTahu == 4 && !simulaceMod) || (simulaceMod && pocetTahu == 4))//zajistí, že na y-ové pozici nejnižší nepřítelovo pole nezůstane samo vzadu
                {
                    idOdebiranehoPole = 0;
                    novePoleX = leveOdsazeni - posun * 2;
                    novePoleY = horniOdsazeni + posun * 4;
                    poleKeKontroleX = 0;
                    poleKeKontroleY = 0;
                }
            }
            return (idOdebiranehoPole, novePoleX, novePoleY, poleKeKontroleX, poleKeKontroleY);
        }

        private(int, int, int, int) PripravaKoncovychTahu(int n, int pocetPosledniRadek, int pocetPredposledniRadek, int pozXPosledniRadek, int pozXPredposledniRadek, int poz_X_PHr, int poz_Y_PHr)
        {
            if (n == 3 && poz_Y_PHr == horniOdsazeni + posun * 12 && poz_X_PHr >= leveOdsazeni + posun + 2)
            {
                pocetPosledniRadek++;
                if (poz_X_PHr < pozXPosledniRadek)
                {
                    pozXPosledniRadek = poz_X_PHr;
                }
            }

            if (n == 4 && poz_Y_PHr == horniOdsazeni + posun * 12 && poz_X_PHr <= leveOdsazeni - posun - 2)
            {
                pocetPosledniRadek++;
                if (poz_X_PHr > pozXPosledniRadek)
                {
                    pozXPosledniRadek = poz_X_PHr;
                }
            }

            if (n == 5 && poz_Y_PHr == horniOdsazeni + posun * 4 && poz_X_PHr >= leveOdsazeni + posun + 2)
            {
                pocetPosledniRadek++;
                if (poz_X_PHr < pozXPosledniRadek)
                {
                    pozXPosledniRadek = poz_X_PHr;
                }
            }

            if (n == 6 && poz_Y_PHr == horniOdsazeni + posun * 4 && poz_X_PHr <= leveOdsazeni - posun - 2)
            {
                pocetPosledniRadek++;
                if (poz_X_PHr > pozXPosledniRadek)
                {
                    pozXPosledniRadek = poz_X_PHr;
                }
            }

            if (n == 3 && poz_Y_PHr == horniOdsazeni + posun * 11 && poz_X_PHr >= leveOdsazeni + posun * 2 + posun / 2)
            {
                pocetPredposledniRadek++;
                if (poz_X_PHr < pozXPredposledniRadek)
                {
                    pozXPredposledniRadek = poz_X_PHr;
                }
            }

            if (n == 4 && poz_Y_PHr == horniOdsazeni + posun * 11 && poz_X_PHr <= leveOdsazeni - posun * 2 - posun / 2)
            {
                pocetPredposledniRadek++;
                if (poz_X_PHr > pozXPredposledniRadek)
                {
                    pozXPredposledniRadek = poz_X_PHr;
                }
            }

            if (n == 5 && poz_Y_PHr == horniOdsazeni + posun * 5 && poz_X_PHr >= leveOdsazeni + posun * 2 + posun / 2)
            {
                pocetPredposledniRadek++;
                if (poz_X_PHr < pozXPredposledniRadek)
                {
                    pozXPredposledniRadek = poz_X_PHr;
                }
            }

            if (n == 6 && poz_Y_PHr == horniOdsazeni + posun * 5 && poz_X_PHr <= leveOdsazeni - posun * 2 - posun / 2)
            {
                pocetPredposledniRadek++;
                if (poz_X_PHr > pozXPredposledniRadek)
                {
                    pozXPredposledniRadek = poz_X_PHr;
                }
            }
            return (pocetPosledniRadek, pocetPredposledniRadek, pozXPosledniRadek, pozXPredposledniRadek);
        }

        private (int, int) ZapocitaniKamenuVychozihoHrace(int n, int pocetPosledniRadek, int pocetPredposledniRadek, int poz_X_PHr, int poz_Y_PHr)
        {
            if (n == 3 && poz_X_PHr >= leveOdsazeni + posun * 5 && poz_Y_PHr == horniOdsazeni + posun * 12)
            {
                pocetPosledniRadek++;
            }
            if (n == 3 && poz_X_PHr == leveOdsazeni + posun * 4 + posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 11)
            {
                pocetPredposledniRadek++;
            }

            if (n == 4 && poz_X_PHr <= leveOdsazeni - posun * 5 && poz_Y_PHr == horniOdsazeni + posun * 12)
            {
                pocetPosledniRadek++;
            }
            if (n == 4 && poz_X_PHr == leveOdsazeni - posun * 4 - posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 11)
            {
                pocetPredposledniRadek++;
            }

            if (n == 5 && poz_X_PHr >= leveOdsazeni + posun * 5 && poz_Y_PHr == horniOdsazeni + posun * 4)
            {
                pocetPosledniRadek++;
            }
            if (n == 5 && poz_X_PHr == leveOdsazeni + posun * 4 + posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 5)
            {
                pocetPredposledniRadek++;
            }

            if (n == 6 && poz_X_PHr <= leveOdsazeni - posun * 5 && poz_Y_PHr == horniOdsazeni + posun * 4)
            {
                pocetPosledniRadek++;
            }
            if (n == 6 && poz_X_PHr == leveOdsazeni - posun * 4 - posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 5)
            {
                pocetPredposledniRadek++;
            }
            return (pocetPosledniRadek, pocetPredposledniRadek);
        }

        private (int, int, int, int, int) OsetreniKoncovychTahu(int n, int pocetPosledniRadek, int pocetPredposledniRadek, int pozXPosledniRadek, int pozXPredposledniRadek, int novePoleX, int novePoleY, int idOdebiranehoPole, int delkaSkokuX, int delkaSkokuY, int poleKeKontroleX, int poleKeKontroleY)
        {
            int poz_X_PHr, poz_Y_PHr, poz_X_MT, poz_Y_MT;
            bool hracSePohlSkokem;

            if ((pocetPosledniRadek == 5 && pocetPredposledniRadek >= 3) || (pocetPosledniRadek >= 4 && pocetPredposledniRadek == 4))
            {
                poleKeKontroleX = 0;
                poleKeKontroleY = 0;
                overovatVyhodnostTahu = false;
                hracSePohlSkokem = false;
                for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                {
                    PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                    poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                    poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                    int _idPocitacovehoHrace = pocitacovyHrac.Get_idPocitacovehoHrace();
                    if (_idPocitacovehoHrace != n)
                    {
                        continue;
                    }

                    if (n == 3 && ((poz_X_PHr == leveOdsazeni + posun * 2 && poz_Y_PHr == horniOdsazeni + posun * 12) || (poz_X_PHr == leveOdsazeni + posun * 2 + posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 11)))
                    {
                        mozneTahyPocitacovehoHrace.Clear();
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (poz_X_MT > poz_X_PHr && poz_Y_MT < poz_Y_PHr && poz_Y_PHr - poz_Y_MT == posun)
                            {
                                novePoleX = poz_X_MT;
                                novePoleY = poz_Y_MT;
                                idOdebiranehoPole = i;
                            }
                        }
                    }

                    if (n == 4 && ((poz_X_PHr == leveOdsazeni - posun * 2 && poz_Y_PHr == horniOdsazeni + posun * 12) || (poz_X_PHr == leveOdsazeni - posun * 2 - posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 11)))
                    {
                        mozneTahyPocitacovehoHrace.Clear();
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (poz_X_MT < poz_X_PHr && poz_Y_MT < poz_Y_PHr && poz_Y_PHr - poz_Y_MT == posun)
                            {
                                novePoleX = poz_X_MT;
                                novePoleY = poz_Y_MT;
                                idOdebiranehoPole = i;
                            }
                        }
                    }

                    if (n == 5 && ((poz_X_PHr == leveOdsazeni + posun * 2 && poz_Y_PHr == horniOdsazeni + posun * 4) || (poz_X_PHr == leveOdsazeni + posun * 2 + posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 5)))
                    {
                        mozneTahyPocitacovehoHrace.Clear();
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (poz_X_MT > poz_X_PHr && poz_Y_MT > poz_Y_PHr && poz_Y_MT - poz_Y_PHr == posun)
                            {
                                novePoleX = poz_X_MT;
                                novePoleY = poz_Y_MT;
                                idOdebiranehoPole = i;
                            }
                        }
                    }

                    if (n == 6 && ((poz_X_PHr == leveOdsazeni - posun * 2 && poz_Y_PHr == horniOdsazeni + posun * 4) || (poz_X_PHr == leveOdsazeni - posun * 2 - posun / 2 && poz_Y_PHr == horniOdsazeni + posun * 5)))
                    {
                        mozneTahyPocitacovehoHrace.Clear();
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (poz_X_MT < poz_X_PHr && poz_Y_MT > poz_Y_PHr && poz_Y_MT - poz_Y_PHr == posun)
                            {
                                novePoleX = poz_X_MT;
                                novePoleY = poz_Y_MT;
                                idOdebiranehoPole = i;
                            }
                        }
                    }
                }
            }

            //pokud má nepřítel na posledním a předposledním řádku na y-ové ose správně rozmístěná pole k ukončení hry, zajistíme přesun nesprávně umístěného pole na 3. řádku odspodu
            //pohyb provedeme na x-ové ose směrem v závislosti na tom, o kterého nepřítele se jedná (popř. pokud tento tah není možný, provedeme tah směrem dolů na y-ové ose)
            if (pocetPosledniRadek == 4 && pocetPredposledniRadek == 3)
            {
                poleKeKontroleX = 0;
                poleKeKontroleY = 0;
                overovatVyhodnostTahu = false;
                hracSePohlSkokem = false;
                for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                {
                    PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                    poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                    poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                    int _idPocitacovehoHrace = pocitacovyHrac.Get_idPocitacovehoHrace();
                    if (_idPocitacovehoHrace != n)
                    {
                        continue;
                    }

                    //hledáme vhodný tah na x-ové ose
                    if (n == 3 && pozXPosledniRadek == leveOdsazeni + posun * 3 && pozXPredposledniRadek == leveOdsazeni + posun * 3 + posun / 2 && poz_X_PHr == leveOdsazeni + posun * 3 && poz_Y_PHr == horniOdsazeni + posun * 10)
                    {
                        bool nalezenTah = false;
                        mozneTahyPocitacovehoHrace.Clear();
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (poz_X_MT > poz_X_PHr && poz_Y_MT == poz_Y_PHr)
                            {
                                novePoleX = poz_X_MT;
                                novePoleY = poz_Y_MT;
                                idOdebiranehoPole = i;
                                nalezenTah = true;
                            }
                        }

                        if (!nalezenTah)//tah na x-ové ose nenalezen, provedeme tedy tah směrem dolů na y-ové ose
                        {
                            vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                            for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                            {
                                MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                                poz_X_MT = moznyTah.Get_poz_X_MT();
                                poz_Y_MT = moznyTah.Get_poz_Y_MT();

                                if (poz_Y_MT < poz_Y_PHr && poz_X_MT > poz_X_PHr)
                                {
                                    novePoleX = poz_X_MT;
                                    novePoleY = poz_Y_MT;
                                    idOdebiranehoPole = i;
                                }
                            }
                        }
                    }

                    //hledáme vhodný tah na x-ové ose
                    if (n == 4 && pozXPosledniRadek == leveOdsazeni - posun * 3 && pozXPredposledniRadek == leveOdsazeni - posun * 3 - posun / 2 && poz_X_PHr == leveOdsazeni - posun * 3 && poz_Y_PHr == horniOdsazeni + posun * 10)
                    {
                        bool nalezenTah = false;
                        mozneTahyPocitacovehoHrace.Clear();
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (poz_X_MT < poz_X_PHr && poz_Y_MT == poz_Y_PHr)
                            {
                                novePoleX = poz_X_MT;
                                novePoleY = poz_Y_MT;
                                idOdebiranehoPole = i;
                                nalezenTah = true;
                            }
                        }

                        if (!nalezenTah)//tah na x-ové ose nenalezen, provedeme tedy tah směrem dolů na y-ové ose
                        {
                            vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                            for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                            {
                                MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                                poz_X_MT = moznyTah.Get_poz_X_MT();
                                poz_Y_MT = moznyTah.Get_poz_Y_MT();

                                if (poz_Y_MT < poz_Y_PHr && poz_X_MT < poz_X_PHr)
                                {
                                    novePoleX = poz_X_MT;
                                    novePoleY = poz_Y_MT;
                                    idOdebiranehoPole = i;
                                }
                            }
                        }
                    }

                    //hledáme vhodný tah na x-ové ose
                    if (n == 5 && pozXPosledniRadek == leveOdsazeni + posun * 3 && pozXPredposledniRadek == leveOdsazeni + posun * 3 + posun / 2 && poz_X_PHr == leveOdsazeni + posun * 3 && poz_Y_PHr == horniOdsazeni + posun * 6)
                    {
                        bool nalezenTah = false;
                        mozneTahyPocitacovehoHrace.Clear();
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (poz_X_MT > poz_X_PHr && poz_Y_MT == poz_Y_PHr)
                            {
                                novePoleX = poz_X_MT;
                                novePoleY = poz_Y_MT;
                                idOdebiranehoPole = i;
                                nalezenTah = true;
                            }
                        }

                        if (!nalezenTah)//tah na x-ové ose nenalezen, provedeme tedy tah směrem nahoru na y-ové ose
                        {
                            vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                            for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                            {
                                MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                                poz_X_MT = moznyTah.Get_poz_X_MT();
                                poz_Y_MT = moznyTah.Get_poz_Y_MT();

                                if (poz_Y_MT > poz_Y_PHr && poz_X_MT > poz_X_PHr)
                                {
                                    novePoleX = poz_X_MT;
                                    novePoleY = poz_Y_MT;
                                    idOdebiranehoPole = i;
                                }
                            }
                        }
                    }

                    //hledáme vhodný tah na x-ové ose
                    if (n == 6 && pozXPosledniRadek == leveOdsazeni - posun * 3 && pozXPredposledniRadek == leveOdsazeni - posun * 3 - posun / 2 && poz_X_PHr == leveOdsazeni - posun * 3 && poz_Y_PHr == horniOdsazeni + posun * 6)
                    {
                        bool nalezenTah = false;
                        mozneTahyPocitacovehoHrace.Clear();
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                        for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                        {
                            MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                            poz_X_MT = moznyTah.Get_poz_X_MT();
                            poz_Y_MT = moznyTah.Get_poz_Y_MT();

                            if (poz_X_MT < poz_X_PHr && poz_Y_MT == poz_Y_PHr)
                            {
                                novePoleX = poz_X_MT;
                                novePoleY = poz_Y_MT;
                                idOdebiranehoPole = i;
                                nalezenTah = true;
                            }
                        }

                        if (!nalezenTah)//tah na x-ové ose nenalezen, provedeme tedy tah směrem nahoru na y-ové ose
                        {
                            vypocetMoznychTahu.PridaniMoznychTahu(poz_X_PHr, poz_Y_PHr, n, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                            for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                            {
                                MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[j];
                                poz_X_MT = moznyTah.Get_poz_X_MT();
                                poz_Y_MT = moznyTah.Get_poz_Y_MT();

                                if (poz_Y_MT > poz_Y_PHr && poz_X_MT < poz_X_PHr)
                                {
                                    novePoleX = poz_X_MT;
                                    novePoleY = poz_Y_MT;
                                    idOdebiranehoPole = i;
                                }
                            }
                        }
                    }
                }
            }


            //ošetření případů, kdy je počítačový hráč blokován protilehlým hráčem, a zbývá mu dosadit jeden kámen do rohu nejbližšího ke středu herní desky
            if (n == 3)
            {
                bool[] polohyKamenu = { false, false, false };
                int pocetKamenu = 0;
                for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                {
                    if (polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni + posun * 3 + posun / 2 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 9)
                    {
                        polohyKamenu[2] = true;
                    }
                    if (!(polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 3 || polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 6))
                    {
                        continue;
                    }
                    if ((polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 3 && JePoleVSpodnimPravemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                        (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 6 && JePoleVSpodnimPravemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), false)))
                    {
                        pocetKamenu++;
                    }
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 3 && polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni + posun * 4 + posun / 2 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 9)
                    {
                        polohyKamenu[0] = true;
                    }
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 3 && polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni + posun * 3 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 10)
                    {
                        polohyKamenu[1] = true;
                    }
                }
                if (pocetKamenu == 9 && polohyKamenu[0] == false)//bylo tu true
                {
                    if (polohyKamenu[1] == true && polohyKamenu[2] == false)
                    {
                        novePoleX = leveOdsazeni + posun * 3 + posun / 2;
                        novePoleY = horniOdsazeni + posun * 9;
                    }
                }
            }
            else if (n == 4)
            {
                bool[] polohyKamenu = { false, false, false };
                int pocetKamenu = 0;
                for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                {
                    if (polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni - posun * 3 - posun / 2 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 9)
                    {
                        polohyKamenu[2] = true;
                    }
                    if (!(polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 4 || polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 5))
                    {
                        continue;
                    }
                    if ((polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 4 && JePoleVSpodnimLevemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                        (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 5 && JePoleVSpodnimLevemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), false)))
                    {
                        pocetKamenu++;
                    }
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 4 && polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni - posun * 4 - posun / 2 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 9)
                    {
                        polohyKamenu[0] = true;
                    }
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 4 && polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni - posun * 3 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 10)
                    {
                        polohyKamenu[1] = true;
                    }
                }
                if (pocetKamenu == 9 && polohyKamenu[0] == true)
                {
                    if (polohyKamenu[1] == true && polohyKamenu[2] == false)
                    {
                        novePoleX = leveOdsazeni - posun * 3 - posun / 2;
                        novePoleY = horniOdsazeni + posun * 9;
                    }
                }
            }
            else if (n == 5)
            {
                bool[] polohyKamenu = { false, false, false };
                int pocetKamenu = 0;
                for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                {
                    if (polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni + posun * 3 + posun / 2 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 7)
                    {
                        polohyKamenu[2] = true;
                    }
                    if (!(polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 5 || polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 4))
                    {
                        continue;
                    }
                    if ((polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 5 && JePoleVHornimPravemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                        (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 4 && JePoleVHornimPravemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), false)))
                    {
                        pocetKamenu++;
                    }
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 5 && polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni + posun * 4 + posun / 2 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 7)
                    {
                        polohyKamenu[0] = true;
                    }
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 5 && polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni + posun * 3 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 6)
                    {
                        polohyKamenu[1] = true;
                    }
                }
                if (pocetKamenu == 9 && polohyKamenu[0] == true)
                {
                    if (polohyKamenu[1] == true && polohyKamenu[2] == false)
                    {
                        novePoleX = leveOdsazeni + posun * 3 + posun / 2;
                        novePoleY = horniOdsazeni + posun * 7;
                    }
                }
            }
            else if (n == 6)
            {
                bool[] polohyKamenu = { false, false, false };
                int pocetKamenu = 0;
                for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                {
                    if (polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni - posun * 3 - posun / 2 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 7)
                    {
                        polohyKamenu[2] = true;
                    }
                    if (!(polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 6 || polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 3))
                    {
                        continue;
                    }
                    if ((polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 6 && JePoleVHornimLevemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                        (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 3 && JePoleVHornimLevemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), false)))
                    {
                        pocetKamenu++;
                    }
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 6 && polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni - posun * 4 - posun / 2 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 7)
                    {
                        polohyKamenu[0] = true;
                    }
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == 6 && polePocitacovehoHrace[i].Get_poz_X_PHr() == leveOdsazeni + posun * 3 && polePocitacovehoHrace[i].Get_poz_Y_PHr() == horniOdsazeni + posun * 6)
                    {
                        polohyKamenu[1] = true;
                    }
                }
                if (pocetKamenu == 9 && polohyKamenu[0] == true)
                {
                    if (polohyKamenu[1] == true && polohyKamenu[2] == false)
                    {
                        novePoleX = leveOdsazeni - posun * 3 - posun / 2;
                        novePoleY = horniOdsazeni + posun * 7;
                    }
                }
            }

            return (novePoleX, novePoleY, idOdebiranehoPole, poleKeKontroleX, poleKeKontroleY);
        }

        private bool SplnenyPodminkyProPohyb(int n, bool simulaceMod)
        {
            if ((n == 0 && !simulaceMod) || n == 1 || (pocetHracu == 2 && n > 2) || (pocetHracu == 3 && (n == 2 || n > 4)) || (pocetHracu == 4 && (!simulaceMod && (n == 2 || n == 5) || simulaceMod && (n == 0 || n == 2))))
            {
                return false;
            }
            return true;
        }

        private void VytvoreniTahuLidskehoHrace()
        {
            int poz_X_MT, poz_Y_MT, poz_X_Hr, poz_Y_Hr, delkaSkokuX = 0, delkaSkokuY = 0;
            bool hracSePohlSkokem;

            for (int i = 0; i < poleLidskehoHrace.Count; i++)
            {
                hracSePohlSkokem = false;
                LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                vypocetMoznychTahu.PridaniMoznychTahu(poz_X_Hr, poz_Y_Hr, 1, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);

                for (int j = 0; j < mozneTahyLidskehoHrace.Count; j++)
                {
                    MoznyTahLidskehoHrace moznyTah = mozneTahyLidskehoHrace[j];
                    poz_X_MT = moznyTah.Get_poz_X_MT();
                    poz_Y_MT = moznyTah.Get_poz_Y_MT();

                    if (poz_Y_MT - poz_Y_Hr > posun)//na ověřovaný možný tah se budeme muset dostat skokem
                    {
                        hracSePohlSkokem = true;
                    }
                    else
                    {
                        hracSePohlSkokem = false;
                    }

                    if (hracSePohlSkokem)//na ověřované pole jsme se dostali skokem - zkontrolujeme možné tahy z tohoto pole
                    {
                        delkaSkokuX = Math.Abs(moznyTah.Get_poz_X_MT() - moznyTah.Get_poz_X_KLHr());
                        delkaSkokuY = Math.Abs(moznyTah.Get_poz_Y_MT() - moznyTah.Get_poz_Y_KLHr());
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_MT, poz_Y_MT, 1, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                    }
                }
            }
        }

        private int VypocetNejvyhodnejsihoTahuLidskehoHrace(int pocetHracu)
        {
            int maxRozdilHrac = 0, poz_X_Hr, poz_Y_Hr, poz_X_MT, poz_Y_MT, delkaSkokuX = 0, delkaSkokuY = 0;
            bool hracSePohlSkokem;
            mozneTahyLidskehoHrace.Clear();

            for (int i = 0; i < poleLidskehoHrace.Count; i++)
            {
                mozneTahyLidskehoHrace.Clear();
                hracSePohlSkokem = false;
                LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                vypocetMoznychTahu.PridaniMoznychTahu(poz_X_Hr, poz_Y_Hr, 1, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);

                for (int j = 0; j < mozneTahyLidskehoHrace.Count; j++)
                {
                    MoznyTahLidskehoHrace moznyTah = mozneTahyLidskehoHrace[j];
                    poz_X_MT = moznyTah.Get_poz_X_MT();
                    poz_Y_MT = moznyTah.Get_poz_Y_MT();

                    if (Math.Abs(poz_Y_Hr - poz_Y_MT) > posun || Math.Abs(poz_X_Hr - poz_X_MT) > posun)//na ověřovaný možný tah se budeme muset dostat skokem
                    {
                        hracSePohlSkokem = true;
                    }
                    else
                    {
                        hracSePohlSkokem = false;
                    }

                    if (hracSePohlSkokem)//na ověřované pole jsme se dostali skokem - zkontrolujeme možné tahy z tohoto pole
                    {
                        delkaSkokuX = Math.Abs(moznyTah.Get_poz_X_MT() - moznyTah.Get_poz_X_KLHr());
                        delkaSkokuY = Math.Abs(moznyTah.Get_poz_Y_MT() - moznyTah.Get_poz_Y_KLHr());
                        vypocetMoznychTahu.PridaniMoznychTahu(poz_X_MT, poz_Y_MT, 1, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                    }

                    if (pocetHracu != 4)
                    {
                        if (poz_Y_Hr - poz_Y_MT > maxRozdilHrac)//nalezli jsme možný tah který dostane hráče na y-ové ose dál než dříve nalezený možný tah
                        {
                            maxRozdilHrac = poz_Y_Hr - poz_Y_MT;
                        }
                    }
                    else
                    {
                        if ((poz_Y_Hr - poz_Y_MT) + (poz_X_MT - poz_Y_Hr) > maxRozdilHrac)//nalezli jsme možný tah který dostane hráče k cíli blíže než dříve nalezený možný tah
                        {
                            maxRozdilHrac = (poz_Y_Hr - poz_Y_MT) + (poz_X_MT - poz_Y_Hr);
                        }
                    }
                }
            }
            return maxRozdilHrac;
        }

        //funkce ověří, jestli je daný tah výhodný z hlediska možných tahů lidského hráče - jestli provedením tahu umožníme hráči doskočit dál než před provedením tohoto tahu
        private bool JeTahVyhodny(int poz_X_PHr, int poz_Y_PHr, int poz_X_MT, int poz_Y_MT, int idPocitacovehoHrace, int nejvyhodnejsiHracuvTah, int pocetHracu)
        {
            if(simulaceMod || (poz_X_PHr == 0 && poz_Y_PHr == 0))
            {
                return true;
            }
            bool hracSePohlSkokem;
            int poz_X_Hr, poz_Y_Hr, _poz_X_MT, _poz_Y_MT, delkaSkokuX = 0, delkaSkokuY = 0;
            mozneTahyLidskehoHrace.Clear();
            int odebranePolePocitacovehoHrace = 0;
            bool nalezeno = false;
            for (int i = 0; i < polePocitacovehoHrace.Count; i++)
            {
                PocitacovyHrac odebiranyPocitacovyHracOld = polePocitacovehoHrace[i];
                if (poz_X_PHr == odebiranyPocitacovyHracOld.Get_poz_X_PHr() && poz_Y_PHr == odebiranyPocitacovyHracOld.Get_poz_Y_PHr())
                {
                    odebranePolePocitacovehoHrace = i;
                    nalezeno = true;
                    polePocitacovehoHrace.Remove(odebiranyPocitacovyHracOld);
                    break;
                }
            }
            if (!nalezeno)
            {
                return false;
            }

            PocitacovyHrac pridavanyPocitacovyHracOld = new PocitacovyHrac(poz_X_MT, poz_Y_MT, sirkaPole, vyskaPole, idPocitacovehoHrace);
            polePocitacovehoHrace.Add(pridavanyPocitacovyHracOld);
            for (int i = 0; i < poleLidskehoHrace.Count; i++)
            {
                mozneTahyLidskehoHrace.Clear();
                hracSePohlSkokem = false;
                LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                vypocetMoznychTahu.PridaniMoznychTahu(poz_X_Hr, poz_Y_Hr, 1, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                for (int j = 0; j < mozneTahyLidskehoHrace.Count; j++)
                {
                    MoznyTahLidskehoHrace moznyTah = mozneTahyLidskehoHrace[j];
                    _poz_X_MT = moznyTah.Get_poz_X_MT();
                    _poz_Y_MT = moznyTah.Get_poz_Y_MT();

                    if (Math.Abs(poz_Y_Hr - _poz_Y_MT) > posun || Math.Abs(poz_X_Hr - _poz_X_MT) > posun)//na ověřovaný možný tah se budeme muset dostat skokem
                    {
                        hracSePohlSkokem = true;
                    }
                    else
                    {
                        hracSePohlSkokem = false;
                    }

                    if (hracSePohlSkokem)//na ověřované pole jsme se dostali skokem - zkontrolujeme možné tahy z tohoto pole
                    {
                        delkaSkokuX = Math.Abs(moznyTah.Get_poz_X_MT() - moznyTah.Get_poz_X_KLHr());
                        delkaSkokuY = Math.Abs(moznyTah.Get_poz_Y_MT() - moznyTah.Get_poz_Y_KLHr());
                        vypocetMoznychTahu.PridaniMoznychTahu(_poz_X_MT, _poz_Y_MT, 1, pocetHracu, hracSePohlSkokem, delkaSkokuX, delkaSkokuY, poleLidskehoHrace, polePocitacovehoHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
                    }

                    if ((pocetHracu != 4 && poz_Y_Hr - _poz_Y_MT > nejvyhodnejsiHracuvTah) || (pocetHracu == 4 && (poz_Y_Hr - _poz_Y_MT) + (_poz_X_MT - poz_Y_Hr) > nejvyhodnejsiHracuvTah))
                    {
                        mozneTahyLidskehoHrace.Clear();
                        polePocitacovehoHrace.Remove(pridavanyPocitacovyHracOld);
                        PocitacovyHrac pridavanyPocitacovyHracNew = new PocitacovyHrac(poz_X_PHr, poz_Y_PHr, sirkaPole, vyskaPole, idPocitacovehoHrace);
                        polePocitacovehoHrace.Insert(odebranePolePocitacovehoHrace, pridavanyPocitacovyHracNew);
                        VytvoreniTahuLidskehoHrace();
                        return false;
                    }
                }
            }

            mozneTahyLidskehoHrace.Clear();
            polePocitacovehoHrace.Remove(pridavanyPocitacovyHracOld);
            PocitacovyHrac pridavanyPocitacovyHracNew2 = new PocitacovyHrac(poz_X_PHr, poz_Y_PHr, sirkaPole, vyskaPole, idPocitacovehoHrace);
            polePocitacovehoHrace.Insert(odebranePolePocitacovehoHrace, pridavanyPocitacovyHracNew2);
            VytvoreniTahuLidskehoHrace();
            return true;
        }

        private void PridaniPolePocitacovehoHrace(int idOdebiranehoPole, int novePoleX, int novePoleY, int idPocitacovehoHrace)
        {
            if (novePoleX == 0 && novePoleY == 0)//tato chyba může nastat pokud jsou cílová pole daného nepřítele blokována poli nepřítele, který na těchto polích začínal
            {
                for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                {
                    if (polePocitacovehoHrace[i].Get_idPocitacovehoHrace() == idPocitacovehoHrace)
                    {
                        if ((idPocitacovehoHrace == 0 && !JePoleVNejvyssimRohu(polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                            (idPocitacovehoHrace == 2 && !JePoleVNejnizsimRohu( polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                            (idPocitacovehoHrace == 3 && !JePoleVSpodnimPravemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                            (idPocitacovehoHrace == 4 && !JePoleVSpodnimLevemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                            (idPocitacovehoHrace == 5 && !JePoleVHornimPravemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)) ||
                            (idPocitacovehoHrace == 6 && !JePoleVHornimLevemRohu(polePocitacovehoHrace[i].Get_poz_X_PHr(), polePocitacovehoHrace[i].Get_poz_Y_PHr(), true)))
                        {
                            for (int j = 0; j < mozneTahyPocitacovehoHrace.Count; j++)
                            {
                                if (mozneTahyPocitacovehoHrace[j].Get_poz_X_KPHr() == polePocitacovehoHrace[i].Get_poz_X_PHr() && mozneTahyPocitacovehoHrace[j].Get_poz_Y_KPHr() == polePocitacovehoHrace[i].Get_poz_Y_PHr())
                                {
                                    PridaniPolePocitacovehoHrace(i, mozneTahyPocitacovehoHrace[j].Get_poz_X_MT(), mozneTahyPocitacovehoHrace[j].Get_poz_Y_MT(), idPocitacovehoHrace);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                overovatVyhodnostTahu = true;
                PocitacovyHrac staryPocitacovyHrac = polePocitacovehoHrace[idOdebiranehoPole];
                int idHrace = staryPocitacovyHrac.Get_idPocitacovehoHrace();
                VychoziPolePocitacovehoHrace pole = new VychoziPolePocitacovehoHrace(staryPocitacovyHrac.Get_poz_X_PHr(), staryPocitacovyHrac.Get_poz_Y_PHr(), sirkaPole, vyskaPole, staryPocitacovyHrac.Get_idPocitacovehoHrace());
                vychoziPolePocitacovehoHrace.Add(pole);
                polePocitacovehoHrace.Remove(staryPocitacovyHrac);
                PocitacovyHrac novyPocitacovyHrac = new PocitacovyHrac(novePoleX, novePoleY, sirkaPole, vyskaPole, idHrace);
                polePocitacovehoHrace.Add(novyPocitacovyHrac);
                ZvyrazneniPolePocitacovehoHrace zvyrazneni = new ZvyrazneniPolePocitacovehoHrace(novePoleX, novePoleY, sirkaPole, vyskaPole);
                zvyraznenaPolePocitacovehoHrace.Add(zvyrazneni);
            }
        }

        private bool JePoleVNejvyssimRohu(int poz_Y_PHr, bool kontrolovatCelyTrojUhelnik)
        {
            if (kontrolovatCelyTrojUhelnik)
            {
                if (poz_Y_PHr > horniOdsazeni + posun * 3)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if(poz_Y_PHr <= horniOdsazeni + posun)
                {
                    return true;
                }
                return false;
            }

        }

        private bool JePoleVNejnizsimRohu(int poz_Y_PHr, bool kontrolovatCelyTrojUhelnik)
        {
            if (kontrolovatCelyTrojUhelnik)
            {
                if (poz_Y_PHr < horniOdsazeni + posun * 13)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if(poz_Y_PHr >= horniOdsazeni + posun * 15)
                {
                    return true;
                }
                return false;
            }
        }

        private bool JePoleVSpodnimLevemRohu(int poz_X_PHr, int poz_Y_PHr, bool kontrolovatCelyTrojUhelnik)
        {
            if (kontrolovatCelyTrojUhelnik)
            {
                if ((poz_Y_PHr <= horniOdsazeni + posun * 8) || (poz_Y_PHr >= horniOdsazeni + posun * 13) || (poz_Y_PHr == posun * 9 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_PHr == posun * 10 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 4) || (poz_Y_PHr == posun * 11 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_PHr == posun * 12 + horniOdsazeni && poz_X_PHr > leveOdsazeni - posun * 3))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((poz_Y_PHr == posun * 11 + horniOdsazeni && poz_X_PHr == leveOdsazeni - posun * 5 - posun / 2) || (poz_Y_PHr == posun * 12 + horniOdsazeni && poz_X_PHr <= leveOdsazeni - posun * 5))
                {
                    return true;
                }
                return false;
            }
        }

        private bool JePoleVHornimPravemRohu(int poz_X_PHr, int poz_Y_PHr, bool kontrolovatCelyTrojUhelnik)
        {
            if (kontrolovatCelyTrojUhelnik)
            {
                if ((poz_Y_PHr >= horniOdsazeni + posun * 8) || (poz_Y_PHr <= horniOdsazeni + posun * 3) || (poz_Y_PHr == horniOdsazeni + posun * 7 && poz_X_PHr < leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_PHr == horniOdsazeni + posun * 6 && poz_X_PHr < leveOdsazeni + posun * 4) || (poz_Y_PHr == horniOdsazeni + posun * 5 && poz_X_PHr < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_PHr == horniOdsazeni + posun * 4 && poz_X_PHr < leveOdsazeni + posun * 3))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((poz_Y_PHr == posun * 5 + horniOdsazeni && poz_X_PHr == leveOdsazeni + posun * 5 + posun / 2) || (poz_Y_PHr == posun * 4 + horniOdsazeni && poz_X_PHr >= leveOdsazeni + posun * 5))
                {
                    return true;
                }
                return false;
            }
        }

        private bool JePoleVSpodnimPravemRohu(int poz_X_PHr, int poz_Y_PHr, bool kontrolovatCelyTrojUhelnik)
        {
            if(kontrolovatCelyTrojUhelnik)
            {
                if ((poz_Y_PHr <= horniOdsazeni + posun * 8) || (poz_Y_PHr >= horniOdsazeni + posun * 13) || (poz_Y_PHr == posun * 9 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_PHr == posun * 10 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 4) || (poz_Y_PHr == posun * 11 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_PHr == posun * 12 + horniOdsazeni && poz_X_PHr < leveOdsazeni + posun * 3))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((poz_Y_PHr == posun * 11 + horniOdsazeni && poz_X_PHr == leveOdsazeni + posun * 5 + posun / 2) || (poz_Y_PHr == posun * 12 + horniOdsazeni && poz_X_PHr >= leveOdsazeni + posun * 5))
                {
                    return  true;
                }
                return false;
            }
        }

        private bool JePoleVHornimLevemRohu(int poz_X_PHr, int poz_Y_PHr, bool kontrolovatCelyTrojUhelnik)
        {
            if (kontrolovatCelyTrojUhelnik)
            {
                if ((poz_Y_PHr >= horniOdsazeni + posun * 8) || (poz_Y_PHr <= horniOdsazeni + posun * 3) || (poz_Y_PHr == horniOdsazeni + posun * 7 && poz_X_PHr > leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_PHr == horniOdsazeni + posun * 6 && poz_X_PHr > leveOdsazeni - posun * 4) || (poz_Y_PHr == horniOdsazeni + posun * 5 && poz_X_PHr > leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_PHr == horniOdsazeni + posun * 4 && poz_X_PHr > leveOdsazeni - posun * 3))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((poz_Y_PHr == posun * 5 - horniOdsazeni && poz_X_PHr == leveOdsazeni - posun * 5 - posun / 2) || (poz_Y_PHr == posun * 4 + horniOdsazeni && poz_X_PHr <= leveOdsazeni - posun * 5))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
