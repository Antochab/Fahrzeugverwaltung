using System;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
    /// <summary>
    /// Auswahlmenü zur Anzeige von Daten (Einzel- oder Listen)
    /// </summary>
    public partial class FormMenueFuerDatenausgabe : Form
    {
        private readonly Fahrzeugpool fahrzeugpool;

        public FormMenueFuerDatenausgabe(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void buttonAlleDaten_Click(object sender, EventArgs e)
        {
            FormAlleFahrzeugeAusgeben datenAusgeben = new FormAlleFahrzeugeAusgeben(fahrzeugpool);
            datenAusgeben.Show();
            this.Close();
        }

        private void buttonParkhäuser_Click(object sender, EventArgs e)
        {
            FormParkhäuserAnzeigen formParkhäuserAnzeigen = new FormParkhäuserAnzeigen(fahrzeugpool);
            formParkhäuserAnzeigen.Show();
            this.Close();
        }

        private void buttonStellplätze_Click(object sender, EventArgs e)
        {
            Stellplätze_anzeicgen formStellplätzeAnzeigen = new Stellplätze_anzeicgen(fahrzeugpool);
            formStellplätzeAnzeigen.Show();
            this.Close();
        }

        private void buttonFahrzeugDaten_Click(object sender, EventArgs e)
        {
            FormEinzelnesFahrzeugAusgeben formEinzelnesFahrzeugAusgeben = new FormEinzelnesFahrzeugAusgeben(fahrzeugpool);
            formEinzelnesFahrzeugAusgeben.Show();
            this.Close();
        }
    }
}
