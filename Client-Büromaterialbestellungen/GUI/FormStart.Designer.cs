namespace Büromaterialbestellungen
{
    partial class FormStart
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.buttonProduktbestellung = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.Location = new System.Drawing.Point(244, 59);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(266, 148);
            this.buttonDashboard.TabIndex = 0;
            this.buttonDashboard.Text = "Dashboard";
            this.buttonDashboard.UseVisualStyleBackColor = true;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // buttonProduktbestellung
            // 
            this.buttonProduktbestellung.Location = new System.Drawing.Point(244, 260);
            this.buttonProduktbestellung.Name = "buttonProduktbestellung";
            this.buttonProduktbestellung.Size = new System.Drawing.Size(266, 139);
            this.buttonProduktbestellung.TabIndex = 1;
            this.buttonProduktbestellung.Text = "Produktbestellungen";
            this.buttonProduktbestellung.UseVisualStyleBackColor = true;
            this.buttonProduktbestellung.Click += new System.EventHandler(this.buttonProduktbestellung_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonProduktbestellung);
            this.Controls.Add(this.buttonDashboard);
            this.Name = "FormStart";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Button buttonProduktbestellung;
    }
}

