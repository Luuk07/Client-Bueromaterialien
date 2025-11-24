using Büromaterialbestellungen.Classes.Container;
using Büromaterialbestellungen.Classes.Records;
using CDS.Classes;
using CDS.Enumerations;
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
    // Produktbestellung Formular
    public partial class FormProduktbestellung : Form
    {
        
        UCAddingProduct addingProduct;
        bool blocker = false;
      

        public FormProduktbestellung()
        {
            InitializeComponent();
            OpenTree();
            addingProduct = new UCAddingProduct();
            addingProduct.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            addingProduct.Location = new Point(230, 44);


            dropDownBoxUserNames.Items.AddRange(new string[] { "Dilshod Akramov", "Ralf Biniasch", "Jens Ceasar", "Heiko Dittrich", "Tjalf Ceasar", "Luuk Pehlgrim" });

            AddToShopingcart();

            this.Controls.Add(dropDownBoxUserNames);
            this.Controls.Add(addingProduct);

            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
        }

        public void AddToShopingcart()
        {
       
             addingProduct.added += (s, e) =>
             {
                 if (addingProduct.productName == "Produktname")
                 {
                     MessageBox.Show("Bitte gib ein Produkt an");
                     return;
                 }

                 var existingItem = shoppingCart.Items
                     .Cast<object>()                      
                     .FirstOrDefault(uc => uc != null &&
                      uc.ToString().Contains(addingProduct.Product.ProductName));

                 if (existingItem != null)
                 {
                     shoppingCart.Items.Remove(existingItem);
                 }
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
            //Wenn ein Knotenpunkt ausgewählt wird, wird es nicht übernommen
            if (e.Node.Nodes.Count > 0)
            {
  
                productTree.SelectedNode = null;
                return;
            }

            TreeNode selectedProduct = e.Node;
            addingProduct.productName = selectedProduct.Text; 
        }

        private void shoppingCart_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    if (blocker)
        //    {
        //        return;
        //    }
        //    var selectedProduct = (CclContProduct)shoppingCart.SelectedItem;
            
        //    if (selectedProduct != null)
        //    {
        //        if (selectedProduct.Amount >1)
        //        {
        //            selectedProduct.Amount --;

        //            blocker = true;
        //            // Index merken
        //            int index = shoppingCart.SelectedIndex;

        //            // Item neu zuweisen – erzwingt Update
        //            shoppingCart.Items[index] = selectedProduct;

        //            shoppingCart.ClearSelected();

        //            blocker = false;

                  

        //        }
        //        else
        //        {
              
        //            shoppingCart.Items.Remove(shoppingCart.SelectedItem);
                
        //        }
        //    }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(dropDownBoxUserNames.Text.Length == 0)
            {
                MessageBox.Show("Bitte gib den Namen ein für den bestellt werden soll");
                return;
            }
            if (shoppingCart.Items.Count == 0)
            {
                MessageBox.Show("Bitte füge ein Produkt hinzu");
                return;
            }

            //WarenKorb in die Datenbank
            try
            {
            
                CclCDSDatabase clSvcCDSDatabase = new CclCDSDatabase(CDSStorageType.MariaDB);
                CclCDSTable<CclRecProdut> clProductList = new CclCDSTable<CclRecProdut>(clSvcCDSDatabase.BaseDB.CreateDataAccess());

             

                foreach (CclContProduct item in shoppingCart.Items) { 

                    var rec = new CclRecProdut();
                    rec.ProductName = item.ProductName;
                    rec.Amount = item.Amount;
                    rec.UserName = dropDownBoxUserNames.Text;
                    rec.IsPreOrdered = true;
                    
                


                    clProductList.AddNewRecord(rec);
                }


                clProductList.SaveData();
                shoppingCart.Items.Clear();
            }

            catch (Exception excError)
            {
                MessageBox.Show(excError.Message);
            }
        }

        private void Produckt_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)  
            {
                int index = shoppingCart.IndexFromPoint(e.Location);

                if (index != ListBox.NoMatches)
                {
                    shoppingCart.Items.Remove(shoppingCart.Items[index]);
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                int index = shoppingCart.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    var selectedProduct = (CclContProduct)shoppingCart.Items[index];
                    selectedProduct.Amount++;
                    shoppingCart.Items[index] = shoppingCart.Items[index];
                    shoppingCart.Refresh();
                }
                // Linksklick - nichts tun, da dies bereits im SelectedIndexChanged-Ereignis behandelt wird
            }
            if (e.Button == MouseButtons.Left)
            {
                int index = shoppingCart.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    var selectedProduct = (CclContProduct)shoppingCart.Items[index];
                    selectedProduct.Amount--;
                    shoppingCart.Items[index] = shoppingCart.Items[index];
                    shoppingCart.Refresh();
                    if( selectedProduct.Amount == 0)
                    {
                        shoppingCart.Items.Remove(shoppingCart.Items[index]);
                    }
                }
                // Linksklick - nichts tun, da dies bereits im SelectedIndexChanged-Ereignis behandelt wird
            }
        }

       
    }
}
