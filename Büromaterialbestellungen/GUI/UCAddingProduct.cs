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
        public string productName
        {
            get => labelProductName.Text;
            set => labelProductName.Text = value;
        }

        public CclContProduct Product { get
            {
                return new CclContProduct { Name = productName, Anzahl = labelCount };
            }
        }
        public UCAddingProduct()
        {
            InitializeComponent();
            labelProductCount.Text = labelCount.ToString();
           
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
            labelCount = 1;
            labelProductCount.Text = labelCount.ToString();

        }

      


    }
}
