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
        CclSvcMain SvcMain;
        

        public FormProduktbestellung(CclSvcMain svcMain)
        {
            InitializeComponent();
            SvcMain = svcMain;
            


            ucAddingProduct.Location = new Point(230, 44);
            ucAddingProduct.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            ucAddingProduct.AddToShoppingcart(this);
           

            dropDownBoxUserNames.Items.AddRange(new string[] { "Dilshod Akramov", "Ralf Biniasch", "Jens Ceasar", "Heiko Dittrich", "Tjalf Ceasar", "Luuk Pehlgrim" });

            

            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
        }
        
        public void InitTree()
        {
            productTree.Nodes.Clear();

            var allConnectionPoints = SvcMain.ProductData.Where(p => p.KategorieID == 0 && p.IsConnectionPoint);

            foreach (var root in allConnectionPoints)
            {
                TreeNode parentNood = new TreeNode(root.ProductName);
                parentNood.Tag = root.ProductID;
                productTree.Nodes.Add(parentNood);
               

                AddChildren(parentNood, root.ProductID);    
            }
        }

        public void AddChildren(TreeNode parenNode, int parentProductID )
        {
            
            var childs = SvcMain.ProductData.Where(p => p.KategorieID == parentProductID);
            foreach (var child in childs)
            {
                TreeNode childNode = new TreeNode(child.ProductName);
                childNode.Tag = child.ProductID;
                parenNode.Nodes.Add(childNode);
            }
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
                foreach (CclContProductOrder item in shoppingCart.Items) { 

                    var recProductOrder = new CclRecProductOrder();
                    var recProductData = new CclRecProductData();

                    recProductOrder.ID = item.RecProductOrder.ID;
                    recProductOrder.ProductName = item.RecProductData.ProductName;
                    recProductOrder.ProductID = item.RecProductData.ProductID;
                    recProductOrder.Amount = item.RecProductOrder.Amount;
                    recProductOrder.UserName = dropDownBoxUserNames.Text;
                    
                    recProductOrder.IsPreOrdered = true;
                    recProductOrder.OrderID = SvcMain._svcOrder.ID;
                    recProductOrder.Deadline = item.RecProductOrder.Deadline;
                    recProductOrder.Note = item.RecProductOrder.Note;
                    recProductOrder.ArticelNumber = item.RecProductOrder.ArticelNumber;

                    SvcMain._svcOrder.Date = DateTime.Now;
                    SvcMain.Products.Add(recProductOrder);         
                    SvcMain._svcOrder.AddProduct(recProductData ,recProductOrder);


                }

                SvcMain.AddOrderToAllOrderList(SvcMain._svcOrder);
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
                    var selectedProduct = (CclContProductOrder)shoppingCart.Items[index];
                    selectedProduct.RecProductOrder.Amount++;
                    shoppingCart.Items[index] = shoppingCart.Items[index];
                    shoppingCart.Refresh();
                }
              
            }
            if (e.Button == MouseButtons.Left)
            {
                int index = shoppingCart.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    var selectedProduct = (CclContProductOrder)shoppingCart.Items[index];
                    selectedProduct.RecProductOrder.Amount--;
                    shoppingCart.Items[index] = shoppingCart.Items[index];
                    if( selectedProduct.RecProductOrder.Amount <= 0)
                    {
                        shoppingCart.Items.Remove(shoppingCart.Items[index]);
                    }
                    shoppingCart.Refresh();
                }  
            }
        }

       
    }
}
