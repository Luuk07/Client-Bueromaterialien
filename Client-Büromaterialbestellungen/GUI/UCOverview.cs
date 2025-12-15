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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        // Löscht eintrag bei Doppelklick
        private void mouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (listViewUC.SelectedItems.Count > 0)
            {
                var products = SvcMain.Products;
                var item = listViewUC.SelectedItems[0];

                string listViewID = item.SubItems[0].Text;

                CclRecProductOrder tagProd = item.Tag as CclRecProductOrder;
                if (tagProd == null)
                    return;
                var prodInTable = products.FirstOrDefault(p => p.OrderID == tagProd.OrderID);
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

        // Zeigt bei rechtsklick die komplette Bestellung an
        private void listViewUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (listViewUC.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listViewUC.SelectedItems[0];
                    CclRecProductOrder tagProd = selectedItem.Tag as CclRecProductOrder;
                    var sb = new System.Text.StringBuilder();
                    if (tagProd != null)
                    {
                        var order = SvcMain.Order.FirstOrDefault(o => o.ID == tagProd.OrderID);
                        foreach(var ord in SvcMain.Products)
                        {
                            
                            if(ord.OrderID == tagProd.OrderID)
                            {
                              
                                sb.AppendLine($"Produkt: {ord.ProductName}, Menge: {ord.Amount}");
                            }
                        }
                        MessageBox.Show(sb.ToString());
                    }
                }

            }
        }
    }
}



