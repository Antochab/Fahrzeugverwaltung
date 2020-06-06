namespace Fahrzeugverwaltung.Forms
{
    partial class Hauptmenu
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
            this.buttonFahrzeugAnlegen = new System.Windows.Forms.Button();
            this.buttonDatenAusgeben = new System.Windows.Forms.Button();
            this.buttonSteuerschuldBerechnen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonParkhausAnlegen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFahrzeugAnlegen
            // 
            this.buttonFahrzeugAnlegen.Location = new System.Drawing.Point(73, 17);
            this.buttonFahrzeugAnlegen.Name = "buttonFahrzeugAnlegen";
            this.buttonFahrzeugAnlegen.Size = new System.Drawing.Size(151, 62);
            this.buttonFahrzeugAnlegen.TabIndex = 0;
            this.buttonFahrzeugAnlegen.Text = "Fahrzeug anlegen";
            this.buttonFahrzeugAnlegen.UseVisualStyleBackColor = true;
            this.buttonFahrzeugAnlegen.Click += new System.EventHandler(this.buttonFahrzeugAnlegen_Click);
            // 
            // buttonDatenAusgeben
            // 
            this.buttonDatenAusgeben.Location = new System.Drawing.Point(73, 124);
            this.buttonDatenAusgeben.Name = "buttonDatenAusgeben";
            this.buttonDatenAusgeben.Size = new System.Drawing.Size(151, 71);
            this.buttonDatenAusgeben.TabIndex = 1;
            this.buttonDatenAusgeben.Text = "Daten ausgeben";
            this.buttonDatenAusgeben.UseVisualStyleBackColor = true;
            this.buttonDatenAusgeben.Click += new System.EventHandler(this.buttonDatenAusgeben_Click);
            // 
            // buttonSteuerschuldBerechnen
            // 
            this.buttonSteuerschuldBerechnen.Location = new System.Drawing.Point(73, 226);
            this.buttonSteuerschuldBerechnen.Name = "buttonSteuerschuldBerechnen";
            this.buttonSteuerschuldBerechnen.Size = new System.Drawing.Size(151, 60);
            this.buttonSteuerschuldBerechnen.TabIndex = 2;
            this.buttonSteuerschuldBerechnen.Text = "Steuerschulden";
            this.buttonSteuerschuldBerechnen.UseVisualStyleBackColor = true;
            this.buttonSteuerschuldBerechnen.Click += new System.EventHandler(this.buttonSteuerschuldBerechnen_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonFahrzeugAnlegen);
            this.panel1.Controls.Add(this.buttonSteuerschuldBerechnen);
            this.panel1.Controls.Add(this.buttonDatenAusgeben);
            this.panel1.Controls.Add(this.buttonParkhausAnlegen);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(386, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 410);
            this.panel1.TabIndex = 3;
            // 
            // buttonParkhausAnlegen
            // 
            this.buttonParkhausAnlegen.Location = new System.Drawing.Point(73, 318);
            this.buttonParkhausAnlegen.Name = "buttonParkhausAnlegen";
            this.buttonParkhausAnlegen.Size = new System.Drawing.Size(151, 62);
            this.buttonParkhausAnlegen.TabIndex = 3;
            this.buttonParkhausAnlegen.Text = "Parkhaus anlegen";
            this.buttonParkhausAnlegen.UseVisualStyleBackColor = true;
            this.buttonParkhausAnlegen.Click += new System.EventHandler(this.buttonParkhausAnlegen_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(368, 26);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "ConnectionString (@\"Provider=Microsoft.Jet.OLEDB.4.0...)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Verbindung zur Datenbank";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 68);
            this.button1.TabIndex = 6;
            this.button1.Text = "Verbindung herstellen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Hauptmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Hauptmenu";
            this.Text = "Hauptmenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hauptmenu_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFahrzeugAnlegen;
        private System.Windows.Forms.Button buttonDatenAusgeben;
        private System.Windows.Forms.Button buttonSteuerschuldBerechnen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonParkhausAnlegen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}