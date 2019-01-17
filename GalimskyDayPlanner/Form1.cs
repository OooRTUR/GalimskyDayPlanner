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
        //private static Form1 form = null;
        /*
        public static Form1 GetInstance()
        {
            if (form == null)
            {
                form = this;
                //form.FormClosed += delegate { form = null; };
            }
            return form;
        }*/

        public Label label;
        public TaskInputForm taskInputForm;

        public Form1()
        {
            InitializeComponent();
            //form = GetInstance();
            SetDate(DateTime.Now);
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        //для всех labelTask
        private void labelTask_Click(object sender, EventArgs e)
        {
            label = (Label)sender;
            //label.Text = "text";

            taskInputForm =  TaskInputForm.GetInstance();
            taskInputForm.form1 = this;
            if(taskInputForm.textBox!=null)
                taskInputForm.textBox.Text = label.Text;
            taskInputForm.Show();
            taskInputForm.FormClosed += TaskInputForm_Closed;
            this.Enabled = false;
        }

        private void TaskInputForm_Closed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            //label.Text = form.
            this.Enabled = true;
        }
    }
}
