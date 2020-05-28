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
    public partial class SubMenuFahrzeugAnlegen : Form
    {
        public SubMenuFahrzeugAnlegen()
        {
            InitializeComponent();
        }

    private void SubMenuFahrzeugAnlegen_Load(object sender, EventArgs e)
        {
            buttonLKWAnlegen.Click += button_Click;
            buttonPKWAnlegen.Click += button_Click;
            buttonMotorradAnlegen.Click += button_Click;

        }


    private void button_Click(object sender, EventArgs e)
        {
            this.Close();
            switch (((Button)sender).Name)
            {
                case "buttonPKWAnlegen":
                    FormFahrzeugAnlegen pkwForm = new FormFahrzeugAnlegen("PKW");
                    pkwForm.Show();
                    break;

                case "buttonMotorradAnlegen":
                    FormFahrzeugAnlegen motorradForm = new FormFahrzeugAnlegen("Motorrad");
                    motorradForm.Show();
                    break;

                case "buttonLKWAnlegen":
                    this.Close();
                    FormFahrzeugAnlegen lkwForm = new FormFahrzeugAnlegen("LKW");
                    lkwForm.Show();
                    break;
            }
        }
    }
}
