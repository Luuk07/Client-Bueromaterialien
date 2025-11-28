using Büromaterialbestellungen.Classes.Container;
using Büromaterialbestellungen.Classes.Records;
using Büromaterialbestellungen.Classes.Services;
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
        CclSvcMain svcMain = new CclSvcMain();

        public FormProduktbestellung()
        {
            InitializeComponent();
            OpenTree();
           
            ucAddingProduct.Location = new Point(230, 44);
            ucAddingProduct.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            ucAddingProduct.AddToShoppingcart(this);

            dropDownBoxUserNames.Items.AddRange(new string[] { "Dilshod Akramov", "Ralf Biniasch", "Jens Ceasar", "Heiko Dittrich", "Tjalf Ceasar", "Luuk Pehlgrim" });

            //AddToShoppingcart();

            //this.Controls.Add(dropDownBoxUserNames); //Dachte man muss es immer hinzufügen, aber wenn man es im Designer hinzufügt, ist es schon da
            //this.Controls.Add(ucAddingProduct);

            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
        }
        //public void AddToShoppingcart()
        //{
            
        //    ucAddingProduct.added += (s, e) =>
        //     {
        //         if (ucAddingProduct.productName == "Produktname")
        //         {
        //             MessageBox.Show("Bitte gib ein Produkt an");
        //             return;
        //         }

        //         var existingItem = shoppingCart.Items
        //             .Cast<CclContProduct>()                      
        //             .FirstOrDefault(uc => uc != null &&
        //              uc.ToString().Contains(ucAddingProduct.Product.ProductName));

        //         if (existingItem != null)
        //         {
        //             //shoppingCart.Items.Remove(existingItem);
        //             existingItem.Amount += ucAddingProduct.Product.Amount; // Jetzt wird die Menge addiert

                    
        //             //UI aktualisieren
        //             int index = shoppingCart.Items.IndexOf(existingItem);
        //             shoppingCart.Items[index] = existingItem; 


        //         }
        //         else
        //         {
        //             shoppingCart.Items.Add(ucAddingProduct.Product);
        //         }
        //     }; 
        //}
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

            //TreeNode selectedProduct = e.Node; habe ich gemacht, damit ich sehe woher dieses 'e.Node' herkommt
            ucAddingProduct.productName = e.Node.Text; 
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
                foreach (CclContProduct item in shoppingCart.Items) { 

                    var recProduct = new CclRecProduct();
                    recProduct.ProductName = item.ProductName;
                    recProduct.Amount = item.Amount;
                    recProduct.UserName = dropDownBoxUserNames.Text;
                    recProduct.IsPreOrdered = true;

                    //var recOffice = new CclRecOffice();
                    //recOffice.ProductName = item.ProductName;
                    //recOffice.Amount = item.Amount;
                    //recOffice.UserName = dropDownBoxUserNames.Text;
                    //recOffice.IsPreOrdered = true;


                    //svcDB.putDataToDB(recProduct, recOffice);
                    svcMain.Products.Add(recProduct);
                }

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
              
            }
            if (e.Button == MouseButtons.Left)
            {
                int index = shoppingCart.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    var selectedProduct = (CclContProduct)shoppingCart.Items[index];
                    selectedProduct.Amount--;
                    shoppingCart.Items[index] = shoppingCart.Items[index];
                    if( selectedProduct.Amount <= 0)
                    {
                        shoppingCart.Items.Remove(shoppingCart.Items[index]);
                    }
                    shoppingCart.Refresh();
                }  
            }
        }

       
    }
}
