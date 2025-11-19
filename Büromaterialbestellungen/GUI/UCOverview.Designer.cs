namespace Büromaterialbestellungen.GUI
{
    partial class UCOverview
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Überschrift = new System.Windows.Forms.Label();
            this.listViewUC = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Überschrift
            // 
            this.Überschrift.AutoSize = true;
            this.Überschrift.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Überschrift.Location = new System.Drawing.Point(3, 0);
            this.Überschrift.Name = "Überschrift";
            this.Überschrift.Size = new System.Drawing.Size(184, 55);
            this.Überschrift.TabIndex = 0;
            this.Überschrift.Text = "Anzahl ";
            // 
            // listViewUC
            // 
            this.listViewUC.HideSelection = false;
            this.listViewUC.Location = new System.Drawing.Point(13, 58);
            this.listViewUC.Name = "listViewUC";
            this.listViewUC.Size = new System.Drawing.Size(342, 475);
            this.listViewUC.TabIndex = 1;
            this.listViewUC.UseCompatibleStateImageBehavior = false;
            // 
            // UCOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewUC);
            this.Controls.Add(this.Überschrift);
            this.Name = "UCOverview";
            this.Size = new System.Drawing.Size(368, 549);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Überschrift;
        private System.Windows.Forms.ListView listViewUC;
    }
}
