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
    public partial class ShowUniqueWords : Form
    {
        public ShowUniqueWords(List<string> words)
        {
            InitializeComponent();
            MyInit();
            LoadText(words);
        }

        private void LoadText(List<string> words)
        {
            richTextBox1.Text = "";
            foreach(string word in words)
            {
                if (!richTextBox1.Text.Equals(""))
                {
                    richTextBox1.Text += ", ";
                }

                richTextBox1.Text += word;
            }
        }

        private void MyInit()
        {
            richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            
        }
        
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
