using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module5
{

    public partial class Preference : Form
    {

        private Form1 mainForm;

        public delegate void sendTextProperties(string sample, string fontColor, string backColor, string textSize, string textTitle);
        public sendTextProperties sendSample;

        public Preference(Form1 _form1)
        {
            InitializeComponent();
            mainForm = _form1;
        }


        private void Preference_Load(object sender, EventArgs e)
        {
            
            foreach (FontFamily family in FontFamily.Families)
            {
                fontFamily.Items.Add(family.Name);
            
            }

            fontFamily.SelectedIndex = 0;

            //Setting up predefined text colors
            textColor.Items.Add(Color.Black);
            textColor.Items.Add(Color.Red);
            textColor.Items.Add(Color.Green);
            textColor.Items.Add(Color.Yellow);

            textColor.SelectedIndex = 0;

            //Setting up predefined backgroun colors
            backColor.Items.Add(Color.Empty);
            backColor.Items.Add(Color.Black);
            backColor.Items.Add(Color.Red);
            backColor.Items.Add(Color.Green);
            backColor.Items.Add(Color.Yellow);

            backColor.SelectedIndex = 0;

            int[] fontSizeValues = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            for (int i = 0; i < fontSizeValues.Length; i++)
            {
                textSize.Items.Add(fontSizeValues[i]);
            }

            textSize.SelectedIndex = 0;

        }

        private void backColor_SelectedValueChanged(object sender, EventArgs e)
        {
            if(backColor.Text == textColor.Text)
            {
                MessageBox.Show("Can't pick same background and text color!");
                backColor.SelectedItem = null;
            }
        }

        private void textColor_SelectedValueChanged(object sender, EventArgs e)
        {
            if(textColor.Text == backColor.Text)
            {
                MessageBox.Show("Can't pick same text and background color!");
                textColor.SelectedItem = null;
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            this.sendSample += new sendTextProperties(mainForm.sendSample);
            //string sample, string fontColor, string backColor, int textSize
            sendSample(fontFamily.Text, textColor.Text, backColor.Text, textSize.Text, textTitle.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
