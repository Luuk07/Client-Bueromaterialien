using Büromaterialbestellungen.Classes.Container;
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
using Büromaterialbestellungen.Classes.Services;
using System.Windows.Forms;



namespace Büromaterialbestellungen.GUI
{
    public partial class UCOverview : UserControl
    {
        public CclSvcMain SvcMain;

        public ListView ListViewUC
        {
            get { return listViewUC; }
        }

        public UCOverview()
        {
            InitializeComponent();
        }

        public void InitUC(CclSvcMain _ClSvcMain)
        {
            SvcMain = _ClSvcMain;
        }

        private void mouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (listViewUC.SelectedItems.Count > 0)
            {
                var products = SvcMain.Products;
                var item = listViewUC.SelectedItems[0];

                string listViewID = item.SubItems[0].Text;

                CclRecProduct tagProd = item.Tag as CclRecProduct;
                if (tagProd == null)
                    return;
                var prodInTable = products.FirstOrDefault(p => p.ID == tagProd.ID);
                if (prodInTable != null && prodInTable.IsPreOrdered == true)
                { 
                    var result = MessageBox.Show("Möchten Sie diesen Eintrag wirklich löschen?", "Eintrag löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                    SvcMain.OnDeleted(prodInTable);
                    //products.Remove(prodInTable);
                    //products.SaveData();
                    listViewUC.Items.Remove(item);
                }
                if (prodInTable != null && prodInTable.IsOrdered == true)
                {
                    var result = MessageBox.Show("Haben Sie das Produkt erhalten?", "Eintrag zur Erhaltenliste", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                    SvcMain.OnReceived(prodInTable);
                    listViewUC.Items.Remove(item);
                    listViewUC.Refresh();
                }

            }
        }
    }
}



