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
using System.Windows.Forms;



namespace Büromaterialbestellungen.GUI
{
    public partial class UCOverview : UserControl
    {

        
        public ListView ListViewUC
        {
            get { return listViewUC; }
        }

       

        public UCOverview()
        {
            InitializeComponent();
            
        }

 

        private void mouseDoubleClick(object sender, MouseEventArgs e)
        {
            var result = MessageBox.Show("Möchten Sie diesen Eintrag wirklich löschen?", "Eintrag löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            CclCDSDatabase db = new CclCDSDatabase(CDSStorageType.MariaDB);
            CclCDSTable<CclRecProdut> products =
               new CclCDSTable<CclRecProdut>(db.BaseDB.CreateDataAccess());
            products.LoadData();

            if (listViewUC.SelectedItems.Count > 0)
            {

                var item = listViewUC.SelectedItems[0];

                string listViewID = item.SubItems[0].Text;



                CclRecProdut tagProd = item.Tag as CclRecProdut;
                if (tagProd == null)
                    return;

                var prodInTable = products.FirstOrDefault(p => p.ID == tagProd.ID);

                if (prodInTable != null && prodInTable.IsPreOrdered == true)
                {
                    prodInTable.Deleted = true;
                    products.SaveData();
                    listViewUC.Items.Remove(item);
                }
        
            }
        }
    }
}



