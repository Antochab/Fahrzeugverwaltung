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
            fahrzeugpool.berechneSteuerschuldKennzeichen(textBoxKennzeichen.Text);
        }
    }
}
