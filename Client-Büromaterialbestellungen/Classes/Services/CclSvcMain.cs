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
    // Schnittstelle zwischen GUI und Datenebene
    public class CclSvcMain
    {
        private CclSvcDataStorage _svcDB = new CclSvcDataStorage();
        public ObservableCollection<CclRecProduct> Products { get; set; }

        public CclSvcMain()
        {
            //Holt die Daten aus der DB und speichert sie in der ObservableCollection
            Products = new ObservableCollection<CclRecProduct>(_svcDB.getDataFromDB());

            // Bei Änderung wird SaveProduct aufgerufen
            Products.CollectionChanged += (s, e) => SaveProduct();

        }
       
        public void SaveProduct()
        {
            _svcDB.putDataToDB(Products.ToList());
        }

        public CclContProduct CreateNewProduktForShoppingCart()//string _strName, int _iAmount, string _strUserName)
        {
            CclContProduct clNew = new CclContProduct(); //{ ProductName = _strName, Amount = _iAmount, UserName = _strUserName };

            //Products.Add(clNew);  // CclSvcMain sollte die Liste der Produkte enthalten

            return clNew;  // Du kannst auch eine void-Methode nehmen. Dann fällt diese Rückgabe weg. Kommt darauf an, ob du das neue Produkt auf der aufrufenden Seite noch verwendest.
        }


    }
}
