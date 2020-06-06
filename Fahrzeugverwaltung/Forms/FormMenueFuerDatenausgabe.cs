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

        private void FormDatenAusgeben_Load(object sender, EventArgs e)
        {
        }

        private void buttonParkhäuser_Click(object sender, EventArgs e)
        {
            FormParkhäuserAnzeigen formParkhäuserAnzeigen = new FormParkhäuserAnzeigen(fahrzeugpool);
            formParkhäuserAnzeigen.Show();
        }

        private void buttonStellplätze_Click(object sender, EventArgs e)
        {
            Stellplätze_anzeicgen formStellplätzeAnzeigen = new Stellplätze_anzeicgen(fahrzeugpool);
            formStellplätzeAnzeigen.Show();
        }
    }
}
