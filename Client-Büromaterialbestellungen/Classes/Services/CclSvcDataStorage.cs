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
        CclCDSTable<CclRecProductData> clProductDataList;
        public CclSvcDataStorage()
        {
            clCDSDatabase = new CclCDSDatabase(CDSStorageType.MariaDB);
            clProductList = new CclCDSTable<CclRecProductOrder>(clCDSDatabase.BaseDB.CreateDataAccess());
            clProductDataList = new CclCDSTable<CclRecProductData>(clCDSDatabase.BaseDB.CreateDataAccess());
        }
        public CclCDSTable<CclRecProductOrder> getProductsFromDB()
        {
            // Daten laden
            clProductList.LoadData();
            return clProductList;
        }

        public CclCDSTable<CclRecProductData> getProducstDataFromDB()
        {
            clProductDataList.LoadData();
            return clProductDataList;
        }

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

      


    }
}

