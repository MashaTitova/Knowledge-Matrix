using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace Knowledge_Matrix
{
    public partial class WinForm : Form
    {
        public WinForm()
        {
            InitializeComponent();
        }

        private void WinForm_Load(object sender, EventArgs e)
        {

        }
        private void button_NewGame_Click(object sender, EventArgs e)
        {
            Form_KnowledgeMatrix form = new Form_KnowledgeMatrix();
            form.button_NewGame_Click();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                   "Вы уверены, что хотите закрыть приложение?",
                   "Подтверждение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
                );
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
