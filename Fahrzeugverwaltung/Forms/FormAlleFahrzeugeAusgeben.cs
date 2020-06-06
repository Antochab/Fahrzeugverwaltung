using System;
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

        /// <summary>
        /// Beim Laden des Fensters werden alle Einträge zu den PKWs, LKWs und Motorrädern 
        /// in einzelnen Listboxen angezeigt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            fahrzeugpool.gibAlleDatenAus();
            listBoxPKW.DataSource = fahrzeugpool.AllePKWDaten;
            listBoxMottorad.DataSource = fahrzeugpool.AlleMotorradDaten;
            listBoxLKW.DataSource = fahrzeugpool.AlleLKWDaten;
            ///Einträge sollen nicht redundant gespeichert werden
            fahrzeugpool.AllePKWDaten.Clear();
            fahrzeugpool.AlleMotorradDaten.Clear();
            fahrzeugpool.AlleLKWDaten.Clear();
        }

        private void DatenAusgeben_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
