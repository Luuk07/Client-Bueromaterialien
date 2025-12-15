using Büromaterialbestellungen.Classes.Container;
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

        public CclSvcMain SvcMain;
        

        
        public FormDashboard(CclSvcMain svcMain) 
        {
            InitializeComponent();
            SvcMain = new CclSvcMain();
            ucOverviewVorbestellt.InitUC(svcMain);
            ucOverviewBestellt.InitUC(svcMain);
            ucOverviewErhalten.InitUC(svcMain);
            InitListView(ucOverviewBestellt.ListViewUC);
            InitListView(ucOverviewVorbestellt.ListViewUC);
            InitListView(ucOverviewErhalten.ListViewUC);


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
            var products = SvcMain.Products.Where(prod => !prod.Deleted);

            putDataInListView(products.ToList());
        }
        public void putDataInListView(List<CclRecProductOrder> products)
        {
            
            foreach (var item in products)
            {
                if (item.IsReceived)
                {
                    var lvi = new ListViewItem(item.ProductName);
                    lvi.SubItems.Add(item.Amount.ToString());
                    //lvi.SubItems.Add(item.UserName);
                    lvi.SubItems.Add(item.UserName);
                    lvi.Tag = item;
                    ucOverviewErhalten.ListViewUC.Items.Add(lvi);
                    continue;
                }
                else if (item.IsOrdered)
                {
                    var lvi = new ListViewItem(item.ProductName);
                    lvi.SubItems.Add(item.Amount.ToString());
                    //lvi.SubItems.Add(item.UserName);
                    lvi.SubItems.Add(item.UserName);
                    lvi.Tag = item;
                    ucOverviewBestellt.ListViewUC.Items.Add(lvi);
                    continue;
                }
                else if(item.IsPreOrdered)
                {
                    var lvi = new ListViewItem(item.ProductName);
                    lvi.SubItems.Add(item.Amount.ToString());
                    //lvi.SubItems.Add(item.UserName);
                    lvi.SubItems.Add(item.UserName);
                    lvi.Tag = item;
                    ucOverviewVorbestellt.ListViewUC.Items.Add(lvi);
                    continue;
                }
               
            }
        }

    }

    
}
