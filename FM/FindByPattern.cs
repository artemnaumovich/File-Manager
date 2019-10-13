using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FM
{
    public partial class FindByPattern : Form
    {

        string text = "";
        public FindByPattern(string text)
        {
            InitializeComponent();
            MyInit(text);
        }

        private void MyInit(string text)
        {
            richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            this.text = text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            find(textBox1.Text);
        }


        private void find(string pattern)
        {
            richTextBox1.Clear();

            string[] lines = text.Split('\n');
            int count = 0;
            for (int i = 0; i < lines.Length; i ++)
            {
                string currLine = lines[i];
                if (currLine.Contains(pattern))
                {
                    richTextBox1.Text += ("str " + i.ToString() + ": " + currLine + "\n");
                    count++;
                }
            }
            if (count == 0)
            {
                richTextBox1.Text = "Your pattern wasn't found";
            }
            else
            {
                richTextBox1.Text = "Your pattern was found in " + count.ToString() + "line(s)\n" + richTextBox1.Text;
            }
            
        }
    }
}
