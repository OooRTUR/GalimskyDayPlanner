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
        }

        //=================================================================================
        //CALLBACK METHODS
        //=================================================================================
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Data.date = Utils.GetDateCode(DateTime.Now);
            TimeSpan ts = new TimeSpan(0, 0, 0);
            SetDate(DateTime.Now);
            if(!Data.days.ContainsKey(Data.date))
                Console.WriteLine("На сегодня задач нет");
            //if(Data.dayTasks[])


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Data.dateTime = monthCalendar1.SelectionRange.Start.Date;
            Data.date = Utils.GetDateCode(Data.dateTime);
            SetDate( Data.dateTime);
            OutData();
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

        private void buttonOutDay_Click(object sender, EventArgs e)
        {
            OutData();
        }
        private void buttonSetExample_Click(object sender, EventArgs e)
        {
            SetExampleData();
        }


        //=================================================================================
        //FUNCTIONAL METHODS
        //=================================================================================
        private void SetDate(DateTime date)
        {
            string week = date.DayOfWeek.ToString().ToUpper();
            string day = date.Day.ToString();
            string month = date.ToString("MMMM");
            string year = date.Year.ToString();
            string isToday = date.Date == DateTime.Now.Date ? " (сегодня)" : "";

            TestLabel.Text = date.Date.ToString() + " | " + DateTime.Now.Date.ToString();

            CurrentDateTitle.Text = "Планы на " + week + " " + day + " " + month + " " + year + isToday;
        }

        private void OutData()
        {
            Console.WriteLine("Вывод данных на: "+Data.date);
            if (!Data.days.ContainsKey(Data.date))
            {
                Console.WriteLine("На сегодня задач нет");
                ClearData();
            }
            else
            {
                Console.WriteLine("Задачи дня: " + Data.days[Data.date]);
                ClearData();
                for (int i = 0; i < tableLayoutPanelMain.Controls.Count; i++)
                {
                    if (Data.days[Data.date].tasks.ContainsKey(i))
                        tableLayoutPanelMain.Controls[i].Controls[0].Text = Data.days[Data.date].tasks[i].text;
                }
            }
        }
        private void ClearData()
        {
            for (int i = 0; i < tableLayoutPanelMain.Controls.Count; i++)
                tableLayoutPanelMain.Controls[i].Controls[0].Text = "";
        }

        private void SetExampleData()
        {
            DateTime date1 = new DateTime(2019, 01, 29);
            string textDate1 = Utils.GetDateCode(date1);
            Day day1 = new Day();
            day1.tasks = new Dictionary<int,CalendTask>(19);
            day1.tasks.Add(15,new CalendTask("ааа"));
            day1.tasks.Add(13,new CalendTask("bbb"));
            day1.tasks.Add(10,new CalendTask("fgedf"));
            Data.days.Add(textDate1, day1);
            Console.WriteLine(Data.days.Last());

            DateTime date2 = new DateTime(2019, 01, 25);
            string textDate2 = Utils.GetDateCode(date2);
            Day day2 = new Day();
            day2.tasks = new Dictionary<int, CalendTask>(19);
            day2.tasks.Add(3, new CalendTask("keoekeke"));
            day2.tasks.Add(5, new CalendTask("lelaualal"));
            day2.tasks.Add(19, new CalendTask("gogoodood"));
            Data.days.Add(textDate2, day2);
            Console.WriteLine(Data.days.Last());
        }
        private void SaveData()
        {

        }

        
    }
}
