using Büromaterialbestellungen.Classes.Container;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Büromaterialbestellungen.GUI
{
    public partial class FormProduktbestellung : Form
    {
        
        UCAddingProduct addingProduct;

        bool blocker = false;
      

        public FormProduktbestellung()
        {
            InitializeComponent();
            OpenTree();
            addingProduct = new UCAddingProduct();
            addingProduct.Location = new Point(230, 44); 
            this.Controls.Add(addingProduct);

            addingProduct.added += (s, e) =>
            {
                shoppingCart.Items.Add(addingProduct.Product);
            };

        }

        void OpenTree()
        {
            TreeNode stifte = new TreeNode("Stifte");
            TreeNode mappen = new TreeNode("Mappen");
            productTree.Nodes.Add(stifte);
            productTree.Nodes.Add(mappen);
            stifte.Nodes.Add("Bleistift");
            stifte.Nodes.Add("Kugelschreiber");
            stifte.Nodes.Add("Füller");
            mappen.Nodes.Add("Blaue Mappe");
            mappen.Nodes.Add("Rote Mappe");
            mappen.Nodes.Add("Grüne Mappe");
        }

        private void productTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedProduct = e.Node;
            addingProduct.productName = selectedProduct.Text; 
        }

        private void shoppingCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blocker)
            {
                return;
            }
            var selectedProduct = (CclContProduct)shoppingCart.SelectedItem;
            
            if (selectedProduct != null)
            {
                if (selectedProduct.Anzahl >1)
                {
                    selectedProduct.Anzahl --;

                    blocker = true;
                    // Index merken
                    int index = shoppingCart.SelectedIndex;

                    // Item neu zuweisen – erzwingt Update
                    shoppingCart.Items[index] = selectedProduct;

                    shoppingCart.ClearSelected();

                    blocker = false;

                  

                }
                else
                {
              
                    shoppingCart.Items.Remove(shoppingCart.SelectedItem);
                
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //WarenKorb in die Datenbank
            shoppingCart.Items.Clear();
        }

        private void Produckt_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)  
            {
                int index = shoppingCart.IndexFromPoint(e.Location);

                if (index != ListBox.NoMatches)
                {
                    shoppingCart.Items.Remove(shoppingCart.Items[index]);
                }
            }
        }

  
    }
}
