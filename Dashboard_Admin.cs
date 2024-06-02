using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInput
{
    public partial class Dashboard_Admin : Form
    {
        public Dashboard_Admin()
        {
            InitializeComponent();
            CountPending();
            CountApproved();
            CountCancelled();
            CountPackageA();
            CountPackageB();
            CountPackageC();
            CountPackageD();
            CountPackageE();
            CountPackageF();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Gian Lim\Downloads\EventManagementABCDB.mdf"";Integrated Security=True;Connect Timeout=30");
      
        
        private void reservationBtn_Click(object sender, EventArgs e)
        {
            AdminSetUp Obj = new AdminSetUp();
            Obj.Show();
            this.Hide();
        }

        private void CountPending()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) AS Status FROM ABCCustomerTable WHERE Status = 'Pending'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CountPendingLbl.Text = dt.Rows[0][0].ToString();
            con.Close();

        }

        private void CountApproved()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) AS Status FROM ABCCustomerTable WHERE Status = 'Approved'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CountApprovedLbl.Text = dt.Rows[0][0].ToString();
            con.Close();

        }

        private void CountCancelled()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) AS Status FROM ABCCustomerTable WHERE Status = 'Cancelled'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CountCancelledLbl.Text = dt.Rows[0][0].ToString();
            con.Close();

        }
        private void CountPackageA()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(EVAttendees) AS TotalAttendees FROM ABCCustomerTable WHERE Package = 'Package A'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            PackageALbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }


        private void CountPackageB()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(EVAttendees) AS TotalAttendees FROM ABCCustomerTable WHERE Package = 'Package B'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            PackageBLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountPackageC()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(EVAttendees) AS TotalAttendees FROM ABCCustomerTable WHERE Package = 'Package C'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            PackageCLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountPackageD()
        {
            con.Open();
           
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(EVAttendees) AS TotalAttendees FROM ABCCustomerTable WHERE Package = 'Package D'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            PackageDLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountPackageE()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(EVAttendees) AS TotalAttendees FROM ABCCustomerTable WHERE Package = 'Package E'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            PackageELbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountPackageF()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(EVAttendees) AS TotalAttendees FROM ABCCustomerTable WHERE Package = 'Package F'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            PackageFLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            AdminForm obj = new AdminForm();
            obj.Show();
            this.Hide();
        }

        private string text;
        private int len = 0;
        private void TimerDashboard_Tick(object sender, EventArgs e)
        {
            if (len < text.Length)
            {
                DashboardLbl.Text = DashboardLbl.Text + text.ElementAt(len);
                len++;
            }
            else
                TimerDashboard.Stop();
        }

        private void Dashboard_Admin_Load(object sender, EventArgs e)
        {
            text = DashboardLbl.Text;
            DashboardLbl.Text = "";
            TimerDashboard.Start();
        }

        private void RegisteredAccountsBtn_Click(object sender, EventArgs e)
        {
            RegisteredAccountsForm obj = new RegisteredAccountsForm();
            obj.Show();
            this.Hide();
        }
    }
}
