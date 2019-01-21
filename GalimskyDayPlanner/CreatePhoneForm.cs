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
    public partial class CreatePhoneForm : Form
    {
        public TextBox inputPhone;
        public TextBox inputName;

        public string phoneToSave;
        public string nameToSave;

        public CreatePhoneForm()
        {
            InitializeComponent();
            inputPhone = textBoxPhone;
            inputName = textBoxName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.numbers.Add(new PhoneNumber(textBoxPhone.Text, textBoxName.Text));
            Data.numbers.Last().firstLetter = inputName.Text[0];
            Close();
        }
    }
}
