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

            ucOverviewBestellt.ListViewUC.View = View.Details;
            ucOverviewBestellt.ListViewUC.FullRowSelect = true;
            ucOverviewBestellt.ListViewUC.GridLines = true;

            ucOverviewBestellt.ListViewUC.Columns.Add("Produktname");
            ucOverviewBestellt.ListViewUC.Columns.Add("Menge");
            ucOverviewBestellt.ListViewUC.Columns.Add("Benutzername");


            ucOverviewVorbestellt.ListViewUC.View = View.Details;
            ucOverviewVorbestellt.ListViewUC.FullRowSelect = true;
            ucOverviewVorbestellt.ListViewUC.GridLines = true;

            ucOverviewVorbestellt.ListViewUC.Columns.Add("Produktname");
            ucOverviewVorbestellt.ListViewUC.Columns.Add("Menge");
            ucOverviewVorbestellt.ListViewUC.Columns.Add("Benutzername");


            ucOverviewErhalten.ListViewUC.View = View.Details;
            ucOverviewErhalten.ListViewUC.FullRowSelect = true;
            ucOverviewErhalten.ListViewUC.GridLines = true;

            ucOverviewErhalten.ListViewUC.Columns.Add("Produktname");
            ucOverviewErhalten.ListViewUC.Columns.Add("Menge");
            ucOverviewErhalten.ListViewUC.Columns.Add("Benutzername");

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
                ucOverviewVorbestellt.ListViewUC.Items.Add(lvi);
               
            }



        }
    }
}
