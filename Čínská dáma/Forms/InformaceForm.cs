using System;
using System.Windows.Forms;

namespace Čínská_dáma
{
    public partial class InformaceForm : Form
    {
        public InformaceForm()
        {
            InitializeComponent();
            PravidlaTB.Text = "Pravidla a princip hry Čínská dáma:\r\n" +
                "Hra je pro 2 až 6 hráčů. Cílem hry je přemístit všechna svá pole do protilehlého cípu hvězdy. Hráč, který jako první přemístí všechna svá pole do protilehlého cípu hvězdy, vyhrává.\r\n" +
                "Ve hře je tedy rozhodující rychlost, s jakou je hráč schopen přemístit všechna svá pole. Existují dva typy pohybu - pohyb o jeden krok a pohyb skokem.\r\n" +
                "Hráč provede během jednoho tahu vždy jeden z těchto pohybů. Hráč při tahu hýbe vždy jedním polem. Pokud hráč provede pohyb o jeden krok, jeho tah je ukončen. Pokud provede pohyb skokem, může v tahu pokračovat.\r\n" +
                "Hráč může při pohybu skokem v tahu pokračovat v případě, že je pole na které chce skočit volné (nenachází se na něm pole některého hráče), že je délka skoku stejná jako u prvního skoku, a že hráč při skoku přeskočí pole některého z hráčů.\r\n" +
                "Při přeskoku není pole, přes které daný hráč skáče, ze hry vyřazeno. Hráč přeskakuje vždy nejbližší pole v daném směru.";

            OvladaniTB.Text = "Ovládání hry Čínská dáma:\r\n" +
                "Pohyb začneme kliknutím na pole, se kterým chceme během daného tahu pohnout.\r\n" +
                "Po kliknutí na dané pole se zobrazí možné tahy, na které můžeme z daného pole táhnout. Během tahu můžeme zobrazit možné tahy libovolného množství polí, po kliknutí na možný tah už ale musíme tah dokončit s polem, se kterým jsme začli táhnout.\r\n" +
                "Možné tahy se budou zobrazovat i z polí, na která jsme se posunuli skokem. Tah je možno ukončit kliknutím na pole, na kterém se právě nacházíme, nebo stisknutím tlačítka s motivem pohybu.\r\n";

            OAplikaciTB.Text = "Informace o této aplikaci:\r\n" +
                "Aplikace byla vytvořena jako součást bakalářské práce Čínská dáma, odevzdávané na Fakultě elektrotechniky a informatiky Vysoké Školy Báňské - Technické univerzity Ostrava v akademickém roce 2020/2021.\r\n" +
                "Student: Josef Micak / MIC0378\r\n" +
                "Kontakt: josef.micak.st@vsb.cz";
        }

        private void PokracovatDoMenuButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
