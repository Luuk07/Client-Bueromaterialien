using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Container
{
    // Container class for products in the shopping cart
    public class CclContProduct
    {
        public string ProductName { get; set; }

        public int Amount { get; set; }

        //public DateTime AddDate { get; set; }

        public string UserName { get; set; }

        public override string ToString()
        {
            return $"Produkt: {ProductName}, Menge: {Amount}";
        }
    }
}
