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
    public partial class TaskInputForm : Form
    {
        public string text;
        private static TaskInputForm form = null;

        public static Form1 form1;


        public TaskInputForm()
        {
            InitializeComponent();
        }

        public static TaskInputForm GetInstance()
        {
            if (form == null)
            {
                form = new TaskInputForm();
                form.FormClosed += delegate {
                    form = null;

                };
            }
            return form;
        }

        private void SendInput_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            text = textBox.Text;
            label1.Text = text;
        }
    }
}
