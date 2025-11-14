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
       
        private bool isBestelltHidden = false;
        private bool isVorbestelltHidden = false;
        private bool isErhaltenHidden = false;
        FormStart formStart = new FormStart();
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void buttonBestellt_Click(object sender, EventArgs e)
        {
            if (isBestelltHidden)
            {
                ucOverviewBestellt.Show();
                isBestelltHidden = false;
            }
            else 
            { 
                ucOverviewBestellt.Hide();
                isBestelltHidden = true;
            }
        }

        private void buttonVorbestellt_Click(object sender, EventArgs e)
        {
            if (isVorbestelltHidden)
            {
                ucOverviewVorbestellt.Show();
                isVorbestelltHidden = false;
            }
            else
            {
                ucOverviewVorbestellt.Hide();
                isVorbestelltHidden = true;
            }

        }

        private void buttonErhalten_Click(object sender, EventArgs e)
        {
            if (isErhaltenHidden)
            {
                ucOverviewErhalten.Show();
                isErhaltenHidden = false;
            }
            else
            {
                ucOverviewErhalten.Hide();
                isErhaltenHidden = true;
            }

        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            formStart.ShowDialog();

        }
    }
}
