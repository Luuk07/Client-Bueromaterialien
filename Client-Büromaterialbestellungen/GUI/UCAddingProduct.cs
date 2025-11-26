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
    public partial class UCAddingProduct : UserControl
    {
        public int labelCount = 1;
        public event EventHandler added;
        
        //FormProduktbestellung formProduktbestellung = new FormProduktbestellung();

        public string productName
        {
            get => labelProductName.Text;
            set => labelProductName.Text = value;
        }

        //public CclContProduct Product {get; set;}

        public CclContProduct Product
        {
            get
            {
                return new CclContProduct { ProductName = productName, Amount = labelCount };
            }
        }

        public UCAddingProduct()
        {
            InitializeComponent();
            //AddToShoppingcart();
            labelProductCount.Text = labelCount.ToString();
            labelCount = 1; 
            //Product = new CclContProduct { ProductName = productName, Amount = labelCount }; //Besser, da es dann nur ein Product gibt, sonst gäbe es immer neue Instanzen
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
            added?.Invoke(this, EventArgs.Empty);
            Product.Amount = labelCount;
            Product.ProductName = productName;
            labelCount = 1;
            labelProductCount.Text = labelCount.ToString();

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
                    .Cast<CclContProduct>()
                    .FirstOrDefault(uc => uc != null &&
                     uc.ToString().Contains(Product.ProductName));

                if (existingItem != null)
                {
                    //shoppingCart.Items.Remove(existingItem);
                    existingItem.Amount += Product.Amount; // Jetzt wird die Menge addiert


                    //UI aktualisieren
                    int index = formProduktbestellung.shoppingCart.Items.IndexOf(existingItem);
                    formProduktbestellung.shoppingCart.Items[index] = existingItem;


                }
                else
                {
                    formProduktbestellung.shoppingCart.Items.Add(Product);
                }
            };
        }




    }
}
