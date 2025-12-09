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
        public ObservableCollection<CclRecProductOrder> Products { get; set; }

        public ObservableCollection<CclRecProductData> ProductData { get;set; }

        //public List<CclContProductOrder> AllProducts { get; set; } 


        public CclSvcMain()
        {
            //Holt die Daten aus der DB und speichert sie in der ObservableCollection
            Products = new ObservableCollection<CclRecProductOrder>(_svcDB.getProductsFromDB());
            ProductData = new ObservableCollection<CclRecProductData>(_svcDB.getProducstDataFromDB());

            Products.CollectionChanged += (s, e) => SaveProduct();

        }
        
        public int GetProductIDByName(string productName)
        {
            var product = ProductData.FirstOrDefault(p => p.ProductName == productName);
            if (product != null)
            {
                return product.ProductID;
            }
            return 0; 
        }

        public int GetKategorieIDByName(string productName)
        {
            var product = ProductData.FirstOrDefault(p => p.ProductName == productName);
            if (product != null)
            {
                return product.KategorieID;
            }
            return 0;
        }

        public void SaveProduct()
        {
            _svcDB.putPruductToDB(Products.ToList());
        }

        public void OnDeleted(CclRecProductOrder product)
        {
            product.Deleted = true;
            _svcDB.putPruductToDB(Products.ToList());
        }
        public void OnReceived(CclRecProductOrder product)
        {
            product.Deleted = false;
            product.IsReceived = true;
            product.IsOrdered = false;
            product.IsPreOrdered = false;
            _svcDB.putPruductToDB(Products.ToList());
        }

        public CclContProductOrder CreateNewProduktForShoppingCart()
        {
            CclContProductOrder clNew = new CclContProductOrder();

            return clNew;  
        }

        //Fügt das Produkt dem Warenkorb hinzu
        //public void AddProductToShoppingCart(CclContProductOrder product)
        //{
        //    AllProducts.Add(product);
        //}



    }
}
