using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Container
{
    public class CclContProduct
    {
        public string Name { get; set; }

        public int Anzahl { get; set; }

        public DateTime AddDate { get; set; }


        public override string ToString()
        {
            return $"Produkt: {Name}, Menge: {Anzahl}";
        }
    }
}
