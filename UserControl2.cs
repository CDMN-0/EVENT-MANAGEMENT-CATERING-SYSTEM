using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace UserInput
{
    public partial class ucDayText : UserControl
    {
       
        public ucDayText()
        {
            InitializeComponent();
        }
        private void ucDayText_Load(object sender, EventArgs e)
        {

        }
        

        public void days(int numday)
        {
            lbDays.Text = numday.ToString();
        }

        public void changeBG()
        {
            lbDays.BackColor = Color.Green;
            this.BackColor = Color.Green;
        }
        private void ucDayText_Click(object sender, EventArgs e)
        {
            if(this.BackColor == Color.Green)
            {
                MessageBox.Show("This date currently have a reservation. Please choose a different date.");
            }
            else
            {
                try
                {
                    userReference.ucDay = lbDays.Text;
                    userReference.cMonth = userReference.newMonth + "/";
                    userReference.cYear = "/" + userReference.newYear;
                }
                catch
                {
                    userReference.ucDay = lbDays.Text;
                    userReference.cMonth = UserSetUp.currentMonth.ToString() + "/";
                    userReference.cYear = "/" + UserSetUp.currentYear.ToString();
                }
            }
        }
    }
}
