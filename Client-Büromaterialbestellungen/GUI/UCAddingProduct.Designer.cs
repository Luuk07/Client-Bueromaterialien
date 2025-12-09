namespace Büromaterialbestellungen.GUI
{
    partial class UCAddingProduct
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
            this.labelProductName = new System.Windows.Forms.Label();
            this.buttonAddToShopingCart = new System.Windows.Forms.Button();
            this.labelProductCount = new System.Windows.Forms.Label();
            this.buttonDeleteOne = new System.Windows.Forms.Button();
            this.buttonAddOne = new System.Windows.Forms.Button();
            this.textBoxInputNote = new System.Windows.Forms.TextBox();
            this.labelAnmerkungen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(25, 44);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(139, 25);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Produktname";
            // 
            // buttonAddToShopingCart
            // 
            this.buttonAddToShopingCart.Location = new System.Drawing.Point(30, 97);
            this.buttonAddToShopingCart.Name = "buttonAddToShopingCart";
            this.buttonAddToShopingCart.Size = new System.Drawing.Size(197, 54);
            this.buttonAddToShopingCart.TabIndex = 1;
            this.buttonAddToShopingCart.Text = "Hinzufügen";
            this.buttonAddToShopingCart.UseVisualStyleBackColor = true;
            this.buttonAddToShopingCart.Click += new System.EventHandler(this.buttonAddToShopingCart_Click);
            // 
            // labelProductCount
            // 
            this.labelProductCount.AutoSize = true;
            this.labelProductCount.Location = new System.Drawing.Point(125, 209);
            this.labelProductCount.Name = "labelProductCount";
            this.labelProductCount.Size = new System.Drawing.Size(24, 25);
            this.labelProductCount.TabIndex = 2;
            this.labelProductCount.Text = "0";
            // 
            // buttonDeleteOne
            // 
            this.buttonDeleteOne.Location = new System.Drawing.Point(46, 193);
            this.buttonDeleteOne.Name = "buttonDeleteOne";
            this.buttonDeleteOne.Size = new System.Drawing.Size(56, 56);
            this.buttonDeleteOne.TabIndex = 3;
            this.buttonDeleteOne.Text = "-";
            this.buttonDeleteOne.UseVisualStyleBackColor = true;
            this.buttonDeleteOne.Click += new System.EventHandler(this.buttonDeleteOne_Click);
            // 
            // buttonAddOne
            // 
            this.buttonAddOne.Location = new System.Drawing.Point(157, 193);
            this.buttonAddOne.Name = "buttonAddOne";
            this.buttonAddOne.Size = new System.Drawing.Size(69, 55);
            this.buttonAddOne.TabIndex = 4;
            this.buttonAddOne.Text = "+";
            this.buttonAddOne.UseVisualStyleBackColor = true;
            this.buttonAddOne.Click += new System.EventHandler(this.buttonAddOne_Click);
            // 
            // textBoxInputNote
            // 
            this.textBoxInputNote.Location = new System.Drawing.Point(30, 322);
            this.textBoxInputNote.Name = "textBoxInputNote";
            this.textBoxInputNote.Size = new System.Drawing.Size(244, 31);
            this.textBoxInputNote.TabIndex = 5;
            // 
            // labelAnmerkungen
            // 
            this.labelAnmerkungen.AutoSize = true;
            this.labelAnmerkungen.Location = new System.Drawing.Point(25, 269);
            this.labelAnmerkungen.Name = "labelAnmerkungen";
            this.labelAnmerkungen.Size = new System.Drawing.Size(151, 25);
            this.labelAnmerkungen.TabIndex = 6;
            this.labelAnmerkungen.Text = "Anmerkungen:";
            // 
            // UCAddingProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelAnmerkungen);
            this.Controls.Add(this.textBoxInputNote);
            this.Controls.Add(this.buttonAddOne);
            this.Controls.Add(this.buttonDeleteOne);
            this.Controls.Add(this.labelProductCount);
            this.Controls.Add(this.buttonAddToShopingCart);
            this.Controls.Add(this.labelProductName);
            this.Name = "UCAddingProduct";
            this.Size = new System.Drawing.Size(349, 466);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Button buttonAddToShopingCart;
        private System.Windows.Forms.Label labelProductCount;
        private System.Windows.Forms.Button buttonDeleteOne;
        private System.Windows.Forms.Button buttonAddOne;
        private System.Windows.Forms.TextBox textBoxInputNote;
        private System.Windows.Forms.Label labelAnmerkungen;
    }
}
