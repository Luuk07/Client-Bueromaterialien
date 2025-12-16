using Büromaterialbestellungen.Classes.Records;
using Büromaterialbestellungen.Classes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Container
{
   
    public class CclContProductOrder
    {  

        public CclRecProductOrder RecProductOrder { get; set; }

        public CclRecProductData RecProductData { get; set; }

        public CclSvcOrder Order { get; set; }


        public CclContProductOrder(CclRecProductOrder recProductOrder, CclRecProductData recProductData, CclSvcOrder cclSvcOrder)
        {
            RecProductOrder = recProductOrder;
            RecProductData = recProductData;
            Order = cclSvcOrder;

        }

        public CclContProductOrder(): this( new CclRecProductOrder(), new CclRecProductData(), new CclSvcOrder())
        {
        }


        public override string ToString()
        {
            return $"Produkt: {RecProductData.ProductName}, Menge: {RecProductOrder.Amount}, Anmerkung:{RecProductOrder.Note} Artikelnumme: {RecProductOrder.ArticelNumber} ";
        }
    }
}
