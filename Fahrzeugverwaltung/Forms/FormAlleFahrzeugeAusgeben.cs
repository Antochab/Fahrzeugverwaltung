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
    public partial class FormAlleFahrzeugeAusgeben : Form
    {
        private Fahrzeugpool fahrzeugpool;
        public FormAlleFahrzeugeAusgeben(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fahrzeugpool.gibAlleDatenAus();
            listBoxPKW.DataSource = fahrzeugpool.AllePKWDaten;
            listBoxMottorad.DataSource = fahrzeugpool.AlleMotorradDaten;
            listBoxLKW.DataSource = fahrzeugpool.AlleLKWDaten;
            fahrzeugpool.AllePKWDaten.Clear();
            fahrzeugpool.AlleMotorradDaten.Clear();
            fahrzeugpool.AlleLKWDaten.Clear();
        }

        private void DatenAusgeben_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
