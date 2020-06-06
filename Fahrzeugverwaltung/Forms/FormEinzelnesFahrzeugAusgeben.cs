using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
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
