using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace UserInput
{
    public partial class User_LoginUp : KryptonForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Gian Lim\Downloads\EventManagementABCDB.mdf"";Integrated Security=True;Connect Timeout=30");
        public User_LoginUp()
        {
            InitializeComponent();
        }
        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtGmail.Clear(); // Clear the initial text
            txtGmail.Click -= txtEmail_Click;
        }

        private int code = 1000; // Move the code variable to the class scope
        private void TimerLogin_Tick(object sender, EventArgs e)
        {
            code += 10;
            if (code == 9999)
            {
                code = 1000;
            }
        }
        /*
        void mailCodeSend{}
        void mailAcceptSend{}
        void mailRejectSend{}
         */
        private void btnSend_Click(object sender, EventArgs e)
        {
            TimerLogin.Stop();
            string to, from, pass, mail;
            to = txtGmail.Text;
            from = "wanifybusiness.gmail.com";
            mail = code.ToString();
            userReference.currentCode = mail;
            pass = "add your password";

            if (string.IsNullOrEmpty(to))
            {
                GmailLbl.Text = "Enter your email";
                return;
            }
            else if (!IsValidEmail(to))
            {
                GmailLbl.Text = "Wrong format of email!";
                return;
            }
            else
            {
                GmailLbl.Text = "";
            }

            MailMessage mssg = new MailMessage();
            mssg.To.Add(to);
            mssg.From = new MailAddress(from);
            mssg.Body = "Your code is: " + mail;
            mssg.Subject = "ABCCatering - Verification Code";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            
            try
            {
                TimerLogin.Start();
                smtp.Send(mssg);
                MessageBox.Show("Verification code sent successfully! Check your email.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConfirm.Enabled = true;
                txtConfirm.ReadOnly = false;
                txtConfirm.Enabled = true;

                userReference.emailStore = txtGmail.Text;

    
            }
            catch (Exception ex)
            {
                TimerLogin.Start();
                MessageBox.Show("An error occurred while sending the verification code: " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            if (txtConfirm.Text == userReference.currentCode)
            {
                btnConfirm.Enabled = false;
                txtConfirm.ReadOnly = true;
                txtConfirm.Enabled = false;

                PasswordUserBtn.Enabled = true;
                PasswordUserTxt.ReadOnly = false;
                PasswordUserTxt.Enabled = true;
                CodeLbl.Text = "";
            }

            else
            {

                CodeLbl.Text = "Wrong inputted code!";
            }
        }

     

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PasswordUserBtn_Click(object sender, EventArgs e)
        {

            PasswordUserBtn.Enabled = false;
            PasswordUserTxt.ReadOnly = true;
            PasswordUserTxt.Enabled = false;

            if (PasswordUserTxt.Text == "" )
                {
                    MessageBox.Show("Missing Information");
                }

                else
                {
                    try
                    {

                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO RegistrationTable(CustomerEmail, CustomerPassword) VALUES(@CEM, @CPD)", con);
                       
                        cmd.Parameters.AddWithValue("@CEM", txtGmail.Text);
                        cmd.Parameters.AddWithValue("@CPD", PasswordUserTxt.Text);
                      
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account Registered");
                    AdminForm obj = new AdminForm();
                    obj.Show();
                    this.Hide();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show(ex.Message);
                    }

                
                }
            }
        int counter = 1;
        private void showPassword_Click(object sender, EventArgs e)
        {
            
            if (counter == 1)
            {
                counter--;
                PasswordUserTxt.PasswordChar = '\0';
                showPassword.Image = Properties.Resources.eyeopensmall;
            }
            else
            {
                counter++;
                PasswordUserTxt.PasswordChar = '*';
                showPassword.Image = Properties.Resources.eyeclosesmall;
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            AdminForm Obj = new AdminForm();
            Obj.Show();
            this.Hide();
        }
    }
    }


