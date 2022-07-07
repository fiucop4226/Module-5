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

  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void sendSample(string fontFamily, string textColor, string backColor, string textSize, string textTitle)
        {

            //----------------------------------------------
            //From Preferences form
            Font set = new Font(fontFamily, Int32.Parse(textSize));
            Color setTextColor = Color.FromName(textColor);
            Color setBackColor;
            
            //MessageBox.Show(fontFamily + " " + textColor + " " + backColor + " " + textSize);
            this.textEditor.Font = set;
            this.textEditor.ForeColor = setTextColor;
            if (backColor != "")
            {
                setBackColor = Color.FromName(backColor);
            }
            else
            {
                setBackColor = Color.FromName("White");
            }
            this.textEditor.BackColor = setBackColor;
            this.Text = textTitle;
            //-----------------------------------------------

        }

        private void textPreferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preference newWindow = new Preference(this);
            newWindow.Show();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
