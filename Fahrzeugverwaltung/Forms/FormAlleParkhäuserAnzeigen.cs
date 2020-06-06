using System;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
    /// <summary>
    /// Form zur Anzeige aller Parkhäuser
    /// </summary>
    public partial class FormParkhäuserAnzeigen : Form
    {
        private Fahrzeugpool fahrzeugpool;
        public FormParkhäuserAnzeigen(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void FormParkhäuserAnzeigen_Load(object sender, EventArgs e)
        {
            listBoxParkhäuser.DataSource = fahrzeugpool.Parkhausverwaltung.gibAlleParkhausDatenAus();
        }
    }
}
