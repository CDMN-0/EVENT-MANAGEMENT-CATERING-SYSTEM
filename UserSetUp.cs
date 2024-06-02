using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Globalization;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Siticone.UI.WinForms.Suite;
using ClosedXML.Report.Utils;

namespace UserInput
{

    public partial class UserSetUp : KryptonForm
    {
        static DateTime currentDateTime = DateTime.Now;
        public static int currentYear = currentDateTime.Year;
        public static int currentMonth = currentDateTime.Month;

        String monthName;

        public UserSetUp()
        {
            InitializeComponent();
            getIni();
            ShowEvents();
            timer1.Start();
            // MessageBox.Show(currentFormatDate);
            if (currentMonth <= currentDateTime.Month)
            {
                btnBack.Enabled = false;
            }
        }

        private void UserClear()
        {
            FnameTxt.Text = "";
            ContactTxt.Text = "";
            LocateTxt.Text = "";
            EventTypeTxt.Text = "";
            PackageCmbox.SelectedIndex = -1;
            AttendeesTxt.Text = "";
            SpecialTxt.Text = "";
            DateTxt.Text = "";
            TimeInCmbox.SelectedIndex = -1;
            TimeOutCmbox.SelectedIndex = -1;
            PricingTxt.Text = "";
            userReference.cYear = "";
            userReference.cMonth = "";
            userReference.newMonth = ""; 
            userReference.newYear = ""; 
            userReference.ucDay = "";
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Gian Lim\Downloads\EventManagementABCDB.mdf"";Integrated Security=True;Connect Timeout=30");

        private void ShowEvents()
        {
            try
            {
                AdminSetUp adminForm = new AdminSetUp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Regex alphaOnly = new Regex("^[A-Za-z.\\s]+$");
        Regex alphaNumericOnly = new Regex("^[A-Za-z0-9.\\s]+$");
        Regex numericOnly = new Regex("^[0-9]+$");

        private void SubmitBtn_Click(object sender, EventArgs e)
        {


            var time1 = TimeInCmbox.SelectedIndex;
            var time2 = TimeOutCmbox.SelectedIndex;
            int timeCount = Convert.ToInt32(time2) - Convert.ToInt32(time1);
            int attendeesCount= Convert.ToInt32(AttendeesTxt.Text);

            if (FnameTxt.Text == "" || ContactTxt.Text == "" || LocateTxt.Text == "" ||
                EventTypeTxt.Text == "" ||
                DateTxt.Text == "" ||
                PackageCmbox.SelectedIndex == -1 ||
                AttendeesTxt.Text == "" ||
                SpecialTxt.Text == "" ||
                TimeInCmbox.SelectedIndex == -1 ||
                TimeOutCmbox.SelectedIndex == -1 ||
                PricingTxt.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (!alphaOnly.IsMatch(FnameTxt.Text) || !numericOnly.IsMatch(ContactTxt.Text) || !alphaNumericOnly.IsMatch(LocateTxt.Text) || !alphaNumericOnly.IsMatch(EventTypeTxt.Text) || time1 > time2 || timeCount < 3 || attendeesCount < 200 || attendeesCount > 1000)
            {
                String fNameWarning = "";
                String contactWarning = "";
                String locationWarning = "";
                String eventWarning = "";
                String invalidTime1 = "";
                String invalidTime2 = "";
                String invalidAttendees1 = "";
                String invalidAttendees2 = "";

                if (!alphaOnly.IsMatch(FnameTxt.Text))
                {
                    fNameWarning = "First name will only accept alphabetical characters.\n\n";
                }
                if (!numericOnly.IsMatch(ContactTxt.Text))
                {
                    contactWarning = "Contact number will only accept numbers. Do not use spaces, symbols, or alphabetical characters.\n\n";
                }
                if (!alphaNumericOnly.IsMatch(LocateTxt.Text))
                {
                    locationWarning = "Location will not accept any symbols, only use alphanumerical characters.\n\n";
                }
                if (!alphaNumericOnly.IsMatch(EventTypeTxt.Text))
                {
                    eventWarning = "Event Type will not accept any symbols, only use alphanumerical characters.\n\n";
                }
                if (time1 > time2)
                {
                    invalidTime1 = "Invalid time, please select another time frame.\n\n";
                }
                if (timeCount < 3)
                {
                    invalidTime2 = "We only accept a minimum of 3 hours in reservation.\n\n";
                }
                if (attendeesCount < 200)
                {
                    invalidAttendees1 = "We only accept a minimum of 200 attendees.\n\n";
                }
                if (attendeesCount > 1000)
                {
                    invalidAttendees2 = "We only accept a maximum of 1000 attendees.";
                }
                MessageBox.Show(fNameWarning + contactWarning + locationWarning + eventWarning + invalidTime1 + invalidTime2 + invalidAttendees1 + invalidAttendees2);
            }
            else
            {
                try
                {
                    DialogResult result = MessageBox.Show("Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO ABCCustomerTable(CustName, CustEmail, Password, CustPhone, EVName, EVDate, EVAddress, EVAttendees, Package,  TotalPrice, Instruction, StartTime, EndTime, Status) VALUES(@CN, @CE, @PC, @CP, @EN, @ED, @EA, @EVA, @PA, @TP, @IN, @ST, @ET, @STA)", con);
                        cmd.Parameters.AddWithValue("@CN", FnameTxt.Text);
                        cmd.Parameters.AddWithValue("@CE", userReference.StoreCustomerEmail);
                        cmd.Parameters.AddWithValue("@PC", userReference.StoreCustomerPassword);
                        cmd.Parameters.AddWithValue("@CP", ContactTxt.Text);
                        cmd.Parameters.AddWithValue("@EN", EventTypeTxt.Text);
                        cmd.Parameters.AddWithValue("@ED", DateTxt.Text);
                        cmd.Parameters.AddWithValue("@EA", LocateTxt.Text);
                        cmd.Parameters.AddWithValue("@EVA", AttendeesTxt.Text);
                        cmd.Parameters.AddWithValue("@PA", PackageCmbox.SelectedItem);
                        cmd.Parameters.AddWithValue("@TP", PricingTxt.Text);
                        cmd.Parameters.AddWithValue("@IN", SpecialTxt.Text);
                        cmd.Parameters.AddWithValue("@ST", TimeInCmbox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ET", TimeOutCmbox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@STA", "Pending");


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Event Added");

                        con.Close();

                        flpCalendarContainer.Controls.Clear();
                        ShowEvents();
                        UserClear();

                        displayDays();
                    }

                    else if (result == DialogResult.No)
                    {
                        
                    }

                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /*  if (FnameTxt.Text != null || ContactTxt.Text != null || LocateTxt.Text != null || EventTypeTxt.Text != null ||  PackageCmbox.SelectedIndex != null || AttendeesTxt.Text != null || 
                         SpecialTxt.Text != null ||  DateTxt.Text != null || TimeInCmbox.SelectedIndex != -1 || TimeOutCmbox.SelectedIndex != -1 || PricingTxt.Text != null)

                 DialogResult result = MessageBox.Show("Are you sure about your inputted details?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        UserClear();
                        AdminSetUp admform = new AdminSetUp();
                          admform.Show();
                          this.Hide();

                    }
                    else if (result == DialogResult.No)
                    {

                    }
                }
        */

        private void UserSetUp_Load(object sender, EventArgs e)
        {
            displayDays();
            con.Open();
            string query = "SELECT Package FROM PackageTable";
            SqlCommand cmd = new SqlCommand(query, con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Read the value from the database
                    string value = reader["Package"].ToString();

                    // Add the value to the target ComboBox
                    PackageCmbox.Items.Add(value);

                }
            }
            con.Close();


            PricingTxt.ReadOnly = true;
            PricingTxt.Enabled = false;


            for (int hour = 7; hour <= 22; hour++)
            {
                for (int minute = 0; minute < 60; minute +=60)
                {
                    if (hour == 22 && minute >= 30)
                        continue;

                    string timeString = $"{hour:00}:{minute:00}";
                    TimeInCmbox.Items.Add(timeString);
                    TimeOutCmbox.Items.Add(timeString);
                }
            }
        }

        string storedDate;

        ucDayText udctext;
        private void displayDays()
        {
            userReference.newMonth = currentMonth.ToString();
            userReference.newYear = currentYear.ToString();
            con.Open();
            SqlDataAdapter checkDate = new SqlDataAdapter("SELECT CONVERT(date, EVDate, 101) AS EVDate FROM ABCCustomerTable", con);
            String dbconvert = checkDate.ToString();
            DataTable dt = new DataTable();
            checkDate.Fill(dt);
            con.Close();

            monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth);
            lblMonthName.Text = monthName + " " + currentYear;
            DateTime startOfTheMonth = new DateTime(currentYear, currentMonth, 1);

            int days = DateTime.DaysInMonth(currentYear, currentMonth);
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;

            for (int x = 1; x < dayOfTheWeek; x++)
            {
                ucDay udc = new ucDay();
                flpCalendarContainer.Controls.Add(udc);
            }

            for (int x = 1; x <= days; x++)
            {
                udctext = new ucDayText();
                udctext.days(x);
                if (dt.Rows.Count > 0)
                {
                    for (int z = 0; z < dt.Rows.Count; z++)
                    {
                        storedDate = dt.Rows[z]["EVDate"].ToString();
                        string day = storedDate.Substring(0, 2);
                        string month = storedDate.Substring(3, 2);
                        string year = storedDate.Substring(6, 4);
                        string _monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(month));
                        try
                        {
                            if (x == Convert.ToInt32(day) && monthName.Equals(_monthName) && currentYear.ToString().Equals(year))
                            {
                                udctext.changeBG();
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                flpCalendarContainer.Controls.Add(udctext);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            flpCalendarContainer.Controls.Clear();
            currentMonth += 1;

            if (currentMonth == 13)
            {
                currentYear++;
                userReference.newYear = currentYear.ToString();
                currentMonth -= 12;
            }

            if (currentMonth > currentDateTime.Month && currentYear == currentDateTime.Year)
            {
                btnBack.Enabled = true;
            }
            userReference.newMonth = currentMonth.ToString();
            displayDays();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            flpCalendarContainer.Controls.Clear();
            currentMonth -= 1;

            if (currentMonth == 0)
            {
                currentYear--;
                userReference.newYear = currentYear.ToString();
                currentMonth += 12;
            }

            if (currentMonth <= currentDateTime.Month && currentYear == currentDateTime.Year)
            {
                btnBack.Enabled = false;
            }
            userReference.newMonth = currentMonth.ToString();
            displayDays();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTxt.Text = userReference.cMonth + userReference.ucDay + userReference.cYear;
        }

        private void UpdatePricing()
        {
            if (PackageCmbox.SelectedItem != null && !string.IsNullOrEmpty(AttendeesTxt.Text))
            {
                string selectedPackage = PackageCmbox.SelectedItem.ToString();
                long attendees = long.Parse(AttendeesTxt.Text);
                long packageAPrice = 0;

                switch (selectedPackage) //Add Ignore Case
                {
                    case "PACKAGE A":
                        packageAPrice = attendees * 500;
                        break;
                    case "PACKAGE B":
                        packageAPrice = attendees * 300;
                        break;
                    case "PACKAGE C":
                        packageAPrice = attendees * 350;
                        break;
                    case "PACKAGE D":
                        packageAPrice = attendees * 400;
                        break;
                    case "PACKAGE E":
                        packageAPrice = attendees * 500;
                        break;
                    case "PACKAGE F":
                        packageAPrice = attendees * 350;
                        break;
                }

                long dex = packageAPrice;

                // Display the approximate pricing in another TextBox
                PricingTxt.Text = dex.ToString();
            }
            else
            {
                // Handle the case when either the package is not selected or the attendees are not filled
                PricingTxt.Text = "Please select a package and enter the number of attendees.";
            }
        }
        private void AttendeesTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            /*      UpdatePricing();*/
        }

        private void AttendeesTxt_TextChanged(object sender, EventArgs e)
        {
            UpdatePricing();
        }
        private void PackageCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePricing();
        }

        private void getIni()
        {
            Settings get = new Settings();
            get.readIni();
            if (get.theme == "dark")
            {
                PanelTop.StateCommon.Color1 = Color.Black;
                PanelBtm.StateCommon.Color1 = Color.Black;
                TitleLbl.ForeColor = Color.White;
                lblname.ForeColor = Color.White;
                lblcontact.ForeColor = Color.White;
                lbllocation.ForeColor = Color.White;
                lblevent.ForeColor = Color.White;
                lblpackage.ForeColor = Color.White;
                lblattendees.ForeColor = Color.White;
                lblSpecial.ForeColor = Color.White;
                lbldate.ForeColor = Color.White;
                lblTimeIn.ForeColor = Color.White;
                lblTimeOut.ForeColor = Color.White;
                lblPricing.ForeColor = Color.White;
                lblMonthName.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label8.ForeColor = Color.White;
                label11.ForeColor = Color.White;
                label10.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label12.ForeColor = Color.White;
                kryptonPanel3.StateCommon.Color1 = Color.Black;
            }

            else
            {
                PanelTop.StateCommon.Color1 = Color.FromArgb(182, 208, 226);
                PanelBtm.StateCommon.Color1 = Color.FromArgb(182, 208, 226);
                kryptonPanel3.StateCommon.Color1 = Color.AliceBlue;
                TitleLbl.ForeColor = Color.Black;
                lblname.ForeColor = Color.Black;
                lblcontact.ForeColor = Color.Black;
                lbllocation.ForeColor = Color.Black;
                lblevent.ForeColor = Color.Black;
                lblpackage.ForeColor = Color.Black;
                lblattendees.ForeColor = Color.Black;
                lblSpecial.ForeColor = Color.Black;
                lbldate.ForeColor = Color.Black;
                lblTimeIn.ForeColor = Color.Black;
                lblTimeOut.ForeColor = Color.Black;
                lblPricing.ForeColor = Color.Black;
                lblMonthName.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;
                label11.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                label12.ForeColor = Color.Black;
                this.BackColor = Color.AliceBlue;
                this.ForeColor = Color.FromArgb(32, 33, 36);
            }
        }

        private void siticoneToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            Settings set = new Settings();
            if (siticoneToggleSwitch1.Checked == true)
            {
                set.writeIni("SECTION", "key", "dark"); // Should always be first code of the body
                PanelTop.StateCommon.Color1 = Color.Black;
                PanelBtm.StateCommon.Color1 = Color.Black;
                TitleLbl.ForeColor = Color.White;
                lblname.ForeColor = Color.White;
                lblcontact.ForeColor = Color.White;
                lbllocation.ForeColor = Color.White;
                lblevent.ForeColor = Color.White;
                lblpackage.ForeColor = Color.White;
                lblattendees.ForeColor = Color.White;
                lblSpecial.ForeColor = Color.White;
                lbldate.ForeColor = Color.White;
                lblTimeIn.ForeColor = Color.White;
                lblTimeOut.ForeColor = Color.White;
                lblPricing.ForeColor = Color.White;
                lblMonthName.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label8.ForeColor = Color.White;
                label11.ForeColor = Color.White;
                label10.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label12.ForeColor = Color.White;
                kryptonPanel3.StateCommon.Color1 = Color.Black;
            }

            else
            {
                set.writeIni("SECTION", "key", "light");
                PanelTop.StateCommon.Color1 = Color.FromArgb(182, 208, 226);
                PanelBtm.StateCommon.Color1 = Color.FromArgb(182, 208, 226);
                kryptonPanel3.StateCommon.Color1 = Color.AliceBlue;
                TitleLbl.ForeColor = Color.Black;
                lblname.ForeColor = Color.Black;
                lblcontact.ForeColor = Color.Black;
                lbllocation.ForeColor = Color.Black;
                lblevent.ForeColor = Color.Black;
                lblpackage.ForeColor = Color.Black;
                lblattendees.ForeColor = Color.Black;
                lblSpecial.ForeColor = Color.Black;
                lbldate.ForeColor = Color.Black;
                lblTimeIn.ForeColor = Color.Black;
                lblTimeOut.ForeColor = Color.Black;
                lblPricing.ForeColor = Color.Black;
                lblMonthName.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;
                label11.ForeColor = Color.Black;
                this.BackColor = Color.AliceBlue;
                this.ForeColor = Color.FromArgb(32, 33, 36);
            }
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            FoodPckForm main = new FoodPckForm();
            main.Show();

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            User_LoginUp obj = new User_LoginUp();
            obj.Show();
            this.Hide();
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            AdminForm obj = new AdminForm();
            obj.Show();
            this.Hide();
        }

        private void lblattendees_Click(object sender, EventArgs e)
        {

        }

        private void AdminBtn_Click_1(object sender, EventArgs e)
        {
            AdminForm obj = new AdminForm();
            obj.Show();
            this.Hide();
        }
    }
}