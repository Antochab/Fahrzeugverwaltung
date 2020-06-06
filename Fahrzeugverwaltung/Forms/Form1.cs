using Fahrzeugverwaltung.Klassen;
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
    public partial class FormParkhäuserAnzeigen : Form
    {
        private Fahrzeugpool fahrzeugpool ;
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
