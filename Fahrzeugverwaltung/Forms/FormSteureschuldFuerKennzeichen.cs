using System;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
    /// <summary>
    /// Form zur Berechnung der Steuerschuld für ein Fahrzeug
    /// </summary>
    public partial class FormSteureschuldFuerKennzeichen : Form
    {
        private readonly Fahrzeugpool fahrzeugpool;
        public FormSteureschuldFuerKennzeichen(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void buttonSteuerBerechnen_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxSteuerschuld.Text =  fahrzeugpool.berechneSteuerschuldKennzeichen(textBoxKennzeichen.Text).ToString();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
