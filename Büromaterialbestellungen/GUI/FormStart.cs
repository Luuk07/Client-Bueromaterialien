using Büromaterialbestellungen.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Büromaterialbestellungen
{
    public partial class FormStart : Form
    {
        FormDashboard dashboard;
        FormProduktbestellung produktbestellung;
        public FormStart()
        {
            InitializeComponent();
        }

       

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard = new FormDashboard();
            dashboard.ShowDialog();
            

        }

        private void buttonProduktbestellung_Click(object sender, EventArgs e)
        {
            this.Hide();
            produktbestellung = new FormProduktbestellung();
            produktbestellung.ShowDialog();
        }
    }
}
