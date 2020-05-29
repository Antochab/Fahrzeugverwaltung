using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
    public partial class Steuerschulden_berechnen : Form
    {
        private Fahrzeugpool fahrzeugpool;
        public Steuerschulden_berechnen(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void buttonSteuerschuldFuerAlle_Click(object sender, EventArgs e)
        {
            fahrzeugpool.berechneSteuerschuld();
        }

        private void buttonFuerKennzeichen_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Steureschuld_fuer_Kennzeichen form_Steureschuld_Fuer_Kennzeichen = new Form_Steureschuld_fuer_Kennzeichen(fahrzeugpool);
            form_Steureschuld_Fuer_Kennzeichen.Show();
        }
    }
}
