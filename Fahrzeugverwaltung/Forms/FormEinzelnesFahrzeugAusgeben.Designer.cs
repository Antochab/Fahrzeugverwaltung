﻿namespace Fahrzeugverwaltung.Forms
{
    partial class FormEinzelnesFahrzeugAusgeben
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
            this.textBoxKennzeichen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSuchen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxKennzeichen
            // 
            this.textBoxKennzeichen.Location = new System.Drawing.Point(12, 64);
            this.textBoxKennzeichen.Name = "textBoxKennzeichen";
            this.textBoxKennzeichen.Size = new System.Drawing.Size(100, 26);
            this.textBoxKennzeichen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kennzeichen";
            // 
            // buttonSuchen
            // 
            this.buttonSuchen.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonSuchen.Location = new System.Drawing.Point(12, 112);
            this.buttonSuchen.Name = "buttonSuchen";
            this.buttonSuchen.Size = new System.Drawing.Size(78, 36);
            this.buttonSuchen.TabIndex = 2;
            this.buttonSuchen.Text = "Suchen";
            this.buttonSuchen.UseVisualStyleBackColor = false;
            this.buttonSuchen.Click += new System.EventHandler(this.buttonSuchen_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(274, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(410, 352);
            this.textBox1.TabIndex = 3;
            // 
            // FormEinzelnesFahrzeugAusgeben
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSuchen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxKennzeichen);
            this.Name = "FormEinzelnesFahrzeugAusgeben";
            this.Text = "Fahrzeug anzeigen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxKennzeichen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSuchen;
        private System.Windows.Forms.TextBox textBox1;
    }
}