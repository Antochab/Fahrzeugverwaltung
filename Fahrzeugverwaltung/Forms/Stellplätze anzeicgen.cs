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
    public partial class Stellplätze_anzeicgen : Form
    {
        private Fahrzeugpool fahrzeugpool;
        public Stellplätze_anzeicgen(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void Stellplätze_anzeicgen_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = fahrzeugpool.Parkhausverwaltung.gibAlleStellplatzDatenAus();
        }
    }
}
