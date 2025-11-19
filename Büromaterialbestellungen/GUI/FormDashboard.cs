using Büromaterialbestellungen.Classes.Records;
using CDS.Classes;
using CDS.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Büromaterialbestellungen.GUI
{
    public partial class FormDashboard : Form
    {
      

        public FormDashboard()
        {
            InitializeComponent();

            ucOverviewBestellt.BestelltListView.View = View.Details;
            ucOverviewBestellt.BestelltListView.FullRowSelect = true;
            ucOverviewBestellt.BestelltListView.GridLines = true;

            ucOverviewBestellt.BestelltListView.Columns.Add("Produktname");
            ucOverviewBestellt.BestelltListView.Columns.Add("Menge");
            ucOverviewBestellt.BestelltListView.Columns.Add("Benutzername");

            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            onEvent();


        }
   
        public void onEvent()
        {
            CclCDSDatabase db = new CclCDSDatabase(CDSStorageType.MariaDB);
            CclCDSTable<CclRecProdut> products =
                new CclCDSTable<CclRecProdut>(db.BaseDB.CreateDataAccess());

            // Daten laden
            products.LoadData();

            foreach (var item in products)
            {
                var lvi = new ListViewItem(item.ProductName);            
                lvi.SubItems.Add(item.Amount.ToString());         
                lvi.SubItems.Add(item.UserName);
                ucOverviewBestellt.BestelltListView.Items.Add(lvi);
               
            }



        }
    }
}
