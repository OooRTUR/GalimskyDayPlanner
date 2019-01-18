using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GalimskyDayPlanner
{
    public partial class PhoneBookForm : Form
    {
        public static PhoneBookForm form;

        List<Label> labels = new List<Label>();

        public PhoneBookForm()
        {
            InitializeComponent();
        }

        public static PhoneBookForm GetInstance()
        {
            if (form == null)
            {
                form = new PhoneBookForm();
                form.FormClosed += delegate {
                    form = null;
                };
            }
            return form;
        }

        string[] testNumbers = {"1234","5454","2223","161","6631" };
        string[] testNames = { "zzzz","gad","dad","rofl","lol"};
        int index = 0;

        private void CrtNumberButton_Click(object sender, EventArgs e)
        {
            CreatePhoneForm createPhoneForm = new CreatePhoneForm();
            createPhoneForm.inputName.Text = "Введите имя";
            createPhoneForm.inputPhone.Text = "Введите номер";
            createPhoneForm.Show();
            this.Enabled = false;
            createPhoneForm.FormClosed += delegate { this.Enabled = true; OutNumbers(); };

            //Data.numbers.Add(new PhoneNumber(testNumbers[index],testNames[index]));
            //index++;
            //OutNumbers();
        }

        private void OutNumbers()
        {
            Data.numbers.Sort();
            
            labels.Clear();

            numbersPanel.Controls.Clear();
            for (int i=0; i < Data.numbers.Count; i++)
            {
                Console.WriteLine(Data.numbers[i]);
                labels.Add(new Label());
                labels[i].Text =Data.numbers[i].Name+" | " + Data.numbers[i].Number;
                labels[i].Location = new Point(10, 10+i*25);
                numbersPanel.Controls.Add(labels[i]);
            }
           
        }
    }
}
