using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void statusChange(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "typing...";
            

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveIsClicked(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "hi";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text documents (.txt)|*.txt";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream st;
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if ((st = f.OpenFile()) != null)
                {
                    string s = f.FileName;
                    String str = File.ReadAllText(s);
                    textEditor.Text = str;

                }

            }
            
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.textEditor.Text);
            this.textEditor.Text = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.textEditor.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textEditor.Text = this.textEditor.Text + Clipboard.GetText();
        }
    }
}
