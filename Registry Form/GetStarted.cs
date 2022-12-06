using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registry_Form
{
    public partial class GetStarted : Form
    {
        public GetStarted()
        {
            InitializeComponent();
           
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsofr.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e) //This part checks for blank spaces
        {
            if (textUsername.Text == "" && textPassword.Text == "" && textConPassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //This part checks for matching passwords
            else if (textPassword.Text == textConPassword.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + textUsername.Text + "','" + textPassword.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //the following three lines set the field to empty at the beginning
                textUsername.Text = "";
                textPassword.Text = "";
                textConPassword.Text = "";

                MessageBox.Show("Your Account has been successfully created!", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            { 
                MessageBox.Show("The Passwords you've entered do not match, Please Re-enter your Password", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassword.Text = "";
                textConPassword.Text = "";
                textPassword.Focus();
            }
            
            
            
        }

        private void checkBoxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            // This part is for the "Show Password" bit on the login screen
            if (checkBoxShowPas.Checked)
            {
                textPassword.PasswordChar = '\0';
                textConPassword.PasswordChar = '\0';
            }
            else
            {
                textPassword.PasswordChar = '•';
                textConPassword.PasswordChar = '•';
            }
            
            
            
            
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //information for the "Clear" button
            textUsername.Text = "";
            textPassword.Text = "";
            textConPassword.Text = "";
            textUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //information for the "Back to Login" button 
            new GetStarted().Show();
            this.Hide();

        }
    }
}
