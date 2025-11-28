using Büromaterialbestellungen.Classes.Records;
using Büromaterialbestellungen.Classes.Services;
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
        //Overview Bestellt, Vorbestellt, Erhalten

        public CclSvcMain svcMain = new CclSvcMain();

        
        public FormDashboard()
        {
            InitializeComponent();
            InitListView(ucOverviewBestellt.ListViewUC);
            InitListView(ucOverviewVorbestellt.ListViewUC);
            InitListView(ucOverviewErhalten.ListViewUC);


           // ucOverviewBestellt.ListViewUC.View = View.Details;
           // ucOverviewBestellt.ListViewUC.FullRowSelect = true;
           // ucOverviewBestellt.ListViewUC.GridLines = true;

           // //ucOverviewBestellt.ListViewUC.Columns.Add("ProdID");
           // ucOverviewBestellt.ListViewUC.Columns.Add("Produktname");
           // ucOverviewBestellt.ListViewUC.Columns.Add("Menge");
           // ucOverviewBestellt.ListViewUC.Columns.Add("Benutzername");



           // ucOverviewVorbestellt.ListViewUC.View = View.Details;
           // ucOverviewVorbestellt.ListViewUC.FullRowSelect = true;
           // ucOverviewVorbestellt.ListViewUC.GridLines = true;

           ////ucOverviewVorbestellt.ListViewUC.Columns.Add("ProdID");
           // ucOverviewVorbestellt.ListViewUC.Columns.Add("Produktname");
           // ucOverviewVorbestellt.ListViewUC.Columns.Add("Menge");
           // ucOverviewVorbestellt.ListViewUC.Columns.Add("Benutzername");


           // ucOverviewErhalten.ListViewUC.View = View.Details;
           // ucOverviewErhalten.ListViewUC.FullRowSelect = true;
           // ucOverviewErhalten.ListViewUC.GridLines = true;

           // //ucOverviewErhalten.ListViewUC.Columns.Add("ProdID");
           // ucOverviewErhalten.ListViewUC.Columns.Add("Produktname");
           // ucOverviewErhalten.ListViewUC.Columns.Add("Menge");
           // ucOverviewErhalten.ListViewUC.Columns.Add("Benutzername");

            //Maximum window size 
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            showDataFromProductsList();
       


        }

        private void InitListView(ListView _clTarget)
        {
            _clTarget.View = View.Details;
            _clTarget.FullRowSelect = true;
            _clTarget.GridLines = true;

           
            _clTarget.Columns.Add("Produktname");
            _clTarget.Columns.Add("Menge");
            _clTarget.Columns.Add("Benutzername");
        }

        //Get Data from Database and show it in the ListView
        public void showDataFromProductsList()
        {
            var products = svcMain.Products;

            putDataInListView(products.ToList());
        }
        public void putDataInListView(List<CclRecProduct> products)
        {
            
            foreach (var item in products)
            {
                if (item.IsReceived)
                {
                    var lvi = new ListViewItem(item.ProductName);
                    lvi.SubItems.Add(item.Amount.ToString());
                    lvi.SubItems.Add(item.UserName);
                    lvi.Tag = item;
                    ucOverviewErhalten.ListViewUC.Items.Add(lvi);
                    continue;
                }
                else if (item.IsOrdered)
                {
                    var lvi = new ListViewItem(item.ProductName);
                    lvi.SubItems.Add(item.Amount.ToString());
                    lvi.SubItems.Add(item.UserName);
                    lvi.Tag = item;
                    ucOverviewBestellt.ListViewUC.Items.Add(lvi);
                    continue;
                }
                else if(item.IsPreOrdered)
                {
                    var lvi = new ListViewItem(item.ProductName);
                    lvi.SubItems.Add(item.Amount.ToString());
                    lvi.SubItems.Add(item.UserName);
                    lvi.Tag = item;
                    ucOverviewVorbestellt.ListViewUC.Items.Add(lvi);
                    continue;
                }
                //var lvi = new ListViewItem(item.ProductName);
                //lvi.SubItems.Add(item.Amount.ToString());
                //lvi.SubItems.Add(item.UserName);
                //lvi.Tag = item;
                //ucOverviewVorbestellt.ListViewUC.Items.Add(lvi);
            }
        }
    }

    
}
