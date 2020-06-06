using Fahrzeugverwaltung.Klassen;
using System;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
    /// <summary>
    /// Form, um ein neues Parkhaus anzulegen
    /// </summary>
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
            try
            {
                parkhausverwaltung.neuesParkhausAnlegen(textBoxOrt.Text, textBoxPLZ.Text, textBoxParkhausnummer.Text, textBoxAnzahlPKW.Text, textBoxAnzahlMotorrad.Text, textBoxAnzahlLKW.Text);
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
