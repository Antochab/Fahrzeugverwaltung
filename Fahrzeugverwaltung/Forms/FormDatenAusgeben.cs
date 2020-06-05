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
    public partial class FormDatenAusgeben : Form
    {
        private readonly Fahrzeugpool fahrzeugpool;
        public FormDatenAusgeben(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void buttonAlleDaten_Click(object sender, EventArgs e)
        {
            DatenAusgeben datenAusgeben = new DatenAusgeben(fahrzeugpool);
            datenAusgeben.Show();
            this.Close();
        }

        private void FormDatenAusgeben_Load(object sender, EventArgs e)
        {
        }
    }
}
