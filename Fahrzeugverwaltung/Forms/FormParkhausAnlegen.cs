using Fahrzeugverwaltung.Klassen;
using System;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
    public partial class FormParkhausAnlegen : Form
    {
        private Parkhauspool parkhausverwaltung;
        public FormParkhausAnlegen(Parkhauspool aParkhausverwaltung)
        {
            InitializeComponent();
            parkhausverwaltung = aParkhausverwaltung;
        }

        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAnlegen_Click(object sender, EventArgs e)
        {
            parkhausverwaltung.neuesParkhausAnlegen(textBoxOrt.Text, textBoxPLZ.Text, textBoxParkhausnummer.Text, Int32.Parse(textBoxAnzahlPKW.Text), Int32.Parse(textBoxAnzahlMotorrad.Text), Int32.Parse(textBoxAnzahlLKW.Text));
        }
    }
}
