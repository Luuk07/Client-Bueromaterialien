using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Container
{
    //Bestelbare Produktdaten, also ob Stift Mappe etc.
    public class CclContProductData
    {
        public string ProductName { get; set; }
        
        public string SupplierName { get; set; }

        public int ProductID { get; set; }
    }
}
