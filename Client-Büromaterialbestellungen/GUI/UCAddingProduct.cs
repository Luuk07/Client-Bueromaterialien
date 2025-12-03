using Büromaterialbestellungen.Classes.Container;
using Büromaterialbestellungen.Classes.Services;
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
    public partial class UCAddingProduct : UserControl
    {
        public int labelCount = 1;
        public event EventHandler added;
        public CclSvcMain svcMain = new CclSvcMain();

        //FormProduktbestellung formProduktbestellung = new FormProduktbestellung();

        public string productName
        {
            get => labelProductName.Text;
            set => labelProductName.Text = value;
        }

       

        public CclContProductOrder Product { get; set; }

        //public CclContProduct Product
        //{
        //    get
        //    {
        //        return new CclContProduct { ProductName = productName, Amount = labelCount };
        //    }
        //}

        public UCAddingProduct()
        {
            InitializeComponent();
            //AddToShoppingcart();
            labelProductCount.Text = labelCount.ToString();
            labelCount = 1; 
            Product = svcMain.CreateNewProduktForShoppingCart(); //Besser, da es dann nur ein Product gibt, sonst gäbe es immer neue Instanzen
        }
        

        private void buttonAddOne_Click(object sender, EventArgs e)
        {
            labelCount++;
            labelProductCount.Text = labelCount.ToString();
        }

        private void buttonDeleteOne_Click(object sender, EventArgs e)
        {
            if(labelCount > 1)
            {
                labelCount--;
                labelProductCount.Text = labelCount.ToString();
            }
        }

        private void buttonAddToShopingCart_Click(object sender, EventArgs e)
        {
            Product.RecProductOrder.Amount = labelCount;
            Product.RecProductData.ProductName = productName;
            Product.RecProductData.ProductID = svcMain.GetProductIDByName(productName);
            Product.RecProductData.KategorieID = svcMain.GetKategorieIDByName(productName);
            added?.Invoke(this, EventArgs.Empty);
            labelCount = 1;
            labelProductCount.Text = labelCount.ToString();
            //svcMain.AddProductToShoppingCart(Product);
        }

        public void AddToShoppingcart(FormProduktbestellung formProduktbestellung)
        {
                added += (s, e) =>
                {
                    if (productName == "Produktname")
                    {
                        MessageBox.Show("Bitte gib ein Produkt an");
                        return;
                    }

                    var existingItem = formProduktbestellung.shoppingCart.Items
                        .Cast<CclContProductOrder>()
                        .FirstOrDefault(uc => uc != null &&
                         uc.ToString().Contains(Product.RecProductData.ProductName));

                    if (existingItem != null)
                    {
                        //shoppingCart.Items.Remove(existingItem);
                        existingItem.RecProductOrder.Amount += Product.RecProductOrder.Amount; // Jetzt wird die Menge addiert
                        //UI aktualisieren
                        int index = formProduktbestellung.shoppingCart.Items.IndexOf(existingItem);
                        formProduktbestellung.shoppingCart.Items[index] = existingItem;
                    }
                    else
                    {
                        formProduktbestellung.shoppingCart.Items.Add(Product);
                    }
                    Product = svcMain.CreateNewProduktForShoppingCart();
                };
            
        }




    }
}
