﻿using System;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
    /// <summary>
    /// Auswahlmenü zum Anlegen eines neuen Fahrzeuges
    /// </summary>
    public partial class FormMenueFahrzeugauswahl : Form
    {
        private Fahrzeugpool fahrzeugpool;
        public FormMenueFahrzeugauswahl(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
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
                    FormFahrzeugAnlegen pkwForm = new FormFahrzeugAnlegen(fahrzeugpool, "PKW");
                    pkwForm.Show();
                    break;

                case "buttonMotorradAnlegen":
                    FormFahrzeugAnlegen motorradForm = new FormFahrzeugAnlegen(fahrzeugpool, "Motorrad");
                    motorradForm.Show();
                    break;

                case "buttonLKWAnlegen":
                    this.Close();
                    FormFahrzeugAnlegen lkwForm = new FormFahrzeugAnlegen(fahrzeugpool, "LKW");
                    lkwForm.Show();
                    break;
            }
        }

    }
}
