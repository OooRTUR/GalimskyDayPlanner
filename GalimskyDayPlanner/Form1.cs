using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalimskyDayPlanner
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            SetDate(DateTime.Now);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalendForm calendForm = new CalendForm();
            calendForm.Show();
        }

        
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            SetDate(monthCalendar1.SelectionRange.Start.Date);
        }

        private void SetDate(DateTime date)
        {
            string week = date.DayOfWeek.ToString().ToUpper();
            string day = date.Day.ToString();
            string month = date.ToString("MMMM");
            string year = date.Year.ToString();
            string isToday = date.Date == DateTime.Now.Date ? " (сегодня)" : "";

            TestLabel.Text = date.Date.ToString()+" | " + DateTime.Now.Date.ToString();

            CurrentDateTitle.Text = "Планы на " + week + " " + day + " " + month + " " + year + isToday;
        }

        private void labelTask_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.Text = "text";
        }
    }
}
