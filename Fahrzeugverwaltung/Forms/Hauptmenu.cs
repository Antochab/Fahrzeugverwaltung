using System;
using System.Data.Common;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;


namespace Fahrzeugverwaltung.Forms
{
    public partial class Hauptmenu : Form
    {
        private Fahrzeugpool fahrzeugpool;
        private String connectionString;


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
            fahrzeugpool.datenInDatenbankSichern(connectionString);
            fahrzeugpool.Parkhausverwaltung.datenInDatenbankSichern(connectionString);
        }

        private void buttonParkhausAnlegen_Click(object sender, EventArgs e)
        {
            FormParkhausAnlegen formParkhausAnlegen = new FormParkhausAnlegen(fahrzeugpool.Parkhausverwaltung);
            formParkhausAnlegen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = textBox1.Text;
                fahrzeugpool.datenAusDatenbankAuslesen(connectionString);
                fahrzeugpool.Parkhausverwaltung.datenAusDatenbankAuslesen(connectionString);
                panel1.Enabled = true;
            }catch(ArgumentException ex)
            {
                MessageBox.Show("Es konnte keine Verbindung zur Datenbank hergestellt werden. \n Bitte ConnectionString überprüfen!");
            }

        }
    }
}