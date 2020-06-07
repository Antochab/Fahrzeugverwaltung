using System;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
/// <summary>
/// Form zur Anzeige eines eintelnen Fahrzeuges
/// </summary>
    public partial class FormEinzelnesFahrzeugAusgeben : Form
    {
        private Fahrzeugpool fahrzeugpool;
        public FormEinzelnesFahrzeugAusgeben(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void buttonSuchen_Click(object sender, System.EventArgs e)
        {
            try
            {
                textBox1.Multiline = true;
                textBox1.Text = Fahrzeugpool.FahrzeugAusgeben(fahrzeugpool.Fahrzeugliste,textBoxKennzeichen.Text);

            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
