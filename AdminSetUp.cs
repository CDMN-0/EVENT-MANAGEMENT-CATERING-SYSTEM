using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using ComponentFactory.Krypton.Toolkit;
using DocumentFormat.OpenXml.Wordprocessing;

namespace UserInput
{
    public partial class AdminSetUp : Form
    {
        SqlConnection con;
        private int Key = 0;

        public AdminSetUp()
        {
            InitializeComponent();
          

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Gian Lim\Downloads\EventManagementABCDB.mdf"";Integrated Security=True;Connect Timeout=30");
            viewData();
            viewData2();
            LoadDataIntoComboBox();
        }
        // Add a property to get the data source of the DataGridView



        private void LoadDataIntoComboBox()
        {
            string query = "SELECT Package FROM PackageTable"; // Replace "Packages" with your actual table name

            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string packageNames = reader["Package"].ToString(); // Replace "PackageName" with the actual column name containing the data
                PackageCMB.Items.Add(packageNames); // Add the item to the ComboBox's items
            }
            reader.Close();
            con.Close();
        }


        public DataTable DataGridViewDataSource
        {
            get { return (DataTable)DataGridViewAdmin.DataSource; }
        }

        private void viewData()
        {
            con.Open();
            string Query = "SELECT * FROM ABCCustomerTable";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);

            DataGridViewAdmin.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



