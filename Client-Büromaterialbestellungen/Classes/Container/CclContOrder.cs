using Büromaterialbestellungen.Classes.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Container
{
    public class CclContOrder
    {
        public CclRecProductOrder RecProductOrder { get; set; }

        public List<CclContProductOrder> ProductOrders { get; set; }
    }
}
