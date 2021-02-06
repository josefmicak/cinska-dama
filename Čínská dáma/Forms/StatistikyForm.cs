using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Čínská_dáma.Forms
{
    public partial class StatistikyForm : Form
    {
        public StatistikyForm()
        {
            InitializeComponent();
            infoLabel.Text = "Statistiky slouží ke zaznamenávání výsledků simulací, tedy her mezi počítačovými hráči.\nHry lidského hráče zde nebudou zaznamenány.";
            NacistStatistiky();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            new MenuForm().Show();
            Hide();
        }

        private void NacistStatistiky()
        {
            string[] radky = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Statistiky.txt");
            
            string obtiznostiText = "";
            for (int i = 0; i < radky.Length; i++)
            {
                string viteziciHrac = "";
                string[] splitStrednik = radky[i].Split(';');
                switch (int.Parse(splitStrednik[0]))
                {
                    case 2:
                        obtiznostiText = "Červený: " + GetObtiznost(int.Parse(splitStrednik[3])) + ", modrý: " + GetObtiznost(int.Parse(splitStrednik[4]));
                        viteziciHrac = GetBarva(int.Parse(splitStrednik[5]), int.Parse(splitStrednik[2]));
                        break;
                    case 3:
                        obtiznostiText = "Zelený: " + GetObtiznost(int.Parse(splitStrednik[3])) + ", žlutý: " + GetObtiznost(int.Parse(splitStrednik[4])) + ", modrý: " + GetObtiznost(int.Parse(splitStrednik[5]));
                        viteziciHrac = GetBarva(int.Parse(splitStrednik[6]), int.Parse(splitStrednik[2]));
                        break;
                    case 4:
                        obtiznostiText = "Zelený: " + GetObtiznost(int.Parse(splitStrednik[3])) + ", žlutý: " + GetObtiznost(int.Parse(splitStrednik[4])) + ", fialový: " + GetObtiznost(int.Parse(splitStrednik[5])) + ", hnědý: " + GetObtiznost(int.Parse(splitStrednik[6]));
                        viteziciHrac = GetBarva(int.Parse(splitStrednik[7]), int.Parse(splitStrednik[2]));
                        break;
                    case 6:
                        obtiznostiText = "Červený: " + GetObtiznost(int.Parse(splitStrednik[3])) + ", zelený: " + GetObtiznost(int.Parse(splitStrednik[4])) + ", žlutý: " + GetObtiznost(int.Parse(splitStrednik[5])) + ", fialový: " + GetObtiznost(int.Parse(splitStrednik[6])) + ", hnědý: " + GetObtiznost(int.Parse(splitStrednik[7])) + ", modrý: " + GetObtiznost(int.Parse(splitStrednik[8]));
                        viteziciHrac = GetBarva(int.Parse(splitStrednik[9]), int.Parse(splitStrednik[2]));
                        break;
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = splitStrednik[0];
                dataGridView1.Rows[i].Cells[1].Value = splitStrednik[1];
                dataGridView1.Rows[i].Cells[2].Value = obtiznostiText;
                dataGridView1.Rows[i].Cells[3].Value = viteziciHrac;
            }
        }

        private string GetBarva(int idHrace, int kontumaceVyhra)
        {
            string vyslednyText;
            switch(idHrace)
            {
                case 1:
                    vyslednyText = "Modrý";
                    break;
                case 2:
                    vyslednyText = "Červený";
                    break;
                case 3:
                    vyslednyText = "Zelený";
                    break;
                case 4:
                    vyslednyText = "Žlutý";
                    break;
                case 5:
                    vyslednyText = "Fialový";
                    break;
                case 6:
                    vyslednyText = "Hnědý";
                    break;
                case 7:
                    vyslednyText = "Modrý";
                    break;
                default:
                    vyslednyText = "Chyba";
                    break;
            }
            if(kontumaceVyhra == 1)
            {
                vyslednyText += " (kontumační výhra)";
            }
            return vyslednyText;
        }

        private string GetObtiznost(int id)
        {
            switch (id)
            {
                case 1:
                    return "lehký";
                case 2:
                    return "střední";
                case 3:
                    return "těžký";
            }
            return "Chyba";
        }
    }
}
