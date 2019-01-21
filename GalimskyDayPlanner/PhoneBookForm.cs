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

        private static Random rand = new Random();
        private void GenList()
        {
            Data.numbers = new List<PhoneNumber>();
            for (int i = 0; i < PhoneNumber.chars.Length; i++)
            {
                int next = rand.Next(2, 5);
                for (int j = 0; j < 5; j++)
                {
                    int index = i * 5 + j;
                    Data.numbers.Add(new PhoneNumber());
                    Data.numbers[index].firstLetter = PhoneNumber.chars[i];
                    Data.numbers[index].SetRandomName(PhoneNumber.chars[i]);
                    Data.numbers[index].SetRandomNumber('8');
                }
            }
            Data.numbers.Sort();
        }

        private void OutNumbers()
        {
            Data.numbers.Sort();
            
            labels.Clear();

            numbersPanel.Controls.Clear();
            char signature = 'A';
            Console.WriteLine('A');
            int ind = 0;
            labels.Add(new Label());
            labels.Last().Text = signature.ToString();
            labels.Last().Location = new Point(10, 10 + ind * 25);
            numbersPanel.Controls.Add(labels.Last());
            for (int i=0; i < Data.numbers.Count; i++)
            {
                if (char.ToUpper(Data.numbers[i].firstLetter) != signature)
                {
                    signature++;
                    labels.Add(new Label());
                    labels.Last().Text = signature.ToString();
                    labels.Last().Location = new Point(10, 10 + ind * 25);
                    numbersPanel.Controls.Add(labels.Last());
                    ind++;
                    Console.WriteLine(signature);
                }
                Console.WriteLine(Data.numbers[i]);
                labels.Add(new Label());
                labels.Last().Text =Data.numbers[i].name+" | " + Data.numbers[i].number;
                labels.Last().Location = new Point(10, 10+ind*25);
                labels.Last().AutoSize = false;
                labels.Last().Width = 400;
                numbersPanel.Controls.Add(labels.Last());
                ind++;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutNumbers();
        }
    }
}
