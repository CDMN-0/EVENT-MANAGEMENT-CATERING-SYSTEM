using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DocumentFormat.OpenXml.Bibliography;

namespace UserInput
{

    public partial class AdminForm : KryptonForm
    {
        public AdminForm()
        {
            InitializeComponent();
            this.ControlBox = true; //Unable to delete the formMax 
            this.MaximizeBox = false;
            this.BackgroundImage = null;
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Gian Lim\Downloads\EventManagementABCDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void LoginBtn_Click(object sender, EventArgs e)
        {


            if (UsernameLbl.Text != null)
            {
                UsernameLbl.Text = "";
            }
            if (PasswordLbl.Text != null)
            {
                PasswordLbl.Text = "";
            }

            if (string.IsNullOrEmpty(UsernameTxt.Text) || string.IsNullOrEmpty(PasswordTxt.Text))
            {
                if (string.IsNullOrEmpty(UsernameTxt.Text))
                {
                    UsernameLbl.Text = "Enter your registered email address";
                }
                if (string.IsNullOrEmpty(PasswordTxt.Text))
                {
                    PasswordLbl.Text = "Enter your password";
                }
            }
            else if (UsernameTxt.Text == "Admin" || PasswordTxt.Text == "Password")
            {
                if(UsernameTxt.Text != "Admin")
                {
                    UsernameLbl.Text = "Enter a registered email address.";
                }
                else if (PasswordTxt.Text != "Password")
                {
                    PasswordLbl.Text = "Incorrect Password.";
                }
                else if (PasswordTxt.Text != "Password" && UsernameTxt.Text != "Admin")
                {
                    PasswordLbl.Text = "Incorrect Password.";
                    UsernameLbl.Text = "Enter a registered email address.";
                }
                else
                {
                    AdminSetUp main = new AdminSetUp();
                    main.Show();
                    this.Hide();
                }
            }
            else
            {
                con.Open();
                string query = "SELECT CustomerEmail, CustomerPassword FROM RegistrationTable";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                bool isValid = false; 

                while (reader.Read())
                {
                    string validateEmail = reader["CustomerEmail"].ToString(); 
                    string validatePassword = reader["CustomerPassword"].ToString();
                    if (validateEmail == UsernameTxt.Text && validatePassword == PasswordTxt.Text)
                    {
                        isValid = true;
                        break; 
                    }
                }
                con.Close();

                if (isValid)
                {
                    userReference.StoreCustomerEmail = UsernameTxt.Text;
                    userReference.StoreCustomerPassword = PasswordTxt.Text;
       

                    UserSetUp obj = new UserSetUp();
                    obj.Show();
                    this.Hide();
                }
                else
                {  
                    UsernameLbl.Text = "Wrong email address or email address is not registered.";
                }
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            User_LoginUp obj = new User_LoginUp();
            obj.Show();
            this.Hide();
        }
        int counter = 1;
        private void showPassword_Click(object sender, EventArgs e)
        {
            if (counter == 1)
            {
                counter--;
                PasswordTxt.PasswordChar = '\0';
                showPassword.Image = Properties.Resources.eyeopensmall;
            }
            else
            {
                counter++;
                PasswordTxt.PasswordChar = '*';
                showPassword.Image = Properties.Resources.eyeclosesmall;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}