using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Registry_Form
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            OleDbConnection con = new OleDbConnection("Provider=Microsofr.Jet.OLEDB.4.0;Data Source=db_users.mdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            //Database Issue figured out! SSMS for the win.

        }

    }

}
