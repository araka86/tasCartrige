using CartrigeAltstar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartrigeAltstar.Nomenclatura.History
{
    public partial class ListHistoryForms : Form
    {
        ContexAltstar db;
        public ListHistoryForms()
        {
            InitializeComponent();

           
            RefreshHistoryDatagrid(this, null);

        }


        private void RefreshHistoryDatagrid(object sender, FormClosingEventArgs e)
        {
            db = new ContexAltstar();
            db.CountCartiges.Load();

            dgHistory.DataSource = db.CountCartiges.Local.ToBindingList();
            

        
        }
    }
}
