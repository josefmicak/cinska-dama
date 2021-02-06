using System;
using System.Collections.Generic;

namespace Čínská_dáma
{
    class VypocetMoznychTahu
    {
        private int sirkaPole;
        private int vyskaPole;
        private int posun;
        private int horniOdsazeni;
        private int leveOdsazeni;
        private List<Pole> herniPole = new List<Pole>();

        public VypocetMoznychTahu(int sirkaPole, int vyskaPole, int posun, int horniOdsazeni, int leveOdsazeni, List<Pole> herniPole)
        {
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;
            this.posun = posun;
            this.herniPole = herniPole;
            this.horniOdsazeni = horniOdsazeni;
            this.leveOdsazeni = leveOdsazeni;
        }

        public (List<MoznyTahLidskehoHrace> mozneTahyLidskehoHrace, List<MoznyTahPocitacovehoHrace> mozneTahyPocitacovehoHrace) PridaniMoznychTahu(int poz_X_KHr, int poz_Y_KHr, int idHrace, int pocetHracu, bool hracSePohlSkokem, int delkaSkokuX, int delkaSkokuY, List<LidskyHrac> poleLidskehoHrace, List<PocitacovyHrac> polePocitacovehoHrace, List<MoznyTahLidskehoHrace> mozneTahyLidskehoHrace, List<MoznyTahPocitacovehoHrace> mozneTahyPocitacovehoHrace)
        {
            int poz_X_Hr, poz_Y_Hr, poz_X_He, poz_Y_He, poz_X_PHr, poz_Y_PHr;

            if(hracSePohlSkokem == false)
            {
                delkaSkokuX = 0;
                delkaSkokuY = 0;
            }

            for (int i = 0; i < herniPole.Count; i++)
            {
                Pole p = herniPole[i];
                poz_X_He = p.Get_poz_X_He();
                poz_Y_He = p.Get_poz_Y_He();

                //nejprve zamezíme přístup do všech trojúhelníků s výjimkou výchozího a cílového trojúhelníku
                if (((idHrace == 0 || idHrace == 2) || (idHrace == 1 && pocetHracu != 4)) && (TahDoObouHornichRohu(poz_X_He, poz_Y_He) || TahDoObouSpodnichRohu(poz_X_He, poz_Y_He)))
                {
                    continue;
                }

                if(idHrace == 3 && (TahDoNejnizsihoANejvyssihoRohu(poz_Y_He) || TahDoHornihoPravehoRohu(poz_X_He, poz_Y_He) || TahDoSpodnihoLevehoRohu(poz_X_He, poz_Y_He)))
                {
                    continue;
                }

                if(idHrace == 4 && (TahDoNejnizsihoANejvyssihoRohu(poz_Y_He) || TahDoHornihoLevehoRohu(poz_X_He, poz_Y_He) || TahDoSpodnihoPravehoRohu(poz_X_He, poz_Y_He)))
                {
                    continue;
                }

                if((idHrace == 5 || (idHrace == 1 && pocetHracu == 4)) && (TahDoNejnizsihoANejvyssihoRohu(poz_Y_He) || TahDoHornihoLevehoRohu(poz_X_He, poz_Y_He) || TahDoSpodnihoPravehoRohu(poz_X_He, poz_Y_He)))
                {
                    continue;
                }

                if((idHrace == 6) && (TahDoNejnizsihoANejvyssihoRohu(poz_Y_He) || TahDoHornihoPravehoRohu(poz_X_He, poz_Y_He) || TahDoSpodnihoLevehoRohu(poz_X_He, poz_Y_He)))
                {
                    continue;
                }

                //řeší přidání možných tahů polí přímo sousedících s vybraným polem 
                //1. podmínka: vzdálenost kliknutého hráčova pole a zrovna procházeného herního pole není větší než dané odsazení mezi herními poli (na y-ové ose)
                //2. podmínka: vzdálenost kliknutého hráčova pole a zrovna procházeného herního pole není větší než dané odsazení mezi herními poli (na x-ové ose)
                //3. podmínka: tah není duplikátní (na daném poli se již nenachází možný tah)
                //4. podmínka: na daném poli není žádné hráčovo nebo nepřítelovo pole
                //5. podmínka: hráč neprovedl ve svém tahu skok
                if (Math.Abs(poz_Y_KHr - poz_Y_He) <= posun && (Math.Abs(poz_X_KHr - poz_X_He) <= posun) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !hracSePohlSkokem)
                {
                    if (idHrace == 1)
                    {
                        MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                        mozneTahyLidskehoHrace.Add(tah);
                    }
                    else
                    {
                        MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                        mozneTahyPocitacovehoHrace.Add(tah);
                    }
                }

                //řeší možné tahy dosažitelné pomocí skoků na vodorovné ose
                for (int j = 0; j < poleLidskehoHrace.Count; j++)
                {
                    LidskyHrac lidskyHrac = poleLidskehoHrace[j];
                    poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                    poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();

                    //1. podmínka: vzdálenost kliknutého hráčova pole a zrovna procházeného hráčova pole je stejná jako vzdálenost zrovna procházeného hráčova pole a zrovna procházeného herního pole
                    //2. podmínka: kliknuté hráčovo pole a právě procházené hráčovo pole jsou na stejné ose
                    //3. podmínka: kliknuté hráčovo pole a právě procházené herní pole jsou na stejné ose
                    //6. podmínka: mezi právě procházeným herním polem a kliknutým hráčovým polem nachází právě 1 hráčovo pole
                    if ((poz_X_KHr - poz_X_Hr == poz_X_Hr - poz_X_He) && (poz_Y_KHr == poz_Y_Hr) && (poz_Y_KHr == poz_Y_He) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !hracSePohlSkokem)
                    {
                        if (idHrace == 1)
                        {
                            MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                            mozneTahyLidskehoHrace.Add(tah);
                        }
                        else
                        {
                            MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                            mozneTahyPocitacovehoHrace.Add(tah);
                        }
                    }
                }

                //řeší možné tahy dosažitelné pomocí skoků na vodorovné ose - nepřítel
                for (int j = 0; j < polePocitacovehoHrace.Count; j++)
                {
                    PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[j];
                    poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                    poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                    //1. podmínka: vzdálenost kliknutého nepřítelova pole a zrovna procházeného nepřítelova pole je stejná jako vzdálenost zrovna procházeného nepřítelova pole a zrovna procházeného herního pole
                    //2. podmínka: kliknuté nepřítelova pole a právě procházené nepřítelova pole jsou na stejné ose
                    //3. podmínka: kliknuté nepřítelova pole a právě procházené herní pole jsou na stejné ose
                    //6. podmínka: mezi právě procházeným herním polem a kliknutým nepřítelova polem nachází právě 1 nepřítelovo pole
                    if ((poz_X_KHr - poz_X_PHr == poz_X_PHr - poz_X_He) && (poz_Y_PHr == poz_Y_KHr) && (poz_Y_KHr == poz_Y_He) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !hracSePohlSkokem)
                    {
                        if (idHrace == 1)
                        {
                            MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                            mozneTahyLidskehoHrace.Add(tah);
                        }
                        else
                        {
                            MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                            mozneTahyPocitacovehoHrace.Add(tah);
                        }
                    }
                }

                //řeši ostatní skoky (tzn. ve zbývajících 4 směrech)
                for (int j = 0; j < poleLidskehoHrace.Count; j++)
                {
                    LidskyHrac lidskyHrac = poleLidskehoHrace[j];
                    poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                    poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                    //1. podmínka: vzdálenost právě procházeného hráčova pole a kliknutého hráčova pole je stejná jako vzdálenost právě procházeného herního pole a právě procházeného hráčova pole (na x-ové ose)
                    //2. podmínka: vzdálenost právě procházeného hráčova pole a kliknutého hráčova pole je stejná jako vzdálenost právě procházeného herního pole a právě procházeného hráčova pole (na y-ové ose)
                    //3. podmínka: vzdálenost kliknutého hráčova pole a právě procházeného herního pole na y-ové ose je 2-krát větší než vzdálenost kliknutého hráčova pole a právě procházeného herního pole na x-ové ose
                    if ((poz_X_Hr - poz_X_KHr == poz_X_He - poz_X_Hr) && (poz_Y_Hr - poz_Y_KHr == poz_Y_He - poz_Y_Hr) && (Math.Abs(poz_Y_KHr - poz_Y_He) == 2 * Math.Abs(poz_X_KHr - poz_X_He)) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !hracSePohlSkokem)
                    {
                        if (idHrace == 1)
                        {
                            MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                            mozneTahyLidskehoHrace.Add(tah);
                        }
                        else
                        {
                            MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                            mozneTahyPocitacovehoHrace.Add(tah);
                        }
                    }
                }

                //řeši ostatní skoky (tzn. ve zbývajících 4 směrech) - nepřítel
                for (int j = 0; j < polePocitacovehoHrace.Count; j++)
                {
                    PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[j];
                    poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                    poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                    //1. podmínka: vzdálenost právě procházeného nepřítelova pole a kliknutého nepřítelova pole je stejná jako vzdálenost právě procházeného nepřítelova pole a právě procházeného herního pole (na x-ové ose)
                    //2. podmínka: vzdálenost právě procházeného nepřítelova pole a kliknutého nepřítelova pole je stejná jako vzdálenost právě procházeného nepřítelova pole a právě procházeného herního pole (na y-ové ose)
                    //3. podmínka: vzdálenost kliknutého hráčova pole a právě procházeného herního pole na y-ové ose je 2-krát větší než vzdálenost právě procházeného herního pole a kliknutého hráčova pole
                    if ((poz_X_PHr - poz_X_KHr == poz_X_He - poz_X_PHr) && (poz_Y_PHr - poz_Y_KHr == poz_Y_He - poz_Y_PHr) && (Math.Abs(poz_Y_KHr - poz_Y_He) == 2 * Math.Abs(poz_X_KHr - poz_X_He)) &&  !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !hracSePohlSkokem)
                    {
                        if (idHrace == 1)
                        {
                            MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                            mozneTahyLidskehoHrace.Add(tah);
                        }
                        else
                        {
                            MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                            mozneTahyPocitacovehoHrace.Add(tah);
                        }
                    }
                }

                //ve zbývající části funkce jsou řešeny možné tahy dostupné po skoku hráče (hráč může v rámci tahu skočit už jen pouze na právě takovou vzdálenost, na jakou skočil při prvním skoku)
                //hráč provedl skok směrem dopředu nebo dozadu
                if (hracSePohlSkokem && delkaSkokuY != 0)
                {
                    if (poz_Y_He == poz_Y_KHr)//právě ověřované herní kole a kliknuté hráčovo pole jsou na y-ové ose na stejné výši
                    {
                        for (int j = 0; j < poleLidskehoHrace.Count; j++)
                        {
                            LidskyHrac lidskyHrac = poleLidskehoHrace[j];
                            poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                            poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                            //1. podmínka: vzdálenost mezi právě procházeným hráčovým polem a právě procházeným herním polem je stejná jako vzdálenost mezi kliknutým hráčovým polem a právě procházeným herním polem (na x-ové ose)
                            //2. podmínka: vzdálenost mezi kliknutým hráčovým polem a právě procházeným herním polem je dvakrát větší než délka skoku na x-ové ose
                            //3. podmínka: vzdálenost mezi právě procházeným herním polem a právě procházeným hráčovým polem je stejná jako délka skoku (na x-ové ose)
                            //4. podmínka: vzdálenost mezi právě procházeným herním polem a kliknutým hráčovým polem na x-ové ose je stejná jako délka skoku na y-ové ose
                            //5. podmínka: právě procházené hráčovo pole a právě procházené herní pole jsou na y-ové ose na stejné výši
                            if ((Math.Abs(poz_X_Hr - poz_X_He) == Math.Abs(poz_X_KHr - poz_X_Hr)) && (Math.Abs(poz_X_KHr - poz_X_He) == delkaSkokuX * 2) && (Math.Abs(poz_X_He - poz_X_Hr) == delkaSkokuX) && (Math.Abs(poz_X_He - poz_X_KHr) == delkaSkokuY) && (poz_Y_Hr == poz_Y_He) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace))
                            {
                                if (idHrace == 1)
                                {
                                    MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                                    mozneTahyLidskehoHrace.Add(tah);
                                }
                                else
                                {
                                    MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                                    mozneTahyPocitacovehoHrace.Add(tah);
                                }
                            }
                        }

                        for (int j = 0; j < polePocitacovehoHrace.Count; j++)
                        {
                            PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[j];
                            poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                            poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                            //1. podmínka: vzdálenost mezi právě procházeným nepřítelovým polem a právě procházeným herním polem je stejná jako vzdálenost mezi kliknutým hráčovým polem a právě procházeným nepřítelovým polem (na x-ové ose)
                            //2. podmínka: vzdálenost mezi kliknutým hráčovým polem a právě procházeným herním polem je dvakrát větší než délka skoku na x-ové ose
                            //3. podmínka: vzdálenost mezi právě procházeným herním polem a právě procházeným nepřítelovým polem je stejná jako délka skoku (na x-ové ose)
                            //4. podmínka: vzdálenost mezi právě procházeným herním polem a kliknutým hráčovým polem na x-ové ose je stejná jako délka skoku na y-ové ose
                            //5. podmínka: právě procházené nepřítelovo pole a právě procházené herní pole jsou na y-ové ose na stejné výši
                            if ((Math.Abs(poz_X_PHr - poz_X_He) == Math.Abs(poz_X_KHr - poz_X_PHr)) && (Math.Abs(poz_X_KHr - poz_X_He) == delkaSkokuX * 2) && (Math.Abs(poz_X_He - poz_X_PHr) == delkaSkokuX) && (Math.Abs(poz_X_He - poz_X_KHr) == delkaSkokuY) && (poz_Y_PHr == poz_Y_He) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace))
                            {
                                if (idHrace == 1)
                                {
                                    MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                                    mozneTahyLidskehoHrace.Add(tah);
                                }
                                else
                                {
                                    MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                                    mozneTahyPocitacovehoHrace.Add(tah);
                                }
                            }
                        }
                    }
                    else//právě ověřované herní kole a kliknuté hráčovo pole nejsou na y-ové ose na stejné výši
                    {
                        for (int j = 0; j < poleLidskehoHrace.Count; j++)
                        {
                            LidskyHrac lidskyHrac = poleLidskehoHrace[j];
                            poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                            poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                            //1. podmínka: vzdálenost mezi kliknutým hráčovým polem a právě procházeným herním polem je stejná jako délka skoku (na x-ové ose)
                            //2. podmínka: vzdálenost mezi právě procházeným herním polem a právě procházeným hráčovým polem je dvakrát menší než délka skoku na x-ové ose 
                            //3. podmínka: vzdálenost mezi právě procházeným herním polem a kliknutým hráčovým polem na x-ové ose je dvakrát menší než délka skoku na y-ové ose
                            //4. podmínka: vzdálenost mezi kliknutým hráčovým polem a právě procházeným herním polem je stejná jako délka skoku (na y-ové ose)
                            //5. podmínka: vzdálenost mezi kliknutým hráčovým polem a právě procházeným hráčovým polem je dvakrát menší než délka skoku (na x-ové ose)
                            //6. podmínka: vzdálenost mezi právě procházeným hráčovým polem a kliknutým hráčovým polem je stejná jako vzdálenost mezi právě procházeným herním polem a právě procházeným hráčovým polem (na y-ové ose)
                            //7. podmínka: vzdálenost mezi právě procházeným hráčovým polem a kliknutým hráčovým polem je stejná jako vzdálenost mezi právě procházeným herním polem a právě procházeným hráčovým polem (na x-ové ose)
                            if ((Math.Abs(poz_X_KHr - poz_X_He) == delkaSkokuX) && (Math.Abs(poz_X_He - poz_X_Hr) == delkaSkokuX / 2) && (Math.Abs(poz_X_He - poz_X_KHr) == delkaSkokuY / 2) && (Math.Abs(poz_Y_KHr - poz_Y_He) == delkaSkokuY) && (Math.Abs(poz_Y_KHr - poz_Y_Hr) == delkaSkokuY / 2) && (poz_Y_Hr - poz_Y_KHr == poz_Y_He - poz_Y_Hr) && (poz_X_Hr - poz_X_KHr == poz_X_He - poz_X_Hr) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace))
                            {
                                if (idHrace == 1)
                                {
                                    MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                                    mozneTahyLidskehoHrace.Add(tah);
                                }
                                else
                                {
                                    MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                                    mozneTahyPocitacovehoHrace.Add(tah);
                                }
                            }
                        }

                        for (int j = 0; j < polePocitacovehoHrace.Count; j++)
                        {
                            PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[j];
                            poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                            poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                            //1. podmínka: vzdálenost mezi kliknutým hráčovým polem a právě procházeným nepřítelovým polem je stejná jako délka skoku (na x-ové ose)
                            //2. podmínka: vzdálenost mezi právě procházeným herním polem a právě procházeným nepřítelovým polem je dvakrát menší než délka skoku na x-ové ose 
                            //3. podmínka: vzdálenost mezi právě procházeným herním polem a kliknutým hráčovým polem na x-ové ose je dvakrát menší než délka skoku na y-ové ose
                            //4. podmínka: vzdálenost mezi kliknutým hráčovým polem a právě procházeným herním polem je stejná jako délka skoku (na y-ové ose)
                            //5. podmínka: vzdálenost mezi kliknutým hráčovým polem a právě procházeným nepřítelovým polem je dvakrát menší než délka skoku (na x-ové ose)
                            //6. podmínka: vzdálenost mezi právě procházeným nepřítelovým polem a kliknutým hráčovým polem je stejná jako vzdálenost mezi právě procházeným herním polem a právě procházeným nepřítelovým polem (na y-ové se)
                            //7. podmínka: vzdálenost mezi právě procházeným nepřítelovým polem a kliknutým hráčovým polem je stejná jako vzdálenost mezi právě procházeným herním polem a právě procházeným nepřítelovým polem (na x-ové se)
                            if ((Math.Abs(poz_X_KHr - poz_X_He) == delkaSkokuX) && (Math.Abs(poz_X_He - poz_X_PHr) == delkaSkokuX / 2) && (Math.Abs(poz_X_He - poz_X_KHr) == delkaSkokuY / 2) && (Math.Abs(poz_Y_KHr - poz_Y_He) == delkaSkokuY) && (Math.Abs(poz_Y_KHr - poz_Y_PHr) == delkaSkokuY / 2) && (poz_Y_PHr - poz_Y_KHr == poz_Y_He - poz_Y_PHr) && (poz_X_PHr - poz_X_KHr == poz_X_He - poz_X_PHr) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace))
                            {
                                if (idHrace == 1)
                                {
                                    MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                                    mozneTahyLidskehoHrace.Add(tah);
                                }
                                else
                                {
                                    MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                                    mozneTahyPocitacovehoHrace.Add(tah);
                                }
                            }
                        }
                    }
                }

                //hráč provedl skok na svislé ose
                if (hracSePohlSkokem && delkaSkokuY == 0)
                {
                    if (poz_Y_He == poz_Y_KHr)//právě procházené herní pole je na y-ové ose na stejné výši jako pole, na které hráč skočil
                    {
                        for (int j = 0; j < poleLidskehoHrace.Count; j++)
                        {
                            LidskyHrac lidskyHrac = poleLidskehoHrace[j];
                            poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                            poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                            //1. podmínka: vzdálenost mezi právě procházeným hráčovým polem a právě procházeným herním polem je stejná, jako vzdálenost mezi polem, na které hráč skočil a právě procházeným herním polem (na x-ové ose)
                            //2. podmínka: vzdálenost mezi polem, na které hráč skočil, a právě procházeným polem je stejné jako délka skoku na x-ové ose
                            //3. podmínka: právě procházené hráčovo pole je na y-ové ose na stejné výši jako právě procházené herní pole
                            if ((Math.Abs(poz_X_Hr - poz_X_He) == Math.Abs(poz_X_KHr - poz_X_Hr)) && (Math.Abs(poz_X_KHr - poz_X_He) == delkaSkokuX) && (poz_Y_Hr == poz_Y_He) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace))
                            {
                                if (idHrace == 1)
                                {
                                    MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                                    mozneTahyLidskehoHrace.Add(tah);
                                }
                                else
                                {
                                    MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                                    mozneTahyPocitacovehoHrace.Add(tah);
                                }
                            }
                        }

                        for (int j = 0; j < polePocitacovehoHrace.Count; j++)
                        {
                            PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[j];
                            poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                            poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                            //1. podmínka: vzdálenost mezi právě procházeným nepřítelovým polem a právě procházeným herním polem je stejná, jako vzdálenost mezi polem, na které hráč skočil a právě procházeným nepřítelovým polem (na x-ové ose)
                            //2. podmínka: vzdálenost mezi polem, na které hráč skočil, a právě procházeným polem je stejné jako délka skoku na x-ové ose
                            //3. podmínka: právě procházené nepřítelovo pole je na y-ové ose na stejné výši jako právě procházené herní pole
                            if ((Math.Abs(poz_X_PHr - poz_X_He) == Math.Abs(poz_X_KHr - poz_X_PHr)) && (Math.Abs(poz_X_KHr - poz_X_He) == delkaSkokuX) && (poz_Y_PHr == poz_Y_He) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace))
                            {
                                if (idHrace == 1)
                                {
                                    MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                                    mozneTahyLidskehoHrace.Add(tah);
                                }
                                else
                                {
                                    MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                                    mozneTahyPocitacovehoHrace.Add(tah);
                                }
                            }
                        }
                    }
                    else//právě procházené herní pole není na y-ové ose na stejné výši jako pole, na které hráč skočil
                    {
                        for (int j = 0; j < poleLidskehoHrace.Count; j++)
                        {
                            LidskyHrac lidskyHrac = poleLidskehoHrace[j];
                            poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                            poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                            //1. podmínka: vzdálenost mezi právě procházeným hráčovým polem a právě procházeným herním polem je stejná, jako vzdálenost mezi polem, na které hráč skočil a právě procházeným herním polem (na x-ové ose)
                            //2. podmínka: vzdálenost mezi právě procházeným hráčovým polem a právě procházeným herním polem je stejná, jako vzdálenost mezi polem, na které hráč skočil a právě procházeným herním polem (na y-ové ose)
                            //3. podmínka: vzdálenost mezi polem, na které hráč skočil a právě procházeným herním polem na y-ové ose je stejná jako délka skoku na x-ové ose
                            //4. podmínka: vzdálenost mezi polem, na které hráč skočil a právě procházeným herním polem na y-ové ose je dvakrát menší než délka skoku na x-ové ose
                            //5. podmínka: vzdálenost mezi polem, na které hráč skočil, a právě procházeným polem je dvakrát menší než délka skoku na x-ové ose
                            if ((Math.Abs(poz_X_Hr - poz_X_He) == Math.Abs(poz_X_KHr - poz_X_Hr)) && (Math.Abs(poz_Y_Hr - poz_Y_He) == Math.Abs(poz_Y_KHr - poz_Y_Hr)) && (Math.Abs(poz_Y_KHr - poz_Y_He) == delkaSkokuX) && Math.Abs(poz_Y_KHr - poz_Y_Hr) * 2 == delkaSkokuX && (Math.Abs(poz_X_KHr - poz_X_He) * 2 == delkaSkokuX) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace))
                            {
                                if (idHrace == 1)
                                {
                                    MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                                    mozneTahyLidskehoHrace.Add(tah);
                                }
                                else
                                {
                                    MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                                    mozneTahyPocitacovehoHrace.Add(tah);
                                }
                            }
                        }

                        for (int j = 0; j < polePocitacovehoHrace.Count; j++)
                        {
                            PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[j];
                            poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                            poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                            //1. podmínka: vzdálenost mezi právě procházeným nepřítelovým polem a právě procházeným herním polem je stejná, jako vzdálenost mezi polem, na které hráč skočil a právě procházeným nepřítelovým polem (na x-ové ose)
                            //2. podmínka: vzdálenost mezi právě procházeným nepřítelovým polem a právě procházeným herním polem je stejná, jako vzdálenost mezi polem, na které hráč skočil a právě procházeným nepřítelovým polem (na y-ové ose)
                            //3. podmínka: vzdálenost mezi polem, na které hráč skočil a právě procházeným nepřítelovým polem na y-ové ose je stejná jako délka skoku na x-ové ose
                            //4. podmínka: vzdálenost mezi polem, na které hráč skočil a právě procházeným nepřítelovým polem na y-ové ose je dvakrát menší než délka skoku na x-ové ose
                            //5. podmínka: vzdálenost mezi polem, na které hráč skočil, a právě procházeným polem je dvakrát menší než délka skoku na x-ové ose
                            if ((Math.Abs(poz_X_PHr - poz_X_He) == Math.Abs(poz_X_KHr - poz_X_PHr)) && (Math.Abs(poz_Y_PHr - poz_Y_He) == Math.Abs(poz_Y_KHr - poz_Y_PHr)) && (Math.Abs(poz_Y_KHr - poz_Y_He) == delkaSkokuX) && Math.Abs(poz_Y_KHr - poz_Y_PHr) * 2 == delkaSkokuX && (Math.Abs(poz_X_KHr - poz_X_He) * 2 == delkaSkokuX) && !JeTahDuplikatni(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace, mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace) && !JeHracovoPole(poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace) && !ExistujeVicHracovychPoli(poz_X_KHr, poz_Y_KHr, poz_X_He, poz_Y_He, poleLidskehoHrace, polePocitacovehoHrace))
                            {
                                if (idHrace == 1)
                                {
                                    MoznyTahLidskehoHrace tah = new MoznyTahLidskehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, sirkaPole, vyskaPole);
                                    mozneTahyLidskehoHrace.Add(tah);
                                }
                                else
                                {
                                    MoznyTahPocitacovehoHrace tah = new MoznyTahPocitacovehoHrace(poz_X_He, poz_Y_He, poz_X_KHr, poz_Y_KHr, idHrace);
                                    mozneTahyPocitacovehoHrace.Add(tah);
                                }
                            }
                        }
                    }
                }
            }
            return (mozneTahyLidskehoHrace, mozneTahyPocitacovehoHrace);
        }

        private bool JeTahDuplikatni(int poz_X_He, int poz_Y_He, int poz_X_KHr, int poz_Y_KHr, int idHrace, List<MoznyTahLidskehoHrace> mozneTahyLidskehoHrace, List<MoznyTahPocitacovehoHrace> mozneTahyPocitacovehoHrace)//ověří, že tah není duplikátní (na daném poli se již nenachází identický možný tah)
        {
            int poz_X_MT, poz_Y_MT, _poz_X_KHr, _poz_Y_KHr;
            if (idHrace == 1)
            {
                for (int i = 0; i < mozneTahyLidskehoHrace.Count; i++)
                {
                    MoznyTahLidskehoHrace moznyTah = mozneTahyLidskehoHrace[i];
                    poz_X_MT = moznyTah.Get_poz_X_MT();
                    poz_Y_MT = moznyTah.Get_poz_Y_MT();
                    _poz_X_KHr = moznyTah.Get_poz_X_KLHr();
                    _poz_Y_KHr = moznyTah.Get_poz_Y_KLHr();
                    if (poz_X_He == poz_X_MT && poz_Y_He == poz_Y_MT && poz_X_KHr == _poz_X_KHr && poz_Y_KHr == _poz_Y_KHr)//nalezli jsme možný tah, jehož souřadnice jsou stejné jako souřadnice tahu, který jsme práve chtěli vložit
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < mozneTahyPocitacovehoHrace.Count; i++)
                {
                    MoznyTahPocitacovehoHrace moznyTah = mozneTahyPocitacovehoHrace[i];
                    poz_X_MT = moznyTah.Get_poz_X_MT();
                    poz_Y_MT = moznyTah.Get_poz_Y_MT();
                    _poz_X_KHr = moznyTah.Get_poz_X_KPHr();
                    _poz_Y_KHr = moznyTah.Get_poz_Y_KPHr();
                    if (poz_X_He == poz_X_MT && poz_Y_He == poz_Y_MT && poz_X_KHr == _poz_X_KHr && poz_Y_KHr == _poz_Y_KHr)//nalezli jsme možný tah, jehož souřadnice jsou stejné jako souřadnice tahu, který jsme práve chtěli vložit
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private bool JeHracovoPole(int poz_X_He, int poz_Y_He, List<LidskyHrac> poleLidskehoHrace, List<PocitacovyHrac> polePocitacovehoHrace)//ověří, že na daném poli není žádné hráčovo nebo nepřítelovo pole
        {
            int poz_X_Hr, poz_Y_Hr, poz_X_PHr, poz_Y_PHr;
            for (int i = 0; i < poleLidskehoHrace.Count; i++)
            {
                LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                if (poz_X_He == poz_X_Hr && poz_Y_He == poz_Y_Hr)//nalezli jsme hráčovo pole, jehož souřadnice jsou stejné jako souřadnice tahu, který jsme práve chtěli vložit
                {
                    return true;
                }
            }

            for (int i = 0; i < polePocitacovehoHrace.Count; i++)
            {
                PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                if (poz_X_He == poz_X_PHr && poz_Y_He == poz_Y_PHr)//nalezli jsme nepřítelovo pole, jehož souřadnice jsou stejné jako souřadnice tahu, který jsme práve chtěli vložit
                {
                    return true;
                }
            }
            return false;
        }

        private bool ExistujeVicHracovychPoli(int poz_X_KHr, int poz_Y_KHr, int poz_X_He, int poz_Y_He, List<LidskyHrac> poleLidskehoHrace, List<PocitacovyHrac> polePocitacovehoHrace)///ověří, že se mezi 2 vstupními poli nachází právě jedno hráčovo nebo nepřítelovo pole
        {
            int poz_X_Hr, poz_Y_Hr, poz_X_PHr, poz_Y_PHr, pocet = 0;
            //funkci rozdělíme na 6 části (je 6 možných směrů)
            if (poz_Y_He < poz_Y_KHr)//ověřované pole je na y-ové ose níže od hráčem kliknutého pole (směr - nahoru)
            {
                if (poz_X_KHr > poz_X_He)//ověřované pole je na x-ové ose níže od hráčem kliknutého pole (směr - nahoru + doleva)
                {
                    for (int i = 0; i < poleLidskehoHrace.Count; i++)
                    {
                        LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                        poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                        poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                        //1. podmínka: vzdálenost mezi hráčem kliknutým polem a právě procházeným hráčovým polem na x-ové ose je dvakrát menší než vzdálenost mezi hráčem kliknutým polem a právě procházeným hráčovým polem na y-ové ose
                        //2. podmínka: ověřované pole je na y-ové ose nižší než právě procházené hráčovo pole
                        //3. podmínka: právě procházené hráčovo pole je na x-ové ose nižší než hráčem kliknuté pole
                        if (((poz_X_KHr - poz_X_Hr) * 2) == (poz_Y_KHr - poz_Y_Hr) && (poz_Y_He < poz_Y_Hr) && (poz_X_Hr < poz_X_KHr))
                        {
                            pocet++;
                        }
                    }

                    for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        //1. podmínka: vzdálenost mezi hráčem kliknutým polem a právě procházeným nepřítelovým polem na x-ové ose je dvakrát menší než vzdálenost mezi hráčem kliknutým polem a právě procházeným nepřítelovým polem na y-ové ose
                        //2. podmínka: ověřované pole je na y-ové ose nižší než právě procházené nepřítelovo pole
                        //3. podmínka: právě procházené nepřítelovo pole je na x-ové ose nižší než hráčem kliknuté pole
                        if (((poz_X_KHr - poz_X_PHr) * 2) == (poz_Y_KHr - poz_Y_PHr) && (poz_Y_He < poz_Y_PHr) && (poz_X_PHr < poz_X_KHr))
                        {
                            pocet++;
                        }
                    }

                    if (pocet == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else//ověřované pole je na x-ové ose výše od hráčem kliknutého pole (směr - nahoru + doprava)
                {
                    for (int i = 0; i < poleLidskehoHrace.Count; i++)
                    {
                        LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                        poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                        poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                        //1. podmínka: vzdálenost mezi hráčem kliknutým polem a právě procházeným hráčovým polem na x-ové ose je dvakrát menší než vzdálenost mezi hráčem kliknutým polem a právě procházeným hráčovým polem na y-ové ose
                        //2. podmínka: ověřované pole je na y-ové ose nižší než právě procházené hráčovo pole
                        //3. podmínka: právě procházené hráčovo pole je na x-ové ose vyšší než hráčem kliknuté pole
                        if (((poz_X_Hr - poz_X_KHr) * 2) == (poz_Y_KHr - poz_Y_Hr) && (poz_Y_He < poz_Y_Hr) && (poz_X_Hr > poz_X_KHr))
                        {
                            pocet++;
                        }
                    }

                    for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        //1. podmínka: vzdálenost mezi hráčem kliknutým polem a právě procházeným nepřítelovým polem na x-ové ose je dvakrát menší než vzdálenost mezi hráčem kliknutým polem a právě procházeným nepřítelovým polem na y-ové ose
                        //2. podmínka: ověřované pole je na y-ové ose nižší než právě procházené nepřítelovo pole
                        //3. podmínka: právě procházené nepřítelovo pole je na x-ové ose vyšší než hráčem kliknuté pole
                        if (((poz_X_PHr - poz_X_KHr) * 2) == (poz_Y_KHr - poz_Y_PHr) && (poz_Y_He < poz_Y_PHr) && (poz_X_PHr > poz_X_KHr))
                        {
                            pocet++;
                        }
                    }

                    if (pocet == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (poz_Y_He > poz_Y_KHr)//ověřované pole je na y-ové ose výše od hráčem kliknutého pole (směr - dolů)
            {
                if (poz_X_KHr > poz_X_He)//ověřované pole je na x-ové ose níže od hráčem kliknutého pole (směr - dolů + doleva)
                {
                    for (int i = 0; i < poleLidskehoHrace.Count; i++)
                    {
                        LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                        poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                        poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                        //1. podmínka: vzdálenost mezi hráčem kliknutým polem a právě procházeným hráčovým polem na x-ové ose je dvakrát menší než vzdálenost mezi hráčem kliknutým polem a právě procházeným hráčovým polem na y-ové ose
                        //2. podmínka: ověřované pole je na y-ové ose vyšší než právě procházené hráčovo pole
                        //3. podmínka: právě procházené hráčovo pole je na x-ové ose nižší než hráčem kliknuté pole
                        if (((poz_X_KHr - poz_X_Hr) * 2) == (poz_Y_Hr - poz_Y_KHr) && (poz_Y_He > poz_Y_Hr) && (poz_X_Hr < poz_X_KHr))
                        {
                            pocet++;
                        }
                    }

                    for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        //1. podmínka: vzdálenost mezi hráčem kliknutým polem a právě procházeným nepřítelovým polem na x-ové ose je dvakrát menší než vzdálenost mezi hráčem kliknutým polem a právě procházeným nepřítelovým polem na y-ové ose
                        //2. podmínka: ověřované pole je na y-ové ose vyšší než právě procházené nepřítelovo pole
                        //3. podmínka: právě procházené nepřítelovo pole je na x-ové ose nižší než hráčem kliknuté pole
                        if (((poz_X_KHr - poz_X_PHr) * 2) == (poz_Y_PHr - poz_Y_KHr) && (poz_Y_He > poz_Y_PHr) && (poz_X_PHr < poz_X_KHr))
                        {
                            pocet++;
                        }
                    }

                    if (pocet == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else//ověřované pole je na x-ové ose níže od hráčem kliknutého pole (směr - dolů + doprava)
                {
                    for (int i = 0; i < poleLidskehoHrace.Count; i++)
                    {
                        LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                        poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                        poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                        //1. podmínka: vzdálenost mezi hráčem kliknutým polem a právě procházeným hráčovým polem na x-ové ose je dvakrát menší než vzdálenost mezi hráčem kliknutým polem a právě procházeným hráčovým polem na y-ové ose
                        //2. podmínka: ověřované pole je na y-ové ose vyšší než právě procházené hráčovo pole
                        //3. podmínka: právě procházené hráčovo pole je na x-ové ose vyšší než hráčem kliknuté pole
                        if (((poz_X_Hr - poz_X_KHr) * 2) == (poz_Y_Hr - poz_Y_KHr) && (poz_Y_He > poz_Y_Hr) && (poz_X_Hr > poz_X_KHr))
                        {
                            pocet++;
                        }
                    }

                    for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        //1. podmínka: vzdálenost mezi hráčem kliknutým polem a právě procházeným nepřítelovým polem na x-ové ose je dvakrát menší než vzdálenost mezi hráčem kliknutým polem a právě procházeným nepřítelovým polem na y-ové ose
                        //2. podmínka: ověřované pole je na y-ové ose vyšší než právě procházené nepřítelovo pole
                        //3. podmínka: právě procházené nepřítelovo pole je na x-ové ose vyšší než hráčem kliknuté pole
                        if (((poz_X_PHr - poz_X_KHr) * 2) == (poz_Y_PHr - poz_Y_KHr) && (poz_Y_He > poz_Y_PHr) && (poz_X_PHr > poz_X_KHr))
                        {
                            pocet++;
                        }
                    }

                    if (pocet == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else//ověřované pole je na y-ové ose na stejné výši jako hráčem kliknuté pole (směr - doleva/doprava)
            {
                if (poz_X_KHr > poz_X_He)//ověřované pole je na x-ové ose níže od hráčem kliknutého pole (směr - doleva)
                {
                    for (int i = 0; i < poleLidskehoHrace.Count; i++)
                    {
                        LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                        poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                        poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                        //1. podmínka: ověřované pole je na y-ové ose na stejné výši jako právě procházené hráčovo pole
                        //2. podmínka: právě procházené hráčovo pole je na x-ové souřadnici níže než kliknuté hráčovo pole
                        //3. podmínka: právě procházené hráčovo pole je na x-ové souřadnici výše než ověřované pole
                        if ((poz_Y_He == poz_Y_Hr) && (poz_X_Hr < poz_X_KHr) && (poz_X_Hr > poz_X_He))
                        {
                            pocet++;
                        }
                    }

                    for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        //1. podmínka: ověřované pole je na y-ové ose na stejné výši jako právě procházené nepřítelovo pole
                        //2. podmínka: právě procházené nepřítelovo pole je na x-ové souřadnici níže než kliknuté hráčovo pole
                        //3. podmínka: právě procházené nepřítelovo pole je na x-ové souřadnici výše než ověřované pole
                        if ((poz_Y_He == poz_Y_PHr) && (poz_X_PHr < poz_X_KHr) && (poz_X_PHr > poz_X_He))
                        {
                            pocet++;
                        }
                    }

                    if (pocet == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else//ověřované pole je na x-ové ose výše od hráčem kliknutého pole (směr - doprava)
                {
                    for (int i = 0; i < poleLidskehoHrace.Count; i++)
                    {
                        LidskyHrac lidskyHrac = poleLidskehoHrace[i];
                        poz_X_Hr = lidskyHrac.Get_poz_X_LHr();
                        poz_Y_Hr = lidskyHrac.Get_poz_Y_LHr();
                        //1. podmínka: ověřované pole je na y-ové ose na stejné výši jako právě procházené hráčovo pole
                        //2. podmínka: právě procházené hráčovo pole je na x-ové souřadnici výše než kliknuté hráčovo pole
                        //3. podmínka: právě procházené hráčovo pole je na x-ové souřadnici níže než ověřované pole
                        if ((poz_Y_He == poz_Y_Hr) && (poz_X_Hr > poz_X_KHr) && (poz_X_Hr < poz_X_He))
                        {
                            pocet++;
                        }
                    }

                    for (int i = 0; i < polePocitacovehoHrace.Count; i++)
                    {
                        PocitacovyHrac pocitacovyHrac = polePocitacovehoHrace[i];
                        poz_X_PHr = pocitacovyHrac.Get_poz_X_PHr();
                        poz_Y_PHr = pocitacovyHrac.Get_poz_Y_PHr();
                        //1. podmínka: ověřované pole je na y-ové ose na stejné výši jako právě procházené nepřítelovo pole
                        //2. podmínka: právě procházené nepřítelovo pole je na x-ové souřadnici výše než kliknuté hráčovo pole
                        //3. podmínka: právě procházené nepřítelovo pole je na x-ové souřadnici níže než ověřované pole
                        if ((poz_Y_He == poz_Y_PHr) && (poz_X_PHr > poz_X_KHr) && (poz_X_PHr < poz_X_He))
                        {
                            pocet++;
                        }
                    }

                    if (pocet == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private bool TahDoObouSpodnichRohu(int poz_X_MT, int poz_Y_MT)
        {
            if ((poz_Y_MT <= horniOdsazeni + posun * 8) || (poz_Y_MT >= horniOdsazeni + posun * 13) || (poz_Y_MT == horniOdsazeni + posun * 9 && poz_X_MT != leveOdsazeni - posun * 4 - posun / 2 && poz_X_MT != leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_MT == horniOdsazeni + posun * 10 && poz_X_MT > leveOdsazeni - posun * 4 && poz_X_MT < leveOdsazeni + posun * 4) || (poz_Y_MT == horniOdsazeni + posun * 11 && poz_X_MT > leveOdsazeni - posun * 3 - posun / 2 && poz_X_MT < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_MT == horniOdsazeni + posun * 12 && poz_X_MT > leveOdsazeni - posun * 3 && poz_X_MT < leveOdsazeni + posun * 3))
            {
                return false;
            }
            return true;
        }

        private bool TahDoObouHornichRohu(int poz_X_MT, int poz_Y_MT)
        {
            if ((poz_Y_MT >= horniOdsazeni + posun * 8) || (poz_Y_MT <= horniOdsazeni + posun * 3) || (poz_Y_MT == horniOdsazeni + posun * 7 && poz_X_MT != leveOdsazeni - posun * 4 - posun / 2 && poz_X_MT != leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_MT == horniOdsazeni + posun * 6 && poz_X_MT > leveOdsazeni - posun * 4 && poz_X_MT < leveOdsazeni + posun * 4) || (poz_Y_MT == horniOdsazeni + posun * 5 && poz_X_MT > leveOdsazeni - posun * 3 - posun / 2 && poz_X_MT < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_MT == horniOdsazeni + posun * 4 && poz_X_MT > leveOdsazeni - posun * 3 && poz_X_MT < leveOdsazeni + posun * 3))
            {
                return false;
            }
            return true;
        }

        private bool TahDoNejnizsihoANejvyssihoRohu(int poz_Y_MT)
        {
            if (poz_Y_MT <= horniOdsazeni + posun * 13 || poz_Y_MT >= horniOdsazeni + posun * 3)
            {
                return false;
            }
            return true;
        }

        private bool TahDoSpodnihoLevehoRohu(int poz_X_MT, int poz_Y_MT)
        {
            if ((poz_Y_MT <= horniOdsazeni + posun * 8) || (poz_Y_MT == posun * 9 + horniOdsazeni && poz_X_MT > leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_MT == posun * 10 + horniOdsazeni && poz_X_MT > leveOdsazeni - posun * 4) || (poz_Y_MT == posun * 11 + horniOdsazeni && poz_X_MT > leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_MT == posun * 12 + horniOdsazeni && poz_X_MT > leveOdsazeni - posun * 3))
            {
                return false;
            }
            return true;
        }

        private bool TahDoHornihoPravehoRohu(int poz_X_MT, int poz_Y_MT)
        {
            if ((poz_Y_MT >= horniOdsazeni + posun * 8) || (poz_Y_MT == horniOdsazeni + posun * 7 && poz_X_MT < leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_MT == horniOdsazeni + posun * 6 && poz_X_MT < leveOdsazeni + posun * 4) || (poz_Y_MT == horniOdsazeni + posun * 5 && poz_X_MT < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_MT == horniOdsazeni + posun * 4 && poz_X_MT < leveOdsazeni + posun * 3))
            {
                return false;
            }
            return true;
        }

        private bool TahDoSpodnihoPravehoRohu(int poz_X_MT, int poz_Y_MT)
        {
            if ((poz_Y_MT <= horniOdsazeni + posun * 8) || (poz_Y_MT == posun * 9 + horniOdsazeni && poz_X_MT < leveOdsazeni + posun * 4 + posun / 2) || (poz_Y_MT == posun * 10 + horniOdsazeni && poz_X_MT < leveOdsazeni + posun * 4) || (poz_Y_MT == posun * 11 + horniOdsazeni && poz_X_MT < leveOdsazeni + posun * 3 + posun / 2) || (poz_Y_MT == posun * 12 + horniOdsazeni && poz_X_MT < leveOdsazeni + posun * 3))
            {
                return false;
            }
            return true;
        }

        private bool TahDoHornihoLevehoRohu(int poz_X_MT, int poz_Y_MT)
        {
            if ((poz_Y_MT >= horniOdsazeni + posun * 8) || (poz_Y_MT == horniOdsazeni + posun * 7 && poz_X_MT > leveOdsazeni - posun * 4 - posun / 2) || (poz_Y_MT == horniOdsazeni + posun * 6 && poz_X_MT > leveOdsazeni - posun * 4) || (poz_Y_MT == horniOdsazeni + posun * 5 && poz_X_MT > leveOdsazeni - posun * 3 - posun / 2) || (poz_Y_MT == horniOdsazeni + posun * 4 && poz_X_MT > leveOdsazeni - posun * 3))
            {
                return false;
            }
            return true;
        }
    }
}
