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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsofr.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            //The "LOGIN" button
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + textUsername.Text + "' and password = '" + textPassword.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            //Now to check to make sure the username and password match the info in the database
            if (dr.Read() == true)
            { //if correct, open the page!!!!!!!
                new Dashboard().Show();
                this.Hide();

            }
            else //if incorrect--
            {
                MessageBox.Show("Invalid Udername or Password, You should try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //next part resets the text boxes
                textUsername.Text = "";
                textPassword.Text = "";
                textUsername.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //information for the "CLEAR" Button
            textUsername.Text = "";
            textPassword.Text = "";
            textUsername.Focus();
        }

        private void checkBoxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            //the "Show Password" Button
            if (checkBoxShowPas.Checked)
            {
                textPassword.PasswordChar = '\0';

            }
            else
            {
                textPassword.PasswordChar = '•';

            }
        }



        private void label6_Click(object sender, EventArgs e)
        {
            //The "Create Account" button
            new GetStarted().Show();
            this.Hide();
        }
    }
}
