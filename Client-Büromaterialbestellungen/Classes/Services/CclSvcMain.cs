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

        public CclSvcOrder _svcOrder { get; set; } = new CclSvcOrder();
        public ObservableCollection<CclRecProductOrder> Products { get; set; }

        public ObservableCollection<CclRecProductData> ProductData { get;set; }

        public ObservableCollection<CclRecOrder> Order { get; set; }

        public List<CclSvcOrder> Orders { get; set; }

        public List<CclContProductOrder> AllProduct { get; set; }




     


        public CclSvcMain()
        {
            //Holt die Daten aus der DB und speichert sie in der ObservableCollection
            Products = new ObservableCollection<CclRecProductOrder>(_svcDB.getProductsFromDB());
            ProductData = new ObservableCollection<CclRecProductData>(_svcDB.getProducstDataFromDB());
            Order = new ObservableCollection<CclRecOrder>(_svcDB.getOrderFromDB());

            Orders = new List<CclSvcOrder>();


            Products.CollectionChanged += (s, e) => SaveProduct();
            Order.CollectionChanged += (s, e) => SaveOrder();

        }

        public void AddOrderToAllOrderList(CclSvcOrder order)
        {
            Orders.Add(order);
            Order.Add(order.Order);
        }

        public void SwitchOrderDataToRecData()
        {

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

        public void SaveOrder()
        {
            _svcDB.putOrderToDB(Order.ToList());
        }

        public void OnDeleted(CclRecProductOrder product)
        {
            product.Deleted = true;
            _svcDB.putPruductToDB(Products.ToList());
            _svcDB.putOrderToDB(Order.ToList());
        }
        public void OnReceived(CclRecProductOrder product)
        {
            product.Deleted = false;
            product.IsReceived = true;
            product.IsOrdered = false;
            product.IsPreOrdered = false;
            _svcDB.putPruductToDB(Products.ToList());
            _svcDB.putOrderToDB(Order.ToList());
        }

        public CclContProductOrder CreateNewProduktForShoppingCart()
        {
            CclContProductOrder clNew = new CclContProductOrder();

            return clNew;  
        }

        



    }
}
