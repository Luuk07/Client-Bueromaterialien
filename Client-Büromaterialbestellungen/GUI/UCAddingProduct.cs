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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Büromaterialbestellungen.GUI
{
    public partial class UCAddingProduct : UserControl
    {
        public int labelCount = 1;
        public event EventHandler added;
        public CclSvcMain svcMain = new CclSvcMain();

      

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

            //ComboBox Unit mit Einheiten füllen
            comboBoxUnit.Items.Add("Stück");
            comboBoxUnit.Items.Add("Karton");
            comboBoxUnit.Items.Add("Dose");
            comboBoxUnit.Items.Add("Rolle");
            comboBoxUnit.Items.Add("Packung");
            comboBoxUnit.Items.Add("Glas");
            comboBoxUnit.Items.Add("Sack");
            comboBoxUnit.Items.Add("Palette");
            //Fristpicker deaktivieren
            fristPicker.Enabled = false;

            comboBoxUnit.SelectedIndex = 0; //Standardwert
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
            Product.RecProductOrder.Unit = comboBoxUnit.SelectedItem.ToString();
            Product.RecProductData.ProductName = productName;
            Product.RecProductData.ProductID = svcMain.GetProductIDByName(productName);
            Product.RecProductData.KategorieID = svcMain.GetKategorieIDByName(productName);
            if (checkBoxFrist.Checked)
            {
                Product.RecProductOrder.Deadline = fristPicker.Value;
            }
            else
            {
                Product.RecProductOrder.Deadline = DateTime.MinValue;
            }

            if (string.IsNullOrWhiteSpace(textBoxInputArtikelnummer.Text))
            {
                Product.RecProductOrder.Note = "Keine Anmerkung";
            }
            else
            {
                Product.RecProductOrder.Note = textBoxInputNote.Text;
            }
            if (string.IsNullOrWhiteSpace(textBoxInputArtikelnummer.Text))
            {
                Product.RecProductOrder.ArticelNumber = "Keine Artikelnummer angegeben";
            }
            else
            {
                Product.RecProductOrder.ArticelNumber = textBoxInputArtikelnummer.Text;
            }

            
            added?.Invoke(this, EventArgs.Empty);
        
           
           
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
                    // UI zurücksetzen
                    labelCount = 1;
                    labelProductCount.Text = labelCount.ToString();
                    textBoxInputNote.Text = "";
                    textBoxInputArtikelnummer.Text = "";

                    var existingItem = formProduktbestellung.shoppingCart.Items
                        .Cast<CclContProductOrder>()
                        .FirstOrDefault(uc => uc != null &&
                         uc.ToString().Contains(Product.RecProductData.ProductName));

                    // Überprüfen, ob es das Item schon gibt und ob die Anmerkungen gleich sind 
                    if (existingItem != null && (existingItem.RecProductOrder.Note == textBoxInputNote.Text))
                    {
                        
                        //shoppingCart.Items.Remove(existingItem);
                        existingItem.RecProductOrder.Amount += Product.RecProductOrder.Amount; // Jetzt wird die Menge addiert
                        existingItem.RecProductOrder.Note = textBoxInputNote.Text; // Anmerkungen aktualisieren
                        existingItem.RecProductOrder.ArticelNumber = textBoxInputArtikelnummer.Text; // Artikelnummer aktualisieren
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
        // Aktiviert oder Deaktiviert die Frist
        private void checkBoxFrist_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFrist.Checked)
            {
                fristPicker.Enabled = true;
            }
            else {
                fristPicker.Enabled = false;
                //Finde keine bessere Möglichkeit
                Product.RecProductOrder.Deadline = DateTime.MinValue;
            }

        }
    }
}
