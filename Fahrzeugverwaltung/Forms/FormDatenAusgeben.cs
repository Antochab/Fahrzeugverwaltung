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
    public partial class FormDatenAusgeben : Form
    {
        private readonly Fahrzeugpool fahrzeugpool;
        public FormDatenAusgeben(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void buttonAlleDaten_Click(object sender, EventArgs e)
        {
            string output = "{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-15}\t{5,-15}\t";
            for (int i = 0; i < 202; i++)
            {
                listBoxDaten.Items.Add(string.Format(output, "AUDI", "A/", "KSJH", "2009", "200", "PKW"));
            }

        }

        private void FormDatenAusgeben_Load(object sender, EventArgs e)
        {
            string output = "{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-15}\t{5,-15}\t";
            listBoxDaten.Items.Add(string.Format(output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassaung", "Anschaffungspreis", "Typ"));
        }
    }
}
