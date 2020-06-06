namespace Fahrzeugverwaltung.Forms
{
    partial class FormAlleFahrzeugeAusgeben
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
            this.listBoxPKW = new System.Windows.Forms.ListBox();
            this.listBoxLKW = new System.Windows.Forms.ListBox();
            this.listBoxMottorad = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxPKW
            // 
            this.listBoxPKW.FormattingEnabled = true;
            this.listBoxPKW.ItemHeight = 20;
            this.listBoxPKW.Location = new System.Drawing.Point(12, 37);
            this.listBoxPKW.Name = "listBoxPKW";
            this.listBoxPKW.Size = new System.Drawing.Size(1330, 184);
            this.listBoxPKW.TabIndex = 0;
            // 
            // listBoxLKW
            // 
            this.listBoxLKW.FormattingEnabled = true;
            this.listBoxLKW.ItemHeight = 20;
            this.listBoxLKW.Location = new System.Drawing.Point(12, 262);
            this.listBoxLKW.Name = "listBoxLKW";
            this.listBoxLKW.Size = new System.Drawing.Size(1330, 184);
            this.listBoxLKW.TabIndex = 1;
            // 
            // listBoxMottorad
            // 
            this.listBoxMottorad.FormattingEnabled = true;
            this.listBoxMottorad.ItemHeight = 20;
            this.listBoxMottorad.Location = new System.Drawing.Point(12, 486);
            this.listBoxMottorad.Name = "listBoxMottorad";
            this.listBoxMottorad.Size = new System.Drawing.Size(1330, 184);
            this.listBoxMottorad.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "PKW";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "LKW";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Motorrad";
            // 
            // FormAlleFahrzeugeAusgeben
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 691);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxMottorad);
            this.Controls.Add(this.listBoxLKW);
            this.Controls.Add(this.listBoxPKW);
            this.Name = "FormAlleFahrzeugeAusgeben";
            this.Text = "Alle Fahrzeuge";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPKW;
        private System.Windows.Forms.ListBox listBoxLKW;
        private System.Windows.Forms.ListBox listBoxMottorad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}