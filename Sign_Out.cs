using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Sign_Out : Form
    {
        public Sign_Out()
        {
            InitializeComponent();         
        }

        //this is the password set up by the owner.
        string setPassword = "1234 ";

        //clicking ok will check to make sure the password is correct.
        //if the password is correct it will close the application,
        //if the passsword is not correct it will inform user and return
        //the user back to the ordering screen
        private void btnOk_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;

            if (password == setPassword)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Password is Incorrect. Only a Manager can sign you out.");
                this.Close();
            }    
        }

        //clicking back closes the password manager and returns you to the 
        //ordering screen
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //when the form is loaded make sure that the characters in the password
        //textbox will show as "*". Also make sure the textbox has focus.
        private void Sign_Out_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtPassword.Focus();
           
        }
    }
}
