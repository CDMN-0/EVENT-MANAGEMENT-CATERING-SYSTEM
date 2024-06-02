using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInput
{
    public partial class RegisteredAccountsForm : Form
    {
        public RegisteredAccountsForm()
        {
            InitializeComponent();
            viewData3();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Gian Lim\Downloads\EventManagementABCDB.mdf"";Integrated Security=True;Connect Timeout=30");

        private void viewData3()
        {
            string Query = "SELECT * FROM RegistrationTable";
            SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);

            SetDataGridViewDataSourcess(DS.Tables[0]);
            DataGridViewRegistration.DataSource = DS.Tables[0];

       /*     DataGridViewRegistration.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;*/
            DataGridViewRegistration.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewRegistration.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 8, FontStyle.Regular);
            DataGridViewRegistration.EnableHeadersVisualStyles = false;
            DataGridViewRegistration.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            DataGridViewRegistration.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 10, FontStyle.Regular);

            DataGridViewRegistration.RowTemplate.Height = 30;
            DataGridViewRegistration.RowHeadersVisible = false;
        }


        public void SetDataGridViewDataSourcess(DataTable dataSource)
        {
            DataGridViewRegistration.DataSource = dataSource;
            DataGridViewRegistration.Refresh(); // Refresh the PackageDataGridView
        }


        private void DataGridViewRegistration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataGridViewRegistration.Rows.Count)
            {
                DataGridViewRegistration.Rows[e.RowIndex].Selected = true;
            DataGridViewRow selectedRow = DataGridViewRegistration.Rows[e.RowIndex];

            EmailAccountTxt.Text = selectedRow.Cells["CustomerEmail"].Value.ToString();
            PasswordAccountTxt.Text = selectedRow.Cells["CustomerPassword"].Value.ToString();
            }
        }

        private void DeleteAccountBtn_Click(object sender, EventArgs e)
        {
           
                if (DataGridViewRegistration.SelectedRows.Count > 0)
                {
                    int rowIndex = DataGridViewRegistration.SelectedRows[0].Index;
                    DataGridViewRow selectedRow = DataGridViewRegistration.Rows[rowIndex];

                    EmailAccountTxt.Text = selectedRow.Cells["CustomerEmail"].Value.ToString();
                 PasswordAccountTxt.Text = selectedRow.Cells["CustomerPassword"].Value.ToString();

                    try
                    {

                    con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM RegistrationTable WHERE CustomerEmail = @CEM AND CustomerPassword = @CPD", con);
                        cmd.Parameters.AddWithValue("@CEM", EmailAccountTxt.Text);
                        cmd.Parameters.AddWithValue("@CPD", PasswordAccountTxt.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        viewData3();

               
                        MessageBox.Show("Account deleted successfully.");

                    EmailAccountTxt.Text = "";
                    PasswordAccountTxt.Text = "";

                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Error: " + ex.Message);
                    }
            }

        }


        private void AddAccountBtn_Click(object sender, EventArgs e)
        {
            if (PasswordAccountTxt.Text == "" || EmailAccountTxt.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (!IsValidEmail(EmailAccountTxt.Text))
            {
                MessageBox.Show("Invalid Email Address.");
                EmailAccountTxt.Text = "";
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO RegistrationTable(CustomerEmail, CustomerPassword) VALUES(@CEM, @CPD)", con);

                    cmd.Parameters.AddWithValue("@CEM", EmailAccountTxt.Text);
                    cmd.Parameters.AddWithValue("@CPD", PasswordAccountTxt.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Registered");
                    con.Close();
                    viewData3();
                }

                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
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
        private void EditAccountBtn_Click(object sender, EventArgs e)
        {
            if (PasswordAccountTxt.Text == "" || EmailAccountTxt.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (!IsValidEmail(EmailAccountTxt.Text))
            {
                MessageBox.Show("Invalid Email Address.");
                EmailAccountTxt.Text = "";
            }
            else
            {
                    try
                    {
                        con.Open();
                    /*string query = "UPDATE ABCCustomerTable SET CustName=@CN, CustEmail=@CE ,CustPhone=@CP, EVName=@EN, EVDate=@ED, EVAddress=@EA, EVAttendees=@EVA, Package=@PA, TotalPrice=@TP, Instruction= @IN , StartTime=@ST, EndTime=@ET, Status=@STA WHERE CustomerID=@key";*/

                    string query = "UPDATE RegistrationTable SET CustomerEmail=@CEM, CustomerPassword=@CPD";
                    SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@CEM", EmailAccountTxt.Text);
                        cmd.Parameters.AddWithValue("@CPD", PasswordAccountTxt.Text);
     
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Data Updated Successfully");
                        viewData3();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
            }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard_Admin Obj = new Dashboard_Admin();
            Obj.Show();
            this.Hide();
        }

        private void reservationBtn_Click(object sender, EventArgs e)
        {
            AdminSetUp obj = new AdminSetUp();
            obj.Show();
            this.Hide();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            AdminForm obj = new AdminForm();
            obj.Show();
            this.Hide();
        }

        private void RegisteredAccountsForm_Load(object sender, EventArgs e)
        {
            DataGridViewRegistration.SelectionMode = DataGridViewSelectionMode.FullRowSelect;      // Set the selection mode to FullRowSelect

            DataGridViewRegistration.CellClick += DataGridViewRegistration_CellContentClick; //For the CellClick
        }
    }
}
