using Fahrzeugverwaltung.Klassen;
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
    public partial class Hauptmenu : Form
    {
        private Fahrzeugpool fahrzeugpool;
        


        public Hauptmenu()
        {
            InitializeComponent();
            fahrzeugpool = new Fahrzeugpool();
        }

        private void buttonFahrzeugAnlegen_Click(object sender, EventArgs e)
        {
            FormMenueFahrzeugauswahl subMenuFahrzeugAnlegen = new FormMenueFahrzeugauswahl(fahrzeugpool);
            subMenuFahrzeugAnlegen.Show();
        }

        private void buttonSteuerschuldBerechnen_Click(object sender, EventArgs e)
        {
            Steuerschulden_berechnen steuerschulden_Berechnen = new Steuerschulden_berechnen(fahrzeugpool);
            steuerschulden_Berechnen.Show();
        }

        private void buttonDatenAusgeben_Click(object sender, EventArgs e)
        {
            FormMenueFuerDatenausgabe formDatenAusgeben = new FormMenueFuerDatenausgabe(fahrzeugpool);
            formDatenAusgeben.Show();
        }

        private void Hauptmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            fahrzeugpool.datenInDatenbankSichern();
            fahrzeugpool.Parkhausverwaltung.datenInDatenbankSichern();
                }

        private void Hauptmenu_Load(object sender, EventArgs e)
        {
            fahrzeugpool.datenAusDatenbankAuslesen();
            fahrzeugpool.Parkhausverwaltung.datenAusDatenbankAuslesen();
        }

        private void buttonParkhausAnlegen_Click(object sender, EventArgs e)
        {
            FormParkhausAnlegen formParkhausAnlegen = new FormParkhausAnlegen(fahrzeugpool.Parkhausverwaltung);
            formParkhausAnlegen.Show();
        }
    }
}