            DataGridViewAdmin.DataSource = ds.Tables[0];
            DataGridViewAdmin.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 10, FontStyle.Regular);
            DataGridViewAdmin.EnableHeadersVisualStyles = false;
            DataGridViewAdmin.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            DataGridViewAdmin.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 14, FontStyle.Regular);
            DataGridViewAdmin.RowTemplate.Height = 30;
            DataGridViewAdmin.RowHeadersVisible = false;



            // Set the data source for the DataGridView on the AdminSetUp form
            SetDataGridViewDataSource(ds.Tables[0]);
            con.Close();
        }

        // Add a method to set the data source of the DataGridView
        public void SetDataGridViewDataSource(DataTable dataSource)
        {
            DataGridViewAdmin.DataSource = dataSource;
            DataGridViewAdmin.Refresh();
        }

        private void viewData2()
        {
            string Query = "SELECT * FROM PackageTable";
            SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);

            SetDataGridViewDataSources(DS.Tables[0]);
            PackageDataGridView.DataSource = DS.Tables[0];


            PackageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PackageDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      
            PackageDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 8, FontStyle.Regular);
            PackageDataGridView.EnableHeadersVisualStyles = false;
            PackageDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            PackageDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 10, FontStyle.Regular);

            PackageDataGridView.RowTemplate.Height = 30;
            PackageDataGridView.RowHeadersVisible = false;
        }

        public void SetDataGridViewDataSources(DataTable dataSource)
        {
            PackageDataGridView.DataSource = dataSource;
            PackageDataGridView.Refresh(); // Refresh the PackageDataGridView
        }


        Regex alphaOnly = new Regex("^[A-Za-z.\\s]+$");
        Regex alphaNumericOnly = new Regex("^[A-Za-z0-9.\\s]+$");
        Regex numericOnly = new Regex("^[0-9]+$");



        private void StatusCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            KryptonComboBox cmb = (KryptonComboBox)sender;

            int selected = cmb.SelectedIndex;
            if (selected == 0)
            {
                userReference.messageUser = "Your application for our catering service has been accepted.";
            }
            else if (selected == 2)
            {
                userReference.messageUser = "Your application for our catering service has been rejected because of the following reason.\nLocation cannot be found on Google maps.\nYou may contact us to try and fix this problem.\nThank you for considering our catering service.";
            }
            else if (selected == 3)
            {
                userReference.messageUser = "Your application for our catering service has been rejected because of the following reason.\nWe cannot cater at the date that you have requested because there is not enough time for us to prepare our services.\nYou may contact us to try and fix this problem.\nThank you for considering our catering service.";
            }
            else if (selected == 4)
            {
                userReference.messageUser = "Your application for our catering service has been rejected because of the following reason.\nWe cannot cater at the date that you have requested because we currently have too many reservations for this month.\nYou may contact us to try and fix this problem.\nThank you for considering our catering service.";
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var time1 = TimeInCmboxAdmin.SelectedIndex;
            var time2 = TimeOutCmboxAdmin.SelectedIndex;

            if (String.IsNullOrEmpty(FnameTxtAdmin.Text) || String.IsNullOrEmpty(ContactTxtAdmin.Text) || String.IsNullOrEmpty(LocateTxtAdmin.Text) || String.IsNullOrEmpty(EventTypeTxtAdmin.Text) || String.IsNullOrEmpty(AttendeesTxtAdmin.Text) || String.IsNullOrEmpty(SpecialTxtAdmin.Text) || String.IsNullOrEmpty(PricingTxtAdmin.Text) || String.IsNullOrEmpty(EmailTxtAdmin.Text) || String.IsNullOrEmpty(DateTxtAdmin.Text))
            {
                MessageBox.Show("Missing Information");
            }
            else if (!alphaOnly.IsMatch(FnameTxtAdmin.Text) || (!numericOnly.IsMatch(ContactTxtAdmin.Text) || (!alphaNumericOnly.IsMatch(LocateTxtAdmin.Text) || (!alphaNumericOnly.IsMatch(EventTypeTxtAdmin.Text)))))
            {
                String fNameWarning = "";
                String contactWarning = "";
                String locationWarning = "";
                String eventWarning = "";

                if (!alphaOnly.IsMatch(FnameTxtAdmin.Text))
                {
                    fNameWarning = "First name will only accept alphabetical characters.";
                }
                if (!numericOnly.IsMatch(ContactTxtAdmin.Text))
                {
                    contactWarning = "Contact number will only accept numbers. Do not use spaces, symbols, or alphabetical characters.";
                }
                if (!alphaNumericOnly.IsMatch(LocateTxtAdmin.Text))
                {
                    locationWarning = "Location will not accept any symbols, only use alphanumerical characters.";
                }
                if (!alphaNumericOnly.IsMatch(EventTypeTxtAdmin.Text))
                {
                    eventWarning = "Event Type will not accept any symbols, only use alphanumerical characters.";
                }
                MessageBox.Show(fNameWarning + "\n" + contactWarning + "\n" + locationWarning + "\n" + eventWarning);
            }
            else if (time1 > time2)
            {
                MessageBox.Show("Invalid time, please select another time frame.");
            }
            else
            {
                try
                {
                    //send email
                    string to, from, pass;
                    to = EmailTxtAdmin.Text;
                    from = "abccateringmsg@gmail.com";
                    pass = "xzomuupvdfxdgane";

                    MailMessage mssg = new MailMessage();
                    mssg.To.Add(to);
                    mssg.From = new MailAddress(from);
                    mssg.Body = userReference.messageUser;
                    mssg.Subject = "ABCCatering - Application Status";

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.Send(mssg);

                    //database
                    con.Open();
                    string query = "UPDATE ABCCustomerTable SET CustName=@CN, CustEmail=@CE ,CustPhone=@CP, EVName=@EN, EVDate=@ED, EVAddress=@EA, EVAttendees=@EVA, Package=@PA, TotalPrice=@TP, Instruction= @IN , StartTime=@ST, EndTime=@ET, Status=@STA WHERE CustomerID=@key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@CN", FnameTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@CE", EmailTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@CP", ContactTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@EN", EventTypeTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@ED", DateTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@EA", LocateTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@EVA", AttendeesTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@PA", PackageCmboxAdmin.SelectedItem);
                    cmd.Parameters.AddWithValue("@TP", PricingTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@IN", SpecialTxtAdmin.Text);
                    cmd.Parameters.AddWithValue("@ST", TimeInCmboxAdmin.Text);
                    cmd.Parameters.AddWithValue("@ET", TimeOutCmboxAdmin.Text);
                    cmd.Parameters.AddWithValue("@STA", StatusCmb.SelectedItem);
                    cmd.Parameters.AddWithValue("@key", Key);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Updated Successfully");
                    viewData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
        }

        private void AddBtn_Click_1(object sender, EventArgs e)
        {
            string newItem = PackageCMB.Text; // Retrieve the value from the TextBox


            if (!IsValidPackage(newItem))
            {
                MessageBox.Show("Invalid Package");
                return;
            }


            if (PackageCMB.Text == "")
            {
                MessageBox.Show("Missing Information");

            }


            else
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO PackageTable(Package) VALUES(@PK)", con);
                    cmd.Parameters.AddWithValue("@PK", newItem);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Package Added");
                    con.Close();

                    PackageCMB.Items.Add(newItem); // Add the new item to the ComboBox
                    PackageCMB.Text = ""; // Clear the TextBox
                    viewData2();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DataGridViewAdmin_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataGridViewAdmin.Rows.Count)
            {
                DataGridViewAdmin.Rows[e.RowIndex].Selected = true;
                DataGridViewRow selectedRow = DataGridViewAdmin.Rows[e.RowIndex];

                FnameTxtAdmin.Text = selectedRow.Cells["CustName"].Value.ToString();
                EmailTxtAdmin.Text = selectedRow.Cells["CustEmail"].Value.ToString();
                ContactTxtAdmin.Text = selectedRow.Cells["CustPhone"].Value.ToString();
                EventTypeTxtAdmin.Text = selectedRow.Cells["EVName"].Value.ToString();
                DateTxtAdmin.Text = selectedRow.Cells["EVDate"].Value.ToString();
                LocateTxtAdmin.Text = selectedRow.Cells["EVAddress"].Value.ToString();
                AttendeesTxtAdmin.Text = selectedRow.Cells["EVAttendees"].Value.ToString();
                PackageCmboxAdmin.SelectedItem = selectedRow.Cells["Package"].Value.ToString();
                PricingTxtAdmin.Text = selectedRow.Cells["TotalPrice"].Value.ToString();
                SpecialTxtAdmin.Text = selectedRow.Cells["Instruction"].Value.ToString();
                TimeInCmboxAdmin.Text = selectedRow.Cells["StartTime"].Value.ToString();
                TimeOutCmboxAdmin.Text = selectedRow.Cells["EndTime"].Value.ToString(); //I make this text to retrieve
                StatusCmb.Text = selectedRow.Cells["Status"].Value.ToString();



                if (selectedRow.Cells[0].Value != null)
                {
                    Key = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                }
                else
                {
                    Key = 0;
                }
            }
        }

        private void AdminSetUp_Load(object sender, EventArgs e)
        {
            DataGridViewAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;      // Set the selection mode to FullRowSelect

            DataGridViewAdmin.CellClick += DataGridViewAdmin_CellContentClick_1; //For the CellClick

            string[] statusitems = { "Approved", "Pending", "Cancelled", "Cancelled - 1", "Cancelled - 2", "Cancelled - 3" };
            foreach(string status in statusitems)
            {
                StatusCmb.Items.Add(status);
            }

      

            string[] packagetypes = { "PACKAGE A", "PACKAGE B", "PACKAGE C", "PACKAGE D", "PACKAGE E", "PACKAGE F" };

            foreach (string packagetype in packagetypes)
            {
                PackageCmboxAdmin.Items.Add(packagetype);
            }

            PricingTxtAdmin.ReadOnly = true;
            PricingTxtAdmin.Enabled = false;


            for (int hour = 0; hour <= 24; hour++)
            {
                for (int minute = 0; minute < 60; minute += 30)
                {
                    if (hour == 24 && minute >= 30)
                        continue;

                    string timeString = $"{hour:00}:{minute:00}";

                    TimeInCmboxAdmin.Items.Add(timeString);
                    TimeOutCmboxAdmin.Items.Add(timeString);
                }
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Event");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from ABCCustomerTable Where CustomerID=@EKey", con);
                    cmd.Parameters.AddWithValue("@EKey", Key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event Deleted");
                    con.Close();
                    viewData();
                }

                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

    

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = "ABCCustomerTable";
                string filePath = "C:\\Users\\Gian Lim\\Downloads\\EventManagementD\\exportFiles\\exceltest.xlsx";

                con.Open();
                string query = $"SELECT * FROM {tableName}";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable exportDT = new DataTable();
                    adapter.Fill(exportDT);

                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Reservations");

                        worksheet.Cell("A1").Value = "ABCCatering Report Module";
                        worksheet.Range("A1:F1").Row(1).Merge();
                        worksheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(3, 1).InsertTable(exportDT);
                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(filePath);
                    }

                    con.Close();
                    MessageBox.Show("Export completed successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show($"An error occurred during the export process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard_Admin Obj = new Dashboard_Admin();
            Obj.Show();
            this.Hide();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {

            AdminForm obj = new AdminForm();
            obj.Show();
            this.Hide();

        }


        /*    private void PackageDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {



                    PackageCMB.Text = PackageDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

            }
    */
        private void PackageDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < PackageDataGridView.Rows.Count)
            {
                PackageDataGridView.Rows[e.RowIndex].Selected = true;
                DataGridViewRow selectedRow = PackageDataGridView.Rows[e.RowIndex];

                PackageCMB.Text = selectedRow.Cells["Package"].Value.ToString();
            }
        }
        private bool IsValidPackage(string package)
        {
            // Define the valid packages
            string[] validPackages = { "PACKAGE A", "PACKAGE B", "PACKAGE C", "PACKAGE D", "PACKAGE E", "PACKAGE F", "PACKAGE G" };

            // Check if the package is in the valid packages array
            return validPackages.Contains(package);
        }


        private void DltBtn_Click_1(object sender, EventArgs e)
        {
            if (PackageDataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = PackageDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = PackageDataGridView.Rows[rowIndex];
                PackageCMB.Text = selectedRow.Cells["Package"].Value.ToString();
                /*   userReference.retrieveCmboxValue = PackageCMB.Text;*/
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM PackageTable WHERE Package = @PK", con);

                    cmd.Parameters.AddWithValue("@PK", PackageCMB.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    viewData2();

                    // Remove the deleted package from the ComboBox
                    PackageCMB.Items.Remove(PackageCMB.Text);

                    MessageBox.Show("Package deleted successfully.");


                    PackageCMB.Text = "";
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void RegisteredBtn_Click(object sender, EventArgs e)
        {
            RegisteredAccountsForm obj = new RegisteredAccountsForm();
            obj.Show();
            this.Hide();
        }
    }
}