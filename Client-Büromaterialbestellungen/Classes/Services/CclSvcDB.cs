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
    public class CclSvcDB
    {
        private CclCDSDatabase clCDSDatabase;
        private CclCDSTable<CclRecProduct> clProductList;
        public CclSvcDB()
        {
            clCDSDatabase = new CclCDSDatabase(CDSStorageType.MariaDB);
            clProductList = new CclCDSTable<CclRecProduct>(clCDSDatabase.BaseDB.CreateDataAccess());
        }
        public CclCDSTable<CclRecProduct> getDataFromDB()
        {
            // Daten laden
            clProductList.LoadData();
            return clProductList;
        }

        public void putDataToDB(List<CclRecProduct> _liRecProducts)
        {
            // Hier könnte Code stehen, um Daten in die Datenbank zu schreiben
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

