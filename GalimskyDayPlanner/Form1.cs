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
        public PhoneBookForm phoneBookForm;

        public Form1()
        {
            InitializeComponent();
            //form = GetInstance();
            SetDate(DateTime.Now);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //if(Data.dayTasks[])
            if (Data.dayTasks == null)
            {
                Console.WriteLine("Задач на сегодня нет");
            }
            //Console.WriteLine(Data.dayTasks);
            Console.WriteLine();
            for (int i = 0; i <tableLayoutPanelMain.Controls.Count; i++)
            {
                Console.WriteLine(tableLayoutPanelMain.Controls[i].Controls[0].Text = i.ToString()+" a");
            }
            /*
            for (int i = tableLayoutPanelRight.Controls.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(tableLayoutPanelRight.Controls[i].Text = i.ToString()+i.ToString());
            }
            */
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
            taskInputForm.startText = label.Text;
            if(taskInputForm.textBox!=null)
                taskInputForm.textBox.Text = label.Text;
            taskInputForm.Show();
            taskInputForm.FormClosed += TaskInputForm_Closed;
            Enabled = false;
        }

        private void TaskInputForm_Closed(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
        }

        private void openBookButton_Click(object sender, EventArgs e)
        {
            phoneBookForm = PhoneBookForm.GetInstance();
            phoneBookForm.Show();
            phoneBookForm.FormClosed += TaskInputForm_Closed;
            Enabled = false;
        }

        private void GetDayTasks()
        {
            for(int i=0; i< Data.dayTasks.Last().calendTasks.Count; i++)
            {

            }
        }

        private void buttonOutDay_Click(object sender, EventArgs e)
        {
            Data.dayTasks.Add(new DayTasks());
            Console.WriteLine(Data.dayTasks.Count);
            Data.dayTasks.Last().SetExample();
            //Data.dayTasks.Last().calendTasks.Sort();
            Console.WriteLine(Data.dayTasks.Last());

            for(int i=0;i <tableLayoutPanelMain.Controls.Count; i++)
            {
                tableLayoutPanelMain.Controls[i].Controls[0].Text = Data.dayTasks.Last().calendTasks[i].text;
                //tableLayoutPanelMain.Controls[i].Controls[1].Text = Data.dayTasks.Last().calendTasks[i].text;

            }
        }
    }
}
