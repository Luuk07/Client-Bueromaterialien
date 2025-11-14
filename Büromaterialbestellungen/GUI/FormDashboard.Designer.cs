namespace Büromaterialbestellungen.GUI
{
    partial class FormDashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucOverviewErhalten = new Büromaterialbestellungen.GUI.UCOverview();
            this.ucOverviewVorbestellt = new Büromaterialbestellungen.GUI.UCOverview();
            this.ucOverviewBestellt = new Büromaterialbestellungen.GUI.UCOverview();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelBestellt = new System.Windows.Forms.Label();
            this.labelVorbestellt = new System.Windows.Forms.Label();
            this.labelErhalten = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            // 
            // ucOverviewErhalten
            // 
            this.ucOverviewErhalten.Location = new System.Drawing.Point(893, 200);
            this.ucOverviewErhalten.Name = "ucOverviewErhalten";
            this.ucOverviewErhalten.Size = new System.Drawing.Size(368, 549);
            this.ucOverviewErhalten.TabIndex = 7;
            // 
            // ucOverviewVorbestellt
            // 
            this.ucOverviewVorbestellt.Location = new System.Drawing.Point(428, 209);
            this.ucOverviewVorbestellt.Name = "ucOverviewVorbestellt";
            this.ucOverviewVorbestellt.Size = new System.Drawing.Size(417, 549);
            this.ucOverviewVorbestellt.TabIndex = 6;
            // 
            // ucOverviewBestellt
            // 
            this.ucOverviewBestellt.Location = new System.Drawing.Point(25, 209);
            this.ucOverviewBestellt.Name = "ucOverviewBestellt";
            this.ucOverviewBestellt.Size = new System.Drawing.Size(351, 549);
            this.ucOverviewBestellt.TabIndex = 5;
            // 
            // buttonMenu
            // 
            this.buttonMenu.Location = new System.Drawing.Point(925, 690);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(238, 76);
            this.buttonMenu.TabIndex = 8;
            this.buttonMenu.Text = "Menü";
            this.buttonMenu.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1081, 734);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelBestellt
            // 
            this.labelBestellt.AutoSize = true;
            this.labelBestellt.Location = new System.Drawing.Point(34, 85);
            this.labelBestellt.Name = "labelBestellt";
            this.labelBestellt.Size = new System.Drawing.Size(83, 25);
            this.labelBestellt.TabIndex = 10;
            this.labelBestellt.Text = "Bestellt";
            // 
            // labelVorbestellt
            // 
            this.labelVorbestellt.AutoSize = true;
            this.labelVorbestellt.Location = new System.Drawing.Point(441, 85);
            this.labelVorbestellt.Name = "labelVorbestellt";
            this.labelVorbestellt.Size = new System.Drawing.Size(114, 25);
            this.labelVorbestellt.TabIndex = 11;
            this.labelVorbestellt.Text = "Vorbestellt";
            // 
            // labelErhalten
            // 
            this.labelErhalten.AutoSize = true;
            this.labelErhalten.Location = new System.Drawing.Point(905, 85);
            this.labelErhalten.Name = "labelErhalten";
            this.labelErhalten.Size = new System.Drawing.Size(92, 25);
            this.labelErhalten.TabIndex = 12;
            this.labelErhalten.Text = "Erhalten";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 806);
            this.Controls.Add(this.labelErhalten);
            this.Controls.Add(this.labelVorbestellt);
            this.Controls.Add(this.labelBestellt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.ucOverviewErhalten);
            this.Controls.Add(this.ucOverviewVorbestellt);
            this.Controls.Add(this.ucOverviewBestellt);
            this.Controls.Add(this.label1);
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UCOverview ucOverviewBestellt;
        private UCOverview ucOverviewVorbestellt;
        private UCOverview ucOverviewErhalten;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelBestellt;
        private System.Windows.Forms.Label labelVorbestellt;
        private System.Windows.Forms.Label labelErhalten;
    }
}