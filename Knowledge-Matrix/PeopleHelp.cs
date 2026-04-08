using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Knowledge_Matrix
{
    public partial class Form_PeopleHelp : Form
    {
        public Form_PeopleHelp()
        {
            InitializeComponent();
        }
        public void textBox_ATextChange(string newText)
        {
            textBox_A.Text = newText;
        }
        public void textBox_BTextChange(string newText)
        {
            textBox_B.Text = newText;
        }
        public void textBox_CTextChange(string newText)
        {
            textBox_C.Text = newText;
        }
        public void textBox_DTextChange(string newText)
        {
            textBox_D.Text = newText;
        }
    }
}
