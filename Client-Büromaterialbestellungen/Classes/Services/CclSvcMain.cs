using Büromaterialbestellungen.Classes.Container;
using Büromaterialbestellungen.Classes.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Services
{
    public class CclSvcMain
    {
        private CclSvcDB _svcDB = new CclSvcDB();
        public ObservableCollection<CclRecProduct> Products { get; set; }

        public CclSvcMain()
        {

            Products = new ObservableCollection<CclRecProduct>(_svcDB.getDataFromDB());

            // Bei Änderung wird SaveProduct aufgerufen
            Products.CollectionChanged += (s, e) => SaveProduct();

        }
       

        public void SaveProduct()
        {
            _svcDB.putDataToDB(Products.ToList());
        }

    }
}
