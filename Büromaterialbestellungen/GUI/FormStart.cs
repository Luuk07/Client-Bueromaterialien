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
        public FormStart()
        {
            InitializeComponent();
           
        }

       

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            var dashboard = new FormDashboard();
            //Wenn Owner geschlossen wird, wird auch alles darunter geschlossen
            dashboard.Owner = this;

            //Wenn dashboard geschlossen wird, wird das Startmenü wieder gezeigt
            dashboard.FormClosing += (s, args) =>
            {
                this.Show();
            };

            this.Hide();
            dashboard.Show();

        }

        private void buttonProduktbestellung_Click(object sender, EventArgs e)
        {
            var produktbestellung = new FormProduktbestellung();

          
            produktbestellung.Owner = this;

            produktbestellung.FormClosing += (s, args) =>
            {
                this.Show();
            };

            this.Hide(); 
            produktbestellung.Show(); 
        }



    }
}
