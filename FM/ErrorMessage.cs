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
    public partial class ErrorMessage : Form
    {
        public ErrorMessage(string textError)
        {
            InitializeComponent();
            MyInit(textError);
        }

        private void MyInit(string textError)
        {
            labelTextError.Text = textError;
            AutoSize = true;
            
        }
        
    }
}
