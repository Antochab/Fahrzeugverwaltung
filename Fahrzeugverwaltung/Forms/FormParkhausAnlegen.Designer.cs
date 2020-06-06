namespace Fahrzeugverwaltung.Forms
{
    partial class FormParkhausAnlegen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPLZ = new System.Windows.Forms.TextBox();
            this.textBoxAnzahlMotorrad = new System.Windows.Forms.TextBox();
            this.textBoxAnzahlPKW = new System.Windows.Forms.TextBox();
            this.textBoxParkhausnummer = new System.Windows.Forms.TextBox();
            this.textBoxOrt = new System.Windows.Forms.TextBox();
            this.textBoxAnzahlLKW = new System.Windows.Forms.TextBox();
            this.buttonAnlegen = new System.Windows.Forms.Button();
            this.buttonAbbrechen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPLZ
            // 
            this.textBoxPLZ.Location = new System.Drawing.Point(169, 148);
            this.textBoxPLZ.Name = "textBoxPLZ";
            this.textBoxPLZ.Size = new System.Drawing.Size(100, 26);
            this.textBoxPLZ.TabIndex = 0;
            // 
            // textBoxAnzahlMotorrad
            // 
            this.textBoxAnzahlMotorrad.Location = new System.Drawing.Point(592, 148);
            this.textBoxAnzahlMotorrad.Name = "textBoxAnzahlMotorrad";
            this.textBoxAnzahlMotorrad.Size = new System.Drawing.Size(100, 26);
            this.textBoxAnzahlMotorrad.TabIndex = 1;
            // 
            // textBoxAnzahlPKW
            // 
            this.textBoxAnzahlPKW.Location = new System.Drawing.Point(592, 59);
            this.textBoxAnzahlPKW.Name = "textBoxAnzahlPKW";
            this.textBoxAnzahlPKW.Size = new System.Drawing.Size(100, 26);
            this.textBoxAnzahlPKW.TabIndex = 2;
            // 
            // textBoxParkhausnummer
            // 
            this.textBoxParkhausnummer.Location = new System.Drawing.Point(169, 59);
            this.textBoxParkhausnummer.Name = "textBoxParkhausnummer";
            this.textBoxParkhausnummer.Size = new System.Drawing.Size(100, 26);
            this.textBoxParkhausnummer.TabIndex = 3;
            // 
            // textBoxOrt
            // 
            this.textBoxOrt.Location = new System.Drawing.Point(169, 233);
            this.textBoxOrt.Name = "textBoxOrt";
            this.textBoxOrt.Size = new System.Drawing.Size(100, 26);
            this.textBoxOrt.TabIndex = 6;
            // 
            // textBoxAnzahlLKW
            // 
            this.textBoxAnzahlLKW.Location = new System.Drawing.Point(592, 233);
            this.textBoxAnzahlLKW.Name = "textBoxAnzahlLKW";
            this.textBoxAnzahlLKW.Size = new System.Drawing.Size(100, 26);
            this.textBoxAnzahlLKW.TabIndex = 7;
            // 
            // buttonAnlegen
            // 
            this.buttonAnlegen.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonAnlegen.Location = new System.Drawing.Point(629, 387);
            this.buttonAnlegen.Name = "buttonAnlegen";
            this.buttonAnlegen.Size = new System.Drawing.Size(159, 51);
            this.buttonAnlegen.TabIndex = 8;
            this.buttonAnlegen.Text = "Anlegen";
            this.buttonAnlegen.UseVisualStyleBackColor = false;
            this.buttonAnlegen.Click += new System.EventHandler(this.buttonAnlegen_Click);
            // 
            // buttonAbbrechen
            // 
            this.buttonAbbrechen.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonAbbrechen.Location = new System.Drawing.Point(446, 387);
            this.buttonAbbrechen.Name = "buttonAbbrechen";
            this.buttonAbbrechen.Size = new System.Drawing.Size(159, 51);
            this.buttonAbbrechen.TabIndex = 9;
            this.buttonAbbrechen.Text = "Abbrechen";
            this.buttonAbbrechen.UseVisualStyleBackColor = false;
            this.buttonAbbrechen.Click += new System.EventHandler(this.buttonAbbrechen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "PLZ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ort";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Anzahl PKW Plätze";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Parkhausnummer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Anzahl Motorrad Plätze";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(360, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Anzahl LKW Plätze";
            // 
            // FormParkhausAnlegen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAbbrechen);
            this.Controls.Add(this.buttonAnlegen);
            this.Controls.Add(this.textBoxAnzahlLKW);
            this.Controls.Add(this.textBoxOrt);
            this.Controls.Add(this.textBoxParkhausnummer);
            this.Controls.Add(this.textBoxAnzahlPKW);
            this.Controls.Add(this.textBoxAnzahlMotorrad);
            this.Controls.Add(this.textBoxPLZ);
            this.Name = "FormParkhausAnlegen";
            this.Text = "Parkhaus anlegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPLZ;
        private System.Windows.Forms.TextBox textBoxAnzahlMotorrad;
        private System.Windows.Forms.TextBox textBoxAnzahlPKW;
        private System.Windows.Forms.TextBox textBoxParkhausnummer;
        private System.Windows.Forms.TextBox textBoxOrt;
        private System.Windows.Forms.TextBox textBoxAnzahlLKW;
        private System.Windows.Forms.Button buttonAnlegen;
        private System.Windows.Forms.Button buttonAbbrechen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}