﻿using System;
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

        public Label lastLabel;
        public Form1 form1;
        public TextBox textBox;

        public string startText;


        public TaskInputForm()
        {
            InitializeComponent();
            textBox = textBox1;
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
            textBox = (TextBox)sender;
            text = textBox.Text;
            form1.label.Text = text;
        }

        private void applyTaskButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelEditButton_Click(object sender, EventArgs e)
        {
            form1.label.Text = startText;
            Close();
        }

        private void deleteTaskButton_Click(object sender, EventArgs e)
        {
            form1.label.Text = "";
            Close();
        }
    }
}
