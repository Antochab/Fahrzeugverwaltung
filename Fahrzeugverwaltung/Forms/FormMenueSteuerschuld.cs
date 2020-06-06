using System;
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
            MessageBox.Show(fahrzeugpool.berechneSteuerschuld().ToString());
        }

        private void buttonFuerKennzeichen_Click(object sender, EventArgs e)
        {
            this.Close();
            FormSteureschuldFuerKennzeichen form_Steureschuld_Fuer_Kennzeichen = new FormSteureschuldFuerKennzeichen(fahrzeugpool);
            form_Steureschuld_Fuer_Kennzeichen.Show();
        }
    }
}
