using Büromaterialbestellungen.Classes.Container;
using Büromaterialbestellungen.Classes.Records;
using CDS.Classes;
using CDS.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Büromaterialbestellungen.Classes.Services
{
    public class CclSvcDataStorage
    {
        private CclCDSDatabase clCDSDatabase;
        private CclCDSTable<CclRecProductOrder> clProductList;
        private CclCDSTable<CclRecProductData> clProductDataList;
        private CclCDSTable<CclRecOrder> clProductOrderList;
        public CclSvcDataStorage()
        {
            clCDSDatabase = new CclCDSDatabase(CDSStorageType.MariaDB);
            clProductList = new CclCDSTable<CclRecProductOrder>(clCDSDatabase.BaseDB.CreateDataAccess());
            clProductDataList = new CclCDSTable<CclRecProductData>(clCDSDatabase.BaseDB.CreateDataAccess());
            clProductOrderList = new CclCDSTable<CclRecOrder>(clCDSDatabase.BaseDB.CreateDataAccess());
        }

        //Lädt die Produkte aus der Datenbank und gibt sie zurück
        public CclCDSTable<CclRecProductOrder> getProductsFromDB()
        {
            // Daten laden
            clProductList.LoadData();
            return clProductList;
        }

        // Lädt die Produktdaten aus der Datenbank und gibt sie zurück
        public CclCDSTable<CclRecProductData> getProducstDataFromDB()
        {
            clProductDataList.LoadData();
            return clProductDataList;
        }

        // Lädt die Bestellungen aus der Datenbank und gibt sie zurück
        public CclCDSTable<CclRecOrder> getOrderFromDB()
        { 
            clProductOrderList.LoadData();
            return clProductOrderList;
        }

        // Speichert die Produkte in der Datenbank
        public void putPruductToDB(List<CclRecProductOrder> _liRecProducts)
        {
            try
            {
                clProductList.Clear();
                clProductList.AddRange(_liRecProducts);
                clProductList.SaveData();
            }

            catch (Exception excError)
            {
                MessageBox.Show(excError.Message);
            }
        }

        // Speichert die Bestellungen in der Datenbank
        public void putOrderToDB(List<CclRecOrder> _liRecOrder)
        {
            try
            {
                clProductOrderList.Clear();
                clProductOrderList.AddRange(_liRecOrder);
                clProductOrderList.SaveData();
            }

            catch (Exception excError)
            {
                MessageBox.Show(excError.Message);
            }
        }






    }
}

