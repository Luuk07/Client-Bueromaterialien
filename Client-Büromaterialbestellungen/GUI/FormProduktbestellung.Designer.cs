namespace Büromaterialbestellungen.GUI
{
    partial class FormProduktbestellung
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
            this.labelHeader = new System.Windows.Forms.Label();
            this.productTree = new System.Windows.Forms.TreeView();
            this.shoppingCart = new System.Windows.Forms.ListBox();
            this.labelShoppingCart = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.dropDownBoxUserNames = new System.Windows.Forms.ComboBox();
            this.ucAddingProduct = new Büromaterialbestellungen.GUI.UCAddingProduct();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(12, 33);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(151, 25);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Benutzername";
            // 
            // productTree
            // 
            this.productTree.Location = new System.Drawing.Point(12, 122);
            this.productTree.Name = "productTree";
            this.productTree.Size = new System.Drawing.Size(446, 752);
            this.productTree.TabIndex = 2;
            this.productTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.productTree_AfterSelect);
            // 
            // shoppingCart
            // 
            this.shoppingCart.FormattingEnabled = true;
            this.shoppingCart.ItemHeight = 25;
            this.shoppingCart.Location = new System.Drawing.Point(822, 122);
            this.shoppingCart.Name = "shoppingCart";
            this.shoppingCart.Size = new System.Drawing.Size(421, 754);
            this.shoppingCart.TabIndex = 3;
            this.shoppingCart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Produckt_MouseClick);
            // 
            // labelShoppingCart
            // 
            this.labelShoppingCart.AutoSize = true;
            this.labelShoppingCart.Location = new System.Drawing.Point(817, 94);
            this.labelShoppingCart.Name = "labelShoppingCart";
            this.labelShoppingCart.Size = new System.Drawing.Size(117, 25);
            this.labelShoppingCart.TabIndex = 4;
            this.labelShoppingCart.Text = "Warenkorb";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(822, 33);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(369, 55);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Abschicken";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // dropDownBoxUserNames
            // 
            this.dropDownBoxUserNames.FormattingEnabled = true;
            this.dropDownBoxUserNames.Location = new System.Drawing.Point(12, 61);
            this.dropDownBoxUserNames.Name = "dropDownBoxUserNames";
            this.dropDownBoxUserNames.Size = new System.Drawing.Size(446, 33);
            this.dropDownBoxUserNames.TabIndex = 6;
            // 
            // ucAddingProduct
            // 
            this.ucAddingProduct.Location = new System.Drawing.Point(464, 122);
            this.ucAddingProduct.Name = "ucAddingProduct";
            this.ucAddingProduct.productName = "Produktname";
            this.ucAddingProduct.Size = new System.Drawing.Size(352, 316);
            this.ucAddingProduct.TabIndex = 7;
            // 
            // FormProduktbestellung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 946);
            this.Controls.Add(this.ucAddingProduct);
            this.Controls.Add(this.dropDownBoxUserNames);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelShoppingCart);
            this.Controls.Add(this.shoppingCart);
            this.Controls.Add(this.productTree);
            this.Controls.Add(this.labelHeader);
            this.Name = "FormProduktbestellung";
            this.Text = "FormProduktbestellung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.TreeView productTree;
        private System.Windows.Forms.ListBox shoppingCart;
        private System.Windows.Forms.Label labelShoppingCart;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ComboBox dropDownBoxUserNames;
        private UCAddingProduct ucAddingProduct;
    }
}