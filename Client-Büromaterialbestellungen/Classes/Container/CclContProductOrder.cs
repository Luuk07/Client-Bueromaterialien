using Büromaterialbestellungen.Classes.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Container
{
    // Container class for products in the shopping cart
    public class CclContProductOrder
    {
        //public string ProductName { get; set; }

        // public int Amount { get; set; }

        //public DateTime AddDate { get; set; }

        public CclRecProductOrder RecProductOrder { get; set; }

        public CclRecProductData RecProductData { get; set; }

        public CclContProductOrder() 
        {
            RecProductOrder = new CclRecProductOrder();
            RecProductData = new CclRecProductData();
        }

        public override string ToString()
        {
            return $"Produkt: {RecProductData.ProductName}, Menge: {RecProductOrder.Amount}, Anmerkung:{RecProductOrder.Note} ";
        }
    }
}
