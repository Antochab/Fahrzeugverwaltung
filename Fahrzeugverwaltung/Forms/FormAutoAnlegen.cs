using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrzeugverwaltung
{
    public partial class FormAutoAnlegen : Form
    {
        Fahrzeugpool fahrzeugpool = new Fahrzeugpool();
        public FormAutoAnlegen()
        {
            InitializeComponent();
        }

        //Hinzufügen eines neuen Fahrzeugs
        //TODO select case oder if case zur abfrage des momentanen Fahrzeugs...
        private void buttonAnlegen_Click(object sender, EventArgs e)
        {
            fahrzeugpool.neuenPKWAnlegen(textBoxHersteller.Text,textBoxModell.Text,textBoxKennzeichen.Text,Convert.ToInt32(textBoxZulassung.Text),float.Parse(textBoxAnschaffungspreis.Text),Convert.ToInt32(textBoxHubraum.Text),Convert.ToInt32(textBoxLeistung.Text),Convert.ToInt32(textBoxSchadstoffklasse.Text));
        }

        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            Console.WriteLine(fahrzeugpool.Fahrzeugliste.Count());
        }
    }
}
