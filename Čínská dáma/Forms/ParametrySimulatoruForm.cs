using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Čínská_dáma.Forms
{
    public partial class ParametrySimulatoruForm : Form
    {
        public ParametrySimulatoruForm()
        {
            InitializeComponent();
            pocetHracu();
        }

        private void zacitSimulaciButton_Click(object sender, EventArgs e)
        {
            int[] obtiznosti = new int[] { obtiznost1TB.Value, obtiznost2TB.Value, obtiznost3TB.Value, obtiznost4TB.Value, obtiznost5TB.Value, obtiznost6TB.Value };
            int pocetHracu;
            if (dvaHraciRB.Checked)
            {
                pocetHracu = 2;
            }
            else if(triHraciRB.Checked)
            {
                pocetHracu = 3;
            }
            else if(ctyriHraciRB.Checked)
            {
                pocetHracu = 4;
            }
            else
            {
                pocetHracu = 6;
            }
            new HraForm(pocetHracu, 1, 1, true, obtiznosti).Show();
            Close();
        }

        private void dvaHraciRB_CheckedChanged(object sender, EventArgs e)
        {
            pocetHracu();
        }

        private void triHraciRB_CheckedChanged(object sender, EventArgs e)
        {
            pocetHracu();
        }

        private void ctyriHraciRB_CheckedChanged(object sender, EventArgs e)
        {
            pocetHracu();
        }

        private void sestHracuRB_CheckedChanged(object sender, EventArgs e)
        {
            pocetHracu();
        }

        private void pocetHracu()
        {
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(TrackBar))
                {
                    C.Enabled = false;
                }
            }
            if (dvaHraciRB.Checked)
            {
                ukazkaPB.Image = Čínská_dáma.Properties.Resources._2Hraci;
                obtiznost1TB.Enabled = true;
                obtiznost6TB.Enabled = true;
            }
            else if (triHraciRB.Checked)
            {
                ukazkaPB.Image = Čínská_dáma.Properties.Resources._3Hraci;
                obtiznost2TB.Enabled = true;
                obtiznost3TB.Enabled = true;
                obtiznost6TB.Enabled = true;
            }
            else if(ctyriHraciRB.Checked)
            {
                ukazkaPB.Image = Čínská_dáma.Properties.Resources._4Hraci_Simulator;
                obtiznost2TB.Enabled = true;
                obtiznost3TB.Enabled = true;
                obtiznost4TB.Enabled = true;
                obtiznost5TB.Enabled = true;
            }
            else
            {
                ukazkaPB.Image = Čínská_dáma.Properties.Resources._6Hracu;
                foreach (Control C in this.Controls)
                {
                    if (C.GetType() == typeof(TrackBar))
                    {
                        C.Enabled = true;
                    }
                }
            }
        }
    }
}
