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
    public partial class InputDataMessage : Form
    {
        public string answer = "";
        public InputDataMessage(string questionText)
        {
            InitializeComponent();
            MyInit(questionText);
        }


        public void MyInit(string questionText)
        {
            labelQusetionText.Text = questionText;
        }

        
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                answer = textBox1.Text;
                Close();
            }
        }
    }
}